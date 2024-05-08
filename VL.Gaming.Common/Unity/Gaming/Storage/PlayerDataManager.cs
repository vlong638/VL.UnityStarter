using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace VL.Gaming.Unity.Gaming.Storage
{
    public class PlayerDataManager : MonoBehaviour
    {
        private string dataFilePath = "playerData.json";

        public void SavePlayerData(PlayerData playerData)
        {
            string filePath = Application.persistentDataPath + "/" + dataFilePath;
            string jsonData = JsonUtility.ToJson(playerData);
            File.WriteAllText(filePath, jsonData);
            Debug.LogWarning($"Player data saved at {filePath}");
        }

        public PlayerData LoadPlayerData()
        {
            string filePath = Application.persistentDataPath + "/" + dataFilePath;
            if (File.Exists(filePath))
            {
                string jsonData = File.ReadAllText(filePath);
                return JsonUtility.FromJson<PlayerData>(jsonData);
            }
            else
            {
                Debug.LogWarning("Player data file not found.");
                return null;
            }
        }

        Queue<int> myQueue = new Queue<int>();
        void Awake()
        {
            Debug.LogWarning("Player Awake");

            myQueue.Enqueue(1);
            Invoke("Show", 1);
            myQueue.Enqueue(2);
            Invoke("Show", 2);
        }
        void Show()
        {
            Debug.Log($"show message after {myQueue.Dequeue()} milliseconds");
        }

        void Update()
        {
            // 检测是否按下了 F5 键
            if (Input.GetKeyDown(KeyCode.F5))
            {
                SavePlayerData(new PlayerData(1, 10, "vl"));
            }
        }
    }
}
