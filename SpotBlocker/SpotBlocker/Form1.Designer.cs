using global::SpotBlocker;

namespace SpotBlocker
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.MainTimer = new System.Windows.Forms.Timer(this.components);
            this.NotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.NotifyIconContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.websiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.separatorToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Heartbeat = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.VolumeMixerButton = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.StartMinimizedCheckbox = new System.Windows.Forms.CheckBox();
            this.RulerBottom = new System.Windows.Forms.Panel();
            this.RulerTop = new System.Windows.Forms.Panel();
            this.imgLoading = new System.Windows.Forms.PictureBox();
            this.StartupCheckbox = new System.Windows.Forms.CheckBox();
            this.MuteButton = new System.Windows.Forms.Button();
            this.BlockBannersCheckbox = new System.Windows.Forms.CheckBox();
            this.DesignWebLink = new System.Windows.Forms.LinkLabel();
            this.WebsiteLink = new System.Windows.Forms.LinkLabel();
            this.SpotifyMuteCheckbox = new System.Windows.Forms.CheckBox();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.imgSpotfy = new System.Windows.Forms.PictureBox();
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnMinimized = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.NotifyIconContextMenu.SuspendLayout();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgLoading)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgSpotfy)).BeginInit();
            this.pnlTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTimer
            // 
            this.MainTimer.Interval = 600;
            this.MainTimer.Tick += new System.EventHandler(this.MainTimer_Tick);
            // 
            // NotifyIcon
            // 
            this.NotifyIcon.ContextMenuStrip = this.NotifyIconContextMenu;
            this.NotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("NotifyIcon.Icon")));
            this.NotifyIcon.Text = "SpotBlocker";
            this.NotifyIcon.Visible = true;
            this.NotifyIcon.BalloonTipClicked += new System.EventHandler(this.NotifyIcon_BalloonTipClicked);
            this.NotifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon_MouseDoubleClick);
            // 
            // NotifyIconContextMenu
            // 
            this.NotifyIconContextMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.NotifyIconContextMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.NotifyIconContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.websiteToolStripMenuItem,
            this.separatorToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.NotifyIconContextMenu.Name = "NotifyIconContextMenu";
            this.NotifyIconContextMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.NotifyIconContextMenu.ShowItemToolTips = false;
            this.NotifyIconContextMenu.Size = new System.Drawing.Size(128, 100);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.openToolStripMenuItem.Size = new System.Drawing.Size(127, 30);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // websiteToolStripMenuItem
            // 
            this.websiteToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.websiteToolStripMenuItem.Name = "websiteToolStripMenuItem";
            this.websiteToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.websiteToolStripMenuItem.Size = new System.Drawing.Size(127, 30);
            this.websiteToolStripMenuItem.Text = "Website";
            this.websiteToolStripMenuItem.Click += new System.EventHandler(this.websiteToolStripMenuItem_Click);
            // 
            // separatorToolStripMenuItem
            // 
            this.separatorToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.separatorToolStripMenuItem.Name = "separatorToolStripMenuItem";
            this.separatorToolStripMenuItem.Padding = new System.Windows.Forms.Padding(20, 10, 0, 0);
            this.separatorToolStripMenuItem.Size = new System.Drawing.Size(124, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(127, 30);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.exitToolStripMenuItem.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // Heartbeat
            // 
            this.Heartbeat.Enabled = true;
            this.Heartbeat.Interval = 295000;
            this.Heartbeat.Tick += new System.EventHandler(this.Heartbeat_Tick);
            // 
            // VolumeMixerButton
            // 
            this.VolumeMixerButton.BackgroundImage = global::SpotBlocker.Properties.Resources.options;
            this.VolumeMixerButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.VolumeMixerButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.VolumeMixerButton.FlatAppearance.BorderSize = 0;
            this.VolumeMixerButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.VolumeMixerButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.VolumeMixerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.VolumeMixerButton.Location = new System.Drawing.Point(486, 12);
            this.VolumeMixerButton.Name = "VolumeMixerButton";
            this.VolumeMixerButton.Size = new System.Drawing.Size(45, 50);
            this.VolumeMixerButton.TabIndex = 0;
            this.toolTip1.SetToolTip(this.VolumeMixerButton, "Open Volume Mixer");
            this.VolumeMixerButton.UseVisualStyleBackColor = true;
            this.VolumeMixerButton.Click += new System.EventHandler(this.VolumeMixerButton_Click);
            this.VolumeMixerButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VolumeMixerButton_MouseDown);
            this.VolumeMixerButton.MouseLeave += new System.EventHandler(this.VolumeMixerButton_MouseLeave);
            this.VolumeMixerButton.MouseHover += new System.EventHandler(this.VolumeMixerButton_MouseHover);
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.pnlMain.BackgroundImage = global::SpotBlocker.Properties.Resources.title_bg_1;
            this.pnlMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnlMain.Controls.Add(this.pictureBox2);
            this.pnlMain.Controls.Add(this.pnlContainer);
            this.pnlMain.Controls.Add(this.pnlTitle);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(2, 2);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(596, 396);
            this.pnlMain.TabIndex = 13;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Image = global::SpotBlocker.Properties.Resources.sb_title_150;
            this.pictureBox2.Location = new System.Drawing.Point(0, 30);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Padding = new System.Windows.Forms.Padding(0, 20, 0, 20);
            this.pictureBox2.Size = new System.Drawing.Size(596, 148);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 15;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_MouseDown);
            this.pictureBox2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form_MouseMove);
            this.pictureBox2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form_MouseUp);
            // 
            // pnlContainer
            // 
            this.pnlContainer.Controls.Add(this.StartMinimizedCheckbox);
            this.pnlContainer.Controls.Add(this.RulerBottom);
            this.pnlContainer.Controls.Add(this.RulerTop);
            this.pnlContainer.Controls.Add(this.imgLoading);
            this.pnlContainer.Controls.Add(this.VolumeMixerButton);
            this.pnlContainer.Controls.Add(this.StartupCheckbox);
            this.pnlContainer.Controls.Add(this.MuteButton);
            this.pnlContainer.Controls.Add(this.BlockBannersCheckbox);
            this.pnlContainer.Controls.Add(this.DesignWebLink);
            this.pnlContainer.Controls.Add(this.WebsiteLink);
            this.pnlContainer.Controls.Add(this.SpotifyMuteCheckbox);
            this.pnlContainer.Controls.Add(this.StatusLabel);
            this.pnlContainer.Controls.Add(this.imgSpotfy);
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlContainer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.pnlContainer.ForeColor = System.Drawing.Color.White;
            this.pnlContainer.Location = new System.Drawing.Point(0, 178);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.pnlContainer.Size = new System.Drawing.Size(596, 218);
            this.pnlContainer.TabIndex = 14;
            // 
            // StartMinimizedCheckbox
            // 
            this.StartMinimizedCheckbox.AutoSize = true;
            this.StartMinimizedCheckbox.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.StartMinimizedCheckbox.FlatAppearance.BorderSize = 0;
            this.StartMinimizedCheckbox.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.StartMinimizedCheckbox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartMinimizedCheckbox.Location = new System.Drawing.Point(183, 155);
            this.StartMinimizedCheckbox.Name = "StartMinimizedCheckbox";
            this.StartMinimizedCheckbox.Size = new System.Drawing.Size(164, 21);
            this.StartMinimizedCheckbox.TabIndex = 20;
            this.StartMinimizedCheckbox.Text = "Start minimized to tray";
            this.StartMinimizedCheckbox.UseVisualStyleBackColor = true;
            this.StartMinimizedCheckbox.CheckedChanged += new System.EventHandler(this.StartMinimizedCheckbox_CheckedChanged);
            // 
            // RulerBottom
            // 
            this.RulerBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.RulerBottom.Location = new System.Drawing.Point(23, 182);
            this.RulerBottom.Name = "RulerBottom";
            this.RulerBottom.Size = new System.Drawing.Size(556, 2);
            this.RulerBottom.TabIndex = 19;
            // 
            // RulerTop
            // 
            this.RulerTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.RulerTop.Location = new System.Drawing.Point(53, 68);
            this.RulerTop.Name = "RulerTop";
            this.RulerTop.Size = new System.Drawing.Size(488, 2);
            this.RulerTop.TabIndex = 17;
            // 
            // imgLoading
            // 
            this.imgLoading.BackColor = System.Drawing.Color.Transparent;
            this.imgLoading.BackgroundImage = global::SpotBlocker.Properties.Resources.sound;
            this.imgLoading.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.imgLoading.Location = new System.Drawing.Point(63, 12);
            this.imgLoading.Name = "imgLoading";
            this.imgLoading.Size = new System.Drawing.Size(45, 50);
            this.imgLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imgLoading.TabIndex = 16;
            this.imgLoading.TabStop = false;
            // 
            // StartupCheckbox
            // 
            this.StartupCheckbox.AutoSize = true;
            this.StartupCheckbox.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.StartupCheckbox.FlatAppearance.BorderSize = 0;
            this.StartupCheckbox.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.StartupCheckbox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartupCheckbox.Location = new System.Drawing.Point(183, 130);
            this.StartupCheckbox.Name = "StartupCheckbox";
            this.StartupCheckbox.Size = new System.Drawing.Size(188, 21);
            this.StartupCheckbox.TabIndex = 3;
            this.StartupCheckbox.Text = "Start SpotBlocker on login";
            this.StartupCheckbox.UseVisualStyleBackColor = true;
            this.StartupCheckbox.CheckedChanged += new System.EventHandler(this.StartupCheckbox_CheckedChanged);
            // 
            // MuteButton
            // 
            this.MuteButton.FlatAppearance.BorderSize = 0;
            this.MuteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MuteButton.Location = new System.Drawing.Point(411, 90);
            this.MuteButton.Name = "MuteButton";
            this.MuteButton.Size = new System.Drawing.Size(120, 50);
            this.MuteButton.TabIndex = 4;
            this.MuteButton.Text = "Mute/UnMute Spotify";
            this.MuteButton.UseVisualStyleBackColor = true;
            this.MuteButton.Visible = false;
            this.MuteButton.Click += new System.EventHandler(this.MuteButton_Click);
            // 
            // BlockBannersCheckbox
            // 
            this.BlockBannersCheckbox.AutoSize = true;
            this.BlockBannersCheckbox.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BlockBannersCheckbox.FlatAppearance.BorderSize = 0;
            this.BlockBannersCheckbox.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.BlockBannersCheckbox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BlockBannersCheckbox.Location = new System.Drawing.Point(183, 105);
            this.BlockBannersCheckbox.Name = "BlockBannersCheckbox";
            this.BlockBannersCheckbox.Size = new System.Drawing.Size(211, 21);
            this.BlockBannersCheckbox.TabIndex = 2;
            this.BlockBannersCheckbox.Text = "Disable all ads (Experimental)";
            this.BlockBannersCheckbox.UseVisualStyleBackColor = true;
            this.BlockBannersCheckbox.Click += new System.EventHandler(this.SkipAdsCheckbox_Click);
            // 
            // DesignWebLink
            // 
            this.DesignWebLink.ActiveLinkColor = System.Drawing.Color.DimGray;
            this.DesignWebLink.AutoSize = true;
            this.DesignWebLink.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.DesignWebLink.LinkColor = System.Drawing.Color.Silver;
            this.DesignWebLink.Location = new System.Drawing.Point(462, 187);
            this.DesignWebLink.Name = "DesignWebLink";
            this.DesignWebLink.Size = new System.Drawing.Size(117, 17);
            this.DesignWebLink.TabIndex = 6;
            this.DesignWebLink.TabStop = true;
            this.DesignWebLink.Text = "About the Project";
            this.DesignWebLink.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.DesignWebLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.AboutWebLink_LinkClicked);
            // 
            // WebsiteLink
            // 
            this.WebsiteLink.ActiveLinkColor = System.Drawing.Color.DimGray;
            this.WebsiteLink.AutoSize = true;
            this.WebsiteLink.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.WebsiteLink.LinkColor = System.Drawing.Color.Silver;
            this.WebsiteLink.Location = new System.Drawing.Point(20, 187);
            this.WebsiteLink.Name = "WebsiteLink";
            this.WebsiteLink.Size = new System.Drawing.Size(107, 17);
            this.WebsiteLink.TabIndex = 5;
            this.WebsiteLink.TabStop = true;
            this.WebsiteLink.Text = "Report Problem";
            this.WebsiteLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.WebsiteLink_LinkClicked);
            // 
            // SpotifyMuteCheckbox
            // 
            this.SpotifyMuteCheckbox.AutoSize = true;
            this.SpotifyMuteCheckbox.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.SpotifyMuteCheckbox.FlatAppearance.BorderSize = 0;
            this.SpotifyMuteCheckbox.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.SpotifyMuteCheckbox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SpotifyMuteCheckbox.Location = new System.Drawing.Point(183, 80);
            this.SpotifyMuteCheckbox.Name = "SpotifyMuteCheckbox";
            this.SpotifyMuteCheckbox.Size = new System.Drawing.Size(132, 21);
            this.SpotifyMuteCheckbox.TabIndex = 1;
            this.SpotifyMuteCheckbox.Text = "Mute only Spotify";
            this.SpotifyMuteCheckbox.UseVisualStyleBackColor = true;
            this.SpotifyMuteCheckbox.CheckedChanged += new System.EventHandler(this.SpotifyMuteCheckBox_CheckedChanged);
            // 
            // StatusLabel
            // 
            this.StatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.StatusLabel.Location = new System.Drawing.Point(114, 12);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(366, 50);
            this.StatusLabel.TabIndex = 9;
            this.StatusLabel.Text = "Loading...";
            this.StatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // imgSpotfy
            // 
            this.imgSpotfy.BackColor = System.Drawing.Color.Transparent;
            this.imgSpotfy.BackgroundImage = global::SpotBlocker.Properties.Resources.spotify;
            this.imgSpotfy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.imgSpotfy.Location = new System.Drawing.Point(63, 74);
            this.imgSpotfy.Name = "imgSpotfy";
            this.imgSpotfy.Size = new System.Drawing.Size(103, 34);
            this.imgSpotfy.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imgSpotfy.TabIndex = 18;
            this.imgSpotfy.TabStop = false;
            // 
            // pnlTitle
            // 
            this.pnlTitle.BackColor = System.Drawing.Color.Transparent;
            this.pnlTitle.Controls.Add(this.label1);
            this.pnlTitle.Controls.Add(this.btnMinimized);
            this.pnlTitle.Controls.Add(this.btnClose);
            this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(596, 30);
            this.pnlTitle.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.label1.Size = new System.Drawing.Size(496, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "SpotBlocker";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_MouseDown);
            this.label1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form_MouseMove);
            this.label1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form_MouseUp);
            // 
            // btnMinimized
            // 
            this.btnMinimized.BackgroundImage = global::SpotBlocker.Properties.Resources.minimized;
            this.btnMinimized.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMinimized.FlatAppearance.BorderSize = 0;
            this.btnMinimized.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnMinimized.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.btnMinimized.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimized.Location = new System.Drawing.Point(496, 0);
            this.btnMinimized.Name = "btnMinimized";
            this.btnMinimized.Size = new System.Drawing.Size(50, 30);
            this.btnMinimized.TabIndex = 0;
            this.btnMinimized.TabStop = false;
            this.btnMinimized.UseVisualStyleBackColor = true;
            this.btnMinimized.Click += new System.EventHandler(this.btnMinimized_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImage = global::SpotBlocker.Properties.Resources.close;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(546, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(50, 30);
            this.btnClose.TabIndex = 0;
            this.btnClose.TabStop = false;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.pnlMain);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SpotBlocker";
            this.Load += new System.EventHandler(this.Main_Load);
            this.Resize += new System.EventHandler(this.Form_Resize);
            this.NotifyIconContextMenu.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.pnlContainer.ResumeLayout(false);
            this.pnlContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgLoading)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgSpotfy)).EndInit();
            this.pnlTitle.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button MuteButton;
        private System.Windows.Forms.NotifyIcon NotifyIcon;
        private System.Windows.Forms.LinkLabel WebsiteLink;
        private System.Windows.Forms.Timer Heartbeat;
        private System.Windows.Forms.CheckBox SpotifyMuteCheckbox;
        private System.Windows.Forms.Button VolumeMixerButton;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.CheckBox BlockBannersCheckbox;
        private System.Windows.Forms.Timer MainTimer;
        private System.Windows.Forms.CheckBox StartupCheckbox;
        private System.Windows.Forms.ContextMenuStrip NotifyIconContextMenu;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem websiteToolStripMenuItem;
        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlContainer;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnMinimized;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PictureBox imgLoading;
        private System.Windows.Forms.PictureBox imgSpotfy;
        private System.Windows.Forms.Panel RulerTop;
        private System.Windows.Forms.Panel RulerBottom;
        private System.Windows.Forms.LinkLabel DesignWebLink;
        private System.Windows.Forms.ToolStripSeparator separatorToolStripMenuItem;
        private System.Windows.Forms.CheckBox StartMinimizedCheckbox;
    }
}

