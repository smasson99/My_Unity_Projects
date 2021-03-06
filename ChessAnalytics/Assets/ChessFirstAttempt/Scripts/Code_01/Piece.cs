﻿using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    //Public values
    public enum TypePiece
    {
        Roi = 0,
        Reine = 1,
        Fou = 2,
        Cavalier = 3,
        Tour = 4,
        Pion = 5
    }
    public TypePiece currentType;
    public Case CurrentCase
    {
        get
        {
            return currentCase;
        }
        set
        {
            if (currentCase != null)
            {
                currentCase.isOccuped = false;
            }
            currentCase = value;
            currentCase.isOccuped = true;
        }
    }
    public bool isWhite = true;
    public bool isDead = false;
    public bool isStarting = true;
    public Sprite[] sprites;
    //Private values
    private SpriteRenderer sprite;
    Collider2D collider;
    private Case currentCase;
    private Action<Piece> up_Click;
    //Private methods
    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        collider = GetComponent<Collider2D>();
    }
    //Public methods
    public void StartAt(Case startCase, TypePiece newType)
    {
        SetType(newType);
        MoveTo(startCase);
    }

    public void MoveTo(Case moveToCase)
    {
        //Update last status:
        CurrentCase.isOccuped = false;
        currentCase.EnableCollider();
        //Change the current case
        CurrentCase = moveToCase;
        //Set the current position
        transform.position = new Vector3(moveToCase.transform.position.x, moveToCase.transform.position.y, 0);
        //Change the status
        isStarting = false;
        CurrentCase.isOccuped = true;
        CurrentCase.DisableCollider();
    }

    private void SetType(TypePiece newType)
    {
        //Prevent an OutOfRangeException, do the change only if the sprites table is well instantiated
        if (sprites.Length == Enum.GetNames(typeof(TypePiece)).Length)
        {
            currentType = newType;
            sprite.sprite = sprites[(int)newType];
        }
    }

    public bool Die(Case GraveCase)
    {
        //currentCase.EnableCollider();
        currentCase = GraveCase;
        transform.position = new Vector3(GraveCase.transform.position.x, GraveCase.transform.position.y, 0);
        //Change the status
        //isDead = true;
        //Return isDead
        return isDead;
    }

    public void SubscribeTo_CLICK_UP(Action<Piece> onUp)
    {
        up_Click = onUp;
        //Debug.Log("Piece on case id == " + currentCase.id + " has been subscribed!");
    }

    private void OnMouseUp()
    {
        up_Click(this);
        Debug.Log("Piece clicked!");
    }

    public void DisableCollider()
    {
        if (collider != null)
        {
            collider.enabled = false;
            //Debug.Log("Piece on case id == " + currentCase.id.ToString() + " is disabled.");
        }
    }

    public void EnableCollider()
    {
        if (collider != null)
        {
            collider.enabled = true;
            //Debug.Log("Piece on case id == " + currentCase.id.ToString() + " is enabled.");
        }
    }
}
