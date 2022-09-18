using System;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] private LockerPuzzle locker;
    [SerializeField] private Image selfImage;
    [SerializeField] private GameManager gameManager;

    public GameManager.Item item;

    public void OnPointerEnter(PointerEventData eventData)
    {
        selfImage.color = Color.yellow;
        
        Debug.Log("Mouse Over" + this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        selfImage.color = Color.white;
        
        Debug.Log("Mouse Exit" + this);

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        gameManager.playerInventory.Add(item);
        locker.lockerItems.Remove(this);
        
        Debug.Log("Mouse Click" + this);
        
        gameManager.playerMessage.SendMessage(item + " Has been added to your inventory.");

        Destroy(gameObject);
    }
}
