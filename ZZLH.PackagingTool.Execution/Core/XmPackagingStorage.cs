using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Runtime.Serialization.Formatters.Binary;

namespace ZZLH.PackagingTool.Execution.Core
{
    public class XmPackagingStorage
    {
        public void SaveProject(PackagingInfo info, string outputFilePath)
        {
            // 删除已存在的目标文件
            if (System.IO.File.Exists(outputFilePath))
                System.IO.File.Delete(outputFilePath);
            using (var outputStream = System.IO.File.OpenWrite(outputFilePath))
            {
                // 封装基本信息
                WriteBaseInfo(outputStream, info);
            }
        }

        public PackagingInfo OpenProject(string projFilePath)
        {
            using (var fs = System.IO.File.OpenRead(projFilePath))
            {
                // 读取基本信息
                return ReadBaseInfo(fs,false);
            }
        }

        public void Pack(PackagingInfo info, string outputFilePath)
        {
            // 创建额外数据块
            string extraDataFile = PathUtil.GetTempRandomFile(".tmp");
            using (var outputStream = System.IO.File.OpenWrite(extraDataFile))
            {
                // 封装基本信息
                WriteBaseInfo(outputStream,info);
                using (var writer = new BinaryWriter(outputStream))
                {
                    // 封装文件
                    WriteFile(writer, info.Option, info.Files);
                    // 写入随机序列
                    WriteRandomBytes(writer,info.Option);
                }
            }
            // 删除已存在的目标文件
            if (System.IO.File.Exists(outputFilePath))
                System.IO.File.Delete(outputFilePath);
            // 生成文件
            string templeteFile = PathUtil.GetEntryFileDir() + "\\ZZLH.PackagingTool.Execution.exe";
            using (var fs = System.IO.File.OpenWrite(outputFilePath))
            {
                // 写入模板数据
                long extraDataPos = CopyTo(templeteFile, fs);
                // 写入额外数据
                CopyTo(extraDataFile,fs);
                // 写入额外数据开始位置
                fs.Write(BitConverter.GetBytes,extraDataPos);
            }
        }

        public PackagingInfo UnPack(string file)
        {
            PackagingInfo info = null;
            
            using (var fs = System.IO.File.OpenRead(file))
            {
                // 读取额外数据块的开始位置
                fs.Seek(fs.Length - 8, SeekOrigin.Begin);
                long extraDataPos = fs.Read(BitConverter.ToInt64, 8);
                fs.Seek(extraDataPos, SeekOrigin.Begin);
                // 读取基本信息
                info = ReadBaseInfo(fs,true);
                using (var br = new BinaryReader(fs))
                {
                    // 读取文件
                    ReadFile(br, info.Option, info.Files);
                    // 读取随机字节序列
                    ReadRandomBytes(br, info.Option);
                }
            }

            return info;
        }

        public void UnPackAndExecute(string file)
        {
            var info = UnPack(file);
            for (int i = 0; i < info.Operations.Count; i++)
            {
                var ope = info.Operations[i];
                Process.Start(ope.FilePath, ope.FileArgument).WaitForExit();
            }
        }

        private PackagingInfo ReadBaseInfo(Stream stream, bool isReplaceToRealPath)
        {
            BinaryFormatter bf = new BinaryFormatter();
            var info = bf.Deserialize(stream) as PackagingInfo;

            if (isReplaceToRealPath)
            {
                for (int i = 0; i < info.Files.Count; i++)
                {
                    var file = info.Files[i];
                    file.OuputFilePath = GetRealFilePath(file.OuputFilePath);
                }
                for (int i = 0; i < info.Operations.Count; i++)
                {
                    var ope = info.Operations[i];
                    ope.FilePath = GetRealFilePath(ope.FilePath);
                } 
            }

            return info;
        }

