using System;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField]
    private int Level = 1;

    [SerializeField]
    private List<Color32> colors;

    [SerializeField]
    private SpriteRenderer renderer;

    public Action<Block> Destroyed;

    public int ScoreCost { get; private set; } = 10;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Ball") {
            if (Level == 1) {
                Destroyed?.Invoke(this);
            } else { 
                DecreaseLevel();
            }
        }
    }

    private void DecreaseLevel()
    {
        Level--;
        renderer.color = colors[Level - 1];
    }
}
