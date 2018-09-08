using System;

namespace ZZLH.PackagingTool.Execution.Core
{
    /// <summary>
    /// 添加文件信息
    /// </summary>
    [Serializable]
    public class AddFileInfo
    {
        /// <summary>
        /// 源文件路径
        /// </summary>
        public string SourceFilePath;
        /// <summary>
        /// 输出文件路径
        /// </summary>
        public string OuputFilePath;

        public AddFileInfo(string source,string output)
        {
            this.SourceFilePath = source;
            this.OuputFilePath = output;
        }
    }
}
