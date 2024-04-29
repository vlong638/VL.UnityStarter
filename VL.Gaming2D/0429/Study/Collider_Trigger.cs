using UnityEngine;

namespace VL.Gaming2D._0429.Study
{
    public class Collider_Trigger: MonoBehaviour
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
