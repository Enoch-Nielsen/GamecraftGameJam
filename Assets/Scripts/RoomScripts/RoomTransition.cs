using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTransition : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] GameObject playerSpawnSpace;
    [SerializeField] private float transitionTime;
    private float transitionTimer = 0.0f;
    private bool doTransition;

    void Start()
    {
        gameManager.gameState = GameManager.GameState.RoomTransition;

        doTransition = true;
    }

    private void Update()
    {
        if (transitionTimer <= transitionTime && doTransition)
        {
            transitionTimer += Time.deltaTime;
        }
        
        if(transitionTimer >= transitionTime)
            RoomChange(gameManager.player, Camera.main);
    }

    private void RoomChange(PlayerController player, Camera camera)
    {
        player.gameObject.SetActive(true);
        player.transform.position = playerSpawnSpace.transform.position;
        camera.transform.position = player.transform.position + new Vector3(7.0F,
            player.transform.position.y + 3.7F, player.transform.position.z);

        gameManager.gameState = GameManager.GameState.Idle;
        Debug.Log(gameManager.gameState);

        gameObject.SetActive(false);
    }
}