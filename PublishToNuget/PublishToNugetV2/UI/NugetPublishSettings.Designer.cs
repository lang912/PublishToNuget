using PublishToNugetV2.NugetHelper;
using System;
using System.Windows.Forms;

namespace PublishToNugetV2.UI
{
    partial class NugetPublishSettings
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.AuthorLable = new System.Windows.Forms.Label();
            this.NugetServerLable = new System.Windows.Forms.Label();
            this.PublishKey = new System.Windows.Forms.Label();
            this.textBoxAuthor = new System.Windows.Forms.TextBox();
            this.textBoxPublishKey = new System.Windows.Forms.TextBox();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.comboBoxSources = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // AuthorLable
            // 
            this.AuthorLable.AutoSize = true;
            this.AuthorLable.Location = new System.Drawing.Point(3, 29);
            this.AuthorLable.Name = "AuthorLable";
            this.AuthorLable.Size = new System.Drawing.Size(53, 12);
            this.AuthorLable.TabIndex = 0;
            this.AuthorLable.Text = "Author：";
            // 
            // NugetServerLable
            // 
            this.NugetServerLable.AutoSize = true;
            this.NugetServerLable.Location = new System.Drawing.Point(3, 97);
            this.NugetServerLable.Name = "NugetServerLable";
            this.NugetServerLable.Size = new System.Drawing.Size(83, 12);
            this.NugetServerLable.TabIndex = 1;
            this.NugetServerLable.Text = "NugetServer：";
            // 
            // PublishKey
            // 
            this.PublishKey.AutoSize = true;
            this.PublishKey.Location = new System.Drawing.Point(3, 166);
            this.PublishKey.Name = "PublishKey";
            this.PublishKey.Size = new System.Drawing.Size(77, 12);
            this.PublishKey.TabIndex = 2;
            this.PublishKey.Text = "PublishKey：";
            // 
            // textBoxAuthor
            // 
            this.textBoxAuthor.Location = new System.Drawing.Point(75, 29);
            this.textBoxAuthor.Name = "textBoxAuthor";
            this.textBoxAuthor.Size = new System.Drawing.Size(198, 21);
            this.textBoxAuthor.TabIndex = 3;
            this.textBoxAuthor.TextChanged += new EventHandler(TextBoxAuthorChange);
            // 
            // textBoxPublishKey
            // 
            this.textBoxPublishKey.Location = new System.Drawing.Point(75, 166);
            this.textBoxPublishKey.Name = "textBoxPublishKey";
            this.textBoxPublishKey.Size = new System.Drawing.Size(198, 21);
            this.textBoxPublishKey.TabIndex = 5;
            this.textBoxPublishKey.TextChanged += new EventHandler(TextBoxPublishKeyChange);
            // 
            // RefreshButton
            // 
            this.RefreshButton.Location = new System.Drawing.Point(279, 97);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(70, 20);
            this.RefreshButton.TabIndex = 6;
            this.RefreshButton.Text = "Refresh";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // comboBoxSources
            // 
            this.comboBoxSources.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSources.FormattingEnabled = true;
            this.comboBoxSources.Location = new System.Drawing.Point(75, 97);
            this.comboBoxSources.Name = "comboBoxSources";
            this.comboBoxSources.Size = new System.Drawing.Size(198, 20);
            this.comboBoxSources.TabIndex = 7;
            this.comboBoxSources.SelectedIndexChanged += new EventHandler(ComboBoxSourceSelectedIndexChanged);
            // 
            // NugetPublishSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.comboBoxSources);
            this.Controls.Add(this.RefreshButton);
            this.Controls.Add(this.textBoxPublishKey);
            this.Controls.Add(this.textBoxAuthor);
            this.Controls.Add(this.PublishKey);
            this.Controls.Add(this.NugetServerLable);
            this.Controls.Add(this.AuthorLable);
            this.Name = "NugetPublishSettings";
            this.Size = new System.Drawing.Size(368, 208);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label AuthorLable;
        private System.Windows.Forms.Label NugetServerLable;
        private System.Windows.Forms.Label PublishKey;
        private System.Windows.Forms.TextBox textBoxAuthor;
        private System.Windows.Forms.TextBox textBoxPublishKey;

        /// <summary>
        /// publishsetting 设置页面
        /// </summary>
        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.ComboBox comboBoxSources;

        /// <summary>
        /// Gets or sets the reference to the underlying OptionsPage object.
        /// </summary>
        internal NugetPublishSettingsPage NugetPublishSettingsPage { get; set; }

       
    }
}
