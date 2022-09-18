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
    public int pipeId;
    
    [SerializeField] private bool leftValid, rightValid, upValid, downValid;
    [SerializeField] private bool leftCheck, rightCheck, upCheck, downCheck;

    public int index;
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
        Vector3 pipePosition = new Vector3(pipePuzzle.pipePositionList[index].x,
            pipePuzzle.pipePositionList[index].y, 0);
        
        gameObject.GetComponent<RectTransform>().localPosition = pipePosition;
    }

    public void OnPlayerClick()
    {
        Debug.Log(this);
        if (pipeId == 0)
        {
            if (canSwap)
            {
                canSwap = false;
                doHighlight = false;

                // Swap Current ID's
                int tempId = pipeId;

                pipePuzzle.currentPipeLayout[index] = pipePuzzle.currentPipeLayout[pipePuzzle.selectedPipe.index];
                pipePuzzle.currentPipeLayout[pipePuzzle.selectedPipe.index] = tempId;

                int tempIndex = index;

                index = pipePuzzle.selectedPipe.index;
                pipePuzzle.selectedPipe.index = tempIndex;

                Pipe tempPipe = pipePuzzle.pipeList[index];

                pipePuzzle.pipeList[index] = pipePuzzle.pipeList[pipePuzzle.selectedPipe.index];
                pipePuzzle.pipeList[pipePuzzle.selectedPipe.index] = tempPipe;
                
                for (int i = 0; i < 9; i++)
                {
                    pipePuzzle.pipeList[i].doHighlight = false;
                    pipePuzzle.pipeList[i].canSwap = false;
                }
            }
            
            return;
        }
        
        pipePuzzle.selectedPipe = this;
        
        for (int i = 0; i < 9; i++)
        {
            pipePuzzle.pipeList[i].doHighlight = false;
            pipePuzzle.pipeList[i].canSwap = false;
        }

        leftCheck = index - 3 > -1;
        rightCheck = index + 3 < 9;
        upCheck = index - 1 > -1 && (index % 3 != 0);
        downCheck = index + 1 < 9 && ((index + 1) % 3 != 0);

        if (leftCheck)
        {
            leftValid = pipePuzzle.pipeList[index - 3].pipeId == 0;
            pipePuzzle.pipeList[index - 3].doHighlight = leftValid;
            pipePuzzle.pipeList[index - 3].canSwap = leftValid;
        }

        if (rightCheck)
        {
            rightValid = pipePuzzle.pipeList[index + 3].pipeId == 0;
            pipePuzzle.pipeList[index + 3].doHighlight = rightValid;
            pipePuzzle.pipeList[index + 3].canSwap = rightValid;
        }

        if (upCheck)
        {
            upValid = pipePuzzle.pipeList[index - 1].pipeId == 0;
            pipePuzzle.pipeList[index - 1].doHighlight = upValid;
            pipePuzzle.pipeList[index - 1].canSwap = upValid;
        }

        if (downCheck)
        {
            downValid = pipePuzzle.pipeList[index + 1].pipeId == 0;
            pipePuzzle.pipeList[index + 1].doHighlight = downValid;
            pipePuzzle.pipeList[index + 1].canSwap = downValid;
        }
    }
}
