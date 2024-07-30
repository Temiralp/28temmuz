using JetBrains.Rider.Unity.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    
    private Rigidbody2D playerRb;

    private float moveSpeed;
    float dirX, dirY;

    #region Initiliaze
    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }
    #endregion
    private void Update()
    {
        PlayerMove();
        

    }



    private void PlayerMove()
    {
        moveSpeed = 10;
        dirX = Input.GetAxisRaw("Horizontal") * moveSpeed;
        dirY = Input.GetAxisRaw("Vertical") * moveSpeed;
        playerRb.velocity = new Vector2 (dirX, dirY);
    }

    

    
}
