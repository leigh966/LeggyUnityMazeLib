using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGame : MonoBehaviour
{
    protected Maze m;
    protected Vector2Int playerPos;
    private MazeGameState gameState;
    // Start is called before the first frame update
    public virtual void Start()
    {
        m = new Maze();
        playerPos = m.startPos;
        gameState = MazeGameState.AWAITING_INPUT;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if(gameState == MazeGameState.AWAITING_INPUT)
        {
            HandleInput();
        }
    }


    private void Move(Vector2Int delta)
    {
        if (m.GetPosition(playerPos.x, playerPos.y).IsValidMove(delta))
        {
            playerPos += delta;
        }
    }


    private void HandleInput()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            Move(Vector2Int.up);
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            Move(Vector2Int.down);
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            Move(Vector2Int.right);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Move(Vector2Int.left);
        }

    }
}
