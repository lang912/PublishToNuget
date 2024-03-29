﻿using PublishToNugetV2.Models;
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
    public partial class PackageDetailsForm : Form
    {
        public static Action<SimplePkgView> AddPkgEvent;
        private string _currPkgId;

        public PackageDetailsForm()
        {
            InitializeComponent();
        }

        public void Ini(string currPkgId)
        {
            _currPkgId = currPkgId;
            NugetPublishSettingsPage settingInfo = NuGetPkgService.GetSettingPage();
            var sources = NuGetPkgService.GetAllPackageSources();
            if (sources != null && sources.Any())
            {
                cbPackageSource.Items.Clear();
                foreach (var sc in sources)
                {
                    cbPackageSource.Items.Add(sc.Value);
                }

                if (string.IsNullOrWhiteSpace(settingInfo.SelectedPackageSource))
                {
                    cbPackageSource.SelectedIndex = 0;
                }
                else
                {
                    cbPackageSource.SelectedItem = settingInfo.SelectedPackageSource;
                }

                //showPkgDetailList();
            }
        }

        private void showPkgDetailList()
        {
            this.dgv_PkgDetails.Rows.Clear();
            var currSource = cbPackageSource.SelectedItem.ToString();
            var details = currSource.GetPkgDetailsByPkgId(_currPkgId);
            if (details != null && details.Any())
            {
                foreach (SimplePkgView simplePkgView in details)
                {
                    int index = this.dgv_PkgDetails.Rows.Add();
                    DataGridViewTextBoxCell version = new DataGridViewTextBoxCell() { Value = simplePkgView.Version };
                    DataGridViewTextBoxCell author = new DataGridViewTextBoxCell() { Value = simplePkgView.Author };
                    DataGridViewTextBoxCell desc = new DataGridViewTextBoxCell() { Value = simplePkgView.Desc };
                    DataGridViewTextBoxCell publishDate = new DataGridViewTextBoxCell() { Value = simplePkgView.PublishDateTime?.DateTime ?? DateTime.MinValue };
                    DataGridViewTextBoxCell downloads = new DataGridViewTextBoxCell() { Value = simplePkgView.DownloadCount };
                    this.dgv_PkgDetails.Rows[index].Cells[0] = version;
                    this.dgv_PkgDetails.Rows[index].Cells[1] = desc;
                    this.dgv_PkgDetails.Rows[index].Cells[2] = publishDate;
                    this.dgv_PkgDetails.Rows[index].Cells[3] = author;
                }
            }
        }

        private void cbPackageSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            showPkgDetailList();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgv_PkgDetails_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var id = this._currPkgId;
            var version = this.dgv_PkgDetails.Rows[e.RowIndex].Cells[0].Value.ToString();
            SimplePkgView model = new SimplePkgView
            {
                Id = id,
                Version = version
            };
            AddPkgEvent?.Invoke(model);
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (this.dgv_PkgDetails.SelectedRows.Count <= 0)
            {
                MessageBox.Show("您还未选择依赖项");
                return;
            }

            if (this.dgv_PkgDetails.SelectedRows.Count != 1)
            {
                MessageBox.Show("只能选择一个依赖项");
                return;
            }

            var id = this._currPkgId;
            var version = this.dgv_PkgDetails.SelectedRows[0].Cells[0].Value.ToString();
            SimplePkgView model = new SimplePkgView
            {
                Id = id,
                Version = version
            };
            AddPkgEvent?.Invoke(model);
        }
    }
}
