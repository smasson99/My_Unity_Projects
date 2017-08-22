using System;
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
    private Action<Case> OnClickUp;
    private Collider2D collider;
    //Methods
    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        collider = GetComponent<Collider2D>();
    }
    //Private methods
    private void Start()
    {
        initialColor = sprite.color;
    }
    private void OnMouseUp()
    {
        OnClickUp(this);
        Debug.Log("Case on id == " + id.ToString() + " is clicked!");
    }
    //Public methods
    public void SetColor(Color newColor)
    {
        sprite.color = newColor;
    }

    public void ResetColor()
    {
        sprite.color = initialColor;
    }

    public void SubscribeToClickUp(Action<Case> OnClickUpEvent)
    {
        OnClickUp = OnClickUpEvent;
        Debug.Log("Case id == " + id.ToString() + "subscribed");
    }

    public void DisableCollider()
    {
        collider.enabled = false;
    }

    public void EnableCollider()
    {
        collider.enabled = true;
    }
}
