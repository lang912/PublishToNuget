using PublishToNugetV2.NugetHelper;
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

        /// <summary>
        /// 初始化nuget源
        /// </summary>
        public void InitNugetSource()
        {
            try
            {
                this.comboBoxSources.Items.Clear();
                var sources = NuGetPkgService.GetAllPackageSources();
                foreach (var item in sources)
                {
                    this.comboBoxSources.Items.Add(item.Value);
                }

                if (string.IsNullOrWhiteSpace(NugetPublishSettingsPage?.SelectedPackageSource) == false)
                {
                    this.comboBoxSources.SelectedItem = NugetPublishSettingsPage.SelectedPackageSource;
                }
                else
                {
                    this.comboBoxSources.SelectedIndex = 0;
                }
            }
            catch
            {

            }

            this.textBoxAuthor.Text = NugetPublishSettingsPage?.Authour ?? string.Empty;
            this.textBoxPublishKey.Text = NugetPublishSettingsPage?.PublishKey ?? string.Empty;
        }

        /// <summary>
        /// 作者失去焦点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxAuthorChange(object sender, EventArgs e)
        {
            NugetPublishSettingsPage.Authour = this.textBoxAuthor.Text;
        }

        /// <summary>
        /// publishkey失去焦点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxPublishKeyChange(object sender, EventArgs e)
        {
            NugetPublishSettingsPage.PublishKey = this.textBoxPublishKey.Text;
        }

        private void ComboBoxSourceSelectedIndexChanged(object sender, EventArgs e)
        {
            NugetPublishSettingsPage.SelectedPackageSource = this.comboBoxSources.SelectedItem.ToString();
        }
    }
}
