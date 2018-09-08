namespace ZZLH.PackagingTool.App
{
    partial class FrmMain
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemNewProj = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemPackage = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.addFileControl1 = new ZZLH.PackagingTool.App.AddFileControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.executeOperationControl1 = new ZZLH.PackagingTool.App.ExecuteOperationControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.optionControl1 = new ZZLH.PackagingTool.App.OptionControl();
            this.buttonPackage = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemOpen,
            this.toolStripMenuItemNewProj,
            this.toolStripMenuItemSave,
            this.toolStripMenuItemPackage,
            this.toolStripMenuItemExit});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(44, 21);
            this.toolStripMenuItem1.Text = "文件";
            // 
            // toolStripMenuItemOpen
            // 
            this.toolStripMenuItemOpen.Name = "toolStripMenuItemOpen";
            this.toolStripMenuItemOpen.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItemOpen.Text = "打开工程";
            this.toolStripMenuItemOpen.Click += new System.EventHandler(this.toolStripMenuItemOpen_Click);
            // 
            // toolStripMenuItemNewProj
            // 
            this.toolStripMenuItemNewProj.Name = "toolStripMenuItemNewProj";
            this.toolStripMenuItemNewProj.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItemNewProj.Text = "新建工程";
            this.toolStripMenuItemNewProj.Click += new System.EventHandler(this.toolStripMenuItemNewProj_Click);
            // 
            // toolStripMenuItemSave
            // 
            this.toolStripMenuItemSave.Name = "toolStripMenuItemSave";
            this.toolStripMenuItemSave.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItemSave.Text = "另存工程";
            this.toolStripMenuItemSave.Click += new System.EventHandler(this.toolStripMenuItemSave_Click);
            // 
            // toolStripMenuItemPackage
            // 
            this.toolStripMenuItemPackage.Name = "toolStripMenuItemPackage";
            this.toolStripMenuItemPackage.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItemPackage.Text = "执行封包";
            this.toolStripMenuItemPackage.Click += new System.EventHandler(this.toolStripMenuItemPackage_Click);
            // 
            // toolStripMenuItemExit
            // 
            this.toolStripMenuItemExit.Name = "toolStripMenuItemExit";
            this.toolStripMenuItemExit.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItemExit.Text = "退出";
            this.toolStripMenuItemExit.Click += new System.EventHandler(this.toolStripMenuItemExit_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(6, 31);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(793, 375);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.addFileControl1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(785, 349);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "文件";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // addFileControl1
            // 
            this.addFileControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addFileControl1.Location = new System.Drawing.Point(3, 3);
            this.addFileControl1.Name = "addFileControl1";
            this.addFileControl1.Size = new System.Drawing.Size(779, 343);
            this.addFileControl1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.executeOperationControl1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(785, 349);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "释放后操作";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // executeOperationControl1
            // 
            this.executeOperationControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.executeOperationControl1.Location = new System.Drawing.Point(3, 3);
            this.executeOperationControl1.Name = "executeOperationControl1";
            this.executeOperationControl1.Size = new System.Drawing.Size(779, 343);
            this.executeOperationControl1.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.optionControl1);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(785, 349);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "选项";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // optionControl1
            // 
            this.optionControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optionControl1.Location = new System.Drawing.Point(0, 0);
            this.optionControl1.Name = "optionControl1";
            this.optionControl1.Size = new System.Drawing.Size(785, 349);
            this.optionControl1.TabIndex = 0;
            // 
            // buttonPackage
            // 
            this.buttonPackage.Location = new System.Drawing.Point(626, 412);
            this.buttonPackage.Name = "buttonPackage";
            this.buttonPackage.Size = new System.Drawing.Size(158, 30);
            this.buttonPackage.TabIndex = 2;
            this.buttonPackage.Text = "执行封包";
            this.buttonPackage.UseVisualStyleBackColor = true;
            this.buttonPackage.Click += new System.EventHandler(this.buttonPackage_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "*.exe|*.exe";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Title = "打开工程";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonPackage);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(816, 489);
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "中招联合打包工具";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemNewProj;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemPackage;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemExit;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button buttonPackage;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage1;
        private AddFileControl addFileControl1;
        private ExecuteOperationControl executeOperationControl1;
        private OptionControl optionControl1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpen;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSave;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

