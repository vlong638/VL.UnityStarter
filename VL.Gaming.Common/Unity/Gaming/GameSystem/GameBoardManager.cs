using UnityEngine;

namespace VL.Gaming.Unity.Gaming.GameSystem
{
    internal class GameBoardManager : MonoBehaviour
    {
        public int gridRadius = 100;  // 网格半径
        public float hexRadius = 1f;  // 六边形的半径
        public GameObject hexPrefab;  // 六边形的预制体

        void Start()
        {
            GenerateHexGrid();
        }

        void GenerateHexGrid()
        {
            for (int q = -gridRadius; q <= gridRadius; q++)
            {
                int r1 = Mathf.Max(-gridRadius, -q - gridRadius);
                int r2 = Mathf.Min(gridRadius, -q + gridRadius);
                for (int r = r1; r <= r2; r++)
                {
                    Vector3 hexPosition = HexToWorldPosition(q, r);
                    Instantiate(hexPrefab, hexPosition, Quaternion.identity, transform);
                }
            }
        }
        Vector3 HexToWorldPosition(int q, int r)
        {
            float x = hexRadius * 3.0f / 2.0f * q;
            float z = hexRadius * Mathf.Sqrt(3.0f) * (r + q / 2.0f);
            return new Vector3(x, 0, z);
        }
    }
}
