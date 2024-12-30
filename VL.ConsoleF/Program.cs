using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VL.ConsoleF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // 设置A目录路径和B文件路径
                string directoryPath = Directory.GetCurrentDirectory(); // 替换为实际A目录路径
                string outputFilePath = Path.Combine(directoryPath, "FileList.txt"); // 替换为实际B文件路径

                // 定义黑名单文件夹
                var blacklistedFolders = new[] { ".vs" , ".git" }; // 替换为实际黑名单文件夹名称
                var blacklistedFiles = new[] { ".vs", ".git", ".gitignore", "FileList.txt","VL.ConsoleF.exe" };

                // 检查A目录是否存在
                if (!Directory.Exists(directoryPath))
                {
                    Console.WriteLine($"目录不存在: {directoryPath}");
                    return;
                }

                // 获取A目录下的所有文件夹和文件
                var allEntries = Directory.GetFileSystemEntries(directoryPath, "*", SearchOption.AllDirectories);

                // 过滤黑名单文件夹
                var filteredEntries = allEntries
                    .Where(entry => !blacklistedFolders.Any(blacklisted => entry.Contains(Path.DirectorySeparatorChar + blacklisted + Path.DirectorySeparatorChar)))
                    .ToArray();

                // 排序文件夹和文件名
                var sortedEntries = filteredEntries
                    .Select(name=> name.Substring(directoryPath.Length))
                    .Where(file => !blacklistedFiles.Any(blackFile => blackFile==(Path.GetFileName(file))))
                    .OrderBy(name => name, StringComparer.OrdinalIgnoreCase);

                // 将结果写入B文件
                File.WriteAllLines(outputFilePath, sortedEntries);

                Console.WriteLine($"已将结果写入文件: {outputFilePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"发生错误: {ex.Message}");
            }
        }
    }
}
