using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ZZLH.PackagingTool.Execution.Core;
using ZZLH.Utils;

namespace ZZLH.PackagingTool.App.Cmd
{
    class Program
    {
        static void Main(string[] args)
        {
            // -outputfile d:\setup.exe
            // -addfile d:\1.exe 
            // -opefile1 "%System32 Folder%\msiexec.exe" -opearg1 "/quiet /qn /uninstall "+productCode
            // -opefile2 "%Root Folder%\1.exe" -opearg2 /qn
            // -compress true
            // -genrandombytes true
            //foreach (var s in args)
            //{
            //    Console.WriteLine(s);
            //}
            //Console.ReadLine();
            try
            {
                PackagingInfo p = new PackagingInfo();
                string outputFile = CommandLineParser.GetArgumentValue(args, "outputfile", "");
                string addFile = CommandLineParser.GetArgumentValue(args, "addfile", "");
                string addFileName = Path.GetFileName(addFile);
                p.Files = new List<AddFileInfo>();
                p.Files.Add(new AddFileInfo(addFile, "%Root Folder%\\" + addFileName));
                p.Operations = new List<ExecuteOperationInfo>();
                for (int i = 0; i < 10; i++)
                {
                    string opeFile = CommandLineParser.GetArgumentValue(args, "opefile" + (i + 1), null);
                    string opeArg = CommandLineParser.GetArgumentValue(args, "opearg" + (i + 1), "");
                    if (opeFile == null)
                        break;
                    p.Operations.Add(new ExecuteOperationInfo(opeFile, opeArg));
                }
                p.Option = new OptionInfo();
                p.Option.IsCompressFile = CommandLineParser.GetArgumentValue(args, "compress", "true").ToLower() == "true";
                p.Option.IsCreateRandomBytes =
                    CommandLineParser.GetArgumentValue(args, "genrandombytes", "true").ToLower() == "true";
                var storage = new XmPackagingStorage();
                storage.Pack(p, outputFile);
                Console.WriteLine("封包成功！");
            }
            catch (Exception ex)
            {
                Console.WriteLine("封包异常：" + ex.Message);
            }
        }
    }
}
