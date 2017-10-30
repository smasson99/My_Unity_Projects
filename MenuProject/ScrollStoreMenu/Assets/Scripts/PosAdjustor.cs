using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosAdjustor : MonoBehaviour
{
    [SerializeField]
    RectTransform myRectTransform;
    [SerializeField]
    float xadjustment = 0.0f;
    [SerializeField]
    float yadjustment = 0.0f;

    // Use this for initialization
    void Start()
    {

        myRectTransform.localPosition = new Vector2(myRectTransform.localPosition.x + xadjustment, myRectTransform.localPosition.y + yadjustment);
    }
}
