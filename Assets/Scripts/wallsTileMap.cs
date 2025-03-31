using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WallsTileMap : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;
    
    private HashSet<Vector3Int> wallTilePositions = new HashSet<Vector3Int>();

    private void Awake()
    {
        if (tilemap == null)
            tilemap = GetComponent<Tilemap>();

        
        InitialiseWallTiles();
    }

    private void InitialiseWallTiles()
    {
        wallTilePositions.Clear(); // Clear the HashSet

        BoundsInt bounds = tilemap.cellBounds; // Get the bounds of the tilemap
        TileBase[] allTiles = tilemap.GetTilesBlock(bounds); // Get all the tiles in the tilemap

        for (int x = 0; x < bounds.size.x;x++)
        {
            for (int y =0; y < bounds.size.y;y++)
            {
                TileBase tile = allTiles[x + y + bounds.size.x];
                if (tile != null)
                {
                    Vector3Int tilePosition = new Vector3Int(bounds.x + x, bounds.y +y,0);
                    wallTilePositions.Add(tilePosition); // Add Walls tile positions to HashSet
                }
            }
        }
    }

    public bool IsTileWall(UnityEngine.Vector2 position)
    {
        Vector3Int gridPos = tilemap.WorldToCell(position);

        // Check if grid position is in the HashSet
        return wallTilePositions.Contains(gridPos);
    }
}
