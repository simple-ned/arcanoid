using UnityEngine;
using UnityEngine.UIElements;

public class Ball : MonoBehaviour, IResetable
{
    [SerializeField]
    private Vector2 velocity = Vector2.down;

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

    void Update()
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

        if (Mathf.Abs(normal.x - normal.y) <= 0.2f) {
            BounceX();
            BounceY();
        } else if (Mathf.Abs(normal.x) > Mathf.Abs(normal.y)) {
            BounceX();
        } else if (Mathf.Abs(normal.y) > Mathf.Abs(normal.x)) {
            BounceY();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
    }

    private void BounceY()
    {
        velocity.y *= -1;
    }

    private void BounceX()
    {
        velocity.x *= -1;
    }

    public void Reset()
    {
        IsMoving = false; 
        transform.parent = paddle.transform;
        transform.localPosition = startPosition;
    }
}
