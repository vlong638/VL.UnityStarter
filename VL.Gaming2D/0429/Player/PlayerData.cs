using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VL.Gaming2D._0429
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
