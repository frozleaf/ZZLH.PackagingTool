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
        /// <para>如果创建随机序列，则随机生成RandomBytes数组；否则根据RandomBytes进行写入。</para>
        /// </summary>
        public bool IsCreateRandomBytes;
        /// <summary>
        /// 随机序列
        /// </summary>
        public byte[] RandomBytes;
    }
}
