using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crate : MonoBehaviour
{
    public CratePuzzle cratePuzzle;
    
    public bool canMove;
    public bool isMoving;

    public float speed;
    public float moveTime, moveTimer;

    public Image selfImage;

    private Vector2 _direction;
    
    private void Start()
    {
        selfImage.color = Color.white;
        moveTimer = moveTime;
    }

    private void Update()
    {
        if (moveTimer <= moveTime)
        {
            transform.Translate(_direction * speed * Time.deltaTime);
        }
        else
        {
            isMoving = false;
            _direction = new Vector2(0, 0);
        }
    }
    
    // 0 Left, 1 Right, 2 Up, 3 Down.
    public void Move(int direction)
    {
        if (isMoving) return;
        
        float moveTimer = 0;

        switch (direction)
        {
            case 0:
                _direction = new Vector2(-1, 0);
                break;
            
            case 1:
                _direction = new Vector2(1, 0);
                break;
            
            case 2:
                _direction = new Vector2(0, 1);
                break;
            
            case 3:
                _direction = new Vector2(0, -1);
                break;
        }
    }
}
