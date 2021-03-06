﻿using System;
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
            // -type pack
            // -packcount 1
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

            string type = CommandLineParser.GetArgumentValue(args, "type", "");
            if (type.Equals("pack"))
            {
                int packCount = Convert.ToInt32(CommandLineParser.GetArgumentValue(args, "packcount", "1"));
                for (int i = 0; i < packCount; i++)
                {
                    Console.WriteLine("第" + (i + 1) + "次封包");
                    string outputFile = CommandLineParser.GetArgumentValue(args, "outputfile", "");
                    if (packCount != 1)
                    {
                        outputFile = PathUtil.ChangeFileName(outputFile, (name) => name + i.ToString().PadLeft(3, '0'));
                    }
                    try
                    {
                        Pack(args, outputFile);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("第" + (i + 1) + "次封包失败，" + ex.Message);
                    }
                }
                Console.WriteLine("全部封包完成！");
            }
            else if (type.Equals("unpack"))
            {
                Unpack(args);
            }
            else
            {
                Console.WriteLine("-type无效");
            }
        }

        static void Pack(string[] args, string outputFile)
        {
            PackagingInfo p = new PackagingInfo();
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
            p.Option.RandomBytes = CommandLineParser.GetArgumentValue(args, "randombytes", "").ToHexArray();
            var storage = new XmPackagingStorage();
            storage.Pack(p, outputFile);
        }

        static void Unpack(string[] args)
        {
            // -type unpack
            // -file d:\1.exe
            string file = CommandLineParser.GetArgumentValue(args, "file", "");
            try
            {
                Console.WriteLine("正在解包...");
                var storage = new XmPackagingStorage();
                var info = storage.UnPack(file);
                if (info.Files.Count == 0)
                {
                    Console.WriteLine("没有封装任何文件");
                }
                else
                {
                    string dir = Path.GetDirectoryName(info.Files[0].OuputFilePath);
                    CommonUtil.OpenInExplorer(dir);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("解包失败，" + ex);
            }
        }
    }
}
