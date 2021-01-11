﻿// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Wolf.Systems.Core.Common.Systems;
using Wolf.Systems.Core.Internal.Common;

namespace Wolf.Systems.Core.Common
{
    /// <summary>
    /// 文件帮助类
    /// </summary>
    public class FileCommon
    {
        #region 得到文件md5

        /// <summary>
        /// 根据本地文件地址得到文件md5
        /// </summary>
        /// <param name="localFilePath">文件绝对地址</param>
        /// <param name="isUpper">是否转大写,默认：true</param>
        /// <returns></returns>
        public static string GetMd5(string localFilePath, bool isUpper = true)
        {
            //检查文件是否存在，如果文件存在则进行计算，否则返回空值
            if (File.Exists(localFilePath))
            {
                using (FileStream fileStream =
                    new FileStream(localFilePath, FileMode.Open, FileAccess.Read))
                {
                    return SecurityCommon.GetMd5Hash(fileStream, isUpper);
                }
            }

            return String.Empty;
        }

        #endregion

        #region 得到文件的Sha1

        /// <summary>
        /// 根据本地文件地址得到文件的Sha1
        /// </summary>
        /// <param name="localFilePath">文件绝对地址</param>
        /// <returns></returns>
        public static string GetSha1(string localFilePath)
        {
            if (!File.Exists(localFilePath))
            {
                return string.Empty;
            }

            using (FileStream fileStream =
                new FileStream(localFilePath, FileMode.Open, FileAccess.Read))
            {
                return fileStream.GetSha(new SHA1CryptoServiceProvider());
            }
        }

        #endregion

        #region 得到文件的Sha256

        /// <summary>
        /// 根据本地文件地址得到文件的Sha256
        /// </summary>
        /// <param name="localFilePath">文件绝对地址</param>
        /// <returns></returns>
        public static string GetSha256(string localFilePath)
        {
            if (!File.Exists(localFilePath))
            {
                return string.Empty;
            }

            using (FileStream fileStream =
                new FileStream(localFilePath, FileMode.Open, FileAccess.Read))
            {
                return fileStream.GetSha(new SHA256CryptoServiceProvider());
            }
        }

        #endregion

        #region 得到文件的Sha384

        /// <summary>
        /// 根据本地文件地址得到文件的Sha384
        /// </summary>
        /// <param name="localFilePath">文件绝对地址</param>
        /// <returns></returns>
        public static string GetSha384(string localFilePath)
        {
            if (!File.Exists(localFilePath))
            {
                return string.Empty;
            }

            using (FileStream fileStream =
                new FileStream(localFilePath, FileMode.Open, FileAccess.Read))
            {
                return fileStream.GetSha(new SHA384CryptoServiceProvider());
            }
        }

        #endregion

        #region 得到文件的Sha512

        /// <summary>
        /// 根据本地文件地址得到文件的Sha512
        /// </summary>
        /// <param name="localFilePath">文件绝对地址</param>
        /// <returns></returns>
        public static string GetSha512(string localFilePath)
        {
            if (!File.Exists(localFilePath))
            {
                return string.Empty;
            }

            using (FileStream fileStream =
                new FileStream(localFilePath, FileMode.Open, FileAccess.Read))
            {
                return fileStream.GetSha(new SHA512CryptoServiceProvider());
            }
        }

        #endregion

        #region 将文件转换成Base64格式

        /// <summary>
        /// 将文件转换成Base64格式
        /// </summary>
        /// <param name="filePath">本地文件绝对地址</param>
        /// <returns></returns>
        public static string FileToBase64(string filePath)
        {
            return FileToBase64Async(filePath, true).Result;
        }

        /// <summary>
        /// 将文件转换成Base64格式
        /// </summary>
        /// <param name="filePath">本地文件绝对地址</param>
        /// <returns></returns>
        public static async Task<string> FileToBase64Async(string filePath)
        {
            return await FileToBase64Async(filePath, false);
        }

