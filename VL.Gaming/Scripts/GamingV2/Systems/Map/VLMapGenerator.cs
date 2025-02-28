using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VL.Gaming.Scripts.GamingV2.Entities;

namespace VL.Gaming.Scripts.GamingV2.Systems
{
    internal class VLMapGenerator
    {
        public static int XSteps = 160;
        public static int YSteps = 90;
        public static float StepX = 0.16f;
        public static float StepY = 0.16f;
        public Floor[] Floors;
        internal float floorWidth;
        internal float floorHeight;
    }
    internal class VLMapGenerateArgs
    {
        public int MapSize { set; get; }

    }
}
