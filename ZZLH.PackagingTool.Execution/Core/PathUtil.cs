using System;

namespace ZZLH.PackagingTool.Execution.Core
{
    /// <summary>
    /// 路径工具类
    /// </summary>
    internal class PathUtil
    {
        /// <summary>
        /// 设置工作目录
        /// </summary>
        public static void SetWorkDirectory(string dir)
        {
            System.Environment.CurrentDirectory = dir;
        }

        /// <summary>
        /// 更改文件名
        /// </summary>
        /// <param name="fullPath">文件全路径</param>
        /// <param name="selector"></param>
        /// <returns>返回新文件路径</returns>
        public static string ChangeFileName(string fullPath, Func<string,string> selector)
        {
            string dir = System.IO.Path.GetDirectoryName(fullPath);
            string fileExtension = System.IO.Path.GetExtension(fullPath);
            string fileNameOld = System.IO.Path.GetFileNameWithoutExtension(fullPath);
            string fileNameNew = selector(fileNameOld);
            return System.IO.Path.Combine(dir, fileNameNew + fileExtension);
        }

        /// <summary>
        /// 更改文件扩展名
        /// </summary>
        /// <param name="fullPath">文件全路径</param>
        /// <param name="newExtension">新扩展名，如：.exe</param>
        /// <returns>返回新文件路径</returns>
        public static string ChangeExtension(string fullPath, string newExtension)
        {
            string dir = System.IO.Path.GetDirectoryName(fullPath);
            string fileName = System.IO.Path.GetFileNameWithoutExtension(fullPath);
            return System.IO.Path.Combine(dir, fileName + newExtension);
        }

        #region 程序入口点路径

        /// <summary>
        /// 获取入口点程序集名
        /// <para>例如：TDLib.Test</para>
        /// </summary>
        /// <returns></returns>
        public static string GetEntryAssemblyName()
        {
            return System.Reflection.Assembly.GetEntryAssembly().GetName().Name;
        }

        /// <summary>
        /// 获取入口点程序文件名
        /// <para>例如：TDLib.Test.exe</para>
        /// </summary>
        /// <returns></returns>
        public static string GetEntryFileName()
        {
            return System.Reflection.Assembly.GetEntryAssembly().ManifestModule.ToString();
        }

        /// <summary>
        /// 获取入口点程序所在路径
        /// </summary>
        /// <returns></returns>
        public static string GetEntryFileDir()
        {
            return System.IO.Path.GetDirectoryName(GetEntryFilePath());
        }

        /// <summary>
        /// 获取入口点程序路径
        /// </summary>
        /// <returns></returns>
        public static string GetEntryFilePath()
        {
            return System.Reflection.Assembly.GetEntryAssembly().Location;
        }

        /// <summary>
        /// 将文件拷贝到指定文件夹，文件名保持不变
        /// </summary>
        /// <param name="sourceFile"></param>
        /// <param name="dstFolder"></param>
        /// <returns>返回目标文件路径</returns>
        public static string CopyToFolder(string sourceFile, string dstFolder)
        {
            string newFileName = System.IO.Path.GetFileName(sourceFile);
            return CopyToFolder(sourceFile, dstFolder, newFileName);
        }

        /// <summary>
        /// 将文件拷贝到指定文件夹
        /// </summary>
        /// <param name="sourceFile"></param>
        /// <param name="dstFolder"></param>
        /// <param name="newFileName"></param>
        /// <returns>返回目标文件路径</returns>
        public static string CopyToFolder(string sourceFile, string dstFolder, string newFileName)
        {
            string dstFile = System.IO.Path.Combine(dstFolder, newFileName);
            System.IO.File.Copy(sourceFile, dstFile, true);
            return dstFile;
        }
        #endregion

        #region 临时文件夹

        /// <summary>
        /// 获取随机文件名，无扩展名
        /// </summary>
        /// <returns></returns>
        public static string GetRandomName()
        {
            return GetRandomName("");
        }

