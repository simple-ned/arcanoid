using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField]
    private float speed = 4.0f;

    [SerializeField]
    private float mouseSensitivity = 5f;

    private Vector2 velocity;
    private Vector2 input;

    [SerializeField]
    private BoxCollider2D boxCollider;

    private float xMin = -4.2f;
    private float xMax = 4.2f;

    private void Update()
    {
        GetInput();
        Move();

        if (transform.position.x > xMax)
        {
            transform.position = new(xMax, transform.position.y, 0);
        } 
        else if (transform.position.x < xMin)
        {
            transform.position = new(xMin, transform.position.y, 0);
        }
    }

    private void Move()
    {
        transform.Translate(velocity * speed * Time.deltaTime);
    }

    private void GetInput()
    {
        velocity = GetMouseInput();

        if (velocity == Vector2.zero)
        {
            velocity = GetKeyboardInput();
        }
    }

    private Vector2 GetKeyboardInput()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            return Vector2.right;
        }  
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            return Vector2.left;
        }

        return Vector2.zero;
    }

    private Vector2 GetMouseInput()
    {
        var input = Input.GetAxis("Mouse X");
        return Vector2.right * input * speed * mouseSensitivity;
    }

    // Hit factor to change angle of hit; -1..1
    public float HitFactor(Vector2 point) { 
        float xOffset = point.x - transform.position.x;
        return xOffset / boxCollider.bounds.extents.x;
    }

}
