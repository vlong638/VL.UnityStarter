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
        float width = 2560, height = 1440;
        int xSteps = 20, ySteps = 12;
        stepX = width / xSteps;
        stepY = height / ySteps;
        float paddingX = stepX / 10;
        float paddingY = stepY / 10;
        float floorWidth = stepX - paddingX * 2;
        float floorHeight = stepY - paddingY * 2;
        Color floorColor;
        ColorUtility.TryParseHtmlString("#BC9401", out floorColor);
        for (int i = 0; i < xSteps; i++)
        {
            for (int j = 0; j < ySteps; j++)
            {
                var image = VLCreator.CreateImage("floor" + i + j, canvasGO).GetComponent<Image>();
                image.color = floorColor;
                image.rectTransform.anchorMin = new Vector2(0f, 0f);
                image.rectTransform.anchorMax = new Vector2(0f, 0f);
                image.rectTransform.pivot = new Vector2(0f, 0f);
                image.rectTransform.sizeDelta = new Vector2(floorWidth, floorHeight);
                image.rectTransform.anchoredPosition = new Vector2(i * stepX + paddingX, j * stepY + paddingY);
            }
        }


        //生成道具
        //生成敌人
        //创建Player
        playerGO.transform.parent = canvasGO.transform;
        playerGO.SetActive(true);
        RectTransform rectTransform = playerGO.GetComponent<RectTransform>();
        rectTransform.anchorMin = new Vector2(0f, 0f);
        rectTransform.anchorMax = new Vector2(0f, 0f);
        rectTransform.pivot = new Vector2(0f, 0f);
        rectTransform.anchoredPosition = new Vector2(0, floorHeight / 2);
    }

    bool isMovingSetup = false;
    bool isMoving = false;
    Vector2 move;
    float stepX, stepY;

    class Movement
    {
        public Vector2 startPosition;
        public Vector2 targetPosition;
        public float moveStartTime = 0f;
        public float moveDuration = 0.2f;
    }
    Movement movement;

    void PlayerMove()
    {
        if (Input.GetKey(KeyCode.W) && !isMovingSetup && !isMoving)
        {
            isMovingSetup = true;
            move = new Vector2(0, stepY);
        }
        if (Input.GetKey(KeyCode.S) && !isMovingSetup && !isMoving)
        {
            isMovingSetup = true;
            move = new Vector2(0, -stepY);
        }
        if (Input.GetKey(KeyCode.A) && !isMovingSetup && !isMoving)
        {
            isMovingSetup = true;
            move = new Vector2(-stepX, 0);
        }
        if (Input.GetKey(KeyCode.D) && !isMovingSetup && !isMoving)
        {
            isMovingSetup = true;
            move = new Vector2(stepX, 0);
        }
        if (isMovingSetup)
        {
            var startPosition = playerGO.GetComponent<RectTransform>().anchoredPosition;
            var targetPosition = new Vector2(startPosition.x + move.x, startPosition.y + move.y);
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
