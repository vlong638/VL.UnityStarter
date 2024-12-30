using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VL.ConsoleF.Tools
{
    public class FileLister
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="directoryPath">待整理的文件夹路径</param>
        /// <param name="outputFilePath">输出的文件路径</param>
        /// <param name="blacklistedFolders">需要过滤的文件夹</param>
        /// <param name="blacklistedFiles">需要过滤的文件</param>
        public static void Run(string directoryPath, string outputFilePath, string[] blacklistedFolders, string[] blacklistedFiles)
        {

            // 获取A目录下的所有文件夹和文件
            var allEntries = Directory.GetFileSystemEntries(directoryPath, "*", SearchOption.AllDirectories);

            // 过滤黑名单文件夹
            var filteredEntries = allEntries
                .Where(entry => !blacklistedFolders.Any(blacklisted => entry.Contains(Path.DirectorySeparatorChar + blacklisted + Path.DirectorySeparatorChar)))
                .ToArray();

            // 排序文件夹和文件名
            var sortedEntries = filteredEntries
                .Select(name => name.Substring(directoryPath.Length))
                .Where(file => !blacklistedFiles.Any(blackFile => blackFile == (Path.GetFileName(file))))
                .OrderBy(name => name, StringComparer.OrdinalIgnoreCase);

            // 将结果写入B文件
            File.WriteAllLines(outputFilePath, sortedEntries);
        }
    }
}
