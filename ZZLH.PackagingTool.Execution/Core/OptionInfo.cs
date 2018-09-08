using System;

namespace ZZLH.PackagingTool.Execution.Core
{
    /// <summary>
    /// 选项信息
    /// </summary>
    [Serializable]
    public class OptionInfo
    {
        /// <summary>
        /// 是否压缩文件
        /// </summary>
        public bool IsCompressFile;
        /// <summary>
        /// 是否静默执行
        /// </summary>
        public bool IsSilentExecute;
        /// <summary>
        /// 是否创建随机序列
        /// </summary>
        public bool IsCreateRandomBytes;
    }
}
