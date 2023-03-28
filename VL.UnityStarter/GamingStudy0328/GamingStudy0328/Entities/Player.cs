using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scenes.GamingStudy0328
{
    public class Player : Creature
    {
        public Vector3 CameraOffSet { get; internal set; }

        public GameObject PlayerGO;
        public GameObject DialogueGO;
        public List<Item> Items = new List<Item>();
        public List<FastItem> FastItems = new List<FastItem>();
        public GameObject MagicBarGO { set; get; }

        public Player(GameObject imageGO) : base(imageGO, "Player")
        {
            PlayerGO = imageGO;
            CameraOffSet = new Vector3(0, 0, -2);
            OperationStatus = OperationStatus.TurnOn;
            IsPlayer = true;

            MagicBarGO = Object.Instantiate(Gaming0328.instance.GameBoard.Resource_MagicBar, SpriteGO.transform);
            BloodBarGO = Object.Instantiate(Gaming0328.instance.GameBoard.Resource_BloodBar, SpriteGO.transform);
        }

        internal void Collect(Floor[,] floors)
        {
            Gaming0328.instance.GameBoard.DisplayText($"---拾取---");
            if (floors[X, Y].Items.Count == 0)
            {
                Gaming0328.instance.GameBoard.DisplayText($"{Name}捡了一把空气");
                return;
            }
            for (int i = floors[X, Y].Items.Count - 1; i >= 0; i--)
            {
                var item = floors[X, Y].Items[i];
                Items.Add(item);
                floors[X, Y].Items.Remove(item);
                Object.Destroy(item.SpriteGO);
                Gaming0328.instance.GameBoard.DisplayText($"{Name}拾取了{item.Name},{item.ItemType}");

                var fastItem = FastItems.FirstOrDefault(c => c.Item == null);
                fastItem.AddItem(item);
            }
        }

        internal void Check(Floor[,] floors)
        {
            Gaming0328.instance.GameBoard.DisplayText($"---查看---");
            foreach (var item in floors[X, Y].Items)
            {
                item.Display(Gaming0328.instance.GameBoard);
            }
            foreach (var creature in floors[X, Y].Creatures)
            {
                if (creature.IsPlayer)
                    continue;
                creature.Display(Gaming0328.instance.GameBoard);
            }
        }

        internal void UseFastItem(string v)
        {
            Gaming0328.instance.GameBoard.DisplayText($"---使用道具---");
            var fastItem = FastItems.FirstOrDefault(c => c.Key == v);
            if (fastItem == null)
            {
                Gaming0328.instance.GameBoard.DisplayText($"{Name}喝了口空气");
                return;
            }
            var buff = VLDictionaries.BuffDic[fastItem.Item.ItemType];
            Buffs.Add(buff.Key, buff.Value);
            Gaming0328.instance.GameBoard.DisplayText($"{Name}使用了{buff.Key},持续({ buff.Value})回合");

            //二步走
            //操作 界面对象
            //操作 逻辑对象
            Gaming0328.Destroy(fastItem.Item.SpriteGO);//界面
            Items.Remove(fastItem.Item);//包裹
            fastItem.Item = null;//快捷栏
        }
    }
}
