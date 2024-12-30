using System.IO;
using UnityEngine;

namespace VL.Gaming.Unity.Tools
{
    public class VLIOHelper
    {
        public static void CreateDirectory(string fileName)
        {
            string fullPath = Path.Combine(Application.dataPath, fileName);
            if (!Directory.Exists(fullPath))
            {
                Directory.CreateDirectory(fullPath);
                Debug.Log("文件夹已创建： " + fullPath);
            }
            else
            {
                Debug.Log("文件夹已存在： " + fullPath);
            }
        }
    }
}
