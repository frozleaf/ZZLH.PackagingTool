﻿using System;
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
    public partial class OptionControl : UserControl,IControlRenderer<OptionInfo>
    {
        public OptionControl()
        {
            InitializeComponent();
            this.textBoxRandomBytes.SetWatermark("请输入随机字节序列");
        }

        public void Render(OptionInfo info)
        {
            if (info == null)
                return;
            this.checkBoxCompressFile.Checked = info.IsCompressFile;
            this.checkBoxCreateRandomBytes.Checked = info.IsCreateRandomBytes;
            this.textBoxRandomBytes.Visible = !this.checkBoxCreateRandomBytes.Checked;
            this.textBoxRandomBytes.Text = info.RandomBytes == null ? "" : info.RandomBytes.ToHexString(true);
        }

        public OptionInfo Fetch()
        {
            var info = new OptionInfo();
            info.IsCompressFile = this.checkBoxCompressFile.Checked;
            info.IsCreateRandomBytes = this.checkBoxCreateRandomBytes.Checked;
            info.RandomBytes = this.textBoxRandomBytes.Text.ToHexArray();
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

        private void checkBoxCreateRandomBytes_CheckedChanged(object sender, EventArgs e)
        {
            this.textBoxRandomBytes.Visible = !this.checkBoxCreateRandomBytes.Checked;
        }
    }
}
