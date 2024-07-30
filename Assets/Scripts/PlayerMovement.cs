using JetBrains.Rider.Unity.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]private Rigidbody bullet;
    [SerializeField]private Transform playerTransform;
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
        FireBullet();

    }



    private void PlayerMove()
    {
        moveSpeed = 10;
        dirX = Input.GetAxisRaw("Horizontal") * moveSpeed;
        dirY = Input.GetAxisRaw("Vertical") * moveSpeed;
        playerRb.velocity = new Vector2 (dirX, dirY);
    }

    public void FireBullet()
    {
        Rigidbody cloneBullet;
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            
            cloneBullet = Instantiate(bullet,new Vector3(playerTransform.position.x ,playerTransform.position.y, 0),transform.rotation);
            cloneBullet.velocity = transform.TransformDirection(Vector3.right *20);
            Destroy(cloneBullet.gameObject, 2);
        }
        
    }

    
}
