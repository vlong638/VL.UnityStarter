using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Gaming0311 : MonoBehaviour
{
    GameBoard GameBoard = new GameBoard();
    public GameObject canvasGO;
    public GameObject playerGO;
    public GameObject textGO;

    void Start()
    {
        Debug.Log($"Game Start");
        GameBoard.Player = new Player(playerGO)
        {
            Attr_HP = 100,
            Attr_AttackMax = 10,
            Attr_AttackMin = 5,
            Attr_Defend = 3
        };
        GameBoard.CanvasGO = canvasGO;
        int displayTime = 2;
        DisplayLevel(displayTime);
        Invoke(nameof(StartGame), displayTime);
        Debug.Log($"Game Started");
    }

    void Update()
    {
        GameBoard.PlayerOperation();
        GameBoard.EnermyOperation();
    }

    void DisplayLevel(int displayTime)
    {
        //添加关卡文本
        var textLevelGO = VLCreator.CreateText("Lv", canvasGO);
        var textLevel = textLevelGO.GetComponent<Text>();
        textLevel.text = "Day1";
        textLevel.horizontalOverflow = HorizontalWrapMode.Overflow;
        textLevel.verticalOverflow = VerticalWrapMode.Overflow;
        var rect = textLevelGO.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(160, 30);
        Destroy(textLevelGO, displayTime);
    }


    void StartGame()
    {
        GameBoard.Init();
    }

}
class Movement
{
    public int X, Y;
    public float XLength { get { return X * GameBoard.StepX; } }
    public float YLength { get { return Y * GameBoard.StepY; } }

    public Vector2 startPosition;
    public Vector2 targetPosition;
    public float moveStartTime = 0f;
    public float moveDuration = 0.2f;

    public Movement(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }
}
class GameBoard
{
    public static float Width = 2560;
    public static float Height = 1440;
    public static int XSteps = 20;
    public static int YSteps = 12;
    public static float StepX = Width / XSteps;
    public static float StepY = Height / YSteps;
    public Floor[,] Floors;
    internal float floorPaddingX;
    internal float floorPaddingY;
    internal float floorWidth;
    internal float floorHeight;
    internal float itemWidth;
    internal float itemHeight;
    internal float enemyWidth;
    internal float enemyHeight;
    internal Player Player;
    internal Movement movement;

    public GameObject CanvasGO { get; internal set; }
    public GameObject ScrollViewGO { get; private set; }
    public GameObject ScrollTextGO { get; private set; }
    public Text ScrollText { get; private set; }

    public ScrollRect ScrollRect;

    public GameBoard()
    {
        Floors = new Floor[XSteps, YSteps];
    }

    public void PlayerOperation()
    {
        if (!Player.OperationData.IsOperating)
        {
            if (Input.GetKey(KeyCode.W))
            {
                Player.OperationData.IsMovingSetup = true;
                movement = new Movement(0, 1);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                Player.OperationData.IsMovingSetup = true;
                movement = new Movement(0, -1);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                Player.OperationData.IsMovingSetup = true;
                movement = new Movement(-1, 0);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                Player.OperationData.IsMovingSetup = true;
                movement = new Movement(1, 0);
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                Player.OperationData.IsCollecttingSetup = true;
            }
            else if (Input.GetKeyDown(KeyCode.F))
            {
                Player.OperationData.IsAttackingSetup = true;
            }
        }
        if (Player.OperationData.IsMovingSetup)
        {
            var startPosition = Player.PlayerGO.GetComponent<RectTransform>().anchoredPosition;
            var targetPosition = new Vector2(startPosition.x + movement.XLength, startPosition.y + movement.YLength);
            movement.startPosition = startPosition;
            movement.targetPosition = targetPosition;
            movement.moveStartTime = Time.time;
            Player.OperationData.IsMoving = true;
            Player.OperationData.IsMovingSetup = false;

            Player.Move(movement);
        }
        if (Player.OperationData.IsMoving)
        {
            Player.DisplaySmoothMove(Player.PlayerGO, movement);
        }
        if (Player.OperationData.IsCollecttingSetup)
        {
            Player.Collect(Floors);
        }
        if (Player.OperationData.IsAttackingSetup)
        {
            Player.Attack(Floors);
        }
    }