        /// <summary>
        /// 将文件转换成Base64格式
        /// </summary>
        /// <param name="filePath">本地文件绝对地址</param>
        /// <param name="isSync">是否同步</param>
        /// <returns></returns>
        private static async Task<string> FileToBase64Async(string filePath, bool isSync)
        {
            string result;
            try
            {
                if (!File.Exists(filePath))
                    return String.Empty;
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    if (isSync)
                    {
                        return fs.ConvertToBase64();
                    }

                    return await fs.ConvertToBase64Async();
                }
            }
            catch
            {
                result = string.Empty;
            }

            return result;
        }

        #endregion

        #region 将文件转换为byte数组

        #region 将文件转换成byte[]数组

        /// <summary>
        /// 将文件转换成byte[]数组
        /// </summary>
        /// <param name="filePath">本地文件绝对地址</param>
        /// <returns>byte[]数组</returns>
        public static byte[] ConvertFileToByte(string filePath)
        {
            return ConvertFileToByte(filePath, true).Result;
        }

        /// <summary>
        /// 将文件转换成byte[]数组
        /// </summary>
        /// <param name="filePath">本地文件绝对地址</param>
        /// <returns>byte[]数组</returns>
        public static async Task<byte[]> ConvertFileToByteAsync(string filePath)
        {
            return await ConvertFileToByte(filePath, false);
        }

