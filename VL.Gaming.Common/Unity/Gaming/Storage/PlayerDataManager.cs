using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace VL.Gaming.Unity.Gaming.Storage
{
    public class PlayerDataManager : MonoBehaviour
    {
        private string dataFilePath = "playerData.json";

        public void SavePlayerData(PlayerData playerData)
        {
            string jsonData = JsonUtility.ToJson(playerData);
            File.WriteAllText(Application.persistentDataPath + "/" + dataFilePath, jsonData);
        }

        public PlayerData LoadPlayerData()
        {
            string filePath = Application.persistentDataPath + "/" + dataFilePath;
            if (File.Exists(filePath))
            {
                Debug.LogWarning($"Player data saved at {filePath}");
                string jsonData = File.ReadAllText(filePath);
                return JsonUtility.FromJson<PlayerData>(jsonData);
            }
            else
            {
                Debug.LogWarning("Player data file not found.");
                return null;
            }
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
