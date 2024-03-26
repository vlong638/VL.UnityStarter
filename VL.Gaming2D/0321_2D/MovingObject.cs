using System;
using System.Collections;
using UnityEngine;
using VL.Gaming2D;

public class MovingObject : MonoBehaviour
{
    public float moveTime = 0.1f;
    public LayerMask blockingLayer;
    protected bool isMoving = false;

    BoxCollider2D boxCollider;
    Rigidbody2D rigidBody;
    float inverseMoveTime;

    protected IEnumerator SmoothMovement(Vector3 end)
    {
        isMoving = true;
        while ((transform.position - end).sqrMagnitude > float.Epsilon)
        {
            Vector3 newPosition = Vector3.MoveTowards(transform.position, end, inverseMoveTime * Time.deltaTime);
            rigidBody.MovePosition(newPosition);
            yield return null;
        }
        isMoving = false;
    }

    protected bool Move(int x, int y, out RaycastHit2D hit)
    {
        Vector2 start = transform.position;
        Vector2 end = start + new Vector2(x, y);
        Debug.Log($"{x},{y},Move from {start.ToString()} to {end.ToString()}");

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

    protected virtual Transform AttemptMove(int x, int y)
    {
        RaycastHit2D hit;
        bool canMove = Move(x, y, out hit);

        if (hit.transform == null)
            return null;

        Transform hitTransform = hit.transform;
        if (!canMove && hitTransform != null)
            OnCantMove(hitTransform);
        return hitTransform;
    }

    protected virtual void OnCantMove(Transform hitTransform)
    {
        throw new NotImplementedException();
    }

    protected virtual void Start()
    {
        Debug.Log($"MovingObject Init()");
        boxCollider = GetComponent<BoxCollider2D>();
        Debug.Log($"boxCollider:" + boxCollider is null ? " null" : boxCollider.ToString());
        rigidBody = GetComponent<Rigidbody2D>();
        inverseMoveTime = 1f / moveTime;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
