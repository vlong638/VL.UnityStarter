using UnityEngine;

namespace VL.UnityStarter.VLGaming3D
{
    public class VLCreater2D
    {
        public static Mesh GroundMesh;

        public static GameObject CreateGround(string name = "", GameObject parent = null)
        {
            GameObject gameObject = new GameObject(name);
            if (parent) gameObject.transform.SetParent(parent.transform);
            gameObject.AddComponent<MeshRenderer>();
            var meshFilter = gameObject.AddComponent<MeshFilter>();
            meshFilter.mesh = GroundMesh;
            var transform = gameObject.transform;
            transform.localScale = new Vector3(4, 4, 4);
            var boxCollider = gameObject.AddComponent<BoxCollider>();
            boxCollider.size = transform.localScale;
            return gameObject;
        }
    }
}
