using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContentItem : MonoBehaviour
{
    [SerializeField]
    private RectTransform myRectTransform;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private float GetHeight()
    {
        return myRectTransform.sizeDelta.y;
    }

    private void Init(SizeParams paramsSize)
    {
        myRectTransform.sizeDelta = new Vector2(paramsSize.x, paramsSize.y);
    }
}
