using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 15f;

    float moveXInput;
    float moveYInput;

    Rigidbody2D rigid;

    void Awake() 
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Start() 
    {
        if(rigid.bodyType != RigidbodyType2D.Dynamic)
            rigid.bodyType = RigidbodyType2D.Dynamic;
    }

    void Update() 
    {
        moveXInput = Input.GetAxis("Horizontal");
        moveYInput = Input.GetAxis("Vertical");
    }

    void FixedUpdate() 
    {
        Move();        
    }

    void Move()
    {
        Vector2 newPos = transform.position;

        newPos.x += moveXInput * moveSpeed * Time.fixedDeltaTime;
        newPos.y += moveYInput * moveSpeed * Time.fixedDeltaTime;

        transform.position = newPos;
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            rigid.bodyType = RigidbodyType2D.Kinematic;

            GameManager.Instance.RestartGame();
        }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Safe"))
        {
            GameManager.Instance.GameOver();
        }
    }

}
