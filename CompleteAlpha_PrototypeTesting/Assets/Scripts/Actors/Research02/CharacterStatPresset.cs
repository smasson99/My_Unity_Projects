using UnityEngine;

[CreateAssetMenu(menuName = "Presset/CharacterStat")]
public class CharacterStatPresset : ScriptableObject
{
    #region:values
    [Tooltip("The Speed of the Character, without any bonus.")]
    [SerializeField]
    private float speed;

    public float Speed
    {
        get { return speed; }
    }

    [Tooltip("The Physical resistance of the Character, without any bonus.")]
    [SerializeField]
    private float physicalResistance;

    public float PhysicalResistance
    {
        get { return physicalResistance; }
    }

    [Tooltip("The Magical resistance of the Character, without any bonus.")]
    [SerializeField]
    private float magicalResistance;

    public float MagicalResistance
    {
        get { return magicalResistance; }
    }

    [Tooltip("The Overhal Elemental resistance of the Character, without any bonus.")]
    [SerializeField]
    private float elementalResistance;

    public float ElementalResistance
    {
        get { return elementalResistance; }
    }

    [Tooltip("The Fire resistance of the Character, without any bonus.")]
    [SerializeField]
    private float fireResistance;

    public float FireResistance
    {
        get { return fireResistance; }
    }

    [Tooltip("The Water resistance of the Character, without any bonus.")]
    [SerializeField]
    private float waterResistance;

    public float WaterResistance
    {
        get { return waterResistance; }
    }

    [Tooltip("The Air resistance of the Character, without any bonus.")]
    [SerializeField]
    private float airResistance;

    public float AirResistance
    {
        get { return airResistance; }
    }

    [Tooltip("The Earth resistance of the Character, without any bonus.")]
    [SerializeField]
    private float earthResistance;

    public float EarthResistance
    {
        get { return earthResistance; }
    }

    [Tooltip("The Ice resistance of the Character, without any bonus.")]
    [SerializeField]
    private float iceResistance;

    public float IceResistance
    {
        get { return iceResistance; }
    }

    [Tooltip("The Critical resistance of the Character, without any bonus.")]
    [SerializeField]
    private float criticalResistance;

    public float CriticalResistance
    {
        get { return criticalResistance; }
    }

    [Tooltip("The Overhall resistance of the Character, without any bonus.")]
    [SerializeField]
    private float overhallResistance;

    public float OverhallResistance
    {
        get { return overhallResistance; }
    }

    [Tooltip("The Critical Chances of the Character, without any bonus.")]
    [SerializeField]
    private float criticalChances;

    public float CriticalChances
    {
        get { return criticalChances; }
    }

    [Tooltip("The DamagePenetration of the Character, without any bonus.")]
    [SerializeField]
    private float damagePenetration;

    public float DamagePenetration
    {
        get { return damagePenetration; }
    }

    [Tooltip("The Block Chances of the Character, without any bonus.")]
    [SerializeField]
    private float blockChances;

    public float BlockChances
    {
        get { return blockChances; }
    }

    [Tooltip("The Dodge Chances of the Character, without any bonus.")]
    [SerializeField]
    private float dodgeChances;

    public float DodgeChances
    {
        get { return dodgeChances; }
    }

    [Tooltip("The Reply Chances of the Character, without any bonus.")]
    [SerializeField]
    private float replyChances;

    public float ReplyChances
    {
        get { return replyChances; }
    }

    [Tooltip("The Melee Damage of the Character")]
    [SerializeField]
    private float meleeDamage;

    public float MeleeDamage
    {
        get { return meleeDamage; }
    }

    [Tooltip("The Range Damage of the Character")]
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

    #region:functionalities

    void Start()
    {
        compiledValues = new float[]
        {
            speed, physicalResistance, magicalResistance, elementalResistance,
            fireResistance, waterResistance, airResistance, earthResistance,
            iceResistance, criticalResistance, overhallResistance, criticalChances,
            damagePenetration, blockChances, dodgeChances, replyChances, meleeDamage,
            rangeDamage
        };
    }
    #endregion
}
