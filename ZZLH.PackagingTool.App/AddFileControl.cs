using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZZLH.PackagingTool.Execution.Core;
using ZZLH.Windows.SimpleRenderer;

namespace ZZLH.PackagingTool.App
{
    public partial class AddFileControl : UserControl, IControlCollectionRenderer<AddFileInfo,TreeNode>
    {
        public AddFileControl()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Render(this.openFileDialog1.FileNames.ToList().Select(s=>new AddFileInfo(s,"")));
                GlobalContext.Project.Files = Fetch();
            }
        }

        private void treeViewFile_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Level != 1)
            {
                this.buttonEdit.Enabled = false;
                this.buttonRemove.Enabled = false;
            }
            else
            {
                this.buttonEdit.Enabled = true;
                this.buttonRemove.Enabled = true;

            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            var info = this.treeViewFile.SelectedNode.Tag as AddFileInfo;
            var frm = new FrmEditFileInfo();
            frm.Render(info);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Update(frm.Fetch(), this.treeViewFile.SelectedNode);
                GlobalContext.Project.Files = Fetch();
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (this.treeViewFile.SelectedNode.Level != 1)
                return;
            this.treeViewFile.SelectedNode.Remove();
        }

        #region 接口实现
        public void Render(IEnumerable<AddFileInfo> list)
        {
            this.treeViewFile.Nodes[0].Nodes.Clear();
            if (list == null)
                return;
            foreach (var info in list)
            {
                Add(info);
            }
            this.treeViewFile.Nodes[0].Expand();
        }

        public void Add(AddFileInfo info)
        {
            var fileName = System.IO.Path.GetFileName(info.SourceFilePath);
            var rootNode = this.treeViewFile.Nodes[0];
            var found = rootNode.Nodes.Find(m => m.Text.Equals(fileName, StringComparison.InvariantCulture));
            if (found.Count==0)
            {
                found.Add(new TreeNode(fileName));
            }
            found[0].Tag = new AddFileInfo(info.SourceFilePath, DirectoryDefinitions.RootFolder + "\\" + fileName);
            rootNode.Nodes.Add(found[0]);
        }

        public List<AddFileInfo> Fetch()
        {
            return this.treeViewFile.Nodes[0].Nodes.Select(s => s.Tag as AddFileInfo);
        }

        public void Clear()
        {
            this.treeViewFile.Nodes[0].Nodes.Clear();
        }

        public void Update(AddFileInfo info, TreeNode control)
        {
            var tag = control.Tag as AddFileInfo;
            control.Tag = info;
            control.Text = System.IO.Path.GetFileName(info.SourceFilePath);
        }
        #endregion

        private void treeViewFile_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            var node = this.treeViewFile.GetNodeAt(e.Location);
            if (node != null && node.Level == 1)
            {
                buttonEdit.PerformClick();
            }
        }
    }
}
