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
    public PlayerController player;
    public bool playerCanInteract;
    public enum Item {None, Knife, RoomKey, Knowledge, LunchBoxKey, Key}
    public List<Item> playerInventory;
    public Interactable currentPlayerInteractable;
    
    [Header("Post Processing")]
    public GameObject blurVolume;
    
    [Header("Game")]
    public GameState gameState;
    public enum GameState {Moving, Idle, Interacting, RoomTransition}
    public PlayerMessage playerMessage;
    public GameObject spawnTransition;

    private void Start()
    {
        Respawn(); // Replace this with START button later.
    }

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

    private void Respawn()
    {
        spawnTransition.SetActive(true);
    }
}
