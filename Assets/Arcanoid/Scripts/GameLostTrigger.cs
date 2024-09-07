using UnityEngine;

public class GameLostTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ball") {
            Debug.LogWarning("Game Lost!");
        }
    }
}
