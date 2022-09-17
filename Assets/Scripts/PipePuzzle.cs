using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class PipePuzzle : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private bool solved = true;
    [SerializeField] private int[,] _currentPipeLayout = new int[3, 3];
    
    // 0 : Nothing, 1 : Straight, Upright : 2, UpLeft : 3, RightUp: 4, DownRight : 5.
    private readonly int[,] _initialPipeLayout = new int[3, 3] {{0, 5, 1}, {0, 1, 4}, {4, 2, 3}};
    private readonly int[,] _finalPipeLayout = new int[3, 3] {{0, 0, 1}, {2, 5, 1}, {4, 3, 4}};

    public List<Pipe> pipeList;
    public Pipe[,] pipes; 

    private void Start()
    {
        _currentPipeLayout = _initialPipeLayout;

        for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 3; y++)
            {
                pipes[x, y] = pipeList[0];
                pipeList.RemoveAt(0);
            }
        }
    }

    private void Update()
    {
        solved = true;
        
        //Checks if the puzzle has been solved.
        for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 3; y++)
            {
                if (_currentPipeLayout[x, y] != _finalPipeLayout[x, y])
                {
                    solved = false;
                }
            }
        }

        if (solved)
        {
            gameManager.playerInventory.Add(GameManager.Item.RoomKey);
        }
    }
}
