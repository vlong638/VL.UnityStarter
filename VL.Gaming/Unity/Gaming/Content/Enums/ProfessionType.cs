using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VL.Gaming.Unity.Gaming.Content.Enums
{
    public enum ProfessionType
    {
        None = 0,

        Vanguard = 100,//先锋
        Berserker,//狂战士
        Shieldbearer,//盾卫
        CheetahKnight,//猎豹骑士

        Rearguard = 200,//后卫
        Pyromancer,//火焰法师
        Cryomancer,//冰霜法师
        Druid,//自然术士

        Mage = 300,//法师
        Stormcaller,//雷霆巫师
        Arcanist,//奥术学者
        ShadowSorcerer,//黑暗巫妖

        Archer = 400,//射手
        Sharpshooter,//精准射手
        VenomArcher,//毒箭手
        AncientMarksman,//远古弓手

        Medic = 500,//医生
        Healer,//治疗术士
        Toxinologist,//毒药大师
        DivinePhysician,//神圣医师
    }
}
