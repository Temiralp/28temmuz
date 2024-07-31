using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region singleton
    private Player instance;
    public Player Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<Player>();
            }
            return instance;
        }
    }
    #endregion

    [SerializeField] private Rigidbody2D bullet;
    public int maxHealth;
    public int health; // player can.
    public int takenDamage;

    
    private void Start()
    {
        takenDamage = 10;   
        maxHealth = 100;
        health = maxHealth;
    }
    private void Update()
    {
        MaxHealth();
        FireBullet();
        
    }
    public void MaxHealth()
    {
        
        if(health <= 0)
        {
            health = 0;
        }
        else if(health > 100)
        {
            health = maxHealth;
        }
    }
    
    public void CanAzalt()
    {
        health -= takenDamage;
    }
    //Merminin ates edildigi zaman.
    public void FireBullet()
    {
        Rigidbody2D cloneBullet;
        if (Input.GetKeyDown(KeyCode.Space))
        {

            cloneBullet = Instantiate(bullet, new Vector2(transform.position.x, transform.position.y), transform.rotation);
            cloneBullet.velocity = transform.TransformDirection(Vector3.right * 20);
            Destroy(cloneBullet.gameObject, 2);
        }
        
    }
    //Bir dusmana carptigi zaman hasar aliyor. ve Dusmani yok oluyor.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "enemy")
        {
            CanAzalt();
            Destroy(collision.gameObject);
            
        }
    }

}
