using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class GameManager : MonoBehaviour
{
    // Player Variables.
    public bool playerCanInteract;
    public enum Item {None ,Knife, RoomKey}
    public List<Item> playerInventory;
    public Interactable currentPlayerInteractable;
    
    // Camera.
    public Camera mainCamera;
    
    // Post Processing
    public GameObject blurVolume;

    // Game Status.
    public enum GameState {Moving,  Interacting, RoomTransition}
    public GameState gameState;

    // Room Management.

    private void Update()
    {
        if (gameState == GameState.Interacting)
        {
            blurVolume.SetActive(true);
        }
        else
        {
            blurVolume.SetActive(false);
        }
    }
}
