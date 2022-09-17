using System;
using System.Collections;
using System.Collections.Generic;
using UI;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class GameManager : MonoBehaviour
{
    [Header("Player")]
    public bool playerCanInteract;
    public enum Item {None ,Knife, RoomKey}
    public List<Item> playerInventory;
    public Interactable currentPlayerInteractable;
    
    [Header("Post Processing")]
    public GameObject blurVolume;
    
    [Header("Game")]
    public GameState gameState;
    public enum GameState {Moving,  Interacting, RoomTransition}
    public PlayerMessage playerMessage;
    
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
