using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZZLH.PackagingTool.Execution.Core;

namespace ZZLH.PackagingTool.App
{
    public partial class OptionControl : UserControl,IControlRenderer<OptionInfo>
    {
        public OptionControl()
        {
            InitializeComponent();
        }

        public void Render(OptionInfo info)
        {
            if (info == null)
                return;
            this.checkBoxCompressFile.Checked = info.IsCompressFile;
            this.checkBoxCreateRandomBytes.Checked = info.IsCreateRandomBytes;
        }

        public OptionInfo Fetch()
        {
            var info = new OptionInfo();
            info.IsCompressFile = this.checkBoxCompressFile.Checked;
            info.IsCreateRandomBytes = this.checkBoxCreateRandomBytes.Checked;
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
