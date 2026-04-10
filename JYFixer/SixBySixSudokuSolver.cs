using System;
using System.IO;

namespace SixBySixSudokuSolver
{
    public class SudokuSolver
    {
        // 验证在 (row, col) 放置数字 num 是否合法（基于当前盘面）
        public static bool IsValidPlacement(int[,] board, int row, int col, int num)
        {
            // 检查行
            for (int c = 0; c < 6; c++)
                if (board[row, c] == num && c != col)
                    return false;

            // 检查列
            for (int r = 0; r < 6; r++)
                if (board[r, col] == num && r != row)
                    return false;

            // 检查宫（六宫为 2 行 × 3 列）
            int startRow = (row / 2) * 2;
            int startCol = (col / 3) * 3;
            for (int r = startRow; r < startRow + 2; r++)
                for (int c = startCol; c < startCol + 3; c++)
                    if (board[r, c] == num && (r != row || c != col))
                        return false;

            return true;
        }

        // 求解数独（回溯法）
        public bool Solve(int[,] board)
        {
            return SolveRecursive(board);
        }

        private bool SolveRecursive(int[,] board)
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (board[i, j] == 0) // 找到空格
                    {
                        for (int num = 1; num <= 6; num++)
                        {
                            if (IsValidPlacement(board, i, j, num))
                            {
                                board[i, j] = num;
                                if (SolveRecursive(board))
                                    return true;
                                board[i, j] = 0; // 回溯
                            }
                        }
                        return false; // 无合法数字，触发回溯
                    }
                }
            }
            return true; // 无空格，求解完成
        }

        // 打印盘面（带分隔线，便于阅读）
        public static void PrintBoard(int[,] board)
        {
            Console.WriteLine("  +-------+-------+");
            for (int i = 0; i < 6; i++)
            {
                Console.Write("  | ");
                for (int j = 0; j < 6; j++)
                {
                    int val = board[i, j];
                    Console.Write(val == 0 ? ". " : $"{val} ");
                    if ((j + 1) % 3 == 0)
                        Console.Write("| ");
                }
                Console.WriteLine();
                if ((i + 1) % 2 == 0 && i != 5)
                    Console.WriteLine("  +-------+-------+");
            }
            Console.WriteLine("  +-------+-------+");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            while (Console.ReadLine() != "q")
            {
                int[,] board = new int[6, 6];

                // 读取盘面（文件或控制台）
                if (args.Length > 0)
                {
                    string filename = args[0];
                    try
                    {
                        string[] lines = File.ReadAllLines(filename);
                        ParseBoard(lines, board);
                        Console.WriteLine($"已从文件 '{filename}' 加载盘面。");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"读取文件失败: {ex.Message}");
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("请输入六宫数独盘面，每行6个字符（1-6 或 0 / . 表示空格）：");
                    string[] lines = new string[6];
                    for (int i = 0; i < 6; i++)
                    {
                        Console.Write($"第{i + 1}行: ");
                        string input = Console.ReadLine();
                        lines[i] = input ?? "";
                    }
                    ParseBoard(lines, board);
                }

                // 显示初始盘面
                Console.WriteLine("\n初始盘面:");
                SudokuSolver.PrintBoard(board);

                // 检查初始合法性
                if (!IsInitialBoardValid(board))
                {
                    Console.WriteLine("错误：初始盘面中存在冲突（同行/列/宫有重复数字）。");
                    return;
                }

                // 求解
                SudokuSolver solver = new SudokuSolver();
                if (solver.Solve(board))
                {
                    Console.WriteLine("\n求解结果:");
                    SudokuSolver.PrintBoard(board);
                }
                else
                {
                    Console.WriteLine("\n无解！");
                }
            }
        }

        // 解析用户输入的6行字符串，填充 board
        static void ParseBoard(string[] lines, int[,] board)
        {
            for (int i = 0; i < 6; i++)
            {
                string line = lines[i].Trim();
                int col = 0;
                for (int j = 0; j < line.Length && col < 6; j++)
                {
                    char c = line[j];
                    if (char.IsWhiteSpace(c)) continue; // 跳过空白字符
                    if (c >= '1' && c <= '6')
                        board[i, col++] = c - '0';
                    else if (c == '0' || c == '.')
                        board[i, col++] = 0;
                    else
                        throw new FormatException($"第{i + 1}行包含无效字符 '{c}'，只允许数字1-6或0/.表示空格。");
                }
                if (col != 6)
                    throw new FormatException($"第{i + 1}行有效数字不足6个。");
            }
        }

        // 检查初始盘面是否存在冲突（复用合法性验证）
        static bool IsInitialBoardValid(int[,] board)
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    int val = board[i, j];
                    if (val != 0)
                    {
                        if (!SudokuSolver.IsValidPlacement(board, i, j, val))
                            return false;
                    }
                }
            }
            return true;
        }
    }
}