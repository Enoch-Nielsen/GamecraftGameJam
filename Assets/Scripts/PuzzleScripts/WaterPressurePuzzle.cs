using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterPressurePuzzle : MonoBehaviour
{
    public Sprite[] sprites = new Sprite[4];
    public Image tube1Image, tube2Image, tube3Image;
    public int tube1 = 0, tube2 = 3, tube3 = 0;
    private bool doDelay = false;
    private float delayTimer = 1.0F;

    [SerializeField] private GameManager gameManager;
    
    private void Update()
    {
        tube1Image.sprite = sprites[tube1];
        tube2Image.sprite = sprites[tube2];
        tube3Image.sprite = sprites[tube3];

        if (doDelay)
        {
            delayTimer -= Time.deltaTime;
        }

        if (tube1 == tube2 && tube1 == tube3)
        {
            doDelay = true;
            
            if (delayTimer <= 0)
            {
                gameManager.playerInventory.Add(GameManager.Item.RoomKey);
                gameManager.gameState = GameManager.GameState.Idle;
                gameManager.playerMessage.SendMessage("You obtained the Room Key!");
                gameObject.SetActive(false);
            }
        }
    }

    public void OnButtonClick(int tube)
    {
        if (doDelay) { return; }
        
        if (tube == 1)
        {
            if (tube1 + 1 > 3 || tube3 - 1 < 0)
            {
                return;
            }
            
            tube1++;
            tube3--;
        }

        if (tube == 2)
        {
            if (tube2 + 1 > 3 || tube1 - 1 < 0)
            {
                return;
            }
            
            tube2++;
            tube1--;
        }

        if (tube == 3)
        {
            if (tube3 + 1 > 3 || tube2 - 1 < 0)
            {
                return;
            }
            
            tube3++;
            tube2--;
        }
    }
}
