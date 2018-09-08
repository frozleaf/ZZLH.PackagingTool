namespace ZZLH.PackagingTool.App
{
    partial class ExecuteOperationControl
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
            this.components = new System.ComponentModel.Container();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.buttonMoveUp = new System.Windows.Forms.Button();
            this.buttonMoveDown = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemSelectLocalFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSelectProjFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemInsertVar = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSelectCommon = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemMsiExec = new System.Windows.Forms.ToolStripMenuItem();
            this.flowLayoutPanel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(859, 467);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "文件路径";
            this.columnHeader2.Width = 400;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "启动参数";
            this.columnHeader3.Width = 200;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.buttonAdd);
            this.flowLayoutPanel1.Controls.Add(this.buttonEdit);
            this.flowLayoutPanel1.Controls.Add(this.buttonRemove);
            this.flowLayoutPanel1.Controls.Add(this.buttonMoveUp);
            this.flowLayoutPanel1.Controls.Add(this.buttonMoveDown);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 467);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(859, 28);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(3, 3);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 1;
            this.buttonAdd.Text = "增加...";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Enabled = false;
            this.buttonEdit.Location = new System.Drawing.Point(84, 3);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(75, 23);
            this.buttonEdit.TabIndex = 2;
            this.buttonEdit.Text = "编辑";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonRemove
            // 
            this.buttonRemove.Enabled = false;
            this.buttonRemove.Location = new System.Drawing.Point(165, 3);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(75, 23);
            this.buttonRemove.TabIndex = 3;
            this.buttonRemove.Text = "移除";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // buttonMoveUp
            // 
            this.buttonMoveUp.Enabled = false;
            this.buttonMoveUp.Location = new System.Drawing.Point(246, 3);
            this.buttonMoveUp.Name = "buttonMoveUp";
            this.buttonMoveUp.Size = new System.Drawing.Size(75, 23);
            this.buttonMoveUp.TabIndex = 4;
            this.buttonMoveUp.Text = "上移";
            this.buttonMoveUp.UseVisualStyleBackColor = true;
            this.buttonMoveUp.Click += new System.EventHandler(this.buttonMoveUp_Click);
            // 
            // buttonMoveDown
            // 
            this.buttonMoveDown.Enabled = false;
            this.buttonMoveDown.Location = new System.Drawing.Point(327, 3);
            this.buttonMoveDown.Name = "buttonMoveDown";
            this.buttonMoveDown.Size = new System.Drawing.Size(75, 23);
            this.buttonMoveDown.TabIndex = 5;
            this.buttonMoveDown.Text = "下移";
            this.buttonMoveDown.UseVisualStyleBackColor = true;
            this.buttonMoveDown.Click += new System.EventHandler(this.buttonMoveDown_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemSelectLocalFile,
            this.toolStripMenuItemSelectProjFile,
            this.toolStripMenuItemInsertVar,
            this.toolStripMenuItemSelectCommon});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(161, 92);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // toolStripMenuItemSelectLocalFile
            // 
            this.toolStripMenuItemSelectLocalFile.Name = "toolStripMenuItemSelectLocalFile";
            this.toolStripMenuItemSelectLocalFile.Size = new System.Drawing.Size(160, 22);
            this.toolStripMenuItemSelectLocalFile.Text = "选择本地文件...";
            this.toolStripMenuItemSelectLocalFile.Visible = false;
            // 
            // toolStripMenuItemSelectProjFile
            // 
            this.toolStripMenuItemSelectProjFile.Name = "toolStripMenuItemSelectProjFile";
            this.toolStripMenuItemSelectProjFile.Size = new System.Drawing.Size(160, 22);
            this.toolStripMenuItemSelectProjFile.Text = "选择项目内文件";
            // 
            // toolStripMenuItemInsertVar
            // 
            this.toolStripMenuItemInsertVar.Name = "toolStripMenuItemInsertVar";
            this.toolStripMenuItemInsertVar.Size = new System.Drawing.Size(160, 22);
            this.toolStripMenuItemInsertVar.Text = "插入变量";
            // 
            // toolStripMenuItemSelectCommon
            // 
            this.toolStripMenuItemSelectCommon.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemMsiExec});
            this.toolStripMenuItemSelectCommon.Name = "toolStripMenuItemSelectCommon";
            this.toolStripMenuItemSelectCommon.Size = new System.Drawing.Size(160, 22);
            this.toolStripMenuItemSelectCommon.Text = "常用";
            // 
            // toolStripMenuItemMsiExec
            // 
            this.toolStripMenuItemMsiExec.Name = "toolStripMenuItemMsiExec";
            this.toolStripMenuItemMsiExec.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItemMsiExec.Text = "msiexec";
            this.toolStripMenuItemMsiExec.Click += new System.EventHandler(this.toolStripMenuItemMsiExec_Click);
            // 
            // ExecuteOperationControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "ExecuteOperationControl";
            this.Size = new System.Drawing.Size(859, 495);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSelectLocalFile;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSelectProjFile;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemInsertVar;
        private System.Windows.Forms.Button buttonMoveUp;
        private System.Windows.Forms.Button buttonMoveDown;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSelectCommon;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemMsiExec;
    }
}
