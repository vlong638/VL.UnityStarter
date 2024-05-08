using System.Collections;
using UnityEngine;

namespace VL.Gaming2D._0429
{
    public class Movement_AutoMove : MonoBehaviour
    {
        [SerializeField]
        public float MoveInterval = 3f;
        [SerializeField]
        public float BaseMoveSpeed = 5f;
        public float MoveSpeed = 0;
        [SerializeField]
        public Vector3 MoveDirection = new Vector3(0, 0, 0);

        private Vector3[] Directions = {
            new Vector2(0.00f, 1.00f),
            new Vector2(0.50f, 0.87f),
            new Vector2(0.87f, 0.50f),
            new Vector2(1.00f, 0.00f),
            new Vector2(0.87f, -0.50f),
            new Vector2(0.50f, -0.87f),
            new Vector2(0.00f, -1.00f),
            new Vector2(-0.50f, -0.87f),
            new Vector2(-0.87f, -0.50f),
            new Vector2(-1.00f, 0.00f),
            new Vector2(-0.87f, 0.50f),
            new Vector2(-0.50f, 0.87f)
        };
        private Rigidbody2D RB;

        void Start()
        {
            RB = GetComponent<Rigidbody2D>();
            StartCoroutine(MoveRoutine());
        }

        IEnumerator MoveRoutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(MoveInterval);

                MoveSpeed = BaseMoveSpeed * Random.Range(0.3f, 1);
                MoveDirection = Directions[Random.Range(0, Directions.Length)];

            }
        }

        void Update()
        {
            transform.Translate(MoveDirection * MoveSpeed * Time.deltaTime, 0);
        }
    }
}
