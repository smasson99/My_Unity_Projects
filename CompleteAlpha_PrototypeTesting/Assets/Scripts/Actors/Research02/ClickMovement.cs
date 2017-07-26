using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class ClickMovement : MonoBehaviour
{
  [SerializeField] private GameObject visual;
  private Vector3 fromPosition;
  private Vector3 toPosition;
  private bool isMoving = false;
  private const int RIGHT_MOUSE_BUTTON = 1;
  private NavMeshAgent agent;

  // Les directions possibles du mob
  //private enum Direction
  //{
  //  FRONT,
  //  RIGHT,
  //  LEFT,
  //  BACK
  //}
  // les sprites possibles du mob
  string[] spriteLinks = { @"Assets/Visual/Actors/IA/Mob/BasicMob/Basic/left_sprite.png",
                           @"Assets/Visual/Actors/IA/Mob/BasicMob/Basic/right_sprite.png",
                           @"Assets/Visual/Actors/IA/Mob/BasicMob/Basic/back_sprite.png",
                           @"Assets/Visual/Actors/IA/Mob/BasicMob/Basic/front_sprite.png",};

  public void Awake()
  {
    agent = GetComponentInParent<NavMeshAgent>();
    fromPosition = agent.transform.position;
    toPosition = agent.transform.position;
  }
  public void Update()
  {
      // button detection
      //if (Input.GetMouseButton(RIGHT_MOUSE_BUTTON))
      //{
      //        Vector3 worldPoint = Camera.main.ScreenToWorldPoint(new Vector3(
      //                                                                        Input.mousePosition.x,
      //                                                                        Input.mousePosition.y,
      //                                                                        7.5f));
      //    agent.SetDestination(worldPoint);
      //}

    // wich side of the character is printed
    fromPosition = agent.transform.position;
    Vector2 positionToPosition = new Vector2(toPosition.x - fromPosition.x, toPosition.z - fromPosition.z);
    float directionAngle = (float)Math.Atan2(positionToPosition.y, positionToPosition.x) * (float)(360 / (Math.PI * 2));
    toPosition = fromPosition;

    //Debug.Log(directionAngle);

    // vérification des angles
    if (directionAngle == 0 && !isMoving)
    {
      // ne rien faire
    }
    // à gauche
    else if (directionAngle < 45 && directionAngle > - 45)
    {
      visual.GetComponent<SpriteRenderer>().sprite = AssetDatabase.LoadAssetAtPath<Sprite>(spriteLinks[0]);
    }
    // à droite
    else if (directionAngle < - 135 || directionAngle > 135)
    {
      visual.GetComponent<SpriteRenderer>().sprite = AssetDatabase.LoadAssetAtPath<Sprite>(spriteLinks[1]);
    }
    // en haut
    else if (directionAngle < - 45 && directionAngle > - 135)
    {
      visual.GetComponent<SpriteRenderer>().sprite = AssetDatabase.LoadAssetAtPath<Sprite>(spriteLinks[2]);
    }
    // en bas
    else if (directionAngle < 135 && directionAngle > 45)
    {
      visual.GetComponent<SpriteRenderer>().sprite = AssetDatabase.LoadAssetAtPath<Sprite>(spriteLinks[3]);
    }
  }
}
