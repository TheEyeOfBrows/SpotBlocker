using System;
using System.IO;
using System.Net;
using System.Reflection;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using CoreAudio;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.Win32;
using System.Drawing;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using SpotBlocker.DTO;

namespace SpotBlocker
{
    public partial class Main : Form
    {
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        private bool muted = false;
        private bool spotifyMute = false;
        private float volume = 0.9f;
        private string lastArtistName = "";
        private int exitTolerance = 0;
        private ToolTip artistTooltip = new ToolTip();

        private string nircmdPath = Application.StartupPath + @"\nircmd.exe";
        private string jsonPath = Application.StartupPath + @"\Newtonsoft.Json.dll";
        private string coreaudioPath = Application.StartupPath + @"\CoreAudio.dll";
        public static string logPath = Application.StartupPath + @"\SpotBlocker-log.txt";

        private string spotifyPath = Environment.GetEnvironmentVariable("APPDATA") + @"\Spotify\spotify.exe";
        private string spotifyPrefsPath = Environment.GetEnvironmentVariable("APPDATA") + @"\Spotify\prefs";
        private string volumeMixerPath = Environment.GetEnvironmentVariable("WINDIR") + @"\System32\SndVol.exe";
        private string hostsPath = Environment.GetEnvironmentVariable("WINDIR") + @"\System32\drivers\etc\hosts";

        private string[] adHosts = { "pubads.g.doubleclick.net", "securepubads.g.doubleclick.net", "www.googletagservices.com", "gads.pubmatic.com", "ads.pubmatic.com", "spclient.wg.spotify.com"};

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("shell32.dll")]
        public static extern bool IsUserAnAdmin();
        [DllImport("user32.dll")]
        static extern bool SetWindowText(IntPtr hWnd, string text);

        // https://msdn.microsoft.com/en-us/library/windows/desktop/ms646275%28v=vs.85%29.aspx
        private const int WM_APPCOMMAND = 0x319;
        private const int APPCOMMAND_VOLUME_MUTE = 0x80000;
        private const int MEDIA_PLAYPAUSE = 0xE0000;
        private const int MEDIA_NEXTTRACK = 0xB0000;
        
        private string SpotBlockerUA = "SpotBlocker " + Assembly.GetExecutingAssembly().GetName().Version.ToString() + " " + System.Environment.OSVersion;

        // Google Analytics stuff
        private Random rnd;
        private long starttime, lasttime;
        private string visitorId;
        private int runs = 1;
        private string domainHash = Properties.Settings.Default.GoogleAnalyticsDomainHash;
        private const string source = "SpotBlocker";
        private string medium = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        private const string sessionNumber = "1";
        private const string campaignNumber = "1";
        private string language = Thread.CurrentThread.CurrentCulture.Name;
        private string screenRes = Screen.PrimaryScreen.Bounds.Width + "x" + Screen.PrimaryScreen.Bounds.Height;
        private string trackingId = Properties.Settings.Default.GoogleAnalyticsId;

        // Ui
        Image[] backgroundImages;
        int currentBackgroundImage;

        public Main()
        {
            InitializeComponent();
        }

