using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public BoardManager boardManager;
    public int playerFoodPoints = 100;
    [HideInInspector]
    public bool playersTurn = true;

    float turnDelay = 0.1f;
    int level = 1;
    List<Enemy> enemies;
    bool enemiesMoving;

    void InitGame()
    {
        enemies.Clear();
        boardManager.SetupScene(level);
    }

    public void GameOver()
    {
        enabled = false;
    }

    IEnumerator MoveEnemies()
    {
        enemiesMoving = true;
        yield return new WaitForSeconds(turnDelay);
        if (enemies.Count==0)
            yield return new WaitForSeconds(turnDelay);
        for (int i = 0; i < enemies.Count; i++)
        {
            enemies[i].MoveEnemy();
            yield return new WaitForSeconds(enemies[i].moveTime);
        }
        playersTurn = true;
        enemiesMoving = false;
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
        if (playersTurn || enemiesMoving)
            return;

        StartCoroutine(MoveEnemies());
    } 
}
