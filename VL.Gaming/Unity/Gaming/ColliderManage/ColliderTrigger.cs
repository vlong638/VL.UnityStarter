using System.Collections.Generic;
using UnityEngine;

namespace VL.Gaming.Unity.Gaming.ColliderManage
{
    public class ColliderTrigger : MonoBehaviour
    {
        [SerializeField]
        public GameObject DialogueBox;

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                Debug.Log("Player entered the trigger area!");
                DialogueBox.transform.Find("Panel").gameObject.SetActive(true);
                
                //DialogueBox.GetComponent<Canvas>().enabled = true;
                //由对话框自行控制关闭
                //myQueue.Enqueue(1);
                //Invoke("Show", 1);
                //myQueue.Enqueue(2);
                //Invoke("Show", 2);
                //Invoke("HideCanvas", 3);
            }
        }

        //Queue<int> myQueue = new Queue<int>();
        //void Show()
        //{
        //    Debug.Log($"show message after {myQueue.Dequeue()} seconds");
        //}
        //void HideCanvas()
        //{
        //    DialogueBox.GetComponent<Canvas>().enabled = false;
        //}
    }
}
