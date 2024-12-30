using System.IO;
using UnityEngine;
using VL.Gaming.Unity.Gaming.Content.Entities;

namespace VL.Gaming.Unity.Gaming.GameSystem
{
    public class GameDataManager : MonoBehaviour
    {
        public static string dataFilePath = "GameData.json";

        public static void SaveGameData()
        {
            Debug.LogWarning("SaveGameData");

            var gameData = new GameData();
            gameData.PlayerData = new PlayerData();
            GameObject player = GameObject.Find("Square_Player");
            gameData.PlayerData.Location = player.transform.position;
            string filePath = Application.persistentDataPath + "/" + dataFilePath;
            string jsonData = JsonUtility.ToJson(gameData);
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
                var data = JsonUtility.FromJson<GameData>(jsonData);
                GameObject player = GameObject.Find("Square_Player");
                player.transform.position = data.PlayerData.Location;
            }
            else
            {
                Debug.LogWarning("Game data file not found.");
            }
        }
    }
}
