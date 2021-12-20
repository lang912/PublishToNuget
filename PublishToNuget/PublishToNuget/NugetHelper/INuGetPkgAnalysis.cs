using PublishToNuget.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublishToNuget.NugetHelper
{
    internal interface INuGetPkgAnalysis
    {
        Dictionary<string, List<SimplePkgView>> GetNuGetPkgs(ProjModel _projModel);
    }
}
