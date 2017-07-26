using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Scripts/Entitys/DestroyableObject")]
public class DestroyableEntity : MonoBehaviour
{
    #region:components
    private Team team;
    private UpdateHealthBar healthBar;

    public Team.TeamName Team
    {
        get { return team.CurrentTeam; }
        set
        {
            team.CurrentTeam = value;
        }
    }
    private Stats stats;
    #endregion
    #region:values
    private float[] currentStats;
    private float[] buffGrid;
    private float[] debuffGrid;
    private float maxHealth;
    private enum DamageType
    {
        PHYSICAL,
        MAGICAL,
        CRITICAL,
        FIRE,
        WATHER,
        EARTH,
        AIR
    }
    #endregion

    #region:basicFunctionnalities
    private void Awake()
    {
        team = GetComponent<Team>();
        stats = GetComponent<Stats>();
        healthBar = GetComponentInChildren<UpdateHealthBar>();
    }
    private void Start()
    {
        //Instantiate values
        currentStats = stats.AllStats;
        buffGrid = new float[stats.NumStats];
        debuffGrid = new float[stats.NumStats];
        maxHealth = currentStats[(int)StatType.HEALTH];
    }
    #endregion

    #region:publicFunctionalities
    public void TakeDamage(float damagePoints, StatType damageResistName)
    {
        currentStats[(int)StatType.HEALTH] -= damagePoints;
        if (currentStats[(int)StatType.HEALTH] < 0)
        {
            currentStats[(int)StatType.HEALTH] = 0;
        }
        healthBar.UpdateVisual(currentStats[(int)StatType.HEALTH], maxHealth);
    }
    #endregion
}
