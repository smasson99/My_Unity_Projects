using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Triggers/ChangePlayerColor")]
public class ChangePlayerColor : MonoBehaviour
{
    [Tooltip("The color to set to the player")]
    [SerializeField]
    private Color newColor = Color.red;

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerEntity playerEntity = other.GetComponentInParent<PlayerEntity>();
        if (playerEntity != null)
        {
            playerEntity.ChangeColorTo(newColor);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        PlayerEntity playerEntity = other.GetComponentInParent<PlayerEntity>();
        if (playerEntity != null)
        {
            playerEntity.ResetColor();
        }
    }
}