        private void ReadFile(BinaryReader reader, OptionInfo optionData, List<AddFileInfo> addFileData)
        {
            int fileCount = reader.ReadInt32();
            if (addFileData.Count != fileCount)
            {
                throw new Exception("程序被篡改");
            }
            for (int i = 0; i < fileCount; i++)
            {
                var fileInfo = addFileData[i];
                var fileLen = reader.ReadInt32();
                var fileBytes = new byte[fileLen];
                reader.Read(fileBytes, 0, fileBytes.Length);
                if (optionData.IsCompressFile)
                {
                    fileBytes = Decompress(new MemoryStream(fileBytes));
                }
                System.IO.File.WriteAllBytes(fileInfo.OuputFilePath, fileBytes);
            }
        }

        private string GetRealFilePath(string filePath)
        {
            foreach (var pair in DirectoryDefinitions.Directories)
            {
                filePath = filePath.Replace(pair.Key, pair.Value);
            }

            return filePath;
        }

        private byte[] ReadRandomBytes(BinaryReader reader, OptionInfo optionData)
        {
            int byteCount = reader.ReadInt32();
            return reader.ReadBytes(byteCount);
        }

        private void WriteBaseInfo(Stream stream, PackagingInfo info)
        {
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(stream, info);
        }

        private void WriteFile(BinaryWriter writer, OptionInfo optionData, List<AddFileInfo> addFileData)
        {
            // 封装文件个数
            writer.Write(addFileData.Count);
            // 封装每个文件
            for (int i = 0; i < addFileData.Count; i++)
            {
                var file = addFileData[i];
                byte[] fileData = null;
                if (optionData.IsCompressFile)
                {
                    // 压缩文件
                    using (var fs = System.IO.File.OpenRead(file.SourceFilePath))
                    {
                        fileData = CompressFile(fs);
                    }
                }
                else
                {
                    // 不压缩文件
                    fileData = System.IO.File.ReadAllBytes(file.SourceFilePath);
                }
                writer.Write(fileData.Length);
                writer.Write(fileData);
            }
        }

        private void WriteRandomBytes(BinaryWriter writer, OptionInfo optionData)
        {
            byte[] randomBytes = optionData.RandomBytes;
            if (optionData.IsCreateRandomBytes)
            {
                // 创建随机序列
                Random r = new Random((int)DateTime.Now.Ticks);
                int byteCount = r.Next(5, 10); // 随机序列长度
                randomBytes = new byte[byteCount];
                for (int i = 0; i < randomBytes.Length; i++)
                {
                    randomBytes[i] = (byte)r.Next(0, 255);
                } 
            }
            else
            {
                // 不创建随机序列
                if (randomBytes == null)
                {
                    randomBytes = new byte[0];
                }
            }
            writer.Write(randomBytes.Length);
            writer.Write(randomBytes, 0, randomBytes.Length);
        }

        private byte[] CompressFile(Stream input)
        {
            input.Position = 0L;
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (var deflateStream = new DeflateStream(memoryStream, CompressionMode.Compress))
                {
                    CopyTo(input, deflateStream);
                }
                // 注意：
                // 压缩流关闭之前，执行memoryStream.ToArray()，则数据会缺失
                byte[] bytes = memoryStream.ToArray();
                // 由于源memoryStream流，被压缩流修改为了不可读，所以重新创建一个流
                return bytes;
            }
        }

        private byte[] Decompress(Stream input)
        {
            using (var deflateStream = new DeflateStream(input, CompressionMode.Decompress))
            {
                MemoryStream memoryStream = new MemoryStream();
                CopyTo(deflateStream, memoryStream);
                memoryStream.Position = 0L;
                return memoryStream.ToArray();
            }
        }

        private long CopyTo(string sourceFile, Stream destination)
        {
            using (var input = System.IO.File.OpenRead(sourceFile))
            {
                return CopyTo(input,destination);
            }
        }

        private long CopyTo(Stream source, Stream destination)
        {
            long length = 0;
            byte[] array = new byte[81920];
            int count;
            while ((count = source.Read(array, 0, array.Length)) != 0)
            {
                destination.Write(array, 0, count);
                length += count;
            }

            return length;
        }
    }
}
