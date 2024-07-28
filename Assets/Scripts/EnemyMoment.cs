using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    float enemySpeed = 0.5f;

    void Update()
    {
        MoveEnemy();
    }

    void MoveEnemy()
    {
        transform.position += Vector3.left * (enemySpeed * Time.deltaTime);
    }
}
