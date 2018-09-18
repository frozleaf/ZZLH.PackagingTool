namespace ZZLH.PackagingTool.App
{
    partial class OptionControl
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
            this.checkBoxCompressFile = new System.Windows.Forms.CheckBox();
            this.checkBoxCreateRandomBytes = new System.Windows.Forms.CheckBox();
            this.textBoxRandomBytes = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // checkBoxCompressFile
            // 
            this.checkBoxCompressFile.AutoSize = true;
            this.checkBoxCompressFile.Location = new System.Drawing.Point(38, 36);
            this.checkBoxCompressFile.Name = "checkBoxCompressFile";
            this.checkBoxCompressFile.Size = new System.Drawing.Size(72, 16);
            this.checkBoxCompressFile.TabIndex = 1;
            this.checkBoxCompressFile.Text = "压缩文件";
            this.checkBoxCompressFile.UseVisualStyleBackColor = true;
            // 
            // checkBoxCreateRandomBytes
            // 
            this.checkBoxCreateRandomBytes.AutoSize = true;
            this.checkBoxCreateRandomBytes.Checked = true;
            this.checkBoxCreateRandomBytes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCreateRandomBytes.Location = new System.Drawing.Point(38, 64);
            this.checkBoxCreateRandomBytes.Name = "checkBoxCreateRandomBytes";
            this.checkBoxCreateRandomBytes.Size = new System.Drawing.Size(120, 16);
            this.checkBoxCreateRandomBytes.TabIndex = 1;
            this.checkBoxCreateRandomBytes.Text = "创建随机字节序列";
            this.checkBoxCreateRandomBytes.UseVisualStyleBackColor = true;
            this.checkBoxCreateRandomBytes.CheckedChanged += new System.EventHandler(this.checkBoxCreateRandomBytes_CheckedChanged);
            // 
            // textBoxRandomBytes
            // 
            this.textBoxRandomBytes.Location = new System.Drawing.Point(164, 61);
            this.textBoxRandomBytes.Name = "textBoxRandomBytes";
            this.textBoxRandomBytes.Size = new System.Drawing.Size(165, 21);
            this.textBoxRandomBytes.TabIndex = 2;
            this.textBoxRandomBytes.Visible = false;
            // 
            // OptionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBoxRandomBytes);
            this.Controls.Add(this.checkBoxCreateRandomBytes);
            this.Controls.Add(this.checkBoxCompressFile);
            this.Name = "OptionControl";
            this.Size = new System.Drawing.Size(502, 315);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxCompressFile;
        private System.Windows.Forms.CheckBox checkBoxCreateRandomBytes;
        private System.Windows.Forms.TextBox textBoxRandomBytes;
    }
}