    public void EnermyOperation()
    {
        //if (floors[X, Y].Items.Count == 0)
        //{
        //    VLDebug.DelegateDebug(() => { Debug.Log($"{Name}捡了一把空气"); });
        //    return;
        //}
        //for (int i = floors[X, Y].Items.Count - 1; i >= 0; i--)
        //{
        //    var item = floors[X, Y].Items[i];
        //    Items.Add(item);
        //    floors[X, Y].Items.Remove(item);
        //    Object.Destroy(item.Image);
        //    VLDebug.DelegateDebug(() => { Debug.Log($"拾取了{item.Name}"); });
        //}
        //OperationData.IsCollecttingSetup = false;
    }

    internal void Init()
    {//创建地面
        floorPaddingX = StepX / 10;
        floorPaddingY = StepY / 10;
        floorWidth = StepX - floorPaddingX * 2;
        floorHeight = StepY - floorPaddingY * 2;
        Color floorColor;
        ColorUtility.TryParseHtmlString("#BC9401", out floorColor);
        for (int i = 0; i < XSteps; i++)
        {
            for (int j = 0; j < YSteps; j++)
            {
                var image = VLCreator.CreateImage("floor" + i + j, CanvasGO).GetComponent<Image>();
                image.color = floorColor;
                image.rectTransform.anchorMin = new Vector2(0f, 0f);
                image.rectTransform.anchorMax = new Vector2(0f, 0f);
                image.rectTransform.pivot = new Vector2(0f, 0f);
                image.rectTransform.sizeDelta = new Vector2(floorWidth, floorHeight);
                image.rectTransform.anchoredPosition = new Vector2(i * StepX + floorPaddingX, j * StepY + floorPaddingY);
                Floors[i, j] = new Floor(image);
            }
        }
        //生成道具
        itemWidth = Mathf.Max(StepX / 4, 30);
        itemHeight = Mathf.Max(StepY / 4, 30);
        Color itemColor;
        ColorUtility.TryParseHtmlString("#00FF47", out itemColor);
        for (int i = 0; i < XSteps; i++)
        {
            for (int j = 0; j < YSteps; j++)
            {
                if (Random.Range(0, 100) < 90)
                    continue;
                var image = VLCreator.CreateImage("item" + i + j, CanvasGO).GetComponent<Image>();
                image.color = itemColor;
                image.rectTransform.anchorMin = new Vector2(0f, 0f);
                image.rectTransform.anchorMax = new Vector2(0f, 0f);
                image.rectTransform.pivot = new Vector2(0f, 0f);
                image.rectTransform.sizeDelta = new Vector2(itemWidth, itemHeight);
                image.rectTransform.anchoredPosition = new Vector2(i * StepX + floorPaddingX, j * StepY + floorPaddingY);
                Floors[i, j].Items.Add(new Item(image)
                {
                    Name = image.name,
                });
            }
        }
        //生成敌人
        enemyWidth = Mathf.Max(StepX / 4, 30);
        enemyHeight = Mathf.Max(StepY / 4, 30);
        Color enemyColor;
        ColorUtility.TryParseHtmlString("#FF0F00", out enemyColor);
        for (int i = 0; i < XSteps; i++)
        {
            for (int j = 0; j < YSteps; j++)
            {
                if (Random.Range(0, 100) < 95)
                    continue;
                var image = VLCreator.CreateImage("enemy" + i + j, CanvasGO).GetComponent<Image>();
                image.color = enemyColor;
                image.rectTransform.anchorMin = new Vector2(0f, 0f);
                image.rectTransform.anchorMax = new Vector2(0f, 0f);
                image.rectTransform.pivot = new Vector2(0f, 0f);
                image.rectTransform.sizeDelta = new Vector2(enemyWidth, enemyHeight);
                image.rectTransform.anchoredPosition = new Vector2(i * StepX + floorPaddingX + floorWidth - enemyWidth
                    , j * StepY + floorPaddingY + floorHeight - enemyHeight);
                Floors[i, j].Creatures.Add(new Creature(image)
                {
                    Name = image.name,
                    Attr_HP = Random.Range(15, 50),
                    Attr_AttackMax = Random.Range(7, 10),
                    Attr_AttackMin = Random.Range(4, 7),
                    Attr_Defend = Random.Range(3, 6),
                }); ;
            }
        }
        //创建Player
        Player.PlayerGO.transform.parent = CanvasGO.transform;
        Player.PlayerGO.SetActive(true);
        RectTransform rect = Player.PlayerGO.GetComponent<RectTransform>();
        rect.anchorMin = new Vector2(0f, 0f);
        rect.anchorMax = new Vector2(0f, 0f);
        rect.pivot = new Vector2(0f, 0f);
        rect.anchoredPosition = new Vector2(floorPaddingX, floorPaddingY + floorHeight / 2 - 20);
        Player.X = 0;
        Player.Y = 0;
        Player.Name = Player.PlayerGO.GetComponentInChildren<Text>().text;
        Player.GameBoard = this;
        //创建文本输出框
        ScrollViewGO = VLCreator.CreateScrollView("TextDisplay", CanvasGO);
        ScrollRect = ScrollViewGO.GetComponent<ScrollRect>();
        rect = ScrollViewGO.GetComponent<RectTransform>();
        rect.anchorMin = new Vector2(0, 0);
        rect.anchorMax = new Vector2(0, 0);
        rect.pivot = new Vector2(0, 0);
        rect.sizeDelta = new Vector2(600, 800);
        rect.anchoredPosition = new Vector2(0, 0);
        var canvasGroup = ScrollViewGO.AddComponent<CanvasGroup>();
        canvasGroup.alpha = 0.6f;
        ScrollTextGO = VLCreator.CreateText("ScrollText", ScrollViewGO);
        rect = ScrollTextGO.GetComponent<RectTransform>();
        rect.anchorMin = new Vector2(0, 0);
        rect.anchorMax = new Vector2(1, 1);
        rect.offsetMin = new Vector2(0f, 0f);
        rect.offsetMax = new Vector2(0f, 0f);
        rect.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 0f, rect.rect.width);
        rect.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Right, 0f, rect.rect.width);
        rect.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 0f, rect.rect.height);
        rect.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom, 0f, rect.rect.height);
        ScrollText = ScrollTextGO.GetComponent<Text>();
        ScrollText.fontSize = 32;
        ScrollText.color = Color.black;
        ScrollText.alignment = TextAnchor.UpperLeft;
    }

    public void DisplayText(string message)
    {
        var texts = ScrollText.text.Split('\n').ToList();
        texts.Add(message);
        if (texts.Count > 20)
            texts.RemoveAt(0);
        ScrollText.text = string.Join("\n", texts);
    }
}
class Floor
{
    public int X;
    public int Y;
    public FloorType FloorType;
    public List<Item> Items = new List<Item>();
    public List<Creature> Creatures = new List<Creature>();
    private Image image;

