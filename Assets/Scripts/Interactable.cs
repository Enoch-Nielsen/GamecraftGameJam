using System;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [Header("Highlight")]
    [SerializeField] private Material outline;
    [SerializeField] [Range(0.0F, 1.0F)] private float outlineAlpha;

    [Header("Manager")]
    [SerializeField] private GameManager _gameManager;
    
    [Header("Traits")]
    public bool requiresKey;
    public bool givesItem;
    public bool hasInterface;
    public bool isDoor;
    public bool hasMessage;
    
    [Header("Values")]
    public GameObject interactiveInterface;
    public GameManager.Item key;
    public GameManager.Item item;
    public string message;
    public bool canInteract;
    public bool infiniteInteractions;
    
    void Start()
    {
        Material material = Instantiate(outline);
        gameObject.GetComponent<MeshRenderer>().materials[1] = material;
        outline = gameObject.GetComponent<MeshRenderer>().materials[1];

        outline.SetFloat("_Alpha", 0);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player") && canInteract)
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
            _gameManager.playerCanInteract = false;
        }
    }
}
