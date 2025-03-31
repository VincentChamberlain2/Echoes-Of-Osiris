using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public enum MovementDirection
{
    Up,
    Down,
    Left,
    Right
}
public class CharacterGridMovement : MonoBehaviour
{
   [Header("Movement Settings")]
   [SerializeField] private float moveSpeed = 5f;
   [SerializeField] private UnityEngine.Vector2 gridSize = new UnityEngine.Vector2(1f,1f);
   [SerializeField] private WallsTileMap wallsTileMap;
   [SerializeField] private TileSelection tileSelection;

   private UnityEngine.Vector2 targetPosition;
   private bool isMoving = false;
   private MovementDirection currentDirection = MovementDirection.Down;

    private void Update()
    {
        HandleMovementInput();
    }

    private void HandleMovementInput()
    {
        if (!isMoving && Input.GetMouseButtonDown(0))
        {
            targetPosition = tileSelection.GetHighlightedTilePosition();
            Vector2Int clickedTile = GridUtils.WorldToGrid(targetPosition);

            if (!wallsTileMap.IsTileWall(clickedTile))
            {
                if (targetPosition != UnityEngine.Vector2.zero)
                {
                    FindPathToTargetPosition();
                }
            }
        }

        if (isMoving)
        {
            MoveTowardsTarget();
        }
    }

    private void FindPathToTargetPosition()
    {
        UnityEngine.Vector2 startPosition = GridUtils.GridToWorld(GridUtils.WorldToGrid(transform.position));
        List<UnityEngine.Vector2> path = AStar.FindPath(startPosition,targetPosition,gridSize,wallsTileMap.IsTileWall);

        if(path != null && path.Count > 0)
        {
            StartCoroutine(MoveAlongPath(path));
        }
    }

    private IEnumerator MoveAlongPath(List<UnityEngine.Vector2> path)
    {
        isMoving = true;
        int currentWaypointIndex = 0;

        while ( currentWaypointIndex < path.Count)
        {
            targetPosition = path[currentWaypointIndex] + gridSize / 2;

            while ((UnityEngine.Vector2)transform.position != targetPosition)
            {
                float step = moveSpeed + Time.fixedDeltaTime;
                transform.position = UnityEngine.Vector3.MoveTowards(transform.position,targetPosition,step);

                yield return new WaitForFixedUpdate();
            }
            currentWaypointIndex++;
        }
        isMoving =false;
    }

    private void MoveTowardsTarget()
    {
        UnityEngine.Vector2 direction = (targetPosition -(UnityEngine.Vector2)transform.position).normalized;

        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if(direction.x > 0)
                currentDirection = MovementDirection.Right;
            else
                currentDirection = MovementDirection.Left;
        }
        else
        {
            if(direction.y > 0)
                currentDirection = MovementDirection.Up;
            else
                currentDirection = MovementDirection.Down;
        }
    }

}