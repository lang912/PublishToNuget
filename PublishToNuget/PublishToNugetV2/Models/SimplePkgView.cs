using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublishToNugetV2.Models
{
    public class SimplePkgView
    {
        public string Id { get; set; }

        public string Version { get; set; }

        public string Desc { get; set; }

        public string Author { get; set; }

        public DateTimeOffset? PublishDateTime { get; set; }

        public long DownloadCount { get; set; }

        public string TargetFramework { get; set; }
    }

    public class UpdatePkgView : SimplePkgView
    {
        public string OldVersion { get; set; }
    }
}
