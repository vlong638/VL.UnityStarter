using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace JYFixer.Utils
{
    class MazeGeneratorV2
    {
        private int size; // 迷宫的大小（正方形）
        private int[,] maze;
        private Random random = new Random();
        private const int wallThickness = 1; // 墙壁的线条宽度，单位为像素（约等于1毫米）
        private int linkings; // 用于控制连通路径的数量

        public MazeGeneratorV2(int size, int linkings)
        {
            this.size = size;
            this.linkings = linkings;
            maze = new int[size, size];
        }

        // 生成迷宫
        public void GenerateMaze()
        {
            // 初始化迷宫，墙壁（1）
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    maze[i, j] = 1; // 1表示墙壁
                }
            }
            // 设置随机种子
            random = new Random();

            // 从一个随机位置开始递归生成路径
            GenerateMazeRecursive(1, 1);

            // 设置出入口
            maze[1, 0] = 0;  // 左侧入口
            maze[size - 2, size - 1] = 0; // 右侧出口

            // 根据 linkings 参数添加更多连通路径
            AddLinkings();
        }

        // 递归生成迷宫的路径
        private void GenerateMazeRecursive(int x, int y)
        {
            // 设置当前点为路径（0）
            maze[x, y] = 0;

            // 随机化四个方向
            var directions = new (int, int)[] {
            (-2, 0), // 上
            (2, 0),  // 下
            (0, -2), // 左
            (0, 2)   // 右
        };

            // 随机打乱方向
            Shuffle(directions);

            // 遍历四个方向
            foreach (var direction in directions)
            {
                int newX = x + direction.Item1;
                int newY = y + direction.Item2;

                // 判断是否越界，确保在迷宫范围内
                if (newX > 0 && newX < size - 1 && newY > 0 && newY < size - 1 && maze[newX, newY] == 1)
                {
                    // 如果目标位置是墙壁，则打通路径
                    maze[newX, newY] = 0;
                    // 打通墙壁与当前点的通道
                    maze[x + direction.Item1 / 2, y + direction.Item2 / 2] = 0;

                    // 递归到新的位置
                    GenerateMazeRecursive(newX, newY);
                }
            }
        }

        // 随机打乱方向数组
        private void Shuffle((int, int)[] directions)
        {
            for (int i = 0; i < directions.Length; i++)
            {
                int j = random.Next(i, directions.Length);
                var temp = directions[i];
                directions[i] = directions[j];
                directions[j] = temp;
            }
        }

        // 根据 linkings 参数添加更多连通路径
        private void AddLinkings()
        {
            int addedLinkings = 0;
            while (addedLinkings < linkings)
            {
                int x = random.Next(1, size - 1);
                int y = random.Next(1, size - 1);

                // 确保选择的位置是墙壁
                if (maze[x, y] == 1)
                {
                    // 随机选择一个方向
                    var directions = new (int, int)[] {
                    (-1, 0), // 上
                    (1, 0),  // 下
                    (0, -1), // 左
                    (0, 1)   // 右
                };

                    var direction = directions[random.Next(directions.Length)];
                    int newX = x + direction.Item1;
                    int newY = y + direction.Item2;

                    // 如果邻近的位置是路径并且新位置在迷宫内，打通墙壁
                    if (newX > 0 && newX < size - 1 && newY > 0 && newY < size - 1 && maze[newX, newY] == 0)
                    {
                        maze[x, y] = 0;
                        addedLinkings++;
                    }
                }
            }
        }

        // 将迷宫绘制为图片并保存
        public void SaveMazeToImage(string filePath)
        {
            // 每个单元格的大小（像素），假设每个单元格为20x20像素
            int cellSize = 20;

            // 计算图像的宽高
            int width = size * cellSize;
            int height = size * cellSize;

            // 创建一个Bitmap对象
            using (Bitmap bitmap = new Bitmap(width, height))
            {
                using (System.Drawing.Graphics g = Graphics.FromImage(bitmap))
                {
                    // 清空背景为白色
                    g.Clear(Color.White);

                    // 设置线条宽度为1毫米（约等于1像素，实际效果受DPI影响）
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    g.FillRectangle(Brushes.White, 0, 0, width, height); // 填充背景为白色

                    // 绘制迷宫的墙壁（黑色）
                    for (int i = 0; i < size; i++)
                    {
                        for (int j = 0; j < size; j++)
                        {
                            // 如果是墙壁，绘制黑色矩形
                            if (maze[i, j] == 1)
                            {
                                g.FillRectangle(Brushes.Black, j * cellSize, i * cellSize, cellSize, cellSize);
                            }
                        }
                    }
                }

                // 保存为PNG图片
                bitmap.Save(filePath, ImageFormat.Png);
            }
        }

        // 打印迷宫到控制台（可选）
        public void PrintMaze()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(maze[i, j] == 1 ? "█" : " "); // 使用█表示墙壁，空格表示路径
                }
                Console.WriteLine();
            }
        }
    }

    public class MazeGeneratorV2Helper
    {
        public void Generate()
        {
            for (int i = 0; i < 28; i++)
            {
                // 控制迷宫的大小和复杂度，size参数为迷宫的行列数（必须是奇数）
                int size = 75; // 你可以调整这个值，控制迷宫的复杂度
                int linkings = 50; // 控制增加的连通路径数量

                // 创建迷宫生成器
                var mazeGenerator = new MazeGeneratorV2(size, linkings);

                // 生成迷宫
                mazeGenerator.GenerateMaze();

                // 将迷宫保存为图片
                mazeGenerator.SaveMazeToImage($"Pics\\maze{i}.png");
            }
        }
    }
}
