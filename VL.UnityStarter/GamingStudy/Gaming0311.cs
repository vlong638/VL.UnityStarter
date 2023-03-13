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
        int displayTime = 2;
        DisplayLevel(displayTime);
        Invoke(nameof(StartGame), displayTime);
        Debug.Log($"Game Started");
    }

    void Update()
    {
        PlayerMove();
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

    void StartGame()
    {
        //创建地面
        float floorPaddingX = GameBoard.StepX / 10;
        float floorPaddingY = GameBoard.StepY / 10;
        float floorWidth = GameBoard.StepX - floorPaddingX * 2;
        float floorHeight = GameBoard.StepY - floorPaddingY * 2;
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
                image.rectTransform.sizeDelta = new Vector2(floorWidth, floorHeight);
                image.rectTransform.anchoredPosition = new Vector2(i * GameBoard.StepX + floorPaddingX, j * GameBoard.StepY + floorPaddingY);
                GameBoard.Floors[i, j] = new Floor(image);
            }
        }
        //生成道具
        float itemWidth = Mathf.Max(GameBoard.StepX / 4, 60);
        float itemHeight = Mathf.Max(GameBoard.StepY / 4, 30);
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
                image.rectTransform.sizeDelta = new Vector2(itemWidth, itemHeight);
                image.rectTransform.anchoredPosition = new Vector2(i * GameBoard.StepX + floorPaddingX, j * GameBoard.StepY + floorPaddingY);
                GameBoard.Floors[i, j].Items.Add(new Item(image));
            }
        }
        //生成敌人
        float enemyWidth = Mathf.Max(GameBoard.StepX / 4, 60);
        float enemyHeight = Mathf.Max(GameBoard.StepY / 4, 30);
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
                image.rectTransform.sizeDelta = new Vector2(enemyWidth, enemyHeight);
                image.rectTransform.anchoredPosition = new Vector2(i * GameBoard.StepX + floorPaddingX + floorWidth - enemyWidth
                    , j * GameBoard.StepY + floorPaddingY + floorHeight - enemyHeight);
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
        rectTransform.anchoredPosition = new Vector2(floorPaddingX, floorPaddingY + floorHeight / 2 - 20);
    }

    bool isMovingSetup = false;
    bool isMoving = false;
    Vector2 moveData;
    Movement movement;

    void PlayerMove()
    {
        if (Input.GetKey(KeyCode.W) && !isMovingSetup && !isMoving)
        {
            isMovingSetup = true;
            moveData = new Vector2(0, GameBoard.StepY);
        }
        if (Input.GetKey(KeyCode.S) && !isMovingSetup && !isMoving)
        {
            isMovingSetup = true;
            moveData = new Vector2(0, -GameBoard.StepY);
        }
        if (Input.GetKey(KeyCode.A) && !isMovingSetup && !isMoving)
        {
            isMovingSetup = true;
            moveData = new Vector2(-GameBoard.StepX, 0);
        }
        if (Input.GetKey(KeyCode.D) && !isMovingSetup && !isMoving)
        {
            isMovingSetup = true;
            moveData = new Vector2(GameBoard.StepX, 0);
        }
        if (isMovingSetup)
        {
            var startPosition = playerGO.GetComponent<RectTransform>().anchoredPosition;
            var targetPosition = new Vector2(startPosition.x + moveData.x, startPosition.y + moveData.y);
            movement = new Movement()
            {
                startPosition = startPosition,
                targetPosition = targetPosition,
                moveStartTime = Time.time,
            };
            isMoving = true;
            isMovingSetup = false;
        }
        if (isMoving)
        {
            SmoothMove(playerGO, movement);
        }
    }

    void SmoothMove(GameObject go, Movement m)
    {
        float elapsedTime = Time.time - m.moveStartTime;
        float clampTime = Mathf.Clamp01(elapsedTime / m.moveDuration);
        Vector2 newPosition = Vector2.Lerp(m.startPosition, m.targetPosition, clampTime);
        var rectTransform = go.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = newPosition;
        VLDebug.DelegateDebug(() => {
            //go.text = $"X:{newPosition.x},Y:{newPosition.y}"; 
            Debug.Log($"X:{newPosition.x},Y:{newPosition.y}");
        });
        if (clampTime >= 1.0f)
        {
            isMoving = false;
            isMovingSetup = false;
        }
    }
}

class Movement
{
    public Vector2 startPosition;
    public Vector2 targetPosition;
    public float moveStartTime = 0f;
    public float moveDuration = 0.2f;
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
    private Image image;

    public Item(Image image)
    {
        this.image = image;
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
