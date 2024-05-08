using System;

namespace VL.Gaming.Unity.Gaming.Storage
{
    [Serializable]
    public class PlayerData
    {
        public int playerLevel;
        public float playerHealth;
        public string playerName;

        public PlayerData(int level, float health, string name)
        {
            playerLevel = level;
            playerHealth = health;
            playerName = name;
        }
    }
}
