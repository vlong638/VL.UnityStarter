using System;
using System.Collections.Generic;
using VL.Gaming.Scripts.Gaming.Content.Enums;

namespace VL.Gaming.Scripts.Gaming.Content.Entities
{
    [Serializable]
    public class TeamData
    {
        public PlayerData PlayerData;
        public List<UnitData> UnitDatas;
        public List<InstrumentData> InstrumentDatas;
    }
}
