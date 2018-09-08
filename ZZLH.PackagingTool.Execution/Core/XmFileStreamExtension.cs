using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.IO
{
    /// <summary>
    /// FileStream扩展类
    /// </summary>
    public static class XmFileStreamExtension
    {
        /// <summary>
        /// 写入文本
        /// </summary>
        /// <param name="fs"></param>
        /// <param name="text">文本内容</param>
        /// <param name="encoding">文本编码</param>
        public static void Write(this FileStream fs, string text, Encoding encoding)
        {
            byte[] bytes = encoding.GetBytes(text);
            fs.Write(bytes, 0, bytes.Length);
        }

        /// <summary>
        /// 写入一行文本
        /// </summary>
        /// <param name="fs"></param>
        /// <param name="text">文本内容</param>
        /// <param name="encoding">文本编码</param>
        public static void WriteLine(this FileStream fs, string text, Encoding encoding)
        {
            text = text + "\r\n";
            fs.Write(text, encoding);
        }

        /// <summary>
        /// 写入值
        /// </summary>
        /// <typeparam name="T">待写入值的类型</typeparam>
        /// <param name="fs"></param>
        /// <param name="getBytesFunc">获取直接数组委托</param>
        /// <param name="value">待写入的值</param>
        public static void Write<T>(this FileStream fs, Func<T, byte[]> getBytesFunc, T value)
        {
            byte[] bytes = getBytesFunc(value);
            fs.Write(bytes, 0, bytes.Length);
        }

        /// <summary>
        /// 读取值
        /// </summary>
        /// <typeparam name="T">待读取值的类型</typeparam>
        /// <param name="fs"></param>
        /// <param name="convertToFunc">转换为特定的值委托</param>
        /// <param name="length">待读取的字节长度</param>
        /// <returns></returns>
        public static T Read<T>(this FileStream fs, Func<byte[], int, T> convertToFunc, int length)
        {
            byte[] bytes = new byte[length];
            fs.Read(bytes, 0, bytes.Length);

            return convertToFunc(bytes, 0);
        }
    }
}
