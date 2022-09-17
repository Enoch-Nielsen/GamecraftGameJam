using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Player edited Variables
    [SerializeField] private float speed = 5;

    //Player public Variables

    //Player Specific Variables
    [SerializeField] private GameManager _gameManager;

    // Update is called once per frame
    void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        if (_gameManager.gameState == GameManager.GameState.Moving)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalMovement);
            transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalMovement);
        }
        
        // Check Player Interact
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (_gameManager.gameState == GameManager.GameState.Interacting)
            {
                Debug.Log("Stop Interface");
                _gameManager.currentPlayerInteractable.interactiveInterface.SetActive(false);
                _gameManager.gameState = GameManager.GameState.Moving;

                return;
            }

            if (!_gameManager.currentPlayerInteractable.canInteract)
                return;
            
            if (!_gameManager.playerCanInteract)
                return;
            
            if (_gameManager.currentPlayerInteractable.requiresKey)
            {
                bool playerHasKey = false;

                foreach (var item in _gameManager.playerInventory)
                {
                    if (item == _gameManager.currentPlayerInteractable.key)
                    {
                        playerHasKey = true;
                        _gameManager.playerInventory.Remove(item);
                        break;
                    }
                }
                
                _gameManager.playerMessage.SendMessage(String.Format("You need the {0} to use thisS.", _gameManager.currentPlayerInteractable.key));

                if (!playerHasKey)
                    return;
            }

            if (_gameManager.currentPlayerInteractable.givesItem)
            {
                _gameManager.playerInventory.Add(_gameManager.currentPlayerInteractable.item);
            }
            
            if (_gameManager.currentPlayerInteractable.hasInterface)
            {
                _gameManager.gameState = GameManager.GameState.Interacting;
                _gameManager.currentPlayerInteractable.interactiveInterface.SetActive(true);
            }

            if (_gameManager.currentPlayerInteractable.hasMessage)
            {
                _gameManager.playerMessage.SendMessage(_gameManager.currentPlayerInteractable.message);
            }

            if (!_gameManager.currentPlayerInteractable.infiniteInteractions)
            {
                _gameManager.currentPlayerInteractable.canInteract = false;
            }
        }
    }
}
