using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotBlocker.DTO
{
    public class GitHubRelease
    {
#pragma warning disable CS0649
        public string name;
        public string tag_name;
        public DateTime published_at;
        public List<GitHubReleaseAsset> assets;
#pragma warning restore CS0649
    }
    public class GitHubReleaseAsset
    {
#pragma warning disable CS0649
        public string name;
        public string browser_download_url;
        public DateTime updated_at;
        public string state;
#pragma warning restore CS0649
    }
}
