using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MovingObject
{
    public int wallDamage = 1;
    public int pointsPerFood = 10;
    public int pointsPerSoda = 20;
    public float restartLevelDelay = 1f;

    Animator animator;
    public string trigger_PlayerChop = "PlayerChop";
    public string trigger_PlayerHit = "PlayerHit";
    int food;
    Text foodText;

    public AudioClip[] playerChopClips;
    public AudioClip[] playMoveClips;

    void Awake()
    {
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        Debug.Log($"Player Start()");
        animator = GetComponent<Animator>();
        food = GameManager.instance.playerFoodPoints;
        foodText = GameObject.Find("FoodText").GetComponent<Text>();
        UpdateFoodText($"Food:{food}");
        GameManager.instance.SetPlayer(this);

        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.playersTurn && this.isMoving)
            return;

        int horizontal = (int)Input.GetAxisRaw("Horizontal");// + (Input.GetKey(KeyCode.D) ? 1 : 0) + (Input.GetKey(KeyCode.A) ? -1 : 0);
        int vertical = (int)Input.GetAxisRaw("Vertical");// + (Input.GetKey(KeyCode.W) ? 1 : 0) + (Input.GetKey(KeyCode.S) ? -1 : 0);

        if (horizontal != 0)
            vertical = 0;
        if (horizontal != 0 || vertical != 0)
            AttemptMove(horizontal, vertical);

    }

    void OnDisable()
    {
        GameManager.instance.playerFoodPoints = food;
    }

    void CheckIfGameOver()
    {
        if (food <= 0)
        {
            GameManager.instance.GameOver();
        }
    }

    protected override Transform AttemptMove(int x, int y)
    {
        food--;
        SoundManager.instance.PlaySingle(playMoveClips);
        UpdateFoodText($"Food:{food}");
        var t = base.AttemptMove(x, y);
        CheckIfGameOver();
        GameManager.instance.playersTurn = false;
        return t;
    }

    private void UpdateFoodText(string text)
    {
        foodText.text = text;
    }

    protected override void OnCantMove(Transform hitTransform)
    {
        //Wall
        Wall hitWall = hitTransform.GetComponent<Wall>();
        if (hitWall != null)
        {
            hitWall.DamageWall(wallDamage);
            animator.SetTrigger(trigger_PlayerChop);
        }
        //TODO
        //Enermy
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Exit")
        {
            Invoke("Restart", restartLevelDelay);
            enabled = false;
        }
        else if (collision.tag == "Food")
        {
            food += pointsPerFood;
            UpdateFoodText($"+{pointsPerFood},Food:{food}");
            collision.gameObject.SetActive(false);

        }
        else if (collision.tag == "Soda")
        {
            food += pointsPerSoda;
            UpdateFoodText($"+{pointsPerSoda},Food:{food}");
            collision.gameObject.SetActive(false);
        }
    }

    void Restart()
    {
        //Application.LoadLevel(Application.loadedLevel);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoseFood(int loss)
    {
        animator.SetTrigger(trigger_PlayerHit);
        food -= loss;
        UpdateFoodText($"-{loss} Food:{food}");
        CheckIfGameOver();
    }
}
