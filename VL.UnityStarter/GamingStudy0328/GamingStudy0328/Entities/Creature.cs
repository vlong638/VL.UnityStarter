using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scenes.GamingStudy0328
{
    public class Creature : UnityObject, IAttackableCreature, ICloneableObject<Creature>
    {
        public bool IsPlayer = false;
        public OperationStatus OperationStatus { get; internal set; }
        public GameObject BloodBarGO { set; get; }

        public Creature(GameObject spriteGO, string name = "") : base(spriteGO, name)
        {
            var sprite = spriteGO.GetComponent<SpriteRenderer>();
            sprite.sortingOrder = (int)SortingOrder.Creature;

            BloodBarGO = Gaming0328.instance.GameBoard.Resource_BloodBar;
        }

        public CreatureType CreatureType { set; get; }

        #region AttackableCreature
        public int Attr_MaxHP { set; get; }
        public int Attr_HP { set; get; }
        public int Attr_AttackMax { set; get; }
        public int Attr_AttackMin { set; get; }
        public int Attr_Defend { set; get; }
        public Dictionary<Buff, int> Buffs { set; get; } = new Dictionary<Buff, int>();
        public List<AudioClip> DiedSounds { get; internal set; }

        public AttackResult Attack()
        {
            var movement = Movement;
            AttackResult result = new AttackResult();
            var creature = Gaming0328.instance.GameBoard.Floors[X + movement.X, Y + movement.Y].Creatures.FirstOrDefault(c => c is IAttackableCreature);
            if (creature == null)
                return result;
            result.Creature = creature;
            return Attack(creature);
        }
        AttackResult Attack(Creature creature)
        {
            var floors = Gaming0328.instance.GameBoard.Floors;
            if (IsPlayer) Gaming0328.instance.GameBoard.DisplayText($"---当前状态---");
            Gaming0328.instance.GameBoard.DisplayText($"{Name}:{GetAttackableCreatureDiscription()}");
            Gaming0328.instance.GameBoard.DisplayText($"{creature.Name}:{creature.GetAttackableCreatureDiscription()}");
            Gaming0328.instance.GameBoard.DisplayText($"---攻击---");
            AttackResult result = AttackCore(creature, Buffs);
            result.Creature = creature;
            Gaming0328.instance.GameBoard.DisplayText($"{Name}攻击了{creature.Name},造成了{result.ChangedHP}点伤害");
            if (result.IsDead)
            {
                Gaming0328.instance.GameBoard.DisplayText($"{creature.Name}被打倒了");
            }
            else
            {
                //TODO 具备反击特性才会反击
                //result = creature.Attack(this, Buffs);
                //GameBoard.DisplayText($"{creature.Name}攻击了{Name},造成了{result.ChangedHP}点伤害");
                //if (result.IsDead)
                //{
                //    PlayerGO.SetActive(false);
                //    GameBoard.DisplayText($"{Name}被打倒了");
                //}
            }
            return result;
        }
        AttackResult AttackCore(IAttackableCreature creature, Dictionary<Buff, int> buffs)
        {
            AttackResult result = new AttackResult();
            var real_AttackMin = buffs.Keys.Any(c => c == Buff.DoubleAttack) ? Attr_AttackMin * 2 : Attr_AttackMin;
            var real_AttackMax = buffs.Keys.Any(c => c == Buff.DoubleAttack) ? Attr_AttackMax * 2 : Attr_AttackMax;
            var real_Defend = Buffs.Keys.Any(c => c == Buff.DoubleDefend) ? Attr_Defend * 2 : Attr_Defend;
            result.ChangedHP = Mathf.Max(0, Random.Range(real_AttackMin, real_AttackMax) - creature.Attr_Defend);
            creature.Attr_HP -= result.ChangedHP;
            result.IsDead = creature.Attr_HP <= 0;
            return result;
        }
        public string GetAttackableCreatureDiscription()
        {
            var real_AttackMin = Buffs.Keys.Any(c => c == Buff.DoubleAttack) ? Attr_AttackMin * 2 : Attr_AttackMin;
            var real_AttackMax = Buffs.Keys.Any(c => c == Buff.DoubleAttack) ? Attr_AttackMax * 2 : Attr_AttackMax;
            var real_Defend = Buffs.Keys.Any(c => c == Buff.DoubleDefend) ? Attr_Defend * 2 : Attr_Defend;
            return $@"当前状态<生命:{Attr_HP},攻击:{real_AttackMin}-{real_AttackMax},防御:{real_Defend}>";
        }

        internal void Display(GameBoard gameBoard)
        {
            gameBoard.DisplayText(VLDictionaries.GetDescriptionByCode(Name));
        }

        internal CreatureMove Movement;

        internal void UpdateBuffs(GameBoard GameBoard)
        {
            foreach (var key in Buffs.Keys)
            {
                Buffs[key]--;
                if (Buffs[key] == 0)
                {
                    Buffs.Remove(key);
                    if (IsPlayer)
                        GameBoard.DisplayText($"{key.ToString()},不再生效");
                }
                else
                {
                    if (IsPlayer)
                        GameBoard.DisplayText($"{key.ToString()},剩余({ Buffs[key]})回合");
                }
            }
        }

        public bool CanAttack(Player player)
        {
            //TODO
            //远程战斗单位增加远程攻击
            return Mathf.Abs(player.X - X) <= 1 && Mathf.Abs(player.Y - Y) <= 1;
        }

        public PlayerOperation OperationData = new PlayerOperation();

        #endregion

        // 边界检测
        public bool CheckOverEdge(Floor[,] floors)
        {
            return X + Movement.X < 0 || X + Movement.X > GameBoard.XSteps
                || Y + Movement.Y < 0 || Y + Movement.Y > GameBoard.YSteps;
        }

        // 碰撞检测
        public bool CheckCollider(Floor[,] floors)
        {
            var floor = floors[X + Movement.X, Y + Movement.Y];
            return floor.FloorType == FloorType.River || floor.FloorType == FloorType.Mountain || floor.Items.Any(c => c is BlockItem);
        }

        // 战斗检测
        public bool CheckCloseAttack(Floor[,] floors)
        {
            var floor = floors[X + Movement.X, Y + Movement.Y];
            return floor.Creatures.Any(c => c.CreatureType == CreatureType.Enermy);
        }

        internal void Move(Floor[,] floors)
        {
            floors[X, Y].Creatures.Remove(this);
            X += Movement.X;
            Y += Movement.Y;
            floors[X, Y].Creatures.Add(this);
            VLDebug.DelegateDebug(() =>
            {
                Debug.Log($"{Name}Move X:{X},Y:{Y}");
            });
        }

        public float DisplaySmoothMove(GameObject go, CreatureMove movement, float moveDuration = 0.2f)
        {
            float elapsedTime = Time.time - movement.moveStartTime;
            float clampTime = Mathf.Clamp01(elapsedTime / moveDuration);
            Vector2 newPosition = Vector2.Lerp(movement.startPosition, movement.targetPosition, clampTime);
            go.transform.position = newPosition;
            return clampTime;
        }

        internal void Defeated()
        {
            Gaming0328.instance.GameBoard.Enermies.Remove(this);
            Gaming0328.instance.GameBoard.Floors[X, Y].Creatures.Remove(this);
            Object.Destroy(this.SpriteGO);
        }

        public Creature Clone()
        {
            var spriteGO = Object.Instantiate(SpriteGO);
            return new Creature(spriteGO, Name)
            {
                CreatureType = CreatureType,
                DiedSounds = DiedSounds,
                BloodBarGO = Object.Instantiate(BloodBarGO, spriteGO.transform),
            };
        }

        static float BloodBarScaleX = Gaming0328.instance.GameBoard.Resource_BloodBar.GetComponent<SpriteRenderer>().transform.localScale.x;
        internal void UpdateBloodBar()
        {
            BloodBarGO.transform.localScale = new Vector3(BloodBarScaleX * Attr_HP / Attr_MaxHP, 1, 1);
        }
    }
}
