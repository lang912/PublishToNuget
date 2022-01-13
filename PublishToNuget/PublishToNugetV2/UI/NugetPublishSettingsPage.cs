using Microsoft.VisualStudio.Shell;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PublishToNugetV2.UI
{
    [Guid(GuidString.NugetPublishSettingsPage)]
    public class NugetPublishSettingsPage : DialogPage
    {
        #region Fields

        private NugetPublishSettings optionsControl;

        /// <summary>
        /// 作者
        /// </summary>
        public string Authour { get; set; } = "";

        /// <summary>
        /// 推送key
        /// </summary>
        public string PublishKey { get; set; } = "";

        /// <summary>
        /// 选中的包源
        /// </summary>
        public string SelectedPackageSource { get; set; }


        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets the window an instance of DialogPage that it uses as its user interface.
        /// </summary>
        /// <devdoc>
        /// The window this dialog page will use for its UI.
        /// This window handle must be constant, so if you are
        /// returning a Windows Forms control you must make sure
        /// it does not recreate its handle.  If the window object
        /// implements IComponent it will be sited by the 
        /// dialog page so it can get access to global services.
        /// </devdoc>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected override IWin32Window Window
        {
            get
            {
                if (optionsControl == null)
                {
                    optionsControl = new NugetPublishSettings();
                    optionsControl.Location = new Point(0, 0);
                    optionsControl.NugetPublishSettingsPage = this;
                    optionsControl.InitNugetSource();
                }
                return optionsControl;
            }
        }

        /// <summary>
        /// Gets or sets the path to the image file.
        /// </summary>
        /// <remarks>The property that needs to be persisted.</remarks>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string CustomBitmap { get; set; }

        #endregion Properties

        #region Methods

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (optionsControl != null)
                {
                    optionsControl.Dispose();
                    optionsControl = null;
                }
            }
            base.Dispose(disposing);
        }

        #endregion Methods

    }
}