    public Floor(Image image)
    {
        this.image = image;
    }
}
enum FloorType
{
    None = 0,
    Plain,
    Grassland,
    Forest,
    Mountain,
    River,
}
class Item
{
    public string Name;
    public Image Image;

    public Item(Image image)
    {
        this.Image = image;
    }
}
class Creature : AttackableCreature
{
    public string Name;
    public Image Image;

    public Creature(Image image)
    {
        this.Image = image;
    }
}
class OperationData
{
    public bool IsOperating { get { return IsMovingSetup | IsMoving | IsCollecttingSetup | IsAttackingSetup; } }


    public bool IsAttackingSetup = false;
    public bool IsMovingSetup = false;
    public bool IsMoving = false;
    public bool IsCollecttingSetup = false;
}
class Player : AttackableCreature
{
    public GameBoard GameBoard { get; internal set; }

    public string Name;
    public GameObject PlayerGO;
    public OperationData OperationData = new OperationData();
    public int X;
    public int Y;
    public List<Item> Items = new List<Item>();

    public Player(GameObject playerGO)
    {
        this.PlayerGO = playerGO;
    }

    public void DisplaySmoothMove(GameObject go, Movement m)
    {
        float elapsedTime = Time.time - m.moveStartTime;
        float clampTime = Mathf.Clamp01(elapsedTime / m.moveDuration);
        Vector2 newPosition = Vector2.Lerp(m.startPosition, m.targetPosition, clampTime);
        var rectTransform = go.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = newPosition;
        VLDebug.DelegateDebug(() =>
        {
            Debug.Log($"DisplaySmoothMove X:{newPosition.x},Y:{newPosition.y}");
        });
        if (clampTime >= 1.0f)
        {
            OperationData.IsMoving = false;
            OperationData.IsMovingSetup = false;
        }
    }

