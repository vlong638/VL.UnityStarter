using UnityEngine;

namespace VL.Gaming.Unity.Gaming.Ultis
{
    public class ResourceHelper
    {
        public static GameObject FindGameObjectByName(string name)
        {
            var gameobject = GameObject.Find(name);
            if (gameobject != null)
                return gameobject;
            GameObject[] allObjects = Resources.FindObjectsOfTypeAll<GameObject>();
            foreach (GameObject obj in allObjects)
            {
                if (obj.name == name && !obj.activeInHierarchy)
                {
                    return obj;
                }
            }
            return null;
        }
    }
}
