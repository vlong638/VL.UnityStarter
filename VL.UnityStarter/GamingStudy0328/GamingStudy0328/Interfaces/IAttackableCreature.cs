using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scenes.GamingStudy0328
{
    public interface IAttackableCreature
    {
        int Attr_HP { set; get; }
        int Attr_AttackMax { set; get; }
        int Attr_AttackMin { set; get; }
        int Attr_Defend { set; get; }
        Dictionary<Buff, int> Buffs { set; get; }
        //AttackResult Attack(AttackableCreature creature, Dictionary<Buff, int> buffs);
        string GetAttackableCreatureDiscription();
    }
}
