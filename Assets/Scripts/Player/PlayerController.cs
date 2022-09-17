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
    public Interactable currentInteractable;

    // Start is called before the first frame update
    void Start()
    {
        
    }

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
        if (Input.GetKeyDown(KeyCode.E) && _gameManager.playerCanInteract)
        {
            if (currentInteractable.requiresKey)
            {
                bool playerHasKey = false;

                foreach (var item in _gameManager.playerInventory)
                {
                    if (item == currentInteractable.key)
                    {
                        playerHasKey = true;
                        _gameManager.playerInventory.Remove(item);
                    }
                }

                if (!playerHasKey)
                    return;
            }

            if (currentInteractable.givesItem)
            {
                _gameManager.playerInventory.Add(currentInteractable.item);
            }
            
            if (currentInteractable.hasInterface)
            {
                _gameManager.gameState = GameManager.GameState.Interacting;
                currentInteractable.interactiveInterface.SetActive(true);
            }
        }
    }
}
