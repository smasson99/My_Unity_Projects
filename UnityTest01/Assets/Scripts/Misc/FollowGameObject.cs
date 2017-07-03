using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Scripts/ReparentTo/Follow Game Object")]
public class FollowGameObject : MonoBehaviour
{
    [Header("ReparentTo Object")]
    [Tooltip("GameObject to follow. Z axis is ignored.")]
    [SerializeField]
    private GameObject objectToFollow;

    //void Awake()
    //{
    //    objectToFollow = GameObject.FindGameObjectWithTag("Player");
    //}

    void LateUpdate()
    {
        transform.position = new Vector3(objectToFollow.transform.position.x, objectToFollow.transform.position.y, transform.position.z);
    }
}
