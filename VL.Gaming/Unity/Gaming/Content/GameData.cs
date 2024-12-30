//using System;
//using System.Collections.Generic;

//namespace VL.Gaming.Unity.Gaming.Storage
//{
//    [Serializable]
//    public class GameData
//    {
//        public MapData MapData;
//        public PlayerData PlayerData;

//        //TODO 附近敌人
//        //TODO 派系及派系行为
//    }

//    [Serializable]
//    public class TeamData
//    {
//        public PlayerData PlayerData;
//        public List<UnitData> UnitDatas;
//        public List<InstrumentData> InstrumentDatas;
//    }

//    [Serializable]
//    public class PlayerData: UnitData
//    {
//    }

//    public enum UnitType
//    {
//        None = 0,
//        Player = 1,
//        Footman= 101,
//        Therian = 201,
//    }

//    [Serializable]
//    public class UnitAttributes
//    {
//        /// <summary>
//        /// 力量
//        /// </summary>
//        public int Strength;
//        /// <summary>
//        /// 敏捷
//        /// </summary>
//        public int Agility;
//        /// <summary>
//        /// 体质
//        /// </summary>
//        public int Constitution;
//        /// <summary>
//        /// 智力
//        /// </summary>
//        public int Intelligence;
//        /// <summary>
//        /// 意志
//        /// </summary>
//        public int Willpower;
//        /// <summary>
//        /// 魅力
//        /// </summary>
//        public int Charisma;
//        /// <summary>
//        /// 领导力
//        /// </summary>
//        public int Leadership;
//    }

//    [Serializable]
//    public class UnitData
//    {
//        public UnitType UnitType;
//        public UnitAttributes UnitAttributes;
//        public List<Equipment> Equipments;
//        public Profession Profession;
//        public List<ProfessionSkill> ProfessionSkills;

//        public CombatAttributes CombatAttributes;
//        public List<CombatSkill> CombatSkills;
//    }

//    [Serializable]
//    public class EquipmentAttributes
//    {
//        /// <summary>
//        /// 护甲 => 物理减免
//        /// </summary>
//        public int Armor;
//        /// <summary>
//        /// 护甲穿透
//        /// </summary>
//        public int ArmorPenetration;
//        /// <summary>
//        /// 物理伤害高值
//        /// </summary>
//        public int PhysicalDamageHigh;
//        /// <summary>
//        /// 物理伤害低值
//        /// </summary>
//        public int PhysicalDamageLow;
//        /// <summary>
//        /// 招架
//        /// </summary>
//        public int Parry;
//        /// <summary>
//        /// 闪避
//        /// </summary>
//        public int Dodge;
//        /// <summary>
//        /// 魔法能力
//        /// </summary>
//        public int MagicalPower;
//        /// <summary>
//        /// 攻击距离
//        /// </summary>
//        public int AttackRange;
//        /// <summary>
//        /// 攻击范围
//        /// </summary>
//        public int AttackRadius;
//    }

//    public enum EquipmentType
//    {
//        None = 0,
//        Helmet,// 头盔
//        Armor,// 护甲
//        Boots, // 靴子
//        Gloves,// 手套
//        Shield,// 盾牌
//        Sword, // 剑
//        Bow, // 弓
//        Staff,// 法杖
//        Ring, // 戒指
//        Amulet,// 护身符
//    }

//    [Serializable]
//    public class Equipment
//    {
//        public EquipmentType EquipmentType;
//        public EquipmentAttributes EquipmentAttributes;
//    }

//    public enum InstrumentType
//    {
//        None = 0,

//        Walls = 100,
//        WoodenWalls,
//        StoneWalls,
//        MagicWalls,

//        Towers = 100,
//        ArcherTowers,
//        CannonTowers,

//        Traps = 200,

//        SiegeEngines = 300,
//        Catapults,//Used for long-range attacks on walls and enemies
//        BatteringRams,//Used to break down walls and gates
//        SiegeTowers,//Provide a height advantage for attacking walls, can accommodate multiple soldiers for the assault.

//        MedicalFacilities = 400,
//        HealingStations,//Provide continuous healing effects to units within range.
//        MedicalTents,//Offer temporary healing and resting spots.
//        HealingCrystals,//Release healing waves, restoring the health of nearby units.
//    }

//    [Serializable]
//    public class InstrumentData
//    {
//        public InstrumentType InstrumentType;
//    }

