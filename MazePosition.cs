using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MazePosition
{
    public bool canMoveWest, canMoveEast, canMoveNorth, canMoveSouth;

    public MazePosition(bool left, bool right, bool up, bool down)
    {
        canMoveWest = left;
        canMoveEast = right;
        canMoveNorth = up;
        canMoveSouth = down;
    }

    public MazePosition(bool startingValue) : this(startingValue, startingValue, startingValue, startingValue) 
    {

    }

    public MazePosition(MazePosition pos) : this(pos.canMoveWest, pos.canMoveEast, pos.canMoveNorth, pos.canMoveSouth)
    {

    }

    public bool IsValidMove(Vector2Int move)
    {
        return move.magnitude==1 && (move.x == 1 && canMoveEast || move.x == -1 && canMoveWest || move.y == 1 && canMoveNorth || move.y == -1 && canMoveSouth);
    }

    public List<Vector2Int> GetWalls()
    {
        List<Vector2Int> walls = new List<Vector2Int>();
        if(!canMoveNorth)
        {
            walls.Add(Vector2Int.up);
        }
        if(!canMoveSouth)
        {
            walls.Add(Vector2Int.down);
        }
        if(!canMoveWest)
        {
            walls.Add(Vector2Int.left);
        }
        if(!canMoveEast)
        {
            walls.Add(Vector2Int.right);
        }
        return walls;
    }

}