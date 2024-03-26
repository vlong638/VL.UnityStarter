using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public BoardManager sceneManager;
    public int playerFoodPoints = 100;
    [HideInInspector]
    public bool playersTurn = true;

    int level = 1;

    public void GameOver()
    {
        enabled = false;
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        sceneManager = GetComponent<BoardManager>();
        sceneManager.SetupScene(level);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
