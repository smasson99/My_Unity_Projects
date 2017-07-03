using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[AddComponentMenu("Scripts/Input/Keyboard")]
public class KeyboardMovement : MonoBehaviour
{
    [Header("Target")]
    [Tooltip("The GameObject to move.")]
    [SerializeField]
    private GameObject gameObjectToMove;
    [Tooltip("The GameObject to change the sprite.")]
    [SerializeField]
    private GameObject gameObjectToChangeSprite;
    [Header("Key Configuration")]
    [Tooltip("Key used to move LEFT")]
    [SerializeField]
    private string leftKey = "a";
    [Tooltip("Key used to move the GameObject RIGHT")]
    [SerializeField]
    private string rightKey = "d";
    [Tooltip("Key used to JUMP")]
    [SerializeField]
    private string jumpKey = "w";
    //[Tooltip("Key used to move the GameObject DOWN")]
    //[SerializeField]
    //private string downKey = "s";
    [Header("Options")]
    [Tooltip("Speed of the GameObject.")]
    [SerializeField]
    private float speed = 5;
    [Tooltip("If the GameObject can jump(CHECKED) or not(UNCHECKED)")]
    [SerializeField]
    private bool canJump = true;
    //private bool canJump = false;
    [Tooltip("The force pulse to make the GameObject go upside.")]
    [SerializeField]
    private float jumpPower = 1.50f;

    private enum Direction
    {
        FRONT,
        RIGHT,
        LEFT
    }
    string[] SpriteLinks = { @"Assets/Visuals/Actors/Player/player_front_sprite.png",
                             @"Assets/Visuals/Actors/Player/player_right_sprite.png",
                             @"Assets/Visuals/Actors/Player/player_left_sprite.png" };
    public void Update()
    {
        MoveIfKeyPressed(Vector3.left, leftKey, Direction.LEFT);
        MoveIfKeyPressed(Vector3.right, rightKey,Direction.RIGHT);
        //MoveIfKeyPressed(Vector3.down, downKey);
        JumpIfKeyPressed(Vector3.up, jumpKey);
        // On "lock" la rotation, mais le personnage glisse vers la gauche
        gameObjectToMove.transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    private void MoveIfKeyPressed(Vector2 direction, string keyCode, Direction dir)
    {
        if (Input.GetKey(keyCode))
        {
            gameObjectToMove.GetComponent<Rigidbody2D>().AddForce(direction * speed * Time.deltaTime, ForceMode2D.Impulse);
            gameObjectToChangeSprite.GetComponent<SpriteRenderer>().sprite = AssetDatabase.LoadAssetAtPath<Sprite>(SpriteLinks[(int)dir]);
        }
        else if (Input.GetKeyUp(keyCode))
        {
            // Enlève la "glace" sur le sol si on touche au sol :)
            //if (canJump)
            //{
                gameObjectToMove.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            //}
            gameObjectToChangeSprite.GetComponent<SpriteRenderer>().sprite = AssetDatabase.LoadAssetAtPath<Sprite>(SpriteLinks[0]);
        }
    }

    private void JumpIfKeyPressed(Vector3 direction, string keyCode)
    {
        if (Input.GetKey(keyCode) && canJump)
        {
            gameObjectToMove.GetComponent<Rigidbody2D>().AddForce(direction * jumpPower * Time.deltaTime, ForceMode2D.Impulse);
        }
    }

}
