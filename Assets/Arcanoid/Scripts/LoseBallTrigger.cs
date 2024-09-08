using UnityEngine;

public class LoseBallTrigger : MonoBehaviour
{
    [SerializeField]
    private GameSession gameSession;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ball") {
            gameSession.BallLost();
        }
    }
}
