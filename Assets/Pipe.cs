using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pipe : MonoBehaviour
{
    [SerializeField] private PipePuzzle pipePuzzle;
    
    // 0 : Nothing, 1 : Straight, Upright : 2, UpLeft : 3, RightUp: 4, DownRight : 5.
    [Tooltip("0 : Nothing, 1 : Straight, Upright : 2, UpLeft : 3, RightUp: 4, DownRight : 5")]
    [SerializeField] private int pipeId;
    
    public int xIndex, yIndeX;
    [SerializeField] private bool leftValid, rightValid, upValid, downValid;

    public Image selfImage;
    public bool doHighlight;
    public bool canSwap;

    private void Start()
    {
        selfImage.color = Color.white;
    }

    private void Update()
    {
        if (doHighlight)
        {
            selfImage.color = Color.yellow;
        }
        else
        {
            selfImage.color = Color.white;
        }
        
        // Modify Position Here.
    }

    void OnPlayerClick()
    {
        if (pipeId == 0)
        {
            if (canSwap)
            {
                Pipe temp = this;

                pipePuzzle.pipes[xIndex, yIndeX] = pipePuzzle.selectedPipe;
                pipePuzzle.selectedPipe = temp;
            }
            
            return;
        }
        
        pipePuzzle.selectedPipe = this;
        
        leftValid = pipePuzzle.pipes[xIndex - 1, yIndeX].pipeId == 0;
        rightValid = pipePuzzle.pipes[xIndex + 1, yIndeX].pipeId == 0;
        upValid = pipePuzzle.pipes[xIndex, yIndeX - 1].pipeId == 0;
        downValid = pipePuzzle.pipes[xIndex - 1, yIndeX + 1].pipeId == 0;
        
        pipePuzzle.pipes[xIndex - 1, yIndeX].doHighlight = leftValid;
        pipePuzzle.pipes[xIndex - 1, yIndeX].canSwap = leftValid;
        
        pipePuzzle.pipes[xIndex + 1, yIndeX].doHighlight = rightValid;
        pipePuzzle.pipes[xIndex + 1, yIndeX].canSwap = rightValid;
        
        pipePuzzle.pipes[xIndex, yIndeX - 1].doHighlight = upValid;
        pipePuzzle.pipes[xIndex, yIndeX - 1].canSwap = upValid;
        
        pipePuzzle.pipes[xIndex, yIndeX + 1].doHighlight = downValid;
        pipePuzzle.pipes[xIndex, yIndeX + 1].canSwap = downValid;
    }
}
