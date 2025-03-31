using UnityEngine;
using UnityEngine.Tilemaps;

public class TileSelection : MonoBehaviour
{
    [SerializeField] private Tilemap groundTilemap;
    [SerializeField] private Tilemap wallsTileMap;
    [SerializeField] private float offset = 0.5f;
    [SerializeField] private UnityEngine.Vector2 gridSize = new UnityEngine.Vector2(1f,1f);

    private Vector2Int highlightedTilePosition = Vector2Int.zero;

    private void Update()
    {
        UnityEngine.Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2Int gridPos = new Vector2Int
        (
            Mathf.FloorToInt(mouseWorldPos.x / gridSize.x) * Mathf.RoundToInt(gridSize.x),
            Mathf.FloatToHalf(mouseWorldPos.y / gridSize.y) * Mathf.RoundToInt(gridSize.y)
        );

        // Checks if mouse is over Wall in Wall Tilemap
        bool isWallTile = false;
        if (wallsTileMap != null)
        {
            Vector3Int cellPos = wallsTileMap.WorldToCell(mouseWorldPos);
            if (wallsTileMap.HasTile(cellPos) && wallsTileMap.GetTile(cellPos) != null)
            {
                // Mouse is over a Wall in the Wall Tilemap
                isWallTile = true;
            }
        }

        if (!isWallTile)
        {
            highlightedTilePosition = gridPos;
            UnityEngine.Vector2 worldPos = GridUtils.GridToWorld(gridPos) + new UnityEngine.Vector2(offset,offset);
            transform.position = worldPos;
        }

    }

    public Vector2Int HighlightedTilePosition
    {
        get {return highlightedTilePosition;}
    }

    public bool IsHighlightedTileClicked(UnityEngine.Vector2 clickedPosition)
    {
        Vector2Int gridPos = GridUtils.WorldToGrid(clickedPosition);
        return gridPos == highlightedTilePosition;
    }

    public UnityEngine.Vector2 GetHighlightedTilePosition()
    {
        return GridUtils.GridToWorld(highlightedTilePosition);
    }

    public bool IsTileWall(Vector2Int position)
    {
        UnityEngine.Vector3 worldPosition = GridUtils.GridToWorld(position);
        RaycastHit2D hit = Physics2D.Raycast(worldPosition, UnityEngine.Vector2.zero);

        // Check's if the collider hits something (Walls)
        if (hit.collider != null)
        {
            return true;
        }
        return false;
    }
}