        /// <summary>
        /// 将文件转换成byte[]数组
        /// </summary>
        /// <param name="filePath">本地文件绝对地址</param>
        /// <param name="isSync">是否同步</param>
        /// <returns>byte[]数组</returns>
        private static async Task<byte[]> ConvertFileToByte(string filePath, bool isSync)
        {
            try
            {
                if (!File.Exists(filePath))
                    return new byte[] { };
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    byte[] byteArray = new byte[fs.Length];
                    if (isSync)
                    {
                        fs.Read(byteArray, 0, byteArray.Length);
                    }
                    else
                    {
                        await fs.ReadAsync(byteArray, 0, byteArray.Length);
                    }

                    return byteArray;
                }
            }
            catch
            {
                return null;
            }
        }

        #endregion

        #endregion

        #region 将Csv读入DataTable

        /// <summary>
        /// 将Csv读入DataTable
        /// </summary>
        /// <param name="filePath">csv文件路径</param>
        /// <param name="n">表示第n行是字段title,第n+1行是记录开始</param>
        /// <param name="dataTable"></param>
        /// <param name="encoding">编码格式，默认Utf-8</param>
        public static DataTable ConvertCsvToDataTable(string filePath, int n, DataTable dataTable,
            Encoding encoding = null)
        {
            encoding = encoding ?? Encoding.UTF8;
            StreamReader reader = new StreamReader(filePath, encoding, false);
            int i, m = 0;
            reader.Peek();
            while (reader.Peek() > 0)
            {
                m = m + 1;
                string str = reader.ReadLine().SafeString();
                if (m >= n + 1)
                {
                    string[] split = str.Split(',');

                    DataRow dr = dataTable.NewRow();
                    for (i = 0; i < split.Length; i++)
                    {
                        dr[i] = split[i];
                    }

                    dataTable.Rows.Add(dr);
                }
            }

            return dataTable;
        }

        #endregion

        #region 文件

        #region 获取文件内容

        #region 获取文件内容（支持换行读取）

        /// <summary>
        /// 获取文件内容（支持换行读取）
        /// </summary>
        /// <param name="filePath">本地文件绝对地址</param>
        /// <param name="encoding">编码格式,默认为Encoding.Default</param>
        /// <returns></returns>
        public static string GetFileContent(string filePath, Encoding encoding = null)
        {
            return GetFileContent(filePath, true, encoding).Result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="filePath">本地文件绝对地址</param>
        /// <param name="encoding">编码格式,默认为Encoding.Default</param>
        /// <returns></returns>
        public static async Task<string> GetFileContentAsync(string filePath, Encoding encoding = null)
        {
            return await GetFileContent(filePath, false, encoding);
        }

        /// <summary>
        /// 获取文件内容（支持换行读取）
        /// </summary>
        /// <param name="filePath">本地文件绝对地址</param>
        /// <param name="isSync">是否同步</param>
        /// <param name="encoding">编码格式,默认为Encoding.UTF8</param>
        /// <returns></returns>
        private static async Task<string> GetFileContent(string filePath, bool isSync, Encoding encoding = null)
        {
            string result = string.Empty;
            try
            {
                if (!File.Exists(filePath))
                    return result;
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader reader = new StreamReader(fs, encoding ?? Encoding.UTF8))
                    {
                        result = isSync ? reader.ReadToEnd() : await reader.ReadToEndAsync();
                    }
                }
            }
            catch
            {
                result = string.Empty;
            }

            return result;
        }

        #endregion

        #region 获取文件内容（每行读取）

        /// <summary>
        /// 获取文件内容（每行读取）
        /// </summary>
        /// <param name="filePath">本地文件绝对地址</param>
        /// <param name="encoding">编码格式,默认为Encoding.Default</param>
        /// <returns></returns>
        public static List<string> GetContentFormFile(string filePath, Encoding encoding = null)
        {
            return GetFileContentByLine(filePath, true, encoding).Result;
        }

        /// <summary>
        /// 获取文件内容（每行读取）
        /// </summary>
        /// <param name="filePath">本地文件绝对地址</param>
        /// <param name="encoding">编码格式,默认为Encoding.Default</param>
        /// <returns></returns>
        private static async Task<List<string>> GetContenFormFileAsync(string filePath,
            Encoding encoding = null)
        {
            return await GetFileContentByLine(filePath, false, encoding);
        }

        /// <summary>
        /// 获取文件内容（每行读取）
        /// </summary>
        /// <param name="filePath">本地文件绝对地址</param>
        /// <param name="isSync">是否同步</param>
        /// <param name="encoding">编码格式,默认为Encoding.UTF8</param>
        /// <returns></returns>
        private static async Task<List<string>> GetFileContentByLine(string filePath, bool isSync,
            Encoding encoding = null)
        {
            List<string> result = new List<string>();
            try
            {
                if (!File.Exists(filePath))
                    return result;
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader reader = new StreamReader(fs, encoding ?? Encoding.UTF8))
                    {
                        bool isEnd = true;
                        while (isEnd)
                        {
                            var content = isSync ? reader.ReadLine() : await reader.ReadLineAsync();
                            if (content is null)
                            {
                                isEnd = false;
                                continue;
                            }

                            result.Add(content);
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

            return result;
        }

        #endregion

        #endregion

        #region 获取指定目录中的文件列表

        /// <summary>
        /// 得到当前文件夹下的所有文件地址
        /// </summary>
        /// <param name="path">要搜索的目录的相对或绝对路径</param>
        /// <returns></returns>
        public static string[] GetFiles(string path)
        {
            return Directory.GetFiles(path);
        }

        /// <summary>
        /// 根据通配符搜索文件下的所有地址信息，可选择查询所有层级的或者当前层级的
        /// </summary>
        /// <param name="path">要搜索的目录的相对或绝对路径</param>
        /// <param name="searchPattern">要与 path 中的文件名匹配的搜索字符串。此参数可以包含有效文本路径和通配符（* 和 ?）的组合（请参见“备注”），但不支持正则表达式。</param>
        /// <param name="searchOption">默认当前文件夹下 TopDirectoryOnly，若查询包含所有子目录为AllDirectories</param>
        /// <returns></returns>
        public static string[] GetFiles(string path, string searchPattern,
            SearchOption searchOption = SearchOption.TopDirectoryOnly)
        {
            return Directory.GetFiles(path, searchPattern, searchOption);
        }

        #endregion

        #region 检测指定文件是否存在,如果存在返回true

        /// <summary>
        /// 检测指定文件是否存在,如果存在则返回true。
        /// </summary>
        /// <param name="filePath">文件的绝对路径</param>
        public static bool IsExistFile(string filePath)
        {
            return File.Exists(filePath);
        }

        #endregion

        #region 创建文件

        /// <summary>
        /// 创建文件
        /// </summary>
        /// <param name="directory">文件夹</param>
        /// <param name="fileName">带后缀的文件名</param>
        /// <param name="content">文件内容</param>
        public static void CreateFile(string directory, string fileName, string content)
        {
            CreateFile(directory, fileName, content, Encoding.UTF8);
        }

        /// <summary>
        /// 创建文件
        /// </summary>
        /// <param name="directory">文件夹</param>
        /// <param name="fileName">带后缀的文件名</param>
        /// <param name="content">文件内容</param>
        /// <param name="encoding">编码格式，默认格式：UTF8</param>
        public static void CreateFile(string directory, string fileName, string content, Encoding encoding = null)
        {
            encoding = encoding ?? Encoding.UTF8;
            fileName = fileName.Replace("/", "\\");
            if (fileName.IndexOf("\\", StringComparison.Ordinal) > -1)
                CreateDirectory(directory);
            using (StreamWriter sw = new System.IO.StreamWriter(Path.Combine(directory, fileName), false, encoding))
            {
                sw.Write(content);
                sw.Close();
            }
        }

        #endregion

        #region 移动文件(剪贴--粘贴)

        /// <summary>
        /// 移动文件(剪贴--粘贴)
        /// </summary>
        /// <param name="dir1">要移动的文件的完整路径及全名(包括后缀)</param>
        /// <param name="dir2">文件移动到新的位置,并指定新的完整路径及文件名(包括后缀)</param>
        public static void MoveFile(string dir1, string dir2)
        {
            dir1 = dir1.Replace("/", "\\");
            dir2 = dir2.Replace("/", "\\");
            if (File.Exists(dir1))
                File.Move(dir1, dir2);
        }

        #endregion

        #region 复制文件

        /// <summary>
        /// 复制文件
        /// </summary>
        /// <param name="dir1">要复制的文件的完整路径及全名(包括后缀)</param>
        /// <param name="dir2">目标位置,并指定新的完整路径及全名(包括后缀)</param>
        /// <param name="overwrite">是否覆盖</param>
        public static void CopyFile(string dir1, string dir2, bool overwrite = true)
        {
            dir1 = dir1.Replace("/", "\\");
            dir2 = dir2.Replace("/", "\\");
            if (File.Exists(dir1))
            {
                File.Copy(dir1, dir2, overwrite);
            }
        }

        #endregion

        #region 删除文件

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="file">文件地址及文件名（完整的信息）</param>
        public static void DeleteFile(string file)
        {
            if (File.Exists(file))
                File.Delete(file);
        }

        #endregion

        #region 删除指定目录下的文件(不包含文件夹)

        /// <summary>
        /// 删除指定目录下的文件(文件夹不删除)
        /// </summary>
        /// <param name="recursive">是否递归删除子目录文件（默认递归删除，若为false，则只删除指定目录下的文件）</param>
        /// <param name="directoryPaths">指定目录的绝对路径集合</param>
        public static void DeleteFileByDirectory(bool recursive, params string[] directoryPaths)
        {
            foreach (var directoryPath in directoryPaths)
            {
                DeleteFileByDirectory(directoryPath, recursive);
            }
        }

        /// <summary>
        /// 删除指定目录下的文件(文件夹不删除)
        /// </summary>
        /// <param name="directoryPaths">指定目录的绝对路径集合</param>
        public static void DeleteFileByDirectory(params string[] directoryPaths)
        {
            foreach (var directoryPath in directoryPaths)
            {
                DeleteFileByDirectory(directoryPath, true);
            }
        }

        /// <summary>
        /// 删除指定目录下的文件(文件夹不删除)
        /// </summary>
        /// <param name="directoryPath">指定目录的绝对路径</param>
        /// <param name="recursive">是否递归删除子目录文件（默认递归删除，若为false，则只删除指定目录下的文件）</param>
        public static void DeleteFileByDirectory(string directoryPath, bool recursive)
        {
            if (IsExistDirectory(directoryPath))
            {
                //删除目录中所有的文件
                string[] fileNames = GetFiles(directoryPath);
                foreach (var fileName in fileNames)
                {
                    DeleteFile(fileName);
                }

                if (recursive)
                {
                    string[] directoryNames = GetDirectories(directoryPath);
                    foreach (var directory in directoryNames)
                    {
                        DeleteFileByDirectory(directory, recursive);
                    }
                }
            }
        }

        #endregion

        #region 向文本文件写入内容

        /// <summary>
        /// 向文本文件中写入内容(默认Utf8)
        /// </summary>
        /// <param name="filePath">文件的绝对路径</param>
        /// <param name="content">写入的内容</param>
        public static void WriteText(string filePath, string content)
        {
            WriteText(filePath, content, Encoding.UTF8);
        }

        /// <summary>
        /// 向文本文件中写入内容
        /// </summary>
        /// <param name="filePath">文件的绝对路径</param>
        /// <param name="content">写入的内容</param>
        /// <param name="encoding">编码</param>
        public static void WriteText(string filePath, string content, Encoding encoding)
        {
            File.WriteAllText(filePath, content, encoding);
        }

        #endregion

        #region 向文本文件的尾部追加内容

        /// <summary>
        /// 向文本文件的尾部追加内容
        /// </summary>
        /// <param name="filePath">文件的绝对路径</param>
        /// <param name="content">写入的内容</param>
        public static void AppendText(string filePath, string content)
        {
            File.AppendAllText(filePath, content);
        }

        #endregion

        #region 获取占用情况并杀死（仅windows适用）

        /// <summary>
        /// 获取占用情况并杀死（仅windows适用）
        /// </summary>
        /// <param name="file">要检查被那个进程占用的文件完整地址</param>
        /// <returns></returns>
        public static bool KillProcess(string file)
        {
            if (EnvironmentCommon.GetOs.IsWindows())
            {
                Process tool = new Process
                {
                    StartInfo =
                    {
                        FileName = "handle.exe",
                        Arguments = file + " /accepteula",
                        UseShellExecute = false,
                        RedirectStandardOutput = true
                    }
                };
                tool.Start();
                tool.WaitForExit();
                string outputTool = tool.StandardOutput.ReadToEnd();

                string matchPattern = @"(?<=\s+pid:\s+)\b(\d+)\b(?=\s+)";
                foreach (Match match in Regex.Matches(outputTool, matchPattern))
                {
                    Process.GetProcessById(int.Parse(match.Value)).Kill();
                }

                return true;
            }

            return false;
        }

        #endregion

        #endregion

        #region 文件夹

        #region 获取指定目录中所有子目录列表,若要搜索嵌套的子目录列表,请使用重载方法.

        /// <summary>
        /// 获取指定目录中所有子目录列表,若要搜索嵌套的子目录列表,请使用重载方法.
        /// </summary>
        /// <param name="directoryPath">指定目录的绝对路径</param>
        public static string[] GetDirectories(string directoryPath)
        {
            try
            {
                return Directory.GetDirectories(directoryPath);
            }
            catch (IOException ex)
            {
                throw ex;
            }
        }

        #endregion

        #region 检测指定文件夹是否存在

        /// <summary>
        /// 检测指定文件夹是否存在
        /// </summary>
        /// <param name="directoryPath">文件夹的绝对路径</param>
        /// <returns></returns>
        public static bool IsExistDirectory(string directoryPath)
        {
            return Directory.Exists(directoryPath);
        }

        #endregion

        #region 判断指定文件目录是否是空目录

        /// <summary>
        /// 判断指定文件目录是否是空目录
        /// </summary>
        /// <param name="directoryPath">指定目录的绝对路径</param>
        public static bool IsEmptyDirectory(string directoryPath)
        {
            try
            {
                if (GetFiles(directoryPath).Length > 0 || GetDirectories(directoryPath).Length > 0)
                {
                    return false;
                }

                return true;
            }
            catch (System.Exception ex)
            {
                return true;
            }
        }

        #endregion

        #region 创建目录

        /// <summary>
        /// 创建目录
        /// </summary>
        /// <param name="directory">文件夹绝对路径</param>
        public static void CreateDirectory(string directory)
        {
            if (directory.Length == 0) return;
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);
        }

        #endregion

        #region 删除目录

        /// <summary>
        /// 删除目录
        /// </summary>
        /// <param name="directory">要删除的目录路径和名称</param>
        /// <param name="recursive">是否递归删除子目录（默认递归删除）</param>
        public static void DeleteDirectory(string directory, bool recursive = true)
        {
            try
            {
                DeleteDirectoryExt(directory, recursive);
            }
            catch (IOException ex)
            {
            }
        }

        /// <summary>
        /// 删除目录
        /// </summary>
        /// <param name="directory">要删除的目录路径和名称</param>
        /// <param name="recursive">是否递归删除子目录（默认递归删除）</param>
        private static void DeleteDirectoryExt(string directory, bool recursive = true)
        {
            if (directory.Length == 0) return;
            if (Directory.Exists(directory))
                Directory.Delete(directory, recursive);
        }

        #endregion

        #region 复制文件夹

        /// <summary>
        /// 复制文件夹(递归)
        /// </summary>
        /// <param name="sourceDirectory">源文件夹路径</param>
        /// <param name="optDirectory">目标文件夹路径</param>
        /// <param name="isOverWrite">是否覆盖</param>
        public static void CopyFolder(string sourceDirectory, string optDirectory, bool isOverWrite = true)
        {
            CreateDirectory(optDirectory);

            if (!IsExistDirectory(sourceDirectory)) return;

            string[] directories = GetDirectories(sourceDirectory);

            if (directories.Length > 0)
            {
                foreach (string directory in directories)
                {
                    CopyFolder(directory, Path.Combine(optDirectory, directory),
                        isOverWrite);
                }
            }

            string[] files = GetFiles(sourceDirectory);
            if (files.Length > 0)
            {
                foreach (string file in files)
                {
                    File.Copy(file, Path.Combine(optDirectory, file),
                        isOverWrite);
                }
            }
        }

        #endregion

        #region 删除文件夹B中在文件夹A中存在的文件

        /// <summary>
        /// 删除文件夹B中在文件夹A中存在的文件
        /// 例如：文件夹B中有1.jpg，2.jpg，3.jpg
        /// 文件夹A中1.jpg，2.jpg，则需要删除文件夹B中1.jpg，2.jpg
        /// </summary>
        /// <param name="sourceDirectory">源文件夹</param>
        /// <param name="optDirectory">目标文件夹</param>
        public static void DeleteFolderFiles(string sourceDirectory, string optDirectory)
        {
            if (!IsExistDirectory(optDirectory) || !IsExistDirectory(sourceDirectory))
            {
                return;
            }

            string[] directories = GetDirectories(sourceDirectory);

            if (directories.Length > 0)
            {
                foreach (string directory in directories)
                {
                    DeleteFolderFiles(directory, Path.Combine(optDirectory + directory));
                }
            }

            string[] files = GetFiles(sourceDirectory);
            if (files.Length > 0)
            {
                foreach (string file in files)
                {
                    File.Delete(Path.Combine(optDirectory, file));
                }
            }
        }

        #endregion

        #region 清空指定目录

        /// <summary>
        /// 清空指定目录下所有文件及子目录,但该目录依然保存.
        /// </summary>
        /// <param name="directoryPath">指定目录的绝对路径</param>
        public static void ClearDirectory(string directoryPath)
        {
            if (IsExistDirectory(directoryPath))
            {
                //删除目录中所有的文件
                string[] fileNames = GetFiles(directoryPath);
                foreach (var fileName in fileNames)
                {
                    DeleteFile(fileName);
                }

                //删除目录中所有的子目录
                string[] directoryNames = GetDirectories(directoryPath);
                foreach (var directory in directoryNames)
                {
                    DeleteDirectory(directory, true);
                }
            }
        }

        #endregion

        #region 删除指定目录下的空文件夹，当前目录不删除

        /// <summary>
        /// 删除指定目录下的空文件夹，当前目录不删除
        /// </summary>
        /// <param name="directoryPath">指定目录的绝对路径</param>
        /// <param name="recursive">是否递归删除目录下的空文件夹（默认递归删除，若为false，则只删除指定目录下的空文件夹）</param>
        public static void DeleteEmptyDirectory(string directoryPath, bool recursive = true)
        {
            if (IsExistDirectory(directoryPath))
            {
                string[] directoryNames = GetDirectories(directoryPath);
                if (directoryNames.Length > 0)
                {
                    foreach (var directory in directoryNames)
                    {
                        if (IsEmptyDirectory(directory))
                        {
                            DeleteDirectory(directoryPath, false);
                        }
                        else
                        {
                            DeleteEmptyDirectory(directory, recursive);
                        }
                    }
                }
            }
        }

        #endregion

        #endregion
    }
}
