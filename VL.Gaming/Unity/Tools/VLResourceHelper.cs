using UnityEditor;
using UnityEngine;

namespace VL.Gaming.Unity.Gaming.Tools
{
    public class VLResourceHelper
    {
        public static GameObject CheckExist(string name, bool deleteOnExit = true)
        {
            var check = FindGameObjectByName(name);
            if (check != null && deleteOnExit)
                Undo.DestroyObjectImmediate(check);
            return check;
        }

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
