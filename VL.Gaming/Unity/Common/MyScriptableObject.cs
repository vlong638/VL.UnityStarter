using UnityEngine;

namespace VL.Gaming.Unity.Common
{
    [CreateAssetMenu(menuName = "DataMenu/MyScriptableObject")]
    public class MyScriptableObject : ScriptableObject
    {
        public int intValue;
        public string stringValue;
    }
}
