using JetBrains.Rider.Unity.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]private Rigidbody bullet;


    
    private void Update()
    {
        PlayerMovementUpAndDown();

        Bullet();

    }



    private void PlayerMovementUpAndDown()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Translate(Vector2.up);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Translate(Vector2.down);
        }
    }

    public void Bullet()
    {
        Rigidbody cloneBullet;
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            
            cloneBullet = Instantiate(bullet,new Vector3(-15.9890003f, 0.651000023f, 0),transform.rotation);
            cloneBullet.velocity = transform.TransformDirection(Vector3.right *20);
            Destroy(cloneBullet.gameObject, 2);
        }
        
    }

    
}
