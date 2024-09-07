using UnityEngine;

public class LaunchBall : MonoBehaviour
{
    [SerializeField]
    Ball ball;

    private void Awake()
    {
        ball.IsMoving = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            ball.IsMoving = true;
            transform.parent = null;
        }
    }
}
