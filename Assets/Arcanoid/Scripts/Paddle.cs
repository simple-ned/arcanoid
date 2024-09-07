using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField]
    private float speed = 4.0f;

    [SerializeField]
    private float mouseSensitivity = 5f;

    private Vector2 velocity;
    private Vector2 input;

    private float xMin = -4;
    private float xMax = 4;

    private void Move() { 
        transform.Translate(velocity * speed * Time.deltaTime);
    }

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
}
