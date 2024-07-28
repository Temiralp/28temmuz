using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunOperation : MonoBehaviour
{
    public GameObject bulletPrefab;
    float bulletSpeed = 10.0f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }

        float verticalInput = Input.GetAxis("Vertical");
        transform.position += new Vector3(0, verticalInput, 0) * Time.deltaTime;
    }

    void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().speed = bulletSpeed;
        Debug.Log("Fire");
    }
}
