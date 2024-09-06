using UnityEngine;

public class MouseInput : MonoBehaviour
{
    public Vector2 MouseDelta => new(currentPosition.x - previousPosition.x, 0);
    public Vector2 CurrentPosition => currentPosition;
    
    private Vector2 previousPosition;
    private Vector2 currentPosition;

    private void Update()
    {
        previousPosition = currentPosition;
        currentPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
