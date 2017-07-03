using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Resources;
using UnityEditor;
using UnityEngine;

[AddComponentMenu("Scripts/Input/Keyboard")]
public class KeyboardMovement : MonoBehaviour
{
    [Header("Key Configuration")]
    [Tooltip("The GameObject to move.")]
    [SerializeField]
    private GameObject gameObjectToMove;
    [Tooltip("The GameObject visual.")]
    [SerializeField]
    private GameObject gameObjectToChangeSprite;
    [Tooltip("Speed of the GameObject.")]
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
    [Tooltip("If the GameObject can spawn(CHECKED) or not(UNCHECKED)")]
    [SerializeField]
    private bool canJump = false;
    [Tooltip("Key used to JUMP")]
    [SerializeField]
    private string jumpKey = "space";
    [Tooltip("The force pulse to make the GameObject go upside.")]
    [SerializeField]
    private float jumpPower = 135.00f;

    //Liste des directions
    private enum Direction
    {
        FRONT,
        BACK,
        RIGHT,
        LEFT
    }
    Direction position = Direction.FRONT;
    string[] links = new string[] { @"Assets/Visuals/Actors/front_sprite.png", @"Assets/Visuals/Actors/back_sprite.png", @"Assets/Visuals/Actors/right_sprite.png", @"Assets/Visuals/Actors/left_sprite.png" };

    // Update is called once per frame
    public void Update()
    {
        MoveIfKeyPressed(Vector3.left, leftKey, Direction.LEFT);
        MoveIfKeyPressed(Vector3.right, rightKey, Direction.RIGHT);
        MoveIfKeyPressed(Vector3.up, upKey, position);
        MoveIfKeyPressed(Vector3.down, downKey, position);
        JumpIfKeyPressed(Vector3.up, jumpKey);
    }

    private void MoveIfKeyPressed(Vector3 direction, string keyCode, Direction position)
    {
        if (Input.GetKey(keyCode))
        {
            gameObjectToMove.transform.Translate(direction * speed * Time.deltaTime);
            this.position = position;
            gameObjectToChangeSprite.GetComponent<SpriteRenderer>().sprite = AssetDatabase.LoadAssetAtPath<Sprite>(links[(int)position]);
            gameObjectToChangeSprite.GetComponent<SpriteRenderer>().color = Color.red;
        }
        else if (Input.GetKeyUp(keyCode))
        {
            gameObjectToChangeSprite.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    private void JumpIfKeyPressed(Vector3 direction, string keyCode)
    {
        if (Input.GetKey(keyCode) && canJump)
        {
            gameObjectToMove.GetComponent<Rigidbody2D>().AddForce(direction * jumpPower * Time.deltaTime, ForceMode2D.Impulse);
            gameObjectToChangeSprite.GetComponent<SpriteRenderer>().color = Color.yellow;
        }
        else if (Input.GetKeyUp(keyCode))
        {
            gameObjectToChangeSprite.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
}
