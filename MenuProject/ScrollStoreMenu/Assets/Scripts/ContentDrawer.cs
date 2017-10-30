using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContentDrawer : MonoBehaviour
{
    [SerializeField]
    RectTransform myRectTransform;

    [Tooltip("The prefab of the item content (simple unit) in the list.")]
    [SerializeField]
    private GameObject prefItemContent;

    private static float prefItemHeight;
    [SerializeField]
    private int nbItems = 0;

    [SerializeField]
    float sizeContentX = 450.0f;

    [SerializeField]
    float sizeContentY = 70.0f;

    SizeParams sizeParams;

    // Use this for initialization
    void Start()
    {
        //Inistantiation of values
        sizeParams = new SizeParams(sizeContentX, sizeContentY);
        for (int i = 0; i < 10; ++i)
        {
            DrawItem("", 1);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DrawItem(string name, float value)
    {
        GameObject instance = Instantiate(prefItemContent, transform);
        instance.SetActive(true);
        instance.SendMessage("Init", sizeParams);
        ++nbItems;
    }
}
