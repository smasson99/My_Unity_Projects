using UnityEngine;

public class Killable : MonoBehaviour
{
    #region basicValues

    protected CharacterStatPresset basicStatPresset;
    protected HealthPresset basicHealthPresset;

    #region:health
    public float CurrentHealth { get; protected set; }
    public float MaxHealth { get; set; }
    #endregion

    #region:healing
    public float CurrentHealBonus { get; protected set; }
    [Tooltip("If the Character or the DestructibleObject can be heal/repaired (TRUE) or not (FALSE).")]
    [SerializeField]
    public bool canBeHeal = true;
    #endregion

    #region:resistances
    public float CurrentPhysicalResistance { get; protected set; }

    public float CurrentMagicalResistance { get; protected set; }

    public float CurrentElementalResistance { get; protected set; }

    public float CurrentFireResistance { get; protected set; }

    public float CurrentWaterResistance { get; protected set; }

    public float CurrentAirResistance { get; protected set; }

    public float CurrentEarthResistance { get; protected set; }

    public float CurrentIceResistance { get; protected set; }

    public float CurrentCriticalResistance { get; protected set; }

    public float CurrentOverhallResistance { get; protected set; }
    #endregion

    #endregion

    void Start()
    {
        //Initialise the health
        ResetMaxHealth();
        ResetCurrentHealth();
        //Initialise the healbonus
        //ResetCurrentHealBonus();
        //Initialise the resistances
        ResetCurrentPhysicalResistance();
        ResetCurrentMagicalResistance();
        ResetCurrentElementalResistance();
        ResetCurrentFireResistance();
        ResetCurrentWaterResistance();
        ResetCurrentAirResistance();
        ResetCurrentEarthResistance();
        ResetCurrentIceResistance();
        ResetCurrentCriticalResistance();
        ResetCurrentBasicResistance();
    }
    public Killable(CharacterStatPresset statPresset, HealthPresset healthPresset)
    {
        //Extract the values of the stats and Health
        basicStatPresset = statPresset;
        basicHealthPresset = healthPresset;
    }

    #region:basicFunctionalities
    //Reset the health
    public void ResetMaxHealth()
    {
        MaxHealth = basicHealthPresset.BasicHealth;
    }
    public void ResetCurrentHealth()
    {
        CurrentHealth = MaxHealth;
    }
    //Reset the healing bonus
    //public void ResetCurrentHealBonus()
    //{
    //    CurrentHealBonus = 0.00f;
    //}
    //Reset the resistance
    public void ResetCurrentPhysicalResistance()
    {
        CurrentPhysicalResistance = basicStatPresset.BasicPhysicalResistance;
    }

    public void ResetCurrentMagicalResistance()
    {
        CurrentMagicalResistance = basicStatPresset.BasicMagicalResistance;
    }

    public void ResetCurrentElementalResistance()
    {
        CurrentElementalResistance = basicStatPresset.BasicElementalResistance;
    }

    public void ResetCurrentFireResistance()
    {
        CurrentFireResistance = basicStatPresset.BasicFireResistance;
    }

    public void ResetCurrentWaterResistance()
    {
        CurrentWaterResistance = basicStatPresset.BasicWaterResistance;
    }

    public void ResetCurrentAirResistance()
    {
        CurrentAirResistance = basicStatPresset.BasicAirResistance;
    }

    public void ResetCurrentEarthResistance()
    {
        CurrentEarthResistance = basicStatPresset.BasicEarthResistance;
    }

    public void ResetCurrentIceResistance()
    {
        CurrentIceResistance = basicStatPresset.BasicIceResistance;
    }

    public void ResetCurrentCriticalResistance()
    {
        CurrentCriticalResistance = basicStatPresset.BasicCriticalResistance;
    }

    public void ResetCurrentBasicResistance()
    {
        CurrentOverhallResistance = basicStatPresset.BasicOverhallResistance;
    }
    #endregion
}
