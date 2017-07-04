using UnityEngine;

[CreateAssetMenu(menuName = "Presset/CharacterStat")]
public class CharacterStatPresset : ScriptableObject
{
    #region:values
    [Tooltip("The basic Speed of the Character, without any bonus.")]
    [SerializeField]
    private float speed;

    public float Speed
    {
        get { return speed; }
    }

    [Tooltip("The basic Physical resistance of the Character, without any bonus.")]
    [SerializeField]
    private float physicalResistance;

    public float PhysicalResistance
    {
        get { return physicalResistance; }
    }

    [Tooltip("The basic Magical resistance of the Character, without any bonus.")]
    [SerializeField]
    private float magicalResistance;

    public float MagicalResistance
    {
        get { return magicalResistance; }
    }

    [Tooltip("The basic Overhal Elemental resistance of the Character, without any bonus.")]
    [SerializeField]
    private float elementalResistance;

    public float ElementalResistance
    {
        get { return elementalResistance; }
    }

    [Tooltip("The basic Fire resistance of the Character, without any bonus.")]
    [SerializeField]
    private float fireResistance;

    public float FireResistance
    {
        get { return fireResistance; }
    }

    [Tooltip("The basic Water resistance of the Character, without any bonus.")]
    [SerializeField]
    private float waterResistance;

    public float WaterResistance
    {
        get { return waterResistance; }
    }

    [Tooltip("The basic Air resistance of the Character, without any bonus.")]
    [SerializeField]
    private float airResistance;

    public float AirResistance
    {
        get { return airResistance; }
    }

    [Tooltip("The basic Earth resistance of the Character, without any bonus.")]
    [SerializeField]
    private float earthResistance;

    public float EarthResistance
    {
        get { return earthResistance; }
    }

    [Tooltip("The basic Ice resistance of the Character, without any bonus.")]
    [SerializeField]
    private float iceResistance;

    public float IceResistance
    {
        get { return iceResistance; }
    }

    [Tooltip("The basic Critical resistance of the Character, without any bonus.")]
    [SerializeField]
    private float criticalResistance;

    public float CriticalResistance
    {
        get { return criticalResistance; }
    }

    [Tooltip("The basic Overhall resistance of the Character, without any bonus.")]
    [SerializeField]
    private float overhallResistance;

    public float OverhallResistance
    {
        get { return overhallResistance; }
    }

    [Tooltip("The basic Critical Chances of the Character, without any bonus.")]
    [SerializeField]
    private float criticalChances;

    public float CriticalChances
    {
        get { return criticalChances; }
    }

    [Tooltip("The basic DamagePenetration of the Character, without any bonus.")]
    [SerializeField]
    private float damagePenetration;

    public float DamagePenetration
    {
        get { return damagePenetration; }
    }

    [Tooltip("The basic Block Chances of the Character, without any bonus.")]
    [SerializeField]
    private float blockChances;

    public float BlockChances
    {
        get { return blockChances; }
    }

    [Tooltip("The basic Dodge Chances of the Character, without any bonus.")]
    [SerializeField]
    private float dodgeChances;

    public float DodgeChances
    {
        get { return dodgeChances; }
    }

    [Tooltip("The basic Reply Chances of the Character, without any bonus.")]
    [SerializeField]
    private float replyChances;

    public float ReplyChances
    {
        get { return replyChances; }
    }

    [Tooltip("The basic melee damage of the Character")]
    [SerializeField]
    private float meleeDamage;

    public float MeleeDamage
    {
        get { return meleeDamage; }
    }

    [Tooltip("The basic melee damage of the Character")]
    [SerializeField]
    private float rangeDamage;

    public float RangeDamage
    {
        get { return rangeDamage; }
    }

    private float[] compiledValues;

    public float[] CompiledValues
    {
        get { return compiledValues; }
    }
    #endregion

    private CharacterStatPresset()
    {
        compiledValues = new float[]
        {
            speed, physicalResistance, magicalResistance, elementalResistance, fireResistance,
            waterResistance, airResistance, earthResistance, iceResistance, criticalResistance,
            overhallResistance, criticalChances, damagePenetration, blockChances, dodgeChances,
            replyChances, meleeDamage, rangeDamage
        };
    }
}
