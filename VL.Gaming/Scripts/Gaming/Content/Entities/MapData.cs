using System;
using VL.Gaming.Scripts.Common.Entities;
using VL.Gaming.Scripts.Gaming.Content.Enums;
using VL.Gaming.Scripts.Gaming.GameSystem.Generator;

namespace VL.Gaming.Scripts.Gaming.Content.Entities
{
    [Serializable]
    public class MapData
    {
        public MapGenerationSeed MapGenerationSeed;

        public Guid Id { get; internal set; }
        public int SizeX { get; internal set; }
        public int SizeY { get; internal set; }

        public Serializable2DArray<Floor> Floors;

        //TODO 敌人生成点
        //TODO 附近敌人单位
    }
}
