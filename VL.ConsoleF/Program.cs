using System;
using System.IO;
using VL.ConsoleF.Tools;

namespace VL.ConsoleF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FileList();
        }

        private static void FileList()
        {
            try
            {
                // 设置A目录路径和B文件路径
                string directoryPath = Directory.GetCurrentDirectory(); // 替换为实际A目录路径
                string outputFilePath = Path.Combine(directoryPath, "FileList.txt"); // 替换为实际B文件路径

                // 定义黑名单文件夹
                var blacklistedFolders = new[] { ".vs", ".git" }; // 替换为实际黑名单文件夹名称
                var blacklistedFiles = new[] { ".vs", ".git", ".gitignore", "FileList.txt", "FileLister.exe" };

                // 检查A目录是否存在
                if (!Directory.Exists(directoryPath))
                {
                    Console.WriteLine($"目录不存在: {directoryPath}");
                    return;
                }
                FileLister.Run(directoryPath, outputFilePath, blacklistedFolders, blacklistedFiles);

                Console.WriteLine($"已将结果写入文件: {outputFilePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"发生错误: {ex.Message}");
            }
        }
    }
}
  