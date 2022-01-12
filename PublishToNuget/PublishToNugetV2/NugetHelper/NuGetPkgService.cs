using Microsoft.VisualStudio;
using Microsoft.VisualStudio.ComponentModelHost;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using NuGet.VisualStudio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublishToNugetV2.NugetHelper
{
    internal class NuGetPkgService
    {
        public static PublishToNugetCommandPackage GetSettingPackage()
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            if (Package.GetGlobalService(typeof(SVsShell)) is IVsShell shell)
            {
                Guid guid = new Guid(GuidString.PublishToNugetCommandPackage);
                if (ErrorHandler.Succeeded(shell.IsPackageLoaded(ref guid, out var package)))
                {
                    return package as PublishToNugetCommandPackage;
                }

                if (ErrorHandler.Succeeded(shell.LoadPackage(ref guid, out package)))
                {
                    return package as PublishToNugetCommandPackage;
                }
            }
            return null;
        }

        ////public static OptionPageGrid GetSettingPage()
        ////{
        ////    PublishToNugetPackage package = GetSettingPackage();
        ////    return package?.GetDialogPage(typeof(OptionPageGrid)) as OptionPageGrid;
        ////}

        public static IEnumerable<KeyValuePair<string, string>> GetAllPackageSources()
        {
            IAsyncServiceProvider provider = GetSettingPackage();
            var componentModel = provider.GetServiceAsync(typeof(SComponentModel)).Result as IComponentModel;
            var sourceProvider = componentModel.GetService<IVsPackageSourceProvider>();
            return sourceProvider.GetSources(true, true);
        }
    }
}
