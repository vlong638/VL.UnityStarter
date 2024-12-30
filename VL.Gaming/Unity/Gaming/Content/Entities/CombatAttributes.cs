using System;
using System.Collections.Generic;
using VL.Gaming.Unity.Gaming.Content.Enums;

namespace VL.Gaming.Unity.Gaming.Content.Entities
{
    [Serializable]
    public class CombatAttributes
    {
        /// <summary>
        /// 物理伤害高值
        /// </summary>
        public int PhysicalDamageHigh;
        /// <summary>
        /// 物理伤害低值
        /// </summary>
        public int PhysicalDamageLow;
        /// <summary>
        /// 物理伤害抗性
        /// </summary>
        public int PhysicalDamageResistance;
        /// <summary>
        /// 招架
        /// </summary>
        public int Parry;
        /// <summary>
        /// 闪避
        /// </summary>
        public int Dodge;
        /// <summary>
        /// 魔法伤害高值
        /// </summary>
        public int MagicalDamageHigh;
        /// <summary>
        /// 魔法伤害低值
        /// </summary>
        public int MagicalDamageLow;
        /// <summary>
        /// 魔法伤害抗性
        /// </summary>
        public int MagicalDamageResistance;
        /// <summary>
        /// 治疗伤害高值
        /// </summary>
        public int HealingDamageHigh;
        /// <summary>
        /// 治疗伤害低值
        /// </summary>
        public int HealingDamageLow;
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