        /**
         * Contains the logic for when to mute Spotify
         **/
        private void MainTimer_Tick(object sender, EventArgs e)
        {
            try {
                if (Process.GetProcessesByName("spotify").Length < 1)
                {
                    if (exitTolerance > 20)
                    {
                        File.AppendAllText(logPath, "Spotify process not found\r\n");
                        Notify("Spotify not found, please restart SpotBlocker.");
                        if (exitTolerance > 22)
                        {
                            Notify("Exiting SpotBlocker.");
                            Application.Exit();
                        }
                    }
                    exitTolerance += 1;
                }
                else
                {
                    exitTolerance = 0;
                }

                WebHelperResult whr = WebHelperHook.GetStatus();

                if (whr.isAd) // Track is ad
                {
                    MainTimer.Interval = 1000;
                    if (whr.isPlaying)
                    {
                        Debug.WriteLine("Ad is playing");
                        if (lastArtistName != whr.artistName)
                        {
                            if (!muted) Mute(1);
                            artistTooltip.SetToolTip(StatusLabel, StatusLabel.Text = "Muting ad");
                            lastArtistName = whr.artistName;
                            LogAction("/mute/" + whr.artistName);
                            Debug.WriteLine("Blocked " + whr.artistName);
                        }
                    }
                    else // Ad is paused
                    {
                        Debug.WriteLine("Ad is paused");
                        Resume();
                    }
                }
                else if (whr.isPrivateSession)
                {
                    if (lastArtistName != whr.artistName)
                    {
                        StatusLabel.Text = "Playing: *Private Session*";
                        artistTooltip.SetToolTip(StatusLabel, "");
                        lastArtistName = whr.artistName;
                        MessageBox.Show("Please disable 'Private Session' on Spotify for SpotBlocker to function properly.", "SpotBlocker", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0x40000);
                    }
                }
                else if (!whr.isRunning)
                {
                    StatusLabel.Text = "Spotify is not running";
                    artistTooltip.SetToolTip(StatusLabel, "");
                    //Notify("Error connecting to Spotify. Retrying...");
                    File.AppendAllText(logPath, "Not running.\r\n");
                    MainTimer.Interval = 5000;
                    /*
                    MainTimer.Enabled = false;
                    MessageBox.Show("Spotify is not running. Please restart SpotBlocker after starting Spotify.", "SpotBlocker", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0x40000);
                    StatusLabel.Text = "Spotify is not running";
                    Application.Exit();
                    */
                }
                else if (!whr.isPlaying)
                {
                    StatusLabel.Text = "Spotify is paused";
                    artistTooltip.SetToolTip(StatusLabel, lastArtistName = "");
                }
                else // Song is playing
                {
                    if (muted) Mute(0);
                    if (MainTimer.Interval > 600) MainTimer.Interval = 600;
                    if (lastArtistName != whr.artistName)
                    {
                        StatusLabel.Text = "Playing: " + ShortenName(whr.artistName);
                        artistTooltip.SetToolTip(StatusLabel, lastArtistName = whr.artistName);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                File.AppendAllText(logPath, ex.Message);
            }
        }
       
        /**
         * Mutes/Unmutes Spotify.
         
         * i: 0 = unmute, 1 = mute, 2 = toggle
         **/
        private void Mute(int i)
        {
            if (i == 2) // Toggle mute
                i = (muted ? 0 : 1);

            muted = Convert.ToBoolean(i);

            if (spotifyMute) // Mute only Spotify process
            {
                MMDeviceEnumerator DevEnum = new MMDeviceEnumerator();
                MMDevice device = DevEnum.GetDefaultAudioEndpoint(EDataFlow.eRender, ERole.eMultimedia);
                AudioSessionManager2 asm = device.AudioSessionManager2;
                SessionCollection sessions = asm.Sessions;
                for (int sid = 0; sid < sessions.Count; sid++)
                {
                    string id = sessions[sid].GetSessionIdentifier;
                    if (id.ToLower().IndexOf("spotify.exe") > -1)
                    {
                        if (muted)
                        {
                            volume = sessions[sid].SimpleAudioVolume.MasterVolume;
                            sessions[sid].SimpleAudioVolume.MasterVolume = 0;
                        }
                        else
                        {
                            sessions[sid].SimpleAudioVolume.MasterVolume = volume;
                        }
                    }
                }
            }
            else // Mute all of Windows
            {
                Process process = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = "/C nircmd mutesysvolume " + i.ToString();
                process.StartInfo = startInfo;
                process.Start();
            }

        }

        /**
         * Resumes playing Spotify
         **/
        private void Resume()
        {
            Debug.WriteLine("Resuming Spotify");
            if (spotifyMute)
            {
                SendMessage(GetHandle(), WM_APPCOMMAND, this.Handle, (IntPtr)MEDIA_PLAYPAUSE);
            }
            else
            {
                SendMessage(this.Handle, WM_APPCOMMAND, this.Handle, (IntPtr)MEDIA_PLAYPAUSE);
            }
        }

        /**
         *  Plays next track queued on Spotify
         **/
        private void NextTrack()
        {
            Debug.WriteLine("Skipping to next track");
            if (spotifyMute)
            {
                SendMessage(GetHandle(), WM_APPCOMMAND, this.Handle, (IntPtr)MEDIA_NEXTTRACK);
            }
            else
            {
                SendMessage(this.Handle, WM_APPCOMMAND, this.Handle, (IntPtr)MEDIA_NEXTTRACK);
            }
        }

        /**
         * Gets the Spotify process handle
         **/
        private IntPtr GetHandle()
        {
            foreach (Process t in Process.GetProcesses().Where(t => t.ProcessName.ToLower().Contains("spotify")))
            {
                if (t.MainWindowTitle.Length > 1)
                    return t.MainWindowHandle;
            }
            return IntPtr.Zero;
        }

        /**
         * Gets the source of a given URL
         **/
        private string GetPage(string URL, string ua)
        {
            string result = null;
            using (WebClient w = new WebClient())
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                w.Headers.Add("user-agent", ua);
                result = w.DownloadString(URL);
            }
            return result;
        }

        private string ShortenName(string name)
        {
            if (name.Length > 12)
            {
                return name.Substring(0, 12) + "...";
            }
            return name;
        }

        /**
         * Checks if the current installation is the latest version. Prompts user if not.
         **/
        private void CheckUpdate()
        {
            if (Properties.Settings.Default.UpdateSettings) // If true, then first launch of latest SpotBlocker
            {
                try
                {
                    if (File.Exists(nircmdPath)) File.Delete(nircmdPath);
                    if (File.Exists(jsonPath)) File.Delete(jsonPath);
                    if (File.Exists(coreaudioPath)) File.Delete(coreaudioPath);
                    Properties.Settings.Default.Upgrade();
                    Properties.Settings.Default.UpdateSettings = false;
                    Properties.Settings.Default.UserEducated = false;
                    Properties.Settings.Default.Save();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    MessageBox.Show("There was an error updating SpotBlocker. Please run as Administrator to update.");
                }
            }
            try
            {

                string releaseText = GetPage(Properties.Settings.Default.VersionCheckUrl, SpotBlockerUA);
                GitHubRelease release = Newtonsoft.Json.JsonConvert.DeserializeObject<GitHubRelease>(releaseText);

                int[] releaseSemanticVersion = Regex.Replace(release.tag_name, "[^\\d.]", "").Split(new[] { '.' }).Select(n => Convert.ToInt32(n)).ToArray();
                if (releaseSemanticVersion.Length != 4)
                {
                    throw new Exception(string.Format("Invalid release semantic versioning [{0}]", releaseSemanticVersion.ToString()));
                }

                Version releaseVersion = new Version(releaseSemanticVersion[0], releaseSemanticVersion[1], releaseSemanticVersion[2], releaseSemanticVersion[3]);
                Version currentVersion = Assembly.GetExecutingAssembly().GetName().Version;

                if (releaseVersion <= currentVersion)
                {
                    return;
                }

                if (MessageBox.Show("There is a newer version of SpotBlocker available. Would you like to upgrade?", "SpotBlocker", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Process.Start(Properties.Settings.Default.WebsiteUrl);
                    Application.Exit();
                }
            }
            catch
            {
                MessageBox.Show("Error checking for update.", "SpotBlocker");
            }
        }

        /**
         * Send a request every 5 minutes to Google Analytics
         **/
        private void Heartbeat_Tick(object sender, EventArgs e)
        {
            LogAction("/heartbeat");
        }

        private static bool hasNet45()
        {
            try
            {
                using (RegistryKey ndpKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey("SOFTWARE\\Microsoft\\NET Framework Setup\\NDP\\v4\\Full\\"))
                {
                    int releaseKey = Convert.ToInt32(ndpKey.GetValue("Release"));
                    if (releaseKey >= 378389) return true;
                }
            }
            catch
            {
                // Do nothing
            }
            return false;
        }

        /**
         * Based off of: http://stackoverflow.com/questions/12851868/how-to-send-request-to-google-analytics-in-non-web-based-app
         * 
         * Logs actions using Google Analytics
         **/
        private void LogAction(string pagename)
        {
            if (!Properties.Settings.Default.EnableAnalytics)
            {
                return;
            }
            try
            {
                lasttime = DateTime.Now.Ticks;
                string statsRequest = "http://www.google-analytics.com/__utm.gif" +
                    "?utmwv=4.6.5" +
                    "&utmn=" + rnd.Next(100000000, 999999999) +
                    "&utmcs=-" +
                    "&utmsr=" + screenRes +
                    "&utmsc=-" +
                    "&utmul=" + language +
                    "&utmje=-" +
                    "&utmfl=-" +
                    "&utmdt=" + pagename +
                    "&utmp=" + pagename +
                    "&utmac=" + trackingId + // Account number
                    "&utmcc=" +
                        "__utma%3D" + domainHash + "." + visitorId + "." + starttime + "." + lasttime + "." + starttime + "." + (runs++) +
                        "%3B%2B__utmz%3D" + domainHash + "." + lasttime + "." + sessionNumber + "." + campaignNumber + ".utmcsr%3D" + source + "%7Cutmccn%3D(" + medium + ")%7Cutmcmd%3D" + medium + "%7Cutmcct%3D%2Fd31AaOM%3B";
                using (var client = new WebClient())
                {
                    client.DownloadData(statsRequest);
                }
            }
            catch { /*ignore*/ }
        }

        private void SendToTray()
        {
            this.WindowState = FormWindowState.Minimized;
            this.NotifyIcon.Visible = true;
            this.ShowInTaskbar = false;

            // Set new title background image
            var img = GetRandomTitleImage();
            if (img != null && this.pnlMain != null)
                this.pnlMain.BackgroundImage = img;
        }

        private void RestoreFromTray()
        {
            // Visible toggle makes the redrawing of the form happen before being shown to user.
            this.Visible = false;
            
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Normal;
            this.NotifyIcon.Visible = false;
            this.ShowInTaskbar = true;
            
            this.Visible = true;
        }

        /**
         * Processes window message and shows SpotBlocker when attempting to launch a second instance.
         **/
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WindowUtilities.WM_SHOWAPP)
            {
                if (!this.ShowInTaskbar)
                {
                    RestoreFromTray();
                }
                else
                {
                    this.Activate();
                }
                Notify("SpotBlocker is already open.");
            }
            base.WndProc(ref m);
        }

