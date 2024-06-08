using System.Collections;
using UnityEngine;
using VL.Gaming.Common;
using VL.Gaming.Unity.Gaming.GameSystem.Generator;
using VL.Gaming.Unity.Gaming.Ultis;

namespace VL.Gaming.Unity.Gaming.GameSystem
{
    internal class QuadGameMapManager : MonoBehaviour
    {
        GameObject GameBoardGO;
        GameObject AssetsGO;
        GameObject FloorsGO;
        GameObject BuildingsGO;
        GameObject ItemsGO;
        GameObject CreaturesGO;

        void Start()
        {
            StartGame();
        }

        void StartGame()
        {
            StartCoroutine(StartingGame());
        }

        IEnumerator StartingGame()
        {
            GameBoardGO = new GameObject();
            AssetsGO = new GameObject("AssetsGO"); AssetsGO.SetParent(GameBoardGO);
            FloorsGO = new GameObject("FloorsGO"); FloorsGO.SetParent(GameBoardGO);
            BuildingsGO = new GameObject("BuildingsGO"); BuildingsGO.SetParent(GameBoardGO);
            ItemsGO = new GameObject("ItemsGO"); ItemsGO.SetParent(GameBoardGO);
            CreaturesGO = new GameObject("CreaturesGO"); CreaturesGO.SetParent(GameBoardGO);
            AssetsGO.SetActive(false);

            Debug.Log("开始加载资源");
            StartCoroutine(nameof(PrepareAsset));
            int i = 1;
            while (!VLResourcePool.IsResourceReady)
            {
                Debug.Log("正在加载资源" + i++);
                yield return new WaitForSeconds(1f);
            }

            Debug.Log($"开始生成地图");

            Debug.Log($"开始生成地形");
            yield return QuadGameBoard.Instance.GenerateFloors(FloorsGO);
            Debug.Log($"开始生成建筑");
            yield return QuadGameBoard.Instance.GenerateBuildings(BuildingsGO);
        }

        void PrepareAsset()
        {
            VLResourcePool.LoadResource(AssetsGO);
        }
    }
}
