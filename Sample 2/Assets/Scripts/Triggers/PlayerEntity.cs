using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Entitys/Player")]
public class PlayerEntity : MonoBehaviour
{
    private SpriteRenderer renderer;

    private Color startingColor;

    // Use this for initialization
    void Awake()
    {
        renderer = GetComponentInChildren<SpriteRenderer>();
        startingColor = renderer.color;
    }


    public void ChangeColorTo(Color color)
    {
        renderer.color = color;
    }

    public void ResetColor()
    {
        renderer.color = startingColor;
    }
}
