using UnityEngine;

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
        velocity *= speed;
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
        transform.Translate(velocity * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var point = collision.GetContact(0);
        var delta = (Vector2)transform.position - point.point;
        if (delta.x != 0) {
            BounceX();
        }

        if (delta.y != 0) {
            BounceY();
        }

        if (collision.collider.tag == "Blocks") {
            Debug.Log($"Center - {transform.position}, Point - {point.point}, Object - {collision.collider.name}");
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
