using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class CratePuzzle : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private bool solved = true;
    
    // 0 : Nothing, 1 : White, 2 : Black.
    public int[] currentPipeLayout = new int[] {0, 5, 1, 0, 1, 4, 4, 2, 3};
    private int[] finalPipeLayout = new[] {0, 0, 1, 2, 5, 1, 4, 3, 4};
    

    public List<Pipe> crateList;
    public List<Vector2> cratePositionList;

    public Crate selectedPipe;

    private bool doDelay;
    private float delayTimer = 1.0f;

    private void Update()
    {
        solved = true;
        
        //Checks if the puzzle has been solved.
        for (int i = 0; i < 9; i++)
        {
            if (currentPipeLayout[i] != finalPipeLayout[i])
            {
                solved = false;
                Debug.Log(currentPipeLayout[i] + " | " + finalPipeLayout[i]);
            }
        }

        if (doDelay)
        {
            delayTimer -= Time.deltaTime;
        }

        if (solved)
        {
            doDelay = true;
            
            if (delayTimer <= 0)
            {
                gameManager.playerInventory.Add(GameManager.Item.RoomKey);
                gameManager.gameState = GameManager.GameState.Idle;
                gameManager.playerMessage.SendMessage("You obtained the Room Key!");
                gameManager.currentPlayerInteractable.canInteract = false;
                gameObject.SetActive(false);
            }
        }
    }
}
