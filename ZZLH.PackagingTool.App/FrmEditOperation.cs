using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZZLH.PackagingTool.Execution.Core;
using ZZLH.Windows.SimpleRenderer;

namespace ZZLH.PackagingTool.App
{
    public partial class FrmEditOperation : Form,IControlRenderer<ExecuteOperationInfo>
    {
        public FrmEditOperation()
        {
            InitializeComponent();
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            this.contextMenuStrip1.Show(this.buttonBrowse, new Point(0, this.buttonBrowse.Height));
        }

        #region 接口实现
        public void Render(ExecuteOperationInfo info)
        {
            this.textBoxFilePath.Text = info.FilePath;
            this.textBoxFileArg.Text = info.FileArgument;
        }

        public ExecuteOperationInfo Fetch()
        {
            string path = this.textBoxFilePath.Text;
            string arg = this.textBoxFileArg.Text;
            var info = new ExecuteOperationInfo(path, arg);
            return info;
        }

        public bool Check()
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        } 
        #endregion

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            this.toolStripMenuItemSelectProjFile.DropDownItems.Clear();
            if (GlobalContext.Project.Files != null)
            {
                foreach (var file in GlobalContext.Project.Files)
                {
                    var item = this.toolStripMenuItemSelectProjFile.DropDownItems.Add(file.OuputFilePath);
                    item.Click += (ss, ee) =>
                    {
                        this.textBoxFilePath.SelectedText = file.OuputFilePath;
                    };
                }
            }
            this.toolStripMenuItemInsertVar.DropDownItems.Clear();
            foreach (var pair in DirectoryDefinitions.Directories)
            {
                var item = this.toolStripMenuItemInsertVar.DropDownItems.Add(pair.Key);
                item.Click += (ss, ee) =>
                {
                    this.textBoxFilePath.SelectedText = pair.Key;
                };
            }
        }

        private void toolStripMenuItemSelectLocalFile_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.textBoxFilePath.Text = this.openFileDialog1.FileName;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
