using UnityEngine;

public class LoseBallTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ball") {
            GameManager.Instance.BallLost();
        }
    }
}
