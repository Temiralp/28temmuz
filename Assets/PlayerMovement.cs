using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    
    private void Update()
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
}
