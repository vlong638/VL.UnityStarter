using UnityEditor;
using UnityEngine;

namespace VL.Gaming.Unity.Gaming.Ultis
{
    public class VLResourceHelper
    {
        public static GameObject FindGameObjectByName(string name, bool findPrefabInstance = true)
        {
            var gameobject = GameObject.Find(name);
            if (gameobject != null)
                return gameobject;
            GameObject[] allObjects = Resources.FindObjectsOfTypeAll<GameObject>();
            foreach (GameObject obj in allObjects)
            {
                if (obj.name == name && !obj.activeInHierarchy)
                {
                    //过滤预制体(原体)
                    if (PrefabUtility.IsPartOfPrefabAsset(obj))
                        continue;
                    //过滤预制体(实例)
                    if (!findPrefabInstance && PrefabUtility.IsPartOfPrefabInstance(obj))
                        continue;
                    return obj;
                }
            }
            return null;
        }
    }
}
