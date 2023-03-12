using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Gaming0311 : MonoBehaviour
{
    public GameObject canvasGO;
    public GameObject playerGO;
    Text playerText;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log($"Game Start");
        //添加关卡文本
        var textLevelGO = VLCreator.CreateText("Lv", canvasGO);
        var textLevel = textLevelGO.GetComponent<Text>();
        textLevel.text = "Day1";
        textLevel.horizontalOverflow = HorizontalWrapMode.Overflow;
        textLevel.verticalOverflow = VerticalWrapMode.Overflow;
        var rect = textLevelGO.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(160, 30);
        Destroy(textLevelGO, 2);
        Invoke(nameof(StartGame), 2);
        Debug.Log($"Game Started");
    }

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


    bool isJumpingSetup = false;
    bool isJumping = false;
    Vector2 startPosition;
    Vector2 targetPosition;
    Vector2 jump;
    float jumpStartTime = 0f;
    float jumpDuration = 0.5f;

    void Update()
    {
        if (Input.GetKey(KeyCode.W) && !isJumpingSetup && !isJumping)
        {
            isJumpingSetup = true;
            jump = new Vector2(0, 100);
        }
        if (Input.GetKey(KeyCode.A) && !isJumpingSetup && !isJumping)
        {
            isJumpingSetup = true;
            jump = new Vector2(-100, 0);
        }
        if (Input.GetKey(KeyCode.S) && !isJumpingSetup && !isJumping)
        {
            isJumpingSetup = true;
            jump = new Vector2(0, -100);
        }
        if (Input.GetKey(KeyCode.D) && !isJumpingSetup && !isJumping)
        {
            isJumpingSetup = true;
            jump = new Vector2(100, 0);
        }
        if (isJumpingSetup)
        {
            startPosition = playerText.rectTransform.anchoredPosition;
            targetPosition = new Vector2(startPosition.x + jump.x, startPosition.y + jump.y);
            jumpStartTime = Time.time;
            isJumping = true;
            isJumpingSetup = false;
        }
        if (isJumping)
        {
            Jump(playerText);
        }
    }

    float clampTime;
    void Jump(Text go)
    {
        float elapsedTime = Time.time - jumpStartTime;
        clampTime = Mathf.Clamp01(elapsedTime / jumpDuration);
        Vector2 newPosition = Vector2.Lerp(startPosition, targetPosition, clampTime);
        go.rectTransform.anchoredPosition = newPosition;
        if (clampTime >= 1.0f)
        {
            isJumping = false;
            isJumpingSetup = false;
        }
    }
}