﻿using UnityEngine;

[AddComponentMenu("Scripts/Interface/UpdateHealthBar")]
public class UpdateHealthBar : MonoBehaviour
{
    public void UpdateVisual(float currentHealth, float maxHealth)
    {
        transform.localScale = new Vector3(currentHealth/maxHealth, transform.localScale.y, transform.localScale.z);
    }
}