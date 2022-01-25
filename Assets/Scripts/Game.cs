using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private GameObject parent;
    [SerializeField] private GameObject enemyPrefabs;
    [SerializeField] private int xSize, zSize;
    [SerializeField] private float xRange, zRange; //расстояние между префабами

    private GameObject[,] prefabs;

    private void Start()
    {
        CreateEnemy(xRange, zRange);
    }

    private void CreateEnemy(float xOffset, float zOffset)
    {
        prefabs = new GameObject[xSize, zSize];

        float startX = transform.position.x;
        float startZ = transform.position.z;

        for (int x = 0; x < xSize; x++)
        {
            for (int z = 0; z < zSize; z++)
            {
                GameObject newTile = Instantiate(enemyPrefabs,
                    new Vector3(startX + (xOffset * x), 0.5f, startZ + (zOffset * z)),
                    enemyPrefabs.transform.rotation,parent.transform);
                prefabs[x, z] = newTile;
            }
        }
    }
}
