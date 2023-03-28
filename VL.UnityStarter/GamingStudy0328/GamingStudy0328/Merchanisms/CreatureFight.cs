using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scenes.GamingStudy0328
{
    public class AttackResult
    {
        public int ChangedHP;
        public bool IsDead;

        public Creature Creature { get; internal set; }
    }
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
    public class CreatureFightDecorator
    {
        public int Attr_HP_from { set; get; }
        public int Attr_HP_to { set; get; }
        public int Attr_AttackMax_from { set; get; }
        public int Attr_AttackMax_to { set; get; }
        public int Attr_AttackMin_from { set; get; }
        public int Attr_AttackMin_to { set; get; }
        public int Attr_Defend_from { set; get; }
        public int Attr_Defend_to { set; get; }

        internal void Decorate(Creature creature)
        {
            creature.Attr_MaxHP = Random.Range(this.Attr_HP_from, this.Attr_HP_to);
            creature.Attr_HP = creature.Attr_MaxHP;
            creature.Attr_AttackMax = Random.Range(this.Attr_AttackMax_from, this.Attr_AttackMax_to);
            creature.Attr_AttackMin = Random.Range(this.Attr_AttackMin_from, this.Attr_AttackMin_to);
            creature.Attr_Defend = Random.Range(this.Attr_Defend_from, this.Attr_Defend_to);
        }
    }
}
