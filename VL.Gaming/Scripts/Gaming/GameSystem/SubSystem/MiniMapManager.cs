using System.Collections;
using UnityEngine;
using VL.Gaming.Scripts.Common.Enums;
using VL.Gaming.Scripts.Gaming.GameSystem.ChessMove;
using VL.Gaming.Scripts.Gaming.Tools;
using VL.Gaming.Scripts.Gaming.Utils;

namespace VL.Gaming.Scripts.Gaming.GameSystem.SubSystems
{
    public class MiniMapManager : MonoBehaviour
    {
        private static MiniMapManager instance;
        public static MiniMapManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameObject("MiniMapManager").AddComponent<MiniMapManager>();
                }
                return instance;
            }
        }

        void Start()
        {
        }
        void Update()
        {
        }
    }
}
