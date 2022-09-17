using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipePuzzle : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private bool solved = true;
    [SerializeField] private int[,] currentTileLayout = new int[3, 3];
    
    // 0 : Nothing, 1 : Straight, 2 : UpRight, 3: UpLeft, 4: RightUp, DownRight : 5.
    public int[,] initialTileLayout = new int[3, 3] {{0, 5, 1}, {0, 1, 5}, {5, 3, 4}};
    public int[,] finalTileLayout = new int[3, 3] {{0, 0, 1}, {3, }, {}};

    private void Start()
    {
        
    }

    private void Update()
    {
        
        
        solved = true;
        
        //Checks if the puzzle has been solved.
        for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 3; y++)
            {
                if (currentTileLayout[x, y] != finalTileLayout[x, y])
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
