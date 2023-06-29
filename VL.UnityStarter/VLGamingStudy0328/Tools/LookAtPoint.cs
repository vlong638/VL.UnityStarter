using UnityEngine;
using UnityEditor;
namespace Assets.Scenes.VLGamingStudy0328
{
    [ExecuteInEditMode]
    public class LookAtPoint : MonoBehaviour
    {
        public Vector3 lookAtPoint = Vector3.zero;

        public void Update()
        {
            transform.LookAt(lookAtPoint);
        }
    }
}