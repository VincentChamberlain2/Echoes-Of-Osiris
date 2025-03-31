using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GridUtils
{
    public static Vector2Int WorldToGrid(Vector2 worldPosition)
    {
        return new Vector2Int(Mathf.FloorToInt(worldPosition.x),Mathf.FloorToInt(worldPosition.y));
    }

    public static Vector2 GridToWorld(Vector2Int gridPostion)
    {
        return new Vector2(gridPostion.x,gridPostion.y);
    }
}
