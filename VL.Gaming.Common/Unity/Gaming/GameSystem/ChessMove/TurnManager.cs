using System.Collections;
using UnityEngine;
using VL.Gaming.Unity.Common.Enums;
using VL.Gaming.Unity.Gaming.Ultis;

namespace VL.Gaming.Unity.Gaming.GameSystem.ChessMove
{
    public class TurnManager : MonoBehaviour
    {
        private static TurnManager instance;
        public static TurnManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameObject("TurnManager").AddComponent<TurnManager>();
                }
                return instance;
            }
        }

        public enum TurnState
        {
            PlayerTurn,
            PlayerTurnEnd,
            EnemyTurn,
            EnemyTurnEnd,
        }
        public TurnState turnState;
        public int playerActionPoints;
        public int enemyActionPoints;

        void Start()
        {
            playerLayer = LayerMask.GetMask(VLLayerMask.PlayerUnit.ToString());
            enemyLayer = LayerMask.GetMask(VLLayerMask.EnermyUnit.ToString());
            StartPlayerTurn();
        }

        void StartPlayerTurn()
        {
            GameObject.Find("Sprite_CurrentTurn").GetComponent<SpriteRenderer>().sprite = VLResource.Sprite_PlayerTurn;
            turnState = TurnState.PlayerTurn;
            playerActionPoints = 3; // 示例值，实际值根据需要设定
        }

        void StartEnemyTurn()
        {
            GameObject.Find("Sprite_CurrentTurn").GetComponent<SpriteRenderer>().sprite = VLResource.Sprite_EnermyTurn;
            turnState = TurnState.EnemyTurn;
            enemyActionPoints = 3; // 示例值
                                   // 启动敌方AI逻辑
        }

        IEnumerator EnemyTurn()
        {
            Debug.Log("敌方正在思考");
            yield return new WaitForSeconds(1);
            Debug.Log("敌方使用卡牌");
            yield return new WaitForSeconds(1);
            Debug.Log("敌方发动攻击");
            yield return new WaitForSeconds(1);
            EndEnemyTurn();
        }

        void EndPlayerTurn()
        {
            StartEnemyTurn();
        }

        void EndEnemyTurn()
        {
            StartPlayerTurn();
        }

        public LayerMask playerLayer;
        public LayerMask enemyLayer;
        public GameObject selectedPlayerUnit;
        public GameObject selectedEnermyUnit;

        void Update()
        {
            switch (turnState)
            {
                case TurnState.PlayerTurn:
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        EndPlayerTurn();
                    }
                    if (Input.GetMouseButtonDown(0))
                    {
                        if (selectedPlayerUnit == null)//选择玩家棋子
                        {
                            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, playerLayer);
                            if (hit.collider != null)
                            {
                                Debug.Log(hit.collider);
                                if (selectedPlayerUnit != null)
                                    PlayerUnitUnselected();
                                selectedPlayerUnit = hit.collider.gameObject;
                                PlayerUnitSelected();
                            }
                        }
                        if (selectedPlayerUnit != null && selectedEnermyUnit != null)//选择敌方棋子
                        {
                            new DisplayCrash().Display(selectedPlayerUnit, selectedEnermyUnit);
                        }
                    }
                    if (selectedPlayerUnit != null)//已选玩家棋子,悬浮敌方棋子
                    {
                        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, enemyLayer);
                        if (hit.collider != null)
                        {
                            if (hit.collider.gameObject == selectedEnermyUnit)
                                return;
                            if (selectedEnermyUnit != null)
                                EnermyUnitUnselected();
                            selectedEnermyUnit = hit.collider.gameObject;
                            EnermyUnitSelected();
                        }
                        else
                        {
                            if (selectedEnermyUnit != null)
                                EnermyUnitUnselected();
                        }
                    }
                    break;
                case TurnState.PlayerTurnEnd:
                    EndPlayerTurn();
                    break;
                case TurnState.EnemyTurn:
                    break;
                case TurnState.EnemyTurnEnd:
                    EndEnemyTurn();
                    break;
                default:
                    break;
            }
        }

        private void PlayerUnitSelected()
        {
            //选中效果
            var animator = selectedPlayerUnit.GetComponent<Animator>();
            animator.runtimeAnimatorController = VLResource.Controller_Rotate;
            animator.avatar = null;
            animator.applyRootMotion = false;
            animator.updateMode = AnimatorUpdateMode.Normal;
            animator.cullingMode = AnimatorCullingMode.AlwaysAnimate;
        }
        private void PlayerUnitUnselected()
        {
            //选中效果
            var animator = selectedPlayerUnit.GetComponent<Animator>();
            animator.runtimeAnimatorController = null;
            animator.avatar = null;
            animator.applyRootMotion = false;
            animator.updateMode = AnimatorUpdateMode.Normal;
            animator.cullingMode = AnimatorCullingMode.AlwaysAnimate;

            selectedPlayerUnit = null; ;
        }

        private void EnermyUnitSelected()
        {
            //选中效果
            var animator = selectedEnermyUnit.GetComponent<Animator>();
            animator.runtimeAnimatorController = VLResource.Controller_Rotate;
            animator.avatar = null;
            animator.applyRootMotion = false;
            animator.updateMode = AnimatorUpdateMode.Normal;
            animator.cullingMode = AnimatorCullingMode.AlwaysAnimate;
        }
        private void EnermyUnitUnselected()
        {
            //选中效果
            var animator = selectedEnermyUnit.GetComponent<Animator>();
            animator.runtimeAnimatorController = null;
            animator.avatar = null;
            animator.applyRootMotion = false;
            animator.updateMode = AnimatorUpdateMode.Normal;
            animator.cullingMode = AnimatorCullingMode.AlwaysAnimate;

            selectedEnermyUnit = null; ;
        }

        //void SelectUnit(Unit unit)
        //{
        //    if (selectedUnit != null)
        //    {
        //        selectedUnit.Deselect();
        //    }
        //    selectedUnit = unit;
        //    selectedUnit.Select();
        //}
    }

}
