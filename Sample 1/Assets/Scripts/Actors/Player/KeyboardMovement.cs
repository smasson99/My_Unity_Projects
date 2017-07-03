using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Scripts/Input/Keyboard")]
public class KeyboardMovement : MonoBehaviour
{
    [Header("Key Configuration")]
    [Tooltip("Speed of the GameObject")]
    [SerializeField]
    private float speed = 5;
    [Tooltip("Key used to move LEFT")]
    [SerializeField]
    private string leftKey = "a";
    [Tooltip("Key used to move the GameObject RIGHT")]
    [SerializeField]
    private string rightKey = "d";
    [Tooltip("Key used to move the GameObject UP")]
    [SerializeField]
    private string upKey = "w";
    [Tooltip("Key used to move the GameObject DOWN")]
    [SerializeField]
    private string downKey = "s";

    // Update is called once per frame
    public void Update()
    {
        MoveIfKeyPressed(Vector3.left, leftKey);
        MoveIfKeyPressed(Vector3.right, rightKey);
        MoveIfKeyPressed(Vector3.up, upKey);
        MoveIfKeyPressed(Vector3.down, downKey);
    }

    private void MoveIfKeyPressed(Vector3 direction, string keyCode)
    {
        if (Input.GetKey((keyCode)))
        {
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }
}
