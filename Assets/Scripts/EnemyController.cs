using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 2.5f;

    void FixedUpdate() 
    {
        Move();
    }

    void Move()
    {
        Vector2 newPos = transform.position;

        newPos.x += moveSpeed * Time.fixedDeltaTime;

        transform.position = newPos;
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Wall"))
        {
            moveSpeed *= -1;
        }
    }

}
