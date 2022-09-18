using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockerPuzzle : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    public List<UIItem> lockerItems;
    
    private bool doDelay;
    private float delayTimer = 1.0f;

    private void Update()
    {
        if (doDelay)
        {
            delayTimer -= Time.deltaTime;
        }
        
        if (lockerItems.Count == 0)
        {
            doDelay = true;
        
            if (delayTimer <= 0)
            {
                _gameManager.gameState = GameManager.GameState.Idle;
                _gameManager.playerMessage.SendMessage("You obtained the Room Key!");
                _gameManager.currentPlayerInteractable.canInteract = false;
                gameObject.SetActive(false);
            }
        }
    }
}
