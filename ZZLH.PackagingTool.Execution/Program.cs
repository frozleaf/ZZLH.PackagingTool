using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZZLH.PackagingTool.Execution.Core;

namespace ZZLH.PackagingTool.Execution
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var packaging = new XmPackagingStorage();
                var output = PathUtil.GetEntryFilePath();
                packaging.UnPackAndExecute(output);
            }
            catch (Exception ex)
            {
                Environment.Exit(-1);
            }
        }
    }
}
