using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoment : MonoBehaviour
{

    void Update()
    {
        PlayerUpMoment();
        PlayerDownMoment();
    }

    void PlayerUpMoment()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            this.gameObject.transform.position += Vector3.up;
        }
    }
    void PlayerDownMoment()
    {
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            this.gameObject.transform.position += Vector3.down;
        }
    }
}
