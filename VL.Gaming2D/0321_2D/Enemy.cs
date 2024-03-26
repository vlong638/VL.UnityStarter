using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MovingObject
{
    public int playerDamage;

    Animator animator;
    Transform target;
    bool skipMove;//用于控制在一回合后,跳过一回合


    void Awake()
    {
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        Debug.Log($"Enemy Start()");
        animator = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
    }

    protected override Transform AttemptMove(int x, int y)
    {
        if (skipMove)
        {
            skipMove = false;
            return null;
        }

        var t = base.AttemptMove(x, y);
        skipMove = true;
        return t;
    }

    public void MoveEnemy()
    {
        int x = 0, y = 0;
        if (Mathf.Abs(target.position.x - transform.position.x) < float.Epsilon)
        {
            y = target.position.y > transform.position.y ? 1 : -1;
        }
        else
        {
            x = target.position.x > transform.position.x ? 1 : -1;
        }

        AttemptMove(x, y);
    }

    protected override void OnCantMove(Transform hitTransform)
    {
        Player p = hitTransform.GetComponent<Player>();
        if (p == null)
            return;
        p.LoseFood(playerDamage);
    }
}
