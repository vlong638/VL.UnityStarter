using System.Collections.Generic;
using UnityEngine;

namespace VL.UnityStarter.VLGaming.Common
{

    public class ObjectPool : MonoBehaviour
    {
        public GameObject prefab; // 预制体
        public int initialPoolSize = 10; // 初始对象池大小

        private List<GameObject> pool; // 对象池

        private void Awake()
        {
            // 初始化对象池
            pool = new List<GameObject>();
            for (int i = 0; i < initialPoolSize; i++)
            {
                GameObject obj = Instantiate(prefab);
                obj.SetActive(false);
                pool.Add(obj);
            }
        }

        public GameObject GetObjectFromPool()
        {
            // 从对象池获取可用对象
            for (int i = 0; i < pool.Count; i++)
            {
                if (!pool[i].activeInHierarchy)
                {
                    pool[i].SetActive(true);
                    return pool[i];
                }
            }

            // 如果对象池中没有可用对象，则创建一个新对象
            GameObject newObj = Instantiate(prefab);
            pool.Add(newObj);
            return newObj;
        }

        public void ReturnObjectToPool(GameObject obj)
        {
            // 将对象设置为非激活状态并放回对象池中
            obj.SetActive(false);
        }
    }
}
