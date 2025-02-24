using System;
using System.Collections.Generic;
using UnityEngine;
using VL.Gaming.Scripts.Gaming.Content.Enums;

namespace VL.Gaming.Scripts.Gaming.Content.Entities
{
    [Serializable]
    public class PlayerData : UnitData
    {
        public Vector3 Location;
        public List<ItemData> Items = new List<ItemData>();

        public PlayerData()
        {
        }
    }
}
