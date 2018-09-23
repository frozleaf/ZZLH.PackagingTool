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
    public partial class FrmMain : Form, IControlRenderer<PackagingInfo>
    {
        private XmPackagingStorage _storage = new XmPackagingStorage();

        public FrmMain()
        {
            InitializeComponent();
        }

        private void buttonPackage_Click(object sender, EventArgs e)
        {
            this.saveFileDialog1.ClearFilter();
            this.saveFileDialog1.AddFilter("可执行文件", "*.exe");
            if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    GlobalContext.Project = Fetch();
                    _storage.Pack(GlobalContext.Project, this.saveFileDialog1.FileName);
                    MessageBox.Show("封包成功！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("封包失败," + ex, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void toolStripMenuItemNewProj_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要新建工程！", this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) ==
                DialogResult.Cancel)
                return;
            GlobalContext.Project = new PackagingInfo();
            Render(GlobalContext.Project);
        }

        private void toolStripMenuItemPackage_Click(object sender, EventArgs e)
        {
            buttonPackage.PerformClick();
        }

        private void toolStripMenuItemExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripMenuItemOpen_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.ClearFilter();
            this.openFileDialog1.AddFilter("中招联合封包文件", "*.zzlhpackage");
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var info = _storage.OpenProject(this.openFileDialog1.FileName);
                    GlobalContext.Project = info;
                    Render(info);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("工程打开失败," + ex, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #region 实现接口

        public void Render(PackagingInfo info)
        {
            this.addFileControl1.Render(info.Files);
            this.executeOperationControl1.Render(info.Operations);
            this.optionControl1.Render(info.Option);
        }

        public PackagingInfo Fetch()
        {
            var info = new PackagingInfo();
            info.Files = this.addFileControl1.Fetch();
            info.Operations = this.executeOperationControl1.Fetch();
            info.Option = this.optionControl1.Fetch();
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

        private void toolStripMenuItemSave_Click(object sender, EventArgs e)
        {
            this.saveFileDialog1.ClearFilter();
            this.saveFileDialog1.AddFilter("中招联合封包文件", "*.zzlhpackage");
            if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var info = Fetch();
                    _storage.SaveProject(info, this.saveFileDialog1.FileName);
                    MessageBox.Show("另存工程成功！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("另存工程失败," + ex, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
