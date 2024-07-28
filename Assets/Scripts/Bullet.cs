using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10.0f;

    void Update()
    {
        // Kurþunu ileri doðru hareket ettir
        transform.position += Vector3.right * (speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Untagged"))
        {
            //      gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("enemy2"))
        {
            // Eðer çarpýlan obje "Enemy" etikete sahipse hem kurþunu hem de düþmaný pasif hale getir
         //   gameObject.SetActive(false);
           // collision.gameObject.SetActive(false);
        }
    }
}
