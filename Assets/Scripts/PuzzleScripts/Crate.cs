using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crate : MonoBehaviour
{
    [SerializeField] private CratePuzzle cratePuzzle;
    
    // 0 : Nothing, 1 : White, 2 : Black.
    [Tooltip("0 : Nothing, 1 : White, 2 : Black.")]
    public int crateId;
    
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
        Vector3 pipePosition = new Vector3(cratePuzzle.cratePositionList[index].x,
            cratePuzzle.cratePositionList[index].y, 0);
        
        gameObject.GetComponent<RectTransform>().localPosition = pipePosition;
    }

    public void OnPlayerClick()
    {
        Debug.Log(this);
        if (crateId == 0)
        {
            if (canSwap)
            {
                canSwap = false;
                doHighlight = false;

                // Swap Current ID's
                int tempId = crateId;

                cratePuzzle.currentPipeLayout[index] = cratePuzzle.currentPipeLayout[cratePuzzle.selectedPipe.index];
                cratePuzzle.currentPipeLayout[cratePuzzle.selectedPipe.index] = tempId;

                int tempIndex = index;

                index = cratePuzzle.selectedPipe.index;
                cratePuzzle.selectedPipe.index = tempIndex;

                Pipe tempPipe = cratePuzzle.crateList[index];

                cratePuzzle.crateList[index] = cratePuzzle.crateList[cratePuzzle.selectedPipe.index];
                cratePuzzle.crateList[cratePuzzle.selectedPipe.index] = tempPipe;
                
                for (int i = 0; i < 25; i++)
                {
                    cratePuzzle.crateList[i].doHighlight = false;
                    cratePuzzle.crateList[i].canSwap = false;
                }
            }
            
            return;
        }
        
        cratePuzzle.selectedPipe = this;
        
        for (int i = 0; i < 25; i++)
        {
            cratePuzzle.crateList[i].doHighlight = false;
            cratePuzzle.crateList[i].canSwap = false;
        }

        leftCheck = index - 5 > -1;
        rightCheck = index + 5 < 25;
        upCheck = index - 1 > -1 && (index % 5 != 0);
        downCheck = index + 1 < 25 && ((index + 1) % 5 != 0);

        if (leftCheck)
        {
            leftValid = cratePuzzle.crateList[index - 5].pipeId == 0;
            cratePuzzle.crateList[index - 5].doHighlight = leftValid;
            cratePuzzle.crateList[index - 5].canSwap = leftValid;
        }

        if (rightCheck)
        {
            rightValid = cratePuzzle.crateList[index + 3].pipeId == 0;
            cratePuzzle.crateList[index + 5].doHighlight = rightValid;
            cratePuzzle.crateList[index + 5].canSwap = rightValid;
        }

        if (upCheck)
        {
            upValid = cratePuzzle.crateList[index - 5].pipeId == 0;
            cratePuzzle.crateList[index - 5].doHighlight = upValid;
            cratePuzzle.crateList[index - 5].canSwap = upValid;
        }

        if (downCheck)
        {
            downValid = cratePuzzle.crateList[index + 5].pipeId == 0;
            cratePuzzle.crateList[index + 5].doHighlight = downValid;
            cratePuzzle.crateList[index + 5].canSwap = downValid;
        }
    }
}