        /// <summary>
        /// 获取随机文件名，可设置扩展名，扩展名如：.exe
        /// </summary>
        /// <param name="extension"></param>
        /// <returns></returns>
        public static string GetRandomName(string extension)
        {
            return Guid.NewGuid().ToString() + extension;
        }

        /// <summary>
        /// 生成带临时文件路径的随机文件名
        /// </summary>
        /// <param name="extension"></param>
        /// <returns></returns>
        public static string GetTempRandomFile(string extension)
        {
            return GetTempFolder() + "\\" + GetRandomName(extension);
        }

        /// <summary>
        /// 生成带临时文件路径的随机目录
        /// </summary>
        /// <returns></returns>
        public static string GetTempRandomFolder()
        {
            return GetTempRandomFolder(false);
        }

        /// <summary>
        /// 生成带临时文件路径的随机目录
        /// </summary>
        /// <param name="isAutoCreate">是否自动创建目录</param>
        /// <returns></returns>
        public static string GetTempRandomFolder(bool isAutoCreate)
        {
            string dir = GetTempFolder() + "\\" + GetRandomName("");
            if (isAutoCreate)
            {
                if (!System.IO.Directory.Exists(dir))
                {
                    System.IO.Directory.CreateDirectory(dir);
                }
            }
            return dir;
        }

        /// <summary>
        /// 获取临时文件夹
        /// <para>如：C:\Users\Administrator\AppData\Local\Temp</para>
        /// </summary>
        /// <returns></returns>
        public static string GetTempFolder()
        {
            return Environment.GetEnvironmentVariable("temp");
        }
        #endregion

        #region Program Files文件夹

        /// <summary>
        /// 获取Program Files文件夹
        /// <para>如：C:\Program Files</para>
        /// </summary>
        /// <returns></returns>
        public static string GetProgramFilesFolder()
        {
            return GetCurSystemDrive() + "\\Program Files";
        }

        /// <summary>
        /// 获取Program Files (x86)文件夹
        /// <para>如：C:\Program Files (x86)</para>
        /// </summary>
        /// <returns></returns>
        public static string GetProgramFiles86Folder()
        {
            return GetCurSystemDrive() + "\\Program Files (x86)";
        }

        #endregion

        #region 常用系统目录
        /// <summary>
        /// 获取AppData文件夹
        /// <para>如：C:\Users\Administrator\AppData\Roaming</para>
        /// </summary>
        /// <returns></returns>
        public static string GetAppDataFolder()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        }

        /// <summary>
        /// 获取LocalAppData文件夹
        /// <para>如：C:\Users\Administrator\AppData\Local</para>
        /// </summary>
        /// <returns></returns>
        public static string GetLocalAppDataFolder()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        }

        /// <summary>
        /// 获取发送到文件夹
        /// <para>如：C:\Users\Administrator\AppData\Roaming\Microsoft\Windows</para>
        /// </summary>
        /// <returns></returns>
        public static string GetSendToFolder()
        {
            return GetAppDataFolder() + @"\Microsoft\Windows\SendTo";
        }

        /// <summary>
        /// 获取桌面路径
        /// <para>如：C:\Users\Administrator\Desktop</para>
        /// </summary>
        /// <returns></returns>
        public static string GetDesktopFolder()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        }

        /// <summary>
        /// 获取当前用户文件夹
        /// <para>如：C:\Users\Administrator</para>
        /// </summary>
        /// <returns></returns>
        public static string GetCurUserFolder()
        {
            return Environment.GetEnvironmentVariable("userprofile");
        }

        /// <summary>
        /// 获取当前系统所在盘符
        /// <para>如：C:</para>
        /// </summary>
        /// <returns></returns>
        public static string GetCurSystemDrive()
        {
            return Environment.GetEnvironmentVariable("systemdrive");
        }

        /// <summary>
        /// 获取当前系统目录
        /// <para>C:\Windows</para>
        /// </summary>
        /// <returns></returns>
        public static string GetCurSystemDir()
        {
            return Environment.GetEnvironmentVariable("windir");
        }
        
        #endregion
    }
}
