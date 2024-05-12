using System.Collections.Generic;
using System.IO;
using UnityEngine;
using VL.Gaming.Unity.Gaming.Content.Entities;

namespace VL.Gaming.Unity.Gaming.StorageManage
{
    public class GameDataManager : MonoBehaviour
    {
        private string dataFilePath = "GameData.json";

        public void SaveGameData(GameData playerData)
        {
            string filePath = Application.persistentDataPath + "/" + dataFilePath;
            string jsonData = JsonUtility.ToJson(playerData);
            File.WriteAllText(filePath, jsonData);
            Debug.LogWarning($"Game data saved at {filePath}");
        }

        public GameData LoadGameData()
        {
            string filePath = Application.persistentDataPath + "/" + dataFilePath;
            if (File.Exists(filePath))
            {
                string jsonData = File.ReadAllText(filePath);
                return JsonUtility.FromJson<GameData>(jsonData);
            }
            else
            {
                Debug.LogWarning("Game data file not found.");
                return null;
            }
        }

        Queue<int> myQueue = new Queue<int>();
        void Awake()
        {
            Debug.LogWarning("Game Awake");

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
                SaveGameData(new GameData());
            }
        }
    }
}
