using UnityEngine;

[AddComponentMenu("Input/Keyboard")]
public class KeyboardMovement : MonoBehaviour
{
    private const int LEFT_ROTATION = 1;
    private const int RIGHT_ROTATION = -1;

    [Tooltip("Speed of the GameObject in units per second.")]
    [SerializeField]
    private float speed = 5;

    [Tooltip("Roation speed of the GameObject in degrees per second.")]
    [SerializeField]
    private float rotationSpeed = 150;

    [Tooltip("Key to press to move the GameObject to the left.")]
    [SerializeField]
    private string leftKey = "a";

    [Tooltip("Key to press to move the GameObject to the right.")]
    [SerializeField]
    private string rightKey = "d";

    [Tooltip("Key to press to move the GameObject up.")]
    [SerializeField]
    private string upKey = "w";

    [Tooltip("Key to press to move the GameObject down.")]
    [SerializeField]
    private string downKey = "s";

    public void Update()
    {
        RotateIfKeyPressed(LEFT_ROTATION, leftKey);
        RotateIfKeyPressed(RIGHT_ROTATION, rightKey);
        MoveIfKeyPressed(Vector3.up, upKey);
        MoveIfKeyPressed(Vector3.down, downKey);
    }

    private void MoveIfKeyPressed(Vector3 direction, string keyCode)
    {
        if (Input.GetKey(keyCode))
        {
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }

    private void RotateIfKeyPressed(int direction, string keyCode)
    {
        if (Input.GetKey(keyCode))
        {
            transform.Rotate(Vector3.forward, direction * rotationSpeed * Time.deltaTime);
        }
    }
}