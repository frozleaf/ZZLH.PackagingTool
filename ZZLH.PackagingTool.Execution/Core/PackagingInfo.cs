using System;
using System.Collections.Generic;

namespace ZZLH.PackagingTool.Execution.Core
{
    /// <summary>
    /// 封包信息
    /// </summary>
    [Serializable]
    public class PackagingInfo
    {
        /// <summary>
        /// 封包的文件列表
        /// </summary>
        public List<AddFileInfo> Files;
        /// <summary>
        /// 封包的操作列表
        /// </summary>
        public List<ExecuteOperationInfo> Operations;
        /// <summary>
        /// 封包选项信息
        /// </summary>
        public OptionInfo Option;
    }
}