        private void Notify(String message)
        {
            NotifyIcon.ShowBalloonTip(10000, "SpotBlocker", message, ToolTipIcon.None);
        }

        private void NotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!this.ShowInTaskbar && e.Button == MouseButtons.Left)
            {
                RestoreFromTray();
            }
        }

        private void NotifyIcon_BalloonTipClicked(object sender, EventArgs e)
        {
            RestoreFromTray();
        }

        private void Form_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;
                this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
                if (!Properties.Settings.Default.UserEducatedAboutTrayIcon)
                {
                    Notify("SpotBlocker is hidden. Double-click this icon to restore.");
                    Properties.Settings.Default.UserEducatedAboutTrayIcon = true;
                    Properties.Settings.Default.Save();
                }
            }
        }

        private void SpotifyMuteCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            spotifyMute = SpotifyMuteCheckbox.Checked;
            if (visitorId == null) return; // Still setting up UI
            LogAction("/settings/spotifyMute/" + spotifyMute.ToString());
            Properties.Settings.Default.SpotifyMute = spotifyMute;
            Properties.Settings.Default.Save();
        }

        private void SkipAdsCheckbox_Click(object sender, EventArgs e)
        {
            if (visitorId == null) return; // Still setting up UI
            if (!IsUserAnAdmin())
            {
                MessageBox.Show("Enabling/Disabling this option requires Administrator privileges.\n\nPlease reopen SpotBlocker with \"Run as Administrator\".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                BlockBannersCheckbox.Checked = !BlockBannersCheckbox.Checked;
                return;
            }
            if (!File.Exists(hostsPath))
            {
                File.Create(hostsPath).Close();
            }
            try
            {
                // Always clear hosts
                string[] text = File.ReadAllLines(hostsPath);
                text = text.Where(line => !adHosts.Contains(line.Replace("0.0.0.0 ", "")) && line.Length > 0 && !line.Contains("open.spotify.com")).ToArray();
                File.WriteAllLines(hostsPath, text);

                if (BlockBannersCheckbox.Checked)
                {
                    using (StreamWriter sw = File.AppendText(hostsPath))
                    {
                        sw.WriteLine();
                        foreach (string host in adHosts)
                        {
                            sw.WriteLine("0.0.0.0 " + host);
                        }
                    }
                }
                MessageBox.Show("You may need to restart Spotify or your computer for this setting to take effect.", "SpotBlocker", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LogAction("/settings/blockBanners/" + BlockBannersCheckbox.Checked.ToString());
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void StartupCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (visitorId == null) return; // Still setting up UI
            RegistryKey startupKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (StartupCheckbox.Checked)
            {
                startupKey.SetValue("SpotBlocker", "\"" + Application.ExecutablePath + "\"");
            }
            else
            {
                startupKey.DeleteValue("SpotBlocker");
            }
            LogAction("/settings/startup/" + StartupCheckbox.Checked.ToString());
        }

        private void StartMinimizedCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            bool startMinimized = StartMinimizedCheckbox.Checked;
            if (visitorId == null) return; // Still setting up UI

            Properties.Settings.Default.StartMinimized = startMinimized;
            Properties.Settings.Default.Save();

            LogAction("/settings/startminimized/" + StartMinimizedCheckbox.Checked.ToString());
        }

        private void VolumeMixerButton_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(volumeMixerPath);
                LogAction("/button/volumemixer");
            }
            catch
            {
                MessageBox.Show("Could not open Volume Mixer. This is only available on Windows 7/8/10", "SpotBlocker");
            }
        }

        private void MuteButton_Click(object sender, EventArgs e)
        {
            Mute(2);
            LogAction("/button/mute/" + muted.ToString());
        }

        private void WebsiteLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Please leave a comment describing one of these problems:\r\n\r\n1. Audio ads are not muted\r\n2. Audio ads are not blocked but muted\r\n3. Banner ads are not blocked\r\n\r\nNot using one of these will cause your comment to be deleted.\r\n\r\nPlease note that #2 and #3 are experimental features and not guaranteed to work.", "SpotBlocker");
            Process.Start(Properties.Settings.Default.WebsiteUrl);
            LogAction("/button/website");
        }

        private void AboutWebLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(Properties.Settings.Default.WebsiteUrl);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            // Enable web helper
            if (File.Exists(spotifyPrefsPath))
            {
                string[] lines = File.ReadAllLines(spotifyPrefsPath);
                bool webhelperEnabled = false;
                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i].Contains("webhelper.enabled"))
                    {   
                        if (lines[i].Contains("false"))
                        {
                            lines[i] = "webhelper.enabled=true";
                            File.WriteAllLines(spotifyPrefsPath, lines);
                        }
                        webhelperEnabled = true;
                        break;
                    }
                }
                if (!webhelperEnabled)
                {
                    File.AppendAllText(spotifyPrefsPath, "\r\nwebhelper.enabled=true");
                }
            }

            CheckUpdate();

            // Start Spotify and give SpotBlocker higher priority
            try
            {
                if (File.Exists(spotifyPath) && Process.GetProcessesByName("spotify").Length < 1)
                {
                    Process.Start(spotifyPath);
                }
                Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High; // Windows throttles down when minimized to task tray, so make sure SpotBlocker runs smoothly

                // Check for open.spotify.com in hosts
                String hostsContent = File.ReadAllText(hostsPath);
                if (hostsContent.Contains("open.spotify.com"))
                {
                    if (IsUserAnAdmin())
                    {
                        File.WriteAllText(hostsPath, hostsContent.Replace("open.spotify.com", "localhost"));
                        MessageBox.Show("An SpotBlocker patch has been applied to your hosts file. If SpotBlocker is stuck at 'Loading', please restart your computer.", "SpotBlocker", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("SpotBlocker has detected an error in your hosts file.\r\n\r\nPlease re-run SpotBlocker as Administrator or remove 'open.spotify.com' from your hosts file.", "SpotBlocker", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Exit();
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            // Extract dependencies
            try {
                if (!File.Exists(nircmdPath))
                {
                    File.WriteAllBytes(nircmdPath, Properties.Resources.nircmd32);
                }
                if (!File.Exists(jsonPath))
                {
                    File.WriteAllBytes(jsonPath, Properties.Resources.Newtonsoft_Json);
                }
                if (!File.Exists(coreaudioPath))
                {
                    File.WriteAllBytes(coreaudioPath, Properties.Resources.CoreAudio);
                }
            } catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessageBox.Show("Error loading SpotBlocker dependencies. Please run SpotBlocker as administrator or put SpotBlocker in a user folder.");
            }

            // Set up UI
            SpotifyMuteCheckbox.Checked = Properties.Settings.Default.SpotifyMute;
            StartMinimizedCheckbox.Checked = Properties.Settings.Default.StartMinimized;
            if (File.Exists(hostsPath))
            {
                string hostsFile = File.ReadAllText(hostsPath);
                BlockBannersCheckbox.Checked = adHosts.All(host => hostsFile.Contains("0.0.0.0 " + host));
            }
            RegistryKey startupKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (startupKey.GetValue("SpotBlocker") != null)
            {
                if (startupKey.GetValue("SpotBlocker").ToString() == "\"" + Application.ExecutablePath + "\"")
                {
                    StartupCheckbox.Checked = true;
                }
                else // Reg value exists, but not in right path
                {
                    startupKey.DeleteValue("SpotBlocker");
                }
            }

            // Google Analytics
            rnd = new Random(Environment.TickCount);
            starttime = DateTime.Now.Ticks;
            if (string.IsNullOrEmpty(Properties.Settings.Default.UID))
            {
                Properties.Settings.Default.UID = rnd.Next(100000000, 999999999).ToString(); // Build unique visitorId;
                Properties.Settings.Default.Save();
            }
            visitorId = Properties.Settings.Default.UID;
            
            File.AppendAllText(logPath, "-----------\r\n");
            bool unsafeHeaders = WebHelperHook.SetAllowUnsafeHeaderParsing20();
            Debug.WriteLine("Unsafe Headers: " + unsafeHeaders);

            if (!hasNet45())
            {
                if (MessageBox.Show("You do not have .NET Framework 4.5. Download now?", "SpotBlocker Error", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                {
                    Process.Start("https://www.microsoft.com/en-us/download/details.aspx?id=30653");
                }
                else
                {
                    MessageBox.Show("SpotBlocker may not function properly without .NET Framework 4.5 or above.");
                }
            }

            Mute(0);
            
            MainTimer.Enabled = true;

            if (Process.GetProcessesByName("spotifywebhelper").Length < 1)
            {
                Notify("Please enable 'Allow Spotify to be opened from the web' in your Spotify 'Preferences' -> 'Advanced settings'.");

            }

            // Load Images
            backgroundImages = GetBackgroundImages();
            // Assign new image
            pnlMain.BackgroundImage = GetRandomTitleImage();

            // Minimize at start
            if (Properties.Settings.Default.StartMinimized)
            {
                SendToTray();
            }

            LogAction("/launch");
        }

        private Image GetNextTitleImage()
        {
            currentBackgroundImage++;
            if(currentBackgroundImage < 0 || currentBackgroundImage > backgroundImages.Length)
            {
                currentBackgroundImage = 0;
            }
            return backgroundImages[currentBackgroundImage];
        }
        private Image GetRandomTitleImage()
        {
            int newImageIndex;
            Random rand = new Random();
            newImageIndex = rand.Next(backgroundImages.Length - 1);
            if(newImageIndex >= currentBackgroundImage)
            {
                newImageIndex++;
            }
            currentBackgroundImage = newImageIndex;
            return backgroundImages[currentBackgroundImage];
        }

        private Image[] GetBackgroundImages()
        {
            int maxNumberOfImages = 10;
            string titleBase = "title_bg_";
            List<Image> images = new List<Image>();
            
            Image currentImage;

            for(int i = 1; i < maxNumberOfImages; i++)
            {
                currentImage = Properties.Resources.ResourceManager.GetObject(titleBase+i) as Image;
                if(currentImage == null)
                {
                    break;
                }
                images.Add(currentImage);
            }
            return images.ToArray();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RestoreFromTray();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void websiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(Properties.Settings.Default.WebsiteUrl);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnMinimized_Click(object sender, EventArgs e)
        {
            this.SendToTray();
        }

        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void Form_MouseMove(object sender, MouseEventArgs e)
        {

            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void Form_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void VolumeMixerButton_MouseHover(object sender, EventArgs e)
        {
            VolumeMixerButton.BackgroundImage = Properties.Resources.options_mouse;
        }

        private void VolumeMixerButton_MouseLeave(object sender, EventArgs e)
        {
            VolumeMixerButton.BackgroundImage = Properties.Resources.options;
        }

        private void VolumeMixerButton_MouseDown(object sender, MouseEventArgs e)
        {
            VolumeMixerButton.BackgroundImage = Properties.Resources.options;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (!Properties.Settings.Default.UserEducated)
            {
                var result = MessageBox.Show("Spotify ads will not be muted if SpotBlocker is not running.\r\n\r\nAre you sure you want to exit?", "SpotBlocker",
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Warning);

                e.Cancel = (result == DialogResult.No);

                if (result == DialogResult.Yes)
                {
                    Properties.Settings.Default.UserEducated = true;
                    Properties.Settings.Default.Save();
                }
            }
            NotifyIcon.Visible = false;
            NotifyIcon.Icon = null;
        }
    }
}
