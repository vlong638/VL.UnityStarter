using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Gaming0311 : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log($"Game Start");
        Player = new Player(playerGO);
        int displayTime = 2;
        DisplayLevel(displayTime);
        Invoke(nameof(StartGame), displayTime);
        Debug.Log($"Game Started");
    }

    void Update()
    {
        PlayerOperation();
        EnermyOperation();
    }

    private void EnermyOperation()
    {
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

    public GameObject canvasGO;
    public GameObject playerGO;
    Player Player;

    void StartGame()
    {
        //创建地面
        GameBoard.floorPaddingX = GameBoard.StepX / 10;
        GameBoard.floorPaddingY = GameBoard.StepY / 10;
        GameBoard.floorWidth = GameBoard.StepX - GameBoard.floorPaddingX * 2;
        GameBoard.floorHeight = GameBoard.StepY - GameBoard.floorPaddingY * 2;
        Color floorColor;
        ColorUtility.TryParseHtmlString("#BC9401", out floorColor);
        for (int i = 0; i < GameBoard.XSteps; i++)
        {
            for (int j = 0; j < GameBoard.YSteps; j++)
            {
                var image = VLCreator.CreateImage("floor" + i + j, canvasGO).GetComponent<Image>();
                image.color = floorColor;
                image.rectTransform.anchorMin = new Vector2(0f, 0f);
                image.rectTransform.anchorMax = new Vector2(0f, 0f);
                image.rectTransform.pivot = new Vector2(0f, 0f);
                image.rectTransform.sizeDelta = new Vector2(GameBoard.floorWidth, GameBoard.floorHeight);
                image.rectTransform.anchoredPosition = new Vector2(i * GameBoard.StepX + GameBoard.floorPaddingX, j * GameBoard.StepY + GameBoard.floorPaddingY);
                GameBoard.Floors[i, j] = new Floor(image);
            }
        }
        //生成道具
        GameBoard.itemWidth = Mathf.Max(GameBoard.StepX / 4, 30);
        GameBoard.itemHeight = Mathf.Max(GameBoard.StepY / 4, 30);
        Color itemColor;
        ColorUtility.TryParseHtmlString("#00FF47", out itemColor);
        for (int i = 0; i < GameBoard.XSteps; i++)
        {
            for (int j = 0; j < GameBoard.YSteps; j++)
            {
                if (Random.Range(0, 100) < 90)
                    continue;
                var image = VLCreator.CreateImage("item" + i + j, canvasGO).GetComponent<Image>();
                image.color = itemColor;
                image.rectTransform.anchorMin = new Vector2(0f, 0f);
                image.rectTransform.anchorMax = new Vector2(0f, 0f);
                image.rectTransform.pivot = new Vector2(0f, 0f);
                image.rectTransform.sizeDelta = new Vector2(GameBoard.itemWidth, GameBoard.itemHeight);
                image.rectTransform.anchoredPosition = new Vector2(i * GameBoard.StepX + GameBoard.floorPaddingX, j * GameBoard.StepY + GameBoard.floorPaddingY);
                GameBoard.Floors[i, j].Items.Add(new Item(image));
            }
        }
        //生成敌人
        GameBoard.enemyWidth = Mathf.Max(GameBoard.StepX / 4, 30);
        GameBoard.enemyHeight = Mathf.Max(GameBoard.StepY / 4, 30);
        Color enemyColor;
        ColorUtility.TryParseHtmlString("#FF0F00", out enemyColor);
        for (int i = 0; i < GameBoard.XSteps; i++)
        {
            for (int j = 0; j < GameBoard.YSteps; j++)
            {
                if (Random.Range(0, 100) < 95)
                    continue;
                var image = VLCreator.CreateImage("enemy" + i + j, canvasGO).GetComponent<Image>();
                image.color = enemyColor;
                image.rectTransform.anchorMin = new Vector2(0f, 0f);
                image.rectTransform.anchorMax = new Vector2(0f, 0f);
                image.rectTransform.pivot = new Vector2(0f, 0f);
                image.rectTransform.sizeDelta = new Vector2(GameBoard.enemyWidth, GameBoard.enemyHeight);
                image.rectTransform.anchoredPosition = new Vector2(i * GameBoard.StepX + GameBoard.floorPaddingX + GameBoard.floorWidth - GameBoard.enemyWidth
                    , j * GameBoard.StepY + GameBoard.floorPaddingY + GameBoard.floorHeight - GameBoard.enemyHeight);
                GameBoard.Floors[i, j].Creatures.Add(new Creature(image));
            }
        }
        //创建Player
        playerGO.transform.parent = canvasGO.transform;
        playerGO.SetActive(true);
        RectTransform rectTransform = playerGO.GetComponent<RectTransform>();
        rectTransform.anchorMin = new Vector2(0f, 0f);
        rectTransform.anchorMax = new Vector2(0f, 0f);
        rectTransform.pivot = new Vector2(0f, 0f);
        rectTransform.anchoredPosition = new Vector2(GameBoard.floorPaddingX, GameBoard.floorPaddingY + GameBoard.floorHeight / 2 - 20);
        Player.X = 0;
        Player.Y = 0;
    }

    Movement movement;

    void PlayerOperation()
    {
        if (!Player.OperationData.IsMovingSetup && !Player.OperationData.IsMoving)
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
            else if (Input.GetKey(KeyCode.Space))
            {
                Player.OperationData.IsCollectting = true;
            }
        }
        if (Player.OperationData.IsMovingSetup)
        {
            var startPosition = playerGO.GetComponent<RectTransform>().anchoredPosition;
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
            Player.DisplaySmoothMove(playerGO, movement);
        }
        if (Player.OperationData.IsCollectting)
        {
            Player.Collect(GameBoard.Floors);
        }
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
    public static Floor[,] Floors = new Floor[XSteps, YSteps];
    internal static float floorPaddingX;
    internal static float floorPaddingY;
    internal static float floorWidth;
    internal static float floorHeight;
    internal static float itemWidth;
    internal static float itemHeight;
    internal static float enemyWidth;
    internal static float enemyHeight;
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
class Creature
{
    public string Name;
    private Image image;

    public Creature(Image image)
    {
        this.image = image;
    }
}

class OperationData
{
    public bool IsOperating { get { return !IsMovingSetup & !IsMoving & !IsCollectting; } }
    public bool IsMovingSetup = false;
    public bool IsMoving = false;
    public bool IsCollectting = false;
}
class Player
{
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

    internal void Collect(Floor[,] floors)
    {
        for (int i = floors[X, Y].Items.Count - 1; i >= 0; i--)
        {
            var item = floors[X, Y].Items[i];
            Items.Add(item);
            floors[X, Y].Items.Remove(item);
            Object.Destroy(item.Image);
            VLDebug.DelegateDebug(() => { Debug.Log($"拾取了{item.Name}"); });
        }
        OperationData.IsCollectting = false;
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
}