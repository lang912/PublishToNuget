using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using PublishToNugetV2.NugetHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublishToNugetV2.UI
{
    public class VsOutPutWindow
    {
        public static void CreatePane(Guid paneGuid, string title, bool visible, bool clearWithSolution)
        {
            Microsoft.VisualStudio.Shell.ThreadHelper.ThrowIfNotOnUIThread();
            IAsyncServiceProvider provider = NuGetPkgService.GetCommandPackage();
            IVsOutputWindow output = provider.GetServiceAsync(typeof(SVsOutputWindow)) as IVsOutputWindow;
            IVsOutputWindowPane pane;

            // Create a new pane.
            output.CreatePane(ref paneGuid, title, Convert.ToInt32(visible), Convert.ToInt32(clearWithSolution));

            // Retrieve the new pane.
            output.GetPane(ref paneGuid, out pane);

            pane.OutputString("This is the Created Pane \n");
        }

        /// <summary>
        /// 创建输出面板
        /// </summary>
        /// <param name="title">面板标题</param>
        /// <param name="content">输出内容</param>
        public static async void CreatePane(string title, string content)
        {
            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync();
            DTE2 dte = (DTE2)await NuGetPkgService.GetCommandPackage().GetServiceAsync(typeof(DTE));
            OutputWindowPanes panes =
                dte.ToolWindows.OutputWindow.OutputWindowPanes;

            OutputWindowPane pane;
            try
            {
                //ThreadHelper.ThrowIfNotOnUIThread();
                //TextDocument document = pane.TextDocument;
                //EditPoint point = document.StartPoint.CreateEditPoint();

                //// 下面 str 就是输出
                //var str = point.GetText(document.EndPoint);

                // If the pane exists already, write to it.  
                pane = panes.Item(title);
            }
            catch (ArgumentException)
            {
                // Create a new pane and write to it.  
                pane = panes.Add(title);
            }

            pane.OutputString($"{content} {Environment.NewLine}");
        }
    }
}
