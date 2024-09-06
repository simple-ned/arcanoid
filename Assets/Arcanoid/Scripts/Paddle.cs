using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField]
    private float speed = 1.0f;

    private Vector2 velocity;
    private Vector2 input;

    private void Move() { 
        transform.Translate(velocity * speed * Time.deltaTime);
    }

    private void Update()
    {
        GetInput();
        Move();
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
        return Input.GetAxis("Mouse X") * Vector2.right * 5f;
    }
}
