using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Scripts/Stats/Character_DObject_Stats")]
public class Stats : MonoBehaviour
{
    [Tooltip("The main stats of the entity")]
    [SerializeField]
    private HealthPresset healthStats;

    [Tooltip("The second stats of the entity")]
    [SerializeField]
    private CharacterStatPresset characterStats;

    public enum StatType
    {
        HEALTH,
        PASSIVE_HEALTH_REGEN,
        COMBAT_HEALTH_REGEN,
        SPEED,
        PHYSICAL_RESISTANCE,
        MAGICAL_RESISTANCE,
        ELEMENTAL_RESISTANCE,
        FIRE_RESISTANCE,
        WATHER_RESISTANCE,
        AIR_RESISTANCE,
        EARTH_RESISTANCE,
        ICE_RESISTANCE,
        CRITICAL_RESISTANCE,
        OVERHALL_RESISTANCE,
        CRITICAL_CHANCES,
        DAMAGE_PENETRATION,
        BLOCK_CHANCES,
        DODGE_CHANCES,
        REPLY_CHANCES,
        MELEE_DAMAGE,
        RANGE_DAMAGE
    }

    public int NumStats
    {
        get { return System.Enum.GetNames(typeof(StatType)).Length; }
    }

    private float[] stats;

    void Start()
    {
        //Instantiate values
        stats = new float[NumStats];
        //Call the functions
        LaunchTheStatData(stats);
    }

    private void LaunchTheStatData(float[] tab)
    {
        if (tab.Length == healthStats.CompiledValues.Length + characterStats.CompiledValues.Length)
        {
            for (int i = 0; i < healthStats.CompiledValues.Length; i++)
            {
                tab[i] = healthStats.CompiledValues[i];
            }
            for (int i = healthStats.CompiledValues.Length - 1; i < characterStats.CompiledValues.Length; i++)
            {
                tab[i] = characterStats.CompiledValues[i];
            }
        }
    }
}
