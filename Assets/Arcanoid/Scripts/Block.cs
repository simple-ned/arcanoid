using System;
using UnityEngine;

public class Block : MonoBehaviour
{
    public Action<Block> WasHit;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Ball") { 
            WasHit?.Invoke(this);
        }
    }
}