//    [Serializable]
//    public class CombatAttributes
//    {
//        /// <summary>
//        /// 物理伤害高值
//        /// </summary>
//        public int PhysicalDamageHigh;
//        /// <summary>
//        /// 物理伤害低值
//        /// </summary>
//        public int PhysicalDamageLow;
//        /// <summary>
//        /// 物理伤害抗性
//        /// </summary>
//        public int PhysicalDamageResistance;
//        /// <summary>
//        /// 招架
//        /// </summary>
//        public int Parry;
//        /// <summary>
//        /// 闪避
//        /// </summary>
//        public int Dodge;
//        /// <summary>
//        /// 魔法伤害高值
//        /// </summary>
//        public int MagicalDamageHigh;
//        /// <summary>
//        /// 魔法伤害低值
//        /// </summary>
//        public int MagicalDamageLow;
//        /// <summary>
//        /// 魔法伤害抗性
//        /// </summary>
//        public int MagicalDamageResistance;
//        /// <summary>
//        /// 治疗伤害高值
//        /// </summary>
//        public int HealingDamageHigh;
//        /// <summary>
//        /// 治疗伤害低值
//        /// </summary>
//        public int HealingDamageLow;
//        /// <summary>
//        /// 攻击距离
//        /// </summary>
//        public int AttackRange;
//        /// <summary>
//        /// 攻击范围
//        /// </summary>
//        public int AttackRadius;
//    }

//    public enum Profession
//    {
//        None = 0,

//        Vanguard = 100,//先锋
//        Berserker,//狂战士
//        Shieldbearer,//盾卫
//        CheetahKnight,//猎豹骑士

//        Rearguard = 200,//后卫
//        Pyromancer,//火焰法师
//        Cryomancer,//冰霜法师
//        Druid,//自然术士

//        Mage = 300,//法师
//        Stormcaller,//雷霆巫师
//        Arcanist,//奥术学者
//        ShadowSorcerer,//黑暗巫妖

//        Archer = 400,//射手
//        Sharpshooter,//精准射手
//        VenomArcher,//毒箭手
//        AncientMarksman,//远古弓手

//        Medic = 500,//医生
//        Healer,//治疗术士
//        Toxinologist,//毒药大师
//        DivinePhysician,//神圣医师
//    }

//    [Serializable]
//    public class ProfessionSkill
//    {
//        //TODO 技能描述
//    }

//    [Serializable]
//    public class CombatSkill
//    {
//        /// <summary>
//        /// 物理伤害高值
//        /// </summary>
//        public int PhysicalDamageHigh;
//        /// <summary>
//        /// 物理伤害低值
//        /// </summary>
//        public int PhysicalDamageLow;
//        /// <summary>
//        /// 物理伤害抗性
//        /// </summary>
//        public int PhysicalDamageResistance;
//        /// <summary>
//        /// 招架
//        /// </summary>
//        public int Parry;
//        /// <summary>
//        /// 闪避
//        /// </summary>
//        public int Dodge;
//        /// <summary>
//        /// 魔法伤害高值
//        /// </summary>
//        public int MagicalDamageHigh;
//        /// <summary>
//        /// 魔法伤害低值
//        /// </summary>
//        public int MagicalDamageLow;
//        /// <summary>
//        /// 魔法伤害抗性
//        /// </summary>
//        public int MagicalDamageResistance;
//        /// <summary>
//        /// 治疗伤害高值
//        /// </summary>
//        public int HealingDamageHigh;
//        /// <summary>
//        /// 治疗伤害低值
//        /// </summary>
//        public int HealingDamageLow;
//        /// <summary>
//        /// 攻击距离
//        /// </summary>
//        public int AttackRange;
//        /// <summary>
//        /// 攻击范围
//        /// </summary>
//        public int AttackRadius;
//    }

//    public enum MapGenerationSeed
//    {
//        None = 0,
//        Forest = 1,//Forest, Moonwell - Druids, Elves, Goblins
//        Mountains = 2,//Mountains, Rocky Terrain - Dwarves, Stonefolk, Earth Dragons
//        Plains = 3,//Volcano, Magma Area - Demons
//        Swamp = 4,// Plains - Humans
//        Volcano = 5,//Swamp - Lizardfolk, Witches
//    }

//    [Serializable]
//    public class MapData
//    {
//        public MapGenerationSeed MapGenerationSeed;
        
//        //TODO 敌人生成点
//        //TODO 附近敌人单位
//    }
//}
