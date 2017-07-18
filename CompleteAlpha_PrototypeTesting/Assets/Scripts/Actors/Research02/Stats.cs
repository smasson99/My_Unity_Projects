using UnityEngine;

[AddComponentMenu("Scripts/Character/Destroyable_CharaterORObject_Stats")]
public class Stats : MonoBehaviour
{
    #region:values
    [Tooltip("The main stats of the entity")]
    [SerializeField]
    private HealthPresset healthStats;

    [Tooltip("The second stats of the entity")]
    [SerializeField]
    private CharacterStatPresset characterStats;

    public int NumStats
    {
        get { return System.Enum.GetNames(typeof(StatType)).Length; }
    }

    private float[] stats;

    public float[] AllStats
    {
        get { return stats; }
    }

    #endregion
    #region:basicFunctions
    void Awake()
    {
        //Instantiate values
        stats = new float[21] { healthStats.Health, healthStats.PassiveHealthRegen, healthStats.CombatHealthRegen,
            characterStats.Speed, characterStats.PhysicalResistance, characterStats.MagicalResistance, characterStats.ElementalResistance,
        characterStats.FireResistance, characterStats.WaterResistance, characterStats.AirResistance, characterStats.EarthResistance,
        characterStats.IceResistance, characterStats.CriticalResistance, characterStats.OverhallResistance, characterStats.CriticalChances,
        characterStats.DamagePenetration, characterStats.BlockChances, characterStats.DodgeChances, characterStats.ReplyChances,
        characterStats.MeleeDamage, characterStats.RangeDamage};
    }
    #endregion
    #region:functionalities
    #endregion
}

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