using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Case : MonoBehaviour
{
    //Public values
    public int id;
    public bool isOccuped = false;
    //Private values
    private Color initialColor;
    private SpriteRenderer sprite;
    //Methods
    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }
    //Private methods
    private void Start()
    {
        initialColor = sprite.color;
    }

    public void SetColor(Color newColor)
    {
        sprite.color = newColor;
    }

    public void ResetColor()
    {
        sprite.color = initialColor;
    }
}
