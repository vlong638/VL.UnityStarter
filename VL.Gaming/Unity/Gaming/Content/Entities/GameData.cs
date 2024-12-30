using System;
using System.Collections.Generic;
using VL.Gaming.Unity.Gaming.Content.Enums;

namespace VL.Gaming.Unity.Gaming.Content.Entities
{
    [Serializable]
    public class GameData
    {
        public MapData MapData;
        public PlayerData PlayerData;

        //TODO 附近敌人
        //TODO 派系及派系行为
    }
}
