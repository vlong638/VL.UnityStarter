using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using VL.Gaming.Common;
using VL.Gaming.Unity.Gaming.Tools;
using VL.Gaming.Unity.Tools;
using VL.Gaming.Unity.Utils;

namespace VL.Gaming.Unity.UnityTools
{
    internal class Tools_Scene_InitGameBoard
    {
        [MenuItem("Tools/Scene/InitGameBoard")]
        static void InitGameBoard()
        {
            //检查已存在
            VLResourceHelper.CheckExist("PreBattle");
            VLResourceHelper.CheckExist("InBattle");

            //依赖前置
            var sprite = VLResourcePool.Sprite_Rectangle;
            sprite = VLResourcePool.Sprite_Player;
            sprite = VLResourcePool.Sprite_Enermy;
            sprite = VLResourcePool.Sprite_VS;
            sprite = VLResourcePool.Sprite_Rectangle;
            sprite = VLResourcePool.Sprite_Circle;
            var gameObject = VLResourcePool.Prefab_Chess;
            gameObject = VLResourcePool.Prefab_ChessPlaceHolder;

            //PreBattle
            var PreBattle = new GameObject("PreBattle");
            PreBattle.SetActive(false);
            //背景 云顶,天空,悬浮,流云效果
            var Sprite_Background = VLCreator.CreateSprite("Sprite_Background");
            Sprite_Background.SetParent(PreBattle);
            Sprite_Background.SetPosition(0, 0, 0);
            Sprite_Background.SetScale(34.2f, 19.2f, 1);
            var SpriteRenderer = Sprite_Background.GetComponent<SpriteRenderer>();
            SpriteRenderer.sprite = VLResourcePool.Sprite_Rectangle;
            SpriteRenderer.sortingOrder = SortingOrderEnum.Floor.ToInt();
            //Player
            var Sprite_Player = VLCreator.CreateSprite("Sprite_Player");
            Sprite_Player.SetParent(PreBattle);
            Sprite_Player.SetPosition(-5, 0, 0);
            SpriteRenderer = Sprite_Player.GetComponent<SpriteRenderer>();
            SpriteRenderer.sprite = VLResourcePool.Sprite_Player;
            SpriteRenderer.sortingOrder = SortingOrderEnum.Unit.ToInt();
            //Enermy
            var Sprite_Enermy = VLCreator.CreateSprite("Sprite_Enermy");
            Sprite_Enermy.SetParent(PreBattle);
            Sprite_Enermy.SetPosition(5, 0, 0);
            SpriteRenderer = Sprite_Enermy.GetComponent<SpriteRenderer>();
            SpriteRenderer.sprite = VLResourcePool.Sprite_Enermy;
            SpriteRenderer.sortingOrder = SortingOrderEnum.Unit.ToInt();
            //VS
            var Sprite_VS = VLCreator.CreateSprite("Sprite_VS");
            Sprite_VS.SetParent(PreBattle);
            Sprite_VS.SetPosition(0, 0, 0);
            SpriteRenderer = Sprite_VS.GetComponent<SpriteRenderer>();
            SpriteRenderer.sprite = VLResourcePool.Sprite_VS;
            SpriteRenderer.sortingOrder = SortingOrderEnum.Unit.ToInt();

            //InBattle
            var InBattle = new GameObject("InBattle");
            InBattle.SetActive(true);
            //Canvas
            var Canvas_Main = VLCreator.CreateCanvas("Canvas_Main");
            Canvas_Main.SetParent(InBattle);
            //背景 云顶,天空,悬浮,流云效果
            Sprite_Background = VLCreator.CreateSprite("Sprite_Background");
            Sprite_Background.SetParent(InBattle);
            Sprite_Background.SetPosition(0, 0, 0);
            Sprite_Background.SetScale(34.2f, 19.2f, 1);
            SpriteRenderer = Sprite_Background.GetComponent<SpriteRenderer>();
            SpriteRenderer.sprite = VLResourcePool.Sprite_Rectangle;
            SpriteRenderer.sortingOrder = SortingOrderEnum.Floor.ToInt();
            //棋盘
            var Sprite_Board = VLCreator.CreateSprite("Sprite_Board");
            Sprite_Board.SetParent(InBattle);
            Sprite_Board.SetPosition(0, 0, 0);
            Sprite_Board.SetScale(20f, 10f, 1);
            SpriteRenderer = Sprite_Board.GetComponent<SpriteRenderer>();
            SpriteRenderer.sprite = VLResourcePool.Sprite_Circle;
            SpriteRenderer.sortingOrder = SortingOrderEnum.Floor.ToInt();
            SpriteRenderer.color = Color.green;
            //计时器,漏斗
            var Sprite_HourGlass = VLCreator.CreateSprite("Sprite_HourGlass");
            Sprite_HourGlass.SetParent(InBattle);
            //SpriteRenderer = Sprite_HourGlass.GetComponent<SpriteRenderer>();
            //SpriteRenderer.sprite = VLResource.Sprite_HourGlass;
            //SpriteRenderer.sortingOrder = SortingOrderEnum.Item.ToInt();
            var Canvas = VLCreator.CreateCanvas("Canvas");
            Canvas.SetParent(Sprite_HourGlass);
            Canvas.SetPosition(0, 0, 0);
            var canvas = Canvas.GetComponent<Canvas>();
            canvas.renderMode = RenderMode.WorldSpace;
            canvas.sortingOrder = Common.Enums.SortingOrder.Foreground.ToInt();
            var TextGO = VLCreator.CreateText("Text");
            TextGO.SetParent(Canvas);
            TextGO.SetRectSizeDelta(90, 50);
            TextGO.SetScale(0.02f, 0.02f, 1);
            TextGO.SetPosition(0.08f, 0, 0);
            var text = TextGO.GetComponent<Text>();
            text.fontSize = 36;
            text.text = "00:00";
            text.color = Color.black;
            Sprite_HourGlass.SetPosition(-9, 0, 0);
            //当前回合说明
            var Sprite_CurrentTurn = VLCreator.CreateSprite("Sprite_CurrentTurn");
            Sprite_CurrentTurn.SetParent(InBattle);
            //SpriteRenderer = Sprite_CurrentTurn.GetComponent<SpriteRenderer>();
            //SpriteRenderer.sprite = VLResource.Sprite_PlayerTurn;
            //SpriteRenderer.sortingOrder = SortingOrderEnum.Item.ToInt();
            Canvas = VLCreator.CreateCanvas("Canvas");
            Canvas.SetParent(Sprite_CurrentTurn);
            Canvas.SetPosition(0, 0, 0);
            canvas = Canvas.GetComponent<Canvas>();
            canvas.renderMode = RenderMode.WorldSpace;
            canvas.sortingOrder = Common.Enums.SortingOrder.Foreground.ToInt();
            TextGO = VLCreator.CreateText("Text");
            TextGO.SetParent(Canvas);
            TextGO.SetRectSizeDelta(120, 50);
            TextGO.SetScale(0.02f, 0.02f, 1);
            TextGO.SetPosition(0, 0, 0);
            text = TextGO.GetComponent<Text>();
            text.fontSize = 30;
            text.text = "我方回合";
            text.color = Color.black;
            Sprite_CurrentTurn.SetPosition(-8.88f, 0.64f, 0);

            //行列
            float[] columns = new float[] { -7, -3.5f, 0, 3.5f, 7 };
            float[] rows = new float[] { 3.3f, 1.3f, -1f, -3f };
            //Player
            var player = GameObject.Instantiate(VLResourcePool.Prefab_Chess);
            player.SetParent(InBattle);
            player.transform.position = new Vector3(columns[2], rows[3], 0);
            player.layer = Common.Enums.LayerMask.PlayerUnit.ToInt();
            player.AddComponent<BoxCollider2D>();
            player.AddComponent<Animator>();
            //Enermy
            var enermy = GameObject.Instantiate(VLResourcePool.Prefab_Chess);
            enermy.SetParent(InBattle);
            enermy.transform.position = new Vector3(columns[2], rows[0], 0);
            enermy.layer = Common.Enums.LayerMask.EnermyUnit.ToInt();
            enermy.AddComponent<BoxCollider2D>();
            enermy.AddComponent<Animator>();
            //棋子位置(星空战旗)
            for (int r = 0; r < rows.Length; r++)
            {
                for (int c = 0; c < columns.Length; c++)
                {
                    var chess = GameObject.Instantiate(VLResourcePool.Prefab_ChessPlaceHolder);
                    chess.SetParent(InBattle);
                    chess.transform.position = new Vector3(columns[c], rows[r], 0);
                    chess.layer = r >= 2 ? Common.Enums.LayerMask.PlayerUnit.ToInt() : Common.Enums.LayerMask.EnermyUnit.ToInt();
                    chess.AddComponent<BoxCollider2D>();
                    chess.AddComponent<Animator>();
                }
            }
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
