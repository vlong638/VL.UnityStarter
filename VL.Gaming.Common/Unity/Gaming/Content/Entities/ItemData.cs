using System;

namespace VL.Gaming.Unity.Gaming.Content.Entities
{
    [Serializable]
    public class ItemData
    {
        //数据
        public string Name { get; set; }
        public int Count;
        public string Description { get; set; }
        public string ExtraData;//基于附加数据实现附加功能
        //装备数据
        public bool IsEquipment;
        public Equipment Equipment;

        //表现
        public string ImageResource;
    }
}
