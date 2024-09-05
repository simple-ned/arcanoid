using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField]
    private float speed = 1.0f;

    private Vector2 velocity;

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
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            velocity = Vector2.right;
        } else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            velocity = Vector2.left;
        } else {
            velocity = Vector2.zero;
        }
    }
}
