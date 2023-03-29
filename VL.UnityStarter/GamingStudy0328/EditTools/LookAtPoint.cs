using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class LookAtPoint : MonoBehaviour
{
    public Vector3 lookAtPoint = Vector3.zero;

    void Update()
    {
        transform.LookAt(lookAtPoint);
    }
}