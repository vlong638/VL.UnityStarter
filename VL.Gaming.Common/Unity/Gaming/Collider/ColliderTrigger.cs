using System.Collections.Generic;
using UnityEngine;

namespace VL.Gaming.Unity.Gaming.Collider
{
    public class ColliderTrigger : MonoBehaviour
    {
        [SerializeField]
        public GameObject DialogueBox;
        Queue<int> myQueue = new Queue<int>();

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                Debug.Log("Player entered the trigger area!");
                DialogueBox.GetComponent<Canvas>().enabled = true;

                myQueue.Enqueue(1);
                Invoke("Show", 1);
                myQueue.Enqueue(2);
                Invoke("Show", 2);

                Invoke("HideCanvas", 3);
            }
        }

        void Show()
        {
            Debug.Log($"show message after {myQueue.Dequeue()} seconds");
        }
        void HideCanvas()
        {
            DialogueBox.GetComponent<Canvas>().enabled = false;
        }
    }
}
