using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Assets.Scripts.Actors.Misc;
using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu("Scripts/Idle/Navi_Idle")]
public class NaviIdle : MonoBehaviour
{
    [Header("Idle rotation configuration")]
    [Tooltip("The object to turn around the object")]
    [SerializeField]
    private GameObject target;
    [Tooltip("Speed of the translation")]
    [SerializeField]
    private float speed;
    [Tooltip("Max distance of the right rotation")]
    [SerializeField]
    [Range(-5, 5)]
    private float addMax;
    [Tooltip("Min distance of the left rotation")]
    [SerializeField]
    [Range(-5,5)]
    private float addMin;
    [Tooltip("The object can go behind his target")]
    [SerializeField]
    private bool canBehind = true;
    //[Slider()]

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.SetActive(false);
    }


    public void Update()
    {
        Rigidbody2D rigidBody = GetComponent<Rigidbody2D>();

        rigidBody.AddForce();

        Vector3 directionX = Vector3.right;
        Vector3 directionY = Vector3.down;
        if (transform.position.x < (-target.transform.lossyScale.x) / 2 - addMin && directionX != Vector3.right)
        {
            directionX = Vector3.right;
            if (canBehind)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
            }
        }
        else if (transform.position.x > (target.transform.lossyScale.x / 2) + addMax && directionX != Vector3.left)
        {
            directionX = Vector3.left;
            if (canBehind)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
            }
        }
        if (transform.position.y < (-target.transform.lossyScale.y) / 2 - addMin && directionY != Vector3.up)
        {
            directionY = Vector3.up;
            if (canBehind)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
            }
        }
        else if (transform.position.y > (target.transform.lossyScale.y / 2) + addMax && directionY != Vector3.down)
        {
            directionY = Vector3.down;
            if (canBehind)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
            }
        }
        transform.Translate((directionX + directionY) * speed * Time.deltaTime);
    }
}
