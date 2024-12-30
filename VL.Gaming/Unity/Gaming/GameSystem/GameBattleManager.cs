using UnityEngine;
using VL.Gaming.Common;
using VL.Gaming.Unity.Gaming.Tools;
using VL.Gaming.Unity.Tools;

namespace VL.Gaming.Unity.Gaming.GameSystem
{
    internal class GameBattleManager : MonoBehaviour
    {
        private static GameBattleManager instance;
        public static GameBattleManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameObject("GameBattleManager").AddComponent<GameBattleManager>();
                }
                return instance;
            }
        }

        void Awake()
        {
        }

        void Start()
        {
            Debug.Log("GameBattleManager Start()");

            InitGameBoard();

        }

        private void InitGameBoard()
        {
            //GameBoard = new GameObject("GameBoard");
            ////背景
            //var Square_Background = new GameObject("Square_Background");
            //var SpriteRenderer = Square_Background.AddComponent<SpriteRenderer>();
            //SpriteRenderer.sprite = VLResourcePool.Sprite_Rectangle;
            //Square_Background.SetParent(GameBoard);
            //Square_Background.SetScale(34.2f, 19.2f, 1);
            //英雄位置

            //棋子位置(星空战旗)

            //



            //生成Player+Enermy
            //开场动画 左右 街霸气势对抗,叫嚣
            //Player+Enermy归位

            //初始化棋子
            //注入灵魂




            //玩家回合开始

            //选择英雄技能
            //选择目标

            //敌人




        }
    }
}
