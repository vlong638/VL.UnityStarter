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
    Text playerText;

    void StartGame()
    {
        playerGO.transform.parent = canvasGO.transform;
        playerGO.SetActive(true);
        RectTransform rectTransform = playerGO.GetComponent<RectTransform>();
        rectTransform.anchorMin = new Vector2(0f, 0f);
        rectTransform.anchorMax = new Vector2(1f, 1f);
        rectTransform.offsetMin = new Vector2(0f, 0f);
        rectTransform.offsetMax = new Vector2(0f, 0f);
        rectTransform.localPosition = new Vector3(0f, 0f, 0f);
        playerText = playerGO.GetComponent<Text>();
    }

    void Update()
    {
        PlayerMove();
    }

    bool isMovingSetup = false;
    bool isMoving = false;
    Vector2 startPosition;
    Vector2 targetPosition;
    Vector2 move;
    float moveStartTime = 0f;
    float moveDuration = 0.2f;
    int step = 20;

    void PlayerMove()
    {
        if (Input.GetKey(KeyCode.W) && !isMovingSetup && !isMoving)
        {
            isMovingSetup = true;
            move = new Vector2(0, step);
        }
        if (Input.GetKey(KeyCode.A) && !isMovingSetup && !isMoving)
        {
            isMovingSetup = true;
            move = new Vector2(-step, 0);
        }
        if (Input.GetKey(KeyCode.S) && !isMovingSetup && !isMoving)
        {
            isMovingSetup = true;
            move = new Vector2(0, -step);
        }
        if (Input.GetKey(KeyCode.D) && !isMovingSetup && !isMoving)
        {
            isMovingSetup = true;
            move = new Vector2(step, 0);
        }
        if (isMovingSetup)
        {
            startPosition = playerText.rectTransform.anchoredPosition;
            targetPosition = new Vector2(startPosition.x + move.x, startPosition.y + move.y);
            moveStartTime = Time.time;
            isMoving = true;
            isMovingSetup = false;
        }
        if (isMoving)
        {
            SmoothMove(playerText);
        }
    }

    void SmoothMove(Text go)
    {
        float elapsedTime = Time.time - moveStartTime;
        float clampTime = Mathf.Clamp01(elapsedTime / moveDuration);
        Vector2 newPosition = Vector2.Lerp(startPosition, targetPosition, clampTime);
        go.rectTransform.anchoredPosition = newPosition;
        if (clampTime >= 1.0f)
        {
            isMoving = false;
            isMovingSetup = false;
        }
    }
}