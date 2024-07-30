using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform target;
    bool is_going_left = false;
    bool is_going_right = false;
    bool is_going_forward = false;
    bool is_going_backward = false;
    private float moveHorizontal = 0f;
    private float moveVertical = 0f;
    private float movementSpeed = 5f;
    public float followRange = 10.0f;
    private void Awake()
    {

    }

    void Start()
    {

    }

    void Update()
    {
        Inputs();
        Movement();
    }

    private void FixedUpdate()
    {

    }

    private void Inputs()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            is_going_left = true;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            is_going_left = false;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            is_going_right = true;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            is_going_right = false;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            is_going_forward = true;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            is_going_forward = false;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            is_going_backward = true;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            is_going_backward = false;
        }
    }

    private void Movement()
    {
        moveHorizontal = 0;
        moveVertical = 0;

        if (is_going_left)
        {
            moveHorizontal = -1;
        }
        if (is_going_right)
        {
            moveHorizontal = 1;
        }

        if (is_going_forward)
        {
            moveVertical = 1;
        }
        if (is_going_backward)
        {
            moveVertical = -1;
        }

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        transform.position += movement * movementSpeed * Time.deltaTime;
    }
}