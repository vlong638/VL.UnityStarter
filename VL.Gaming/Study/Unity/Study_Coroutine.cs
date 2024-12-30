using System.Collections;
using UnityEngine;

namespace VL.Gaming.Study.Unity
{
    /// <summary>
    /// 协程的执行是同步的
    /// 
    /// </summary>
    internal class Study_Coroutine : MonoBehaviour
    {
        void Start()
        {
            StartCoroutine(MainRoutine());
        }

        IEnumerator MainRoutine()
        {
            Debug.Log("Starting first routine.");
            yield return StartCoroutine(FirstRoutine());
            Debug.Log("First routine complete. Now starting second routine.");
            yield return StartCoroutine(SecondRoutine());
            Debug.Log("Second routine complete. All done.");
        }

        IEnumerator FirstRoutine()
        {
            yield return new WaitForSeconds(2.0f);
            Debug.Log("First routine finished after 2 seconds.");
        }

        IEnumerator SecondRoutine()
        {
            yield return new WaitForSeconds(3.0f);
            Debug.Log("Second routine finished after 3 seconds.");
        }
    }
}
