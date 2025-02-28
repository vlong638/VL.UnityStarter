using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VL.Gaming.Scripts.Gaming.Content.Entities;
using VL.Gaming.Scripts.Tools;

namespace VL.Gaming.Scripts.Gaming.GameSystem.Generator
{
    internal class MapGenerator
    {
        public RandomList<Floor> Resource_Grounds = new RandomList<Floor>(new Floor("Grounds", FloorType.Sand));
        public RandomList<Floor> Resource_Forest = new RandomList<Floor>(new Floor("Forest", FloorType.Tree));
        public RandomList<Floor> Resource_Grass = new RandomList<Floor>(new Floor("Grass", FloorType.Grass));
        public RandomList<Floor> Resource_Waters = new RandomList<Floor>(new Floor("Waters", FloorType.Water));

        internal MapData GenerateMap()
        {
            MapData data = new MapData();
            data.Id = System.Guid.NewGuid();
            data.SizeX = 64;
            data.SizeY = 64;
            var floors = new Floor[data.SizeX, data.SizeY];
            //地表
            InitGrounds(floors);
            //森林
            for (int i = 0; i < 30; i++)
            {
                if (InitForest(floors))
                {
                    i += 10;
                }
            }
            //河流
            //TODO
            //建筑
            //TODO
            //地图连接点
            //TODO
            data.Floors = new Common.Entities.Serializable2DArray<Floor>(floors);
            return data;
        }

        public void InitGrounds(Floor[,] floors)
        {
            for (int i = 0; i < floors.GetLength(0); i++)
            {
                for (int j = 0; j < floors.GetLength(1); j++)
                {
                    var f = Resource_Grounds.GetRandomOne().Clone();
                    f.X = i;
                    f.Y = j;
                    floors[i, j] = f;
                }
            }
        }
        public bool InitForest(Floor[,] floors, int SizeX = 5, int SizeY = 5, int GrassSize = 3)
        {
            // 参数校验
            if (floors == null) return false;

            var maxX = floors.GetLength(0);
            var maxY = floors.GetLength(1);
            // 随机生成森林区域对角点
            Vector2Int pointA = new Vector2Int(
                Random.Range(0, maxX),
                Random.Range(0, maxY)
            );
            Vector2Int pointB = new Vector2Int(
                pointA.x + SizeX,
                pointA.y + SizeY
            );
            int xMin = Mathf.Min(pointA.x, pointB.x);
            int xMax = Mathf.Max(pointA.x, pointB.x, floors.GetLength(0));
            int yMin = Mathf.Min(pointA.y, pointB.y);
            int yMax = Mathf.Max(pointA.y, pointB.y, floors.GetLength(1));

            //重复校验
            if (Resource_Forest.Contains(floors[xMin, yMin])) return false;

            // 计算草地有效范围（考虑地图边界）
            int grassXMin = Mathf.Max(xMin - GrassSize, 0);
            int grassXMax = Mathf.Min(xMax + GrassSize, maxX - 1);
            int grassYMin = Mathf.Max(yMin - GrassSize, 0);
            int grassYMax = Mathf.Min(yMax + GrassSize, maxY - 1);

            // 遍历整个地图生成地形
            for (int x = 0; x < maxX; x++)
            {
                for (int y = 0; y < maxY; y++)
                {
                    // 判断是否在森林区域
                    if (x >= xMin && x <= xMax && y >= yMin && y <= yMax)
                    {
                        var f = Resource_Forest.GetRandomOne().Clone();
                        f.X = x;
                        f.Y = y;
                        floors[x, y] = f;
                    }
                    // 判断是否在草地扩展区
                    else if (x >= grassXMin && x <= grassXMax &&
                            y >= grassYMin && y <= grassYMax)
                    {
                        var f = Resource_Grass.GetRandomOne().Clone();
                        f.X = x;
                        f.Y = y;
                        floors[x, y] = f;
                    }
                }
            }
            return true;
        }
    }

    class RandomList<T>
    {
        public List<T> Data;

        public RandomList(params T[] data)
        {
            Data = data.ToList();
        }
        public RandomList(List<T> data)
        {
            Data = data;
        }

        public T GetRandomOne()
        {
            return Data[VLRandom.Random.Next(0, Data.Count)];
        }
        public bool Contains(T data)
        {
            return Data.Contains(data);
        }
    }
}
