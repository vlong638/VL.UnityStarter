// See https://aka.ms/new-console-template for more information
try
{
    // 设置A目录路径和B文件路径
    string directoryPath =Directory.GetCurrentDirectory(); // 替换为实际A目录路径
    string outputFilePath = Path.Combine(directoryPath,"FileList.txt"); // 替换为实际B文件路径

    // 检查A目录是否存在
    if (!Directory.Exists(directoryPath))
    {
        Console.WriteLine($"目录不存在: {directoryPath}");
        return;
    }

    // 获取A目录下的所有文件夹和文件
    var allEntries = Directory.GetFileSystemEntries(directoryPath, "*", SearchOption.AllDirectories);

    // 排序文件夹和文件名
    var sortedEntries = allEntries
        .Select(Path.GetFileName)
        .Where(name => !string.IsNullOrEmpty(name))
        .OrderBy(name => name, StringComparer.OrdinalIgnoreCase);

    // 将结果写入B文件
    File.WriteAllLines(outputFilePath, sortedEntries);

    Console.WriteLine($"已将结果写入文件: {outputFilePath}");
}
catch (Exception ex)
{
    Console.WriteLine($"发生错误: {ex.Message}");
}
Console.ReadLine();