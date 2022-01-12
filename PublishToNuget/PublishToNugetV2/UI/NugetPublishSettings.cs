using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PublishToNugetV2.UI
{
    public partial class NugetPublishSettings : UserControl
    {
        public NugetPublishSettings()
        {
            InitializeComponent();
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            InitNugetSource();
        }
    }
}
