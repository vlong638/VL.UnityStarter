using System;
using System.Collections.Generic;
using VL.Gaming.Unity.Gaming.Content.Enums;

namespace VL.Gaming.Unity.Gaming.Content.Entities
{
    [Serializable]
    public class EquipmentAttributes
    {
        /// <summary>
        /// 护甲 => 物理减免
        /// </summary>
        public int Armor;
        /// <summary>
        /// 护甲穿透
        /// </summary>
        public int ArmorPenetration;
        /// <summary>
        /// 物理伤害高值
        /// </summary>
        public int PhysicalDamageHigh;
        /// <summary>
        /// 物理伤害低值
        /// </summary>
        public int PhysicalDamageLow;
        /// <summary>
        /// 招架
        /// </summary>
        public int Parry;
        /// <summary>
        /// 闪避
        /// </summary>
        public int Dodge;
        /// <summary>
        /// 魔法能力
        /// </summary>
        public int MagicalPower;
        /// <summary>
        /// 攻击距离
        /// </summary>
        public int AttackRange;
        /// <summary>
        /// 攻击范围
        /// </summary>
        public int AttackRadius;
    }
}
