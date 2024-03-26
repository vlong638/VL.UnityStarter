using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour
{
    public class Count
    {
        public int Minimum;
        public int Maximum;

        public Count(int minimum, int maximum)
        {
            Minimum = minimum;
            Maximum = maximum;
        }
    }

    //Game Content
    int columns = 8;
    int rows = 8;
    Count wallCount = new Count(5, 9);
    Count gunCount = new Count(1, 3);
    public GameObject player;
    public GameObject exit;
    public GameObject[] floorTiles;
    public GameObject[] guns;
    public GameObject[] enemies;
    public GameObject[] wallTiles;
    public GameObject[] outerWallTiles;

    //Game Manage
    Transform boardHolder;
    List<Vector3> gridPositions = new List<Vector3>();

    void InitializeGrid(int column, int row)
    {
        gridPositions.Clear();

        for (int x = 1; x <= column; x++)
        {
            for (int y = 1; y <= row; y++)
            {
                gridPositions.Add(new Vector3(x, y, 0));
            }
        }
    }

    void SetupGameBoard(int column, int row)
    {
        boardHolder = new GameObject("GameBoard").transform;

        for (int x = 0; x <= column + 1; x++)
        {
            for (int y = 0; y < row + 1; y++)
            {
                GameObject toInstantiate = (x == 0 || x == column + 1 || y == 0 || y == column + 1) ? outerWallTiles[Random.Range(0, outerWallTiles.Length)] : floorTiles[Random.Range(0, floorTiles.Length)];
                GameObject instance = Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;
                instance.transform.SetParent(boardHolder);
            }
        }
    }

    Vector3 GetPosition(int x, int y)
    {
        var position = gridPositions.FirstOrDefault(c => c.x == x && c.y == y);
        gridPositions.Remove(position);
        if (position == null)
        {
            throw new NotImplementedException("无效的位置,位置已被占用或不存在");
        }
        return position;
    }
    Vector3 RandomPosition()
    {
        int randomIndex = Random.Range(0, gridPositions.Count);
        Vector3 position = gridPositions[randomIndex];
        gridPositions.RemoveAt(randomIndex);
        return position;
    }

    void LayoutObjectAtRandom(GameObject[] gameObjects, int count)
    {
        if (gameObjects == null || gameObjects.Length == 0)
            return;
        for (int i = 0; i < count; i++)
        {
            var gameObject = gameObjects[Random.Range(0, gameObjects.Length)];
            Vector3 position = RandomPosition();
            Instantiate(gameObject, position, Quaternion.identity);
        }
    }
    void LayoutObjectAtRandom(GameObject gameObject, int count)
    {
        if (gameObject == null)
            return;
        for (int i = 0; i < count; i++)
        {
            Vector3 position = RandomPosition();
            Instantiate(gameObject, position, Quaternion.identity);
        }
    }
    void LayoutObjectAt(GameObject gameObject, Vector3 position)
    {
        if (gameObject == null)
            return;
        Instantiate(gameObject, position, Quaternion.identity);
    }

    public void SetupScene(int level)
    {
        InitializeGrid(columns, rows);
        SetupGameBoard(columns, rows);
        LayoutObjectAt(player, GetPosition(1, 1));
        LayoutObjectAt(exit, GetPosition(8, 8));
        LayoutObjectAtRandom(wallTiles, Random.Range(wallCount.Minimum, wallCount.Maximum));
        LayoutObjectAtRandom(guns, Random.Range(gunCount.Minimum, gunCount.Maximum));
        LayoutObjectAtRandom(enemies, level);
    }

    void Awake()
    {
        InitializeGrid(columns, rows);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}