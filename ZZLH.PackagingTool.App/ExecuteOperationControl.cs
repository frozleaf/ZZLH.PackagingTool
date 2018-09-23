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
    public partial class ExecuteOperationControl : UserControl,IControlCollectionRenderer<ExecuteOperationInfo, ListViewItem>
    {
        public ExecuteOperationControl()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            this.contextMenuStrip1.ShowBelow(this.buttonAdd);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count == 0)
            {
                this.buttonEdit.Enabled = false;
                this.buttonRemove.Enabled = false;
            }
            else
            {
                this.buttonEdit.Enabled = true;
                this.buttonRemove.Enabled = true;
                var item = this.listView1.SelectedItems[0];
                if (item.Index == 0)
                {
                    this.buttonMoveUp.Enabled = false;
                    this.buttonMoveDown.Enabled = true;
                }
                else if (item.Index == this.listView1.Items.Count - 1)
                {
                    this.buttonMoveUp.Enabled = true;
                    this.buttonMoveDown.Enabled = false;
                }
                else
                {
                    this.buttonMoveUp.Enabled = true;
                    this.buttonMoveDown.Enabled = true;
                }
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            var info = this.listView1.SelectedItems[0].Tag as ExecuteOperationInfo;
            var frm = new FrmEditOperation();
            frm.Render(info);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var data = frm.Fetch();
                Update(data, this.listView1.SelectedItems[0]);
            }
        }

        #region 接口实现
        public void Render(IEnumerable<ExecuteOperationInfo> list)
        {
            this.listView1.Items.Clear();
            if (list == null)
                return;
            foreach (var info in list)
            {
                Add(info);
            }
        }

        public void Add(ExecuteOperationInfo info)
        {
            var item = this.listView1.Items.Add(new ListViewItem(new string[] { info.FilePath, info.FileArgument }));
            item.Tag = info;
        }

        public List<ExecuteOperationInfo> Fetch()
        {
            var list = new List<ExecuteOperationInfo>();
            for (int i = 0; i < this.listView1.Items.Count; i++)
            {
                list.Add(this.listView1.Items[i].Tag as ExecuteOperationInfo);
            }

            return list;
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public void Update(ExecuteOperationInfo info, ListViewItem control)
        {
            control.Tag = info;
            control.SubItems[0].Text = info.FilePath;
            control.SubItems[1].Text = info.FileArgument;
        }
        #endregion

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            this.toolStripMenuItemSelectProjFile.DropDownItems.Clear();
            if (GlobalContext.Project.Files != null)
            {
                foreach (var file in GlobalContext.Project.Files)
                {
                    this.toolStripMenuItemSelectProjFile.DropDownItems.Add(file.OuputFilePath, null, (ss, ee) =>
                    {
                        Add(new ExecuteOperationInfo(file.OuputFilePath, ""));
                    });
                }
            }
            this.toolStripMenuItemInsertVar.DropDownItems.Clear();
            foreach (var pair in DirectoryDefinitions.Directories)
            {
                this.toolStripMenuItemInsertVar.DropDownItems.Add(pair.Key, null, (ss, ee) =>
                {
                    Add(new ExecuteOperationInfo(pair.Key, ""));
                });
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count != 0)
            {
                for (int i = this.listView1.SelectedItems.Count - 1; i >= 0; i--)
                {
                    this.listView1.SelectedItems[i].Remove();
                }
            }
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            var item = this.listView1.GetItemAt(e.Location);
            if (item != null)
            {
                item.Selected = true;
                buttonEdit.PerformClick();
            }
        }

        private void toolStripMenuItemMsiExec_Click(object sender, EventArgs e)
        {
            Add(new ExecuteOperationInfo(DirectoryDefinitions.System32Folder + "\\msiexec.exe", "/quiet /qn /uninstall "));
        }

        private void buttonMoveUp_Click(object sender, EventArgs e)
        {
            if (this.listView1.IsSingleItemSelected() == false)
                return;

            this.listView1.GetSelectedItem().MoveUp();
        }

        private void buttonMoveDown_Click(object sender, EventArgs e)
        {
            if (this.listView1.IsSingleItemSelected() == false)
                return;

            this.listView1.GetSelectedItem().MoveDown();
        }
    }
}
