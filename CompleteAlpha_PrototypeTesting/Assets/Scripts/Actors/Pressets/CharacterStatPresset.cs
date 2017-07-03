using UnityEngine;

[CreateAssetMenu]
[AddComponentMenu("Pressets/CharacterStatsPresset")]
public class CharacterStatPresset : ScriptableObject
{
    #region:values
    [Tooltip("The basic Speed of the Character, without any bonus.")]
    [SerializeField]
    private float basicSpeed;

    public float BasicSpeed
    {
        get { return basicSpeed; }
    }

    [Tooltip("The basic Physical resistance of the Character, without any bonus.")]
    [SerializeField]
    private float basicPhysicalResistance;

    public float BasicPhysicalResistance
    {
        get { return basicPhysicalResistance; }
    }

    [Tooltip("The basic Magical resistance of the Character, without any bonus.")]
    [SerializeField]
    private float basicMagicalResistance;

    public float BasicMagicalResistance
    {
        get { return basicMagicalResistance; }
    }

    [Tooltip("The basic Overhal Elemental resistance of the Character, without any bonus.")]
    [SerializeField]
    private float basicElementalResistance;

    public float BasicElementalResistance
    {
        get { return basicElementalResistance; }
    }

    [Tooltip("The basic Fire resistance of the Character, without any bonus.")]
    [SerializeField]
    private float basicFireResistance;

    public float BasicFireResistance
    {
        get { return basicFireResistance; }
    }

    [Tooltip("The basic Water resistance of the Character, without any bonus.")]
    [SerializeField]
    private float basicWaterResistance;

    public float BasicWaterResistance
    {
        get { return basicWaterResistance; }
    }

    [Tooltip("The basic Air resistance of the Character, without any bonus.")]
    [SerializeField]
    private float basicAirResistance;

    public float BasicAirResistance
    {
        get { return basicAirResistance; }
    }

    [Tooltip("The basic Earth resistance of the Character, without any bonus.")]
    [SerializeField]
    private float basicEarthResistance;

    public float BasicEarthResistance
    {
        get { return basicEarthResistance; }
    }

    [Tooltip("The basic Ice resistance of the Character, without any bonus.")]
    [SerializeField]
    private float basicIceResistance;

    public float BasicIceResistance
    {
        get { return basicIceResistance; }
    }

    [Tooltip("The basic Critical resistance of the Character, without any bonus.")]
    [SerializeField]
    private float basicCriticalResistance;

    public float BasicCriticalResistance
    {
        get { return basicCriticalResistance; }
    }

    [Tooltip("The basic Overhall resistance of the Character, without any bonus.")]
    [SerializeField]
    private float basicOverhallResistance;

    public float BasicOverhallResistance
    {
        get { return basicOverhallResistance; }
    }

    [Tooltip("The basic Critical Chances of the Character, without any bonus.")]
    [SerializeField]
    private float basicCriticalChances;

    public float BasicCriticalChances
    {
        get { return basicCriticalChances; }
    }

    [Tooltip("The basic DamagePenetration of the Character, without any bonus.")]
    [SerializeField]
    private float basicDamagePenetration;

    public float BasicDamagePenetration
    {
        get { return basicDamagePenetration; }
    }

    [Tooltip("The basic Block Chances of the Character, without any bonus.")]
    [SerializeField]
    private float basicBlockChances;

    public float BasicBlockChances
    {
        get { return basicBlockChances; }
    }

    [Tooltip("The basic Dodge Chances of the Character, without any bonus.")]
    [SerializeField]
    private float basicDodgeChances;

    public float BasicDodgeChances
    {
        get { return basicDodgeChances; }
    }

    [Tooltip("The basic Reply Chances of the Character, without any bonus.")]
    [SerializeField]
    private float basicReplyChances;

    public float BasicReplyChances
    {
        get { return basicReplyChances; }
    }

    [Tooltip("The basic melee damage of the Character")]
    [SerializeField]
    private float basicMeleeDamage;

    public float BasicMeleeDamage
    {
        get { return basicMeleeDamage; }
    }

    [Tooltip("The basic melee damage of the Character")]
    [SerializeField]
    private float basicRangeDamage;

    public float BasicRangeDamage
    {
        get { return basicRangeDamage; }
    }
    #endregion
}
