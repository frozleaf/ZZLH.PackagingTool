using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZZLH.PackagingTool.Execution.Core;

namespace ZZLH.PackagingTool.App
{
    public partial class FrmEditFileInfo : Form, IControlRenderer<AddFileInfo>
    {
        public FrmEditFileInfo()
        {
            InitializeComponent();
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
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

        public void Render(AddFileInfo info)
        {
            this.textBoxFilePath.Text = info.SourceFilePath;
            this.textBoxVirtualPath.Text = info.OuputFilePath;
        }

        public AddFileInfo Fetch()
        {
            string source = this.textBoxFilePath.Text;
            string output = this.textBoxVirtualPath.Text;
            AddFileInfo info = new AddFileInfo(source,output);
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
    }
}
