using System;
using System.Collections;
using UnityEngine;
using VL.Gaming2D;

public class MovingObject : MonoBehaviour
{
    public float moveTime = 0.1f;
    public LayerMask blockingLayer;

    BoxCollider2D boxCollider;
    Rigidbody2D rigidBody;
    float inverseMoveTime;

    protected IEnumerator SmoothMovement(Vector3 end)
    {
        while (!transform.position.IsZeroDistance(end))
        {
            Vector3 newPosition = Vector3.MoveTowards(transform.position, end, inverseMoveTime * Time.deltaTime);
            rigidBody.MovePosition(newPosition);
            yield return null;
        }
    }

    protected bool Move(int x, int y, out RaycastHit2D hit)
    {
        Vector2 start = transform.position;
        Vector2 end = start + new Vector2(x, y);

        boxCollider.enabled = false;
        hit = Physics2D.Linecast(start, end, blockingLayer);
        boxCollider.enabled = true;

        if (hit.transform == null)
        {
            StartCoroutine(SmoothMovement(end));
            return true;
        }

        return false;
    }

    protected virtual GameObject AttemptMove(int x, int y)
    {
        RaycastHit2D hit;
        bool canMove = Move(x, y, out hit);

        if (hit.transform == null)
            return null;

        GameObject hitComponent = hit.transform.GetComponent<GameObject>();
        if (!canMove && hitComponent != null)
            OnCantMove(hitComponent);
        return hitComponent;
    }

    protected virtual void OnCantMove(GameObject hitComponent)
    {
        throw new NotImplementedException();
    }

    // Start is called before the first frame update
    protected void Init()
    {
        Debug.Log($"MovingObject Init()");
        boxCollider = GetComponent<BoxCollider2D>();
        Debug.Log($"boxCollider:" + boxCollider is null ? " null" : boxCollider.ToString());
        rigidBody = GetComponent<Rigidbody2D>();
        inverseMoveTime = 1f / moveTime;
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
}
