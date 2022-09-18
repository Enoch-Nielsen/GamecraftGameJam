using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CratePuzzle : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private bool solved = false;
    [SerializeField] private GameObject whiteCrate, blackCrate;
    
    // 0 : Nothing, 1 : White, 2 : Black.

    public List<int> initialCrateLayout;
    public List<Crate> crateList;
    public List<Vector2> cratePositionList;

    public Crate selectedCrate;

    private bool doDelay;
    private float delayTimer = 1.0f;

    [SerializeField] private float crateSize;

    private void Start()
    {
        float startPosX = crateSize * 2 * -1;
        float startPosY = startPosX * -1;

        for (int x = 0; x < 5; x++)
        {

            float currentX = startPosX + (crateSize * x);
            
            for (int y = 0; y < 5; y++)
            {
                
                float currentY = startPosY - (crateSize * y);

                cratePositionList.Add(new Vector2(currentX, currentY));
            }
        }

        int index = 0;
        
        foreach (var position in cratePositionList)
        {
            if (initialCrateLayout[index] == 0)
            {
                index++;
                continue;
            }
            
            
            GameObject crate = Instantiate(initialCrateLayout[index] == 1 ? whiteCrate : blackCrate, transform);
            crate.GetComponent<RectTransform>().anchoredPosition = position;

            crateList.Add(crate.GetComponent<Crate>());
            Debug.Log(crateList.Last());

            index++;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            foreach (var crate in crateList)
            {
                crate.Move(0);
            }
        }
        
        if (Input.GetKeyDown(KeyCode.D))
        {
            foreach (var crate in crateList)
            {
                crate.Move(1);
            }
        }
        
        if (Input.GetKeyDown(KeyCode.W))
        {
            foreach (var crate in crateList)
            {
                crate.Move(2);
            }
        }
        
        if (Input.GetKeyDown(KeyCode.S))
        {
            foreach (var crate in crateList)
            {
                crate.Move(3);
            }
        }

        if (doDelay)
        {
            delayTimer -= Time.deltaTime;
        }

        if (solved)
        {
            doDelay = true;
            
            if (delayTimer <= 0)
            {
                gameManager.playerInventory.Add(GameManager.Item.RoomKey);
                gameManager.gameState = GameManager.GameState.Idle;
                gameManager.playerMessage.SendMessage("You obtained the Room Key!");
                gameManager.currentPlayerInteractable.canInteract = false;
                gameObject.SetActive(false);
            }
        }
    }
}
