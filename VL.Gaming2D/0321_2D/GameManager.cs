using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public BoardManager boardManager;
    public float turnDelay = 0.1f;
    public float levelStartDelay = 2f;
    public int playerFoodPoints = 100;
    [HideInInspector]
    public bool playersTurn = true;

    int level = 0;
    Player player;
    List<Enemy> enemies;
    bool enemiesMoving;
    bool doingSetup;
    Text levelText;
    GameObject levelImage;

    void InitGame()
    {
        doingSetup = true;

        levelImage = GameObject.Find("LevelImage");
        levelText = GameObject.Find("LevelText").GetComponent<Text>();
        levelText.text = "Day " + level;
        ShowLevelImage();
        Invoke(nameof(HideLevelImage), levelStartDelay);
        enemies.Clear();
        boardManager.SetupScene(level);

        doingSetup = false;
    }

    public void ShowLevelImage()
    {
        levelImage.SetActive(true);
    }
    public void HideLevelImage()
    {
        levelImage.SetActive(false);
    }

    public void GameOver()
    {
        levelText.text = $"After {level} days, you starved.";
        ShowLevelImage();
        enabled = false;
    }

    IEnumerator MoveEnemies()
    {
        enemiesMoving = true;
        yield return new WaitForSeconds(turnDelay);
        if (enemies.Count == 0)
            yield return new WaitForSeconds(turnDelay);
        for (int i = 0; i < enemies.Count; i++)
        {
            enemies[i].MoveEnemy();
            yield return new WaitForSeconds(enemies[i].moveTime);
        }
        playersTurn = true;
        enemiesMoving = false;
    }

    void OnLevelWasLoaded(int index)
    {
        level++;
        InitGame();
    }

    public void SetPlayer(Player p)
    {
        player = p;
    }

    public void AddEnemyToList(Enemy e)
    {
        enemies.Add(e);
    }


    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);

        enemies = new List<Enemy>();
        boardManager = GetComponent<BoardManager>();

        InitGame();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (playersTurn || enemiesMoving || doingSetup)
            return;

        StartCoroutine(MoveEnemies());
    }
}
