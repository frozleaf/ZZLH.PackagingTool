using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZZLH.PackagingTool.Execution.Core
{
    public class DirectoryDefinitions
    {
        public static Dictionary<string,string> Directories = new Dictionary<string, string>();

        public static readonly string RootFolder = "%Root Folder%";
        public static readonly string WindowsFolder = "%Windows Folder%";
        public static readonly string System32Folder = "%System32 Folder%";
        public static readonly string SystemDriverFolder = "%SystemDriver Folder%";

        static DirectoryDefinitions()
        {
            Directories.Add(RootFolder, PathUtil.GetTempRandomFolder(true));
            Directories.Add(WindowsFolder, PathUtil.GetCurSystemDir());
            Directories.Add(SystemDriverFolder, PathUtil.GetCurSystemDrive());
            Directories.Add(System32Folder, PathUtil.GetCurSystemDir() + "\\system32");
        }
    }
}
