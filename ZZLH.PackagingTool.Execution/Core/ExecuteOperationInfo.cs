using System;

namespace ZZLH.PackagingTool.Execution.Core
{
    /// <summary>
    /// 操作信息
    /// </summary>
    [Serializable]
    public class ExecuteOperationInfo
    {
        /// <summary>
        /// 执行文件路径
        /// </summary>
        public string FilePath;
        /// <summary>
        /// 执行参数
        /// </summary>
        public string FileArgument;

        public ExecuteOperationInfo(string path, string arg)
        {
            this.FilePath = path;
            this.FileArgument = arg;
        }
    }
}
