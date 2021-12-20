using NuGet.Packaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublishToNuget.Models
{
    public class ProjModel
    {
        public string Key { get; set; }

        public string LibName { get; set; }

        public string LibDebugPath { get; set; }

        public string LibReleasePath { get; set; }

        public string Version { get; set; }

        public string Desc { get; set; }

        public string Author { get; set; }

        public IEnumerable<string> Owners { get; set; }

        public ManifestMetadata PackageInfo { get; set; }

        public string NetFrameworkVersion { get; set; }

        public List<string> NetFrameworkVersionList { get; set; }

        public string ProjectPath { get; set; }

        public string ProjectFullName { get; set; }
    }
}
