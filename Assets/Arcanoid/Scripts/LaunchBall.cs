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
        if (Input.GetKeyDown(KeyCode.Mouse0) && !ball.IsMoving) {
            Launch();
        }
    }

    private void Launch()
    {
        float angle = Mathf.Deg2Rad * (Random.value * 70 + 10);

        Vector2 startVelocity = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

        ball.IsMoving = true;
        transform.parent = null;
        ball.SetVelocity(startVelocity);

        enabled = false;
    }
}
