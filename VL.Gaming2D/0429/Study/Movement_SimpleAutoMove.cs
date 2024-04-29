using System.Collections;
using UnityEngine;

namespace VL.Gaming2D._0429
{
    public class Movement_SimpleAutoMove : MonoBehaviour
    {
        [SerializeField]
        public float MoveInterval = 3f;
        [SerializeField]
        public float BaseMoveSpeed = 5f;
        public float MoveSpeed = 0;
        [SerializeField]
        public Vector3 MoveDirection = new Vector3(0, 0, 0);

        private Vector3[] Directions = { Vector2.up, Vector2.down, Vector2.left, Vector2.right }; 
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
