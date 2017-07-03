using System;
using UnityEngine;

public delegate void OnHealthChangeHandler(int oldHealthPoints, int newHealthPoints);
public delegate void OnDeathHandler();

public class Health2 : MonoBehaviour
{
    private int healthPoints;

    public int HealthPoints
    {
        get { return healthPoints; }
        private set
        {
            int oldHealthPoints = healthPoints;

            healthPoints = value;

            if (OnHealthChanged != null)
                OnHealthChanged(oldHealthPoints, healthPoints);
            if (OnDeath != null && healthPoints <= 0)
                OnDeath();
        }
    }

    public event OnHealthChangeHandler OnHealthChanged;
    public event OnDeathHandler OnDeath;

    public void Hit(int hitPoints)

    {
        HealthPoints -= hitPoints;
    }

    public void Heal(int healPoints)
    {
        HealthPoints += healPoints;
    }

}

public class DestroyOnDeath2 : MonoBehaviour
{
    private Health2 health;

    public void Awake()
    {
        health = GetComponent<Health2>();


    }

    public void Start()
    {
        health.OnHealthChanged += OnEnnemyHealthChanged;
        health.OnDeath += OnEnnemyDeath;
    }

    private void OnEnnemyHealthChanged(int healthPoints, int newHealthPoints)
    {
        throw new NotImplementedException();
    }
    private void OnEnnemyDeath()
    {
        throw new NotImplementedException();
    }
}