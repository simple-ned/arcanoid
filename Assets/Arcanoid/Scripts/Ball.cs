using System;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private Vector2 velocity = Vector2.down;

    [SerializeField]
    private float speed = 5.0f;

    private void Start()
    {
        velocity *= speed;
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(velocity * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Paddle") {
            BounceY();
        }
    }

    private void BounceY() {
        velocity.y *= -1;
    }
}
