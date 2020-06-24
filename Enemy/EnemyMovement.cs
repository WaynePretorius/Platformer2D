using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float enemySpeed = 1f;

    private Rigidbody2D enemyBody;

    private void Awake()
    {
        AwakeFuncions();
    }

    private void AwakeFuncions()
    {
        enemyBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        MoveEnemy();
    }

    private void MoveEnemy()
    {
        var newPos = new Vector2(transform.position.x * enemySpeed, enemyBody.position.y);

        enemyBody.velocity = newPos;
    }
}
