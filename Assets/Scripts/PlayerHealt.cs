using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 3; // Player'ýn baþlangýç can deðeri

    void Start()
    {
        // Ýlk can deðerini yazdýr
        Debug.Log("Player Health: " + health);
    }

    void Update()
    {
        // Can deðeri 0 olduðunda player'ý yok et
        if (health <= 0)
        {
            Debug.Log("Player has been destroyed");
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy2"))
        {
            // Can deðerini azalt
            health--;
            Debug.Log("Player Health: " + health);
        }
    }
}
