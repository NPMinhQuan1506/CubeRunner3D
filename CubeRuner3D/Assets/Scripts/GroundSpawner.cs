using UnityEngine;
using System.Collections.Generic;

public class GroundSpawner : MonoBehaviour
{
    public GameObject groundPrefab;
    public Transform player;
    public int tileSize = 10;
    private HashSet<Vector2Int> spawnedTiles = new HashSet<Vector2Int>();

    void Update()
    {
        Vector2Int playerTile = new Vector2Int(
            Mathf.FloorToInt(player.position.x / tileSize),
            Mathf.FloorToInt(player.position.z / tileSize)
        );

        for (int x = -1; x <= 1; x++)
        {
            for (int z = -1; z <= 1; z++)
            {
                Vector2Int tileCoord = playerTile + new Vector2Int(x, z);
                if (!spawnedTiles.Contains(tileCoord))
                {
                    Vector3 spawnPos = new Vector3(tileCoord.x * tileSize, 0, tileCoord.y * tileSize);
                    Instantiate(groundPrefab, spawnPos, Quaternion.identity);
                    spawnedTiles.Add(tileCoord);
                }
            }
        }
    }
}
