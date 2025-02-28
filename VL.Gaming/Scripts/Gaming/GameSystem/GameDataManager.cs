using System.IO;
using UnityEngine;
using VL.Gaming.Scripts.Gaming.Content.Entities;
using VL.Gaming.Scripts.Gaming.Utils;

namespace VL.Gaming.Scripts.Gaming.GameSystem
{
    public class GameDataManager : MonoBehaviour
    {
        public static string dataFilePath = "GameData.json";
        public static GameData GameData;
        public static void SaveGameData()
        {
            Debug.LogWarning("SaveGameData");

            #region 具体内容
            GameData.PlayerData = new PlayerData();
            GameObject player = GameObject.Find("Square_Player");
            GameData.PlayerData.Location = player.transform.position;
            #endregion
            string filePath = Application.persistentDataPath + "/" + dataFilePath;
            string jsonData = JsonUtility.ToJson(GameData);
            File.WriteAllText(filePath, jsonData);
            Debug.LogWarning($"Game data saved at {filePath}");
        }

        public static void LoadGameData()
        {
            Debug.LogWarning("LoadGameData");

            string filePath = Application.persistentDataPath + "/" + dataFilePath;
            if (File.Exists(filePath))
            {
                string jsonData = File.ReadAllText(filePath);
                GameData = JsonUtility.FromJson<GameData>(jsonData);
                #region 具体内容
                GameObject player = GameObject.Find("Square_Player");
                player.transform.position = GameData.PlayerData.Location;
                #endregion
            }
            else
            {
                Debug.LogWarning("Game data file not found.");
            }
        }
    }
}
