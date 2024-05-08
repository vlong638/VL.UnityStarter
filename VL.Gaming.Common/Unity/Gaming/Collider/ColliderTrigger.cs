using UnityEngine;

namespace VL.Gaming.Unity.Gaming.Collider
{
    public class ColliderTrigger : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                Debug.Log("Player entered the trigger area!");
            }
        }
    }
}
