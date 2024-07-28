using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]private GameObject bullet;
    
    private void Update()
    {
        PlayerMovementUpAndDown();



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
        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            Instantiate(bullet);
        }
    }

    
}
