using UnityEngine;

public class Ball : MonoBehaviour, IResetable
{
    private Vector2 velocity;

    [SerializeField]
    private float speed = 5.0f;

    [SerializeField]
    private Paddle paddle;

    private Vector2 startPosition;

    public bool IsMoving { get; set; } = false;

    private void Start()
    {
        startPosition = transform.localPosition;
    }

    void FixedUpdate()
    {
        if (IsMoving) {
            Move();
        }
    }

    private void Move()
    {
        transform.Translate(velocity * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var point = collision.GetContact(0);

        var normal = collision.contacts[0].normal;

        if (collision.collider.name == "Paddle") {
            var paddle = collision.collider.GetComponent<Paddle>();
            var hitFactor = paddle.HitFactor(point.point);
            BounceY(hitFactor);
            return;
        }

        if (Mathf.Abs(normal.x - normal.y) < 0.1f) {
            BounceX();
            BounceY();
        } else if (Mathf.Abs(normal.x) > Mathf.Abs(normal.y)) {
            BounceX();
        } else if (Mathf.Abs(normal.y) > Mathf.Abs(normal.x)) {
            BounceY();
        }

        Debug.Log($"Normal {normal}, new velocity {velocity}");
    }

    private void BounceY(float hitFactor = 0)
    {
        if (hitFactor == 0) {
            velocity.y *= -1;
        } else {
            float angle = Mathf.Deg2Rad * (-hitFactor * 70 + 100);
            velocity = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        }
    }

    private void BounceX()
    {
        velocity.x *= -1;
    }

    public void SetVelocity(Vector2 velocity)
    {
        this.velocity = velocity;
    }

    public void Reset()
    {
        IsMoving = false;
        transform.parent = paddle.transform;
        transform.localPosition = startPosition;
    }
}
