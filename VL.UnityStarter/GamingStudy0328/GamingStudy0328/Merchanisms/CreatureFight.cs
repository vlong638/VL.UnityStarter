using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scenes.GamingStudy0328
{
    public class CreatureFight
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
