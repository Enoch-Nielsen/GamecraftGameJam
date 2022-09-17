using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Player edited Variables
    [SerializeField] private float speed = 5;
    [SerializeField] private int turnDirection;
    [SerializeField] private int prevTurnDirection;
    [SerializeField] private float playerTurnLerp;
    [SerializeField] private float yRotation;

    //Player public Variables
    public float waterSpeed = 1;
    public float turnTime;
    public GameObject playerSprite;
    public Animator animator;

    //Player Specific Variables
    [SerializeField] private GameManager gameManager;

    // Update is called once per frame
    void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        // Update Game State and Animation State.
        if (horizontalMovement != 0 || verticalMovement != 0 && gameManager.gameState != GameManager.GameState.Interacting)
        {
            gameManager.gameState = GameManager.GameState.Moving;
            animator.SetBool("Moving", true);
        }
        else
        {
            animator.SetBool("Moving", false);
        }

        // Update Horizontal Direction
        if (horizontalMovement != 0)
        {
            if (horizontalMovement > 0)
            {
                turnDirection = 1;
            }
            
            if (horizontalMovement < 0)
            {
                turnDirection = -1;
            }

            if (turnDirection != prevTurnDirection)
            {
                playerTurnLerp = 0;
            }

            prevTurnDirection = turnDirection;
        }

        if (turnDirection != 0)
        {
            yRotation = turnDirection < 0 ? 0 : 180;

            if (playerTurnLerp <= turnTime)
            {
                playerTurnLerp += Time.deltaTime;
            }
        }

        playerSprite.transform.localEulerAngles = Vector3.Lerp(playerSprite.transform.localEulerAngles, new Vector3(0, yRotation, 0), playerTurnLerp);

        if (gameManager.gameState == GameManager.GameState.Moving)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed * waterSpeed * verticalMovement);
            transform.Translate(Vector3.right * Time.deltaTime * speed * waterSpeed * horizontalMovement);
        }
        
        // Check Player Interact
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (gameManager.gameState == GameManager.GameState.Interacting)
            {
                Debug.Log("Stop Interface");
                gameManager.currentPlayerInteractable.interactiveInterface.SetActive(false);
                gameManager.gameState = GameManager.GameState.Idle;

                return;
            }

            if (!gameManager.currentPlayerInteractable.canInteract)
                return;
            
            if (!gameManager.playerCanInteract)
                return;

            // Checks to see if the interaction requires a key.
            if (gameManager.currentPlayerInteractable.requiresKey)
            {
                bool playerHasKey = false;

                // Check if player has the needed item in their inventory.
                foreach (var item in gameManager.playerInventory)
                {
                    if (item == gameManager.currentPlayerInteractable.key)
                    {
                        playerHasKey = true;
                        gameManager.playerInventory.Remove(item);
                        break;
                    }
                }
                
                if (!playerHasKey)
                {
                    if (gameManager.currentPlayerInteractable.hasPreMessage)
                    {
                        gameManager.playerMessage.SendMessage(gameManager.currentPlayerInteractable.preInteractionMessage);
                    }
                    
                    return;
                }
            }

            // Checks to see if the interaction rewards an item.
            if (gameManager.currentPlayerInteractable.givesItem)
            {
                bool hasItem = false;
                
                foreach (var item in gameManager.playerInventory)
                {
                    if (item == gameManager.currentPlayerInteractable.item)
                    {
                        hasItem = true;
                    }
                }

                if (!hasItem)
                {
                    gameManager.playerInventory.Add(gameManager.currentPlayerInteractable.item);
                }
            }
            
            if (gameManager.currentPlayerInteractable.hasInterface)
            {
                gameManager.gameState = GameManager.GameState.Interacting;
                gameManager.currentPlayerInteractable.interactiveInterface.SetActive(true);
            }

            if (gameManager.currentPlayerInteractable.hasMessage)
            {
                gameManager.playerMessage.SendMessage(gameManager.currentPlayerInteractable.interactionMessage);
            }

            if (!gameManager.currentPlayerInteractable.infiniteInteractions)
            {
                gameManager.currentPlayerInteractable.canInteract = false;
            }
        }
    }
}
