using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scenes.GamingStudy0328
{
    public class AttackResult
    {
        public int ChangedHP;
        public bool IsDead;

        public Creature Creature { get; internal set; }
    }
}