    internal void Move(Movement movement)
    {
        X += movement.X;
        Y += movement.Y;
        VLDebug.DelegateDebug(() =>
        {
            Debug.Log($"Move X:{X},Y:{Y}");
        });
    }

    internal void Collect(Floor[,] floors)
    {
        OperationData.IsCollecttingSetup = false;
        if (floors[X, Y].Items.Count == 0)
        {
            GameBoard.DisplayText($"{Name}捡了一把空气");
            return;
        }
        for (int i = floors[X, Y].Items.Count - 1; i >= 0; i--)
        {
            var item = floors[X, Y].Items[i];
            Items.Add(item);
            floors[X, Y].Items.Remove(item);
            Object.Destroy(item.Image);
            GameBoard.DisplayText($"{Name}拾取了{item.Name}");
        }
    }

    internal void Attack(Floor[,] floors)
    {
        OperationData.IsAttackingSetup = false;
        var creature = floors[X, Y].Creatures.FirstOrDefault();
        if (creature == null)
        {
            GameBoard.DisplayText($"{Name}打在了空气中");
            return;
        }
        GameBoard.DisplayText($"{Name}:{GetAttackableCreatureDiscription()}");
        GameBoard.DisplayText($"{creature.Name}:{creature.GetAttackableCreatureDiscription()}");
        var result = Attack(creature);
        GameBoard.DisplayText($"{Name}攻击了{creature.Name},造成了{result.ChangedHP}点伤害");
        if (result.IsDead)
        {
            floors[X, Y].Creatures.Remove(creature);
            Object.Destroy(creature.Image);
            GameBoard.DisplayText($"{creature.Name}被打倒了");
        }
        else
        {
            result = creature.Attack(this);
            GameBoard.DisplayText($"{creature.Name}攻击了{Name},造成了{result.ChangedHP}点伤害");
            if (result.IsDead)
            {
                PlayerGO.SetActive(false);
                GameBoard.DisplayText($"{Name}被打倒了");
            }
        }
    }
}

class AttackableCreature
{
    public int Attr_HP;
    public int Attr_AttackMax;

    public int Attr_AttackMin;
    public int Attr_Defend;

    internal AttackResult Attack(AttackableCreature creature)
    {
        AttackResult result = new AttackResult();
        result.ChangedHP = Mathf.Max(0, Random.Range(Attr_AttackMin, Attr_AttackMax) - creature.Attr_Defend);
        creature.Attr_HP -= result.ChangedHP;
        result.IsDead = creature.Attr_HP <= 0;
        return result;
    }

    public string GetAttackableCreatureDiscription()
    {
        return $@"生命:{Attr_HP},攻击:{Attr_AttackMax},防御:{Attr_Defend}";
    }
}

class AttackResult
{
    public int ChangedHP;
    public bool IsDead;
}

