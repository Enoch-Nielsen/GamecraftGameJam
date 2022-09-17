using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    // Outline Variables
    [SerializeField] private Material outline;
    [SerializeField] [Range(0.0F, 1.0F)] private float outlineAlpha;

    // Interactable Variables
    [SerializeField] private GameManager _gameManager;
    [SerializeField]
    
    public bool requiresKey;
    public bool givesItem;
    
    public bool hasInterface;
    public bool isDoor;

    // Conditional Variables
    public GameObject interactiveInterface;
    public GameManager.Item key;
    public GameManager.Item item;
    
    // Start is called before the first frame update
    void Start()
    {
        outline.SetFloat("_Alpha", 0);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            outline.SetFloat("_Alpha", outlineAlpha);
            _gameManager.playerCanInteract = true;
            _gameManager.currentPlayerInteractable = this;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            outline.SetFloat("_Alpha", 0);
            _gameManager.playerCanInteract = true;
        }
    }
}
