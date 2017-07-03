using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterEntity : MonoBehaviour
{
    #region components
    [Tooltip("The health relied stats of the Character")]
    [SerializeField]
    private HealthPresset basicHealthPresset;

    [Tooltip("The basic Character Stats presset of teh Character")]
    [SerializeField]
    private CharacterStatPresset basicStatPresset;
    #endregion

    #region:basicValues

    #region:status
    public bool IsDead { get; protected set; }
    public bool IsInCombat { get; protected set;}
    #endregion

    #region:health
    public float CurrentHealth { get; protected set; }

    public float CurrentPassiveHealthRegen { get; protected set; }

    public float CurrentCombatHealthRegen { get; protected set; }
    #endregion

    #region:healing
    public float HealBonus { get; protected set; }
    [Tooltip("If the Character can be heal (TRUE) or not (FALSE).")] [SerializeField] public bool canBeHeal = true;
    #endregion

    #region:speed
    public float CurrentSpeed { get; protected set; }
    public float SpeedBonus { get; protected set; }
    #endregion

    #region:objectives
    public bool HasObjective { get; protected set; }
    public bool HasTarget { get; set; }

    [Tooltip("If the Character priorise potential encouters or the objective of the Character.")] [SerializeField]
    protected bool priorityToTarget = true;
    public bool PriorityToTarget { get { return priorityToTarget; } private set { priorityToTarget = value; } }

    [Tooltip("The main Objective of the Character.")] [SerializeField] protected GameObject objective;
    protected GameObject target;
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

    #region:damages
    public float CurrentMeleeDamage { get; protected set; }
    public float CurrentRangeDamage { get; protected set; }
    #endregion

    #region:critical
    public float CurrentCriticalChances { get; protected set; }
    public float CriticalDamageBonus { get; protected set; }
    #endregion

    #region:penetration
    public float CurrentDamagePenetration { get; protected set; }
    public float DamagePenetrationBonus { get; protected set; }
    #endregion

    #region:combat
    public float CurrentBlockChances { get; protected set; }
    public float BlockChancesBonus { get; protected set; }

    public float CurrentDodgeChances { get; protected set; }
    public float DodgeChancesBonus { get; protected set; }
    public float CurrentReplyChances { get; protected set; }
    public float ReplyChancesBonus { get; protected set; }
    #endregion

    #endregion

    #region:sideValues
    private NavMeshAgent agent;
    #endregion

    #region:basicMethods
    void Start()
    {
        //Initialise side values:
        agent = GetComponent<NavMeshAgent>();
        //Initialise the hole values of the Character:
        IsDead = false;
        IsInCombat = false;
        ResetObjectiveStatus();
        HasTarget = false;
        ResetCurrentHealth();
        ResetCurrentPassiveHealthRegen();
        ResetCurrentCombatHealthRegen();
        ResetCurrentSpeed();
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
        ResetCurrentMeleeDamage();
        ResetCurrentRangeDamage();
        ResetCurrentCriticalChances();
        ResetCurrentDamagePenetration();
        ResetCurrentBlockChances();
        ResetCurrentDodgeChances();
        ResetCurrentReplyChances();
    }
    void FixedUpdate()
    {
        if (HasObjective && !priorityToTarget)
        {
            agent.SetDestination(objective.transform.position);
        }
    }
    #endregion

    #region:basicFunctionalities

    public void ResetObjectiveStatus()
    {
        if (objective != null && objective)
        {
            HasObjective = true;
        }
        else
        {
            HasObjective = false;
        }
    }

    public void ResetCurrentHealth()
    {
        CurrentHealth = basicHealthPresset.BasicHealth;
    }

    public void ResetCurrentPassiveHealthRegen()
    {
        CurrentPassiveHealthRegen = basicHealthPresset.BasicPassiveHealthRegen;
    }

    public void ResetCurrentCombatHealthRegen()
    {
        CurrentCombatHealthRegen = basicHealthPresset.BasicCombatHealthRegen;
    }

    public void ResetCurrentSpeed()
    {
        CurrentSpeed = basicStatPresset.BasicSpeed;
        agent.speed = CurrentSpeed;
    }

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

    public void ResetCurrentMeleeDamage()
    {
        CurrentMeleeDamage = basicStatPresset.BasicMeleeDamage;
    }

    public void ResetCurrentRangeDamage()
    {
        CurrentRangeDamage = basicStatPresset.BasicRangeDamage;
    }

    public void ResetCurrentCriticalChances()
    {
        CurrentCriticalChances = basicStatPresset.BasicCriticalChances;
    }

    public void ResetCurrentDamagePenetration()
    {
        CurrentDamagePenetration = basicStatPresset.BasicDamagePenetration;
    }

    public void ResetCurrentBlockChances()
    {
        CurrentBlockChances = basicStatPresset.BasicBlockChances;
    }

    public void ResetCurrentDodgeChances()
    {
        CurrentDodgeChances = basicStatPresset.BasicDodgeChances;
    }

    public void ResetCurrentReplyChances()
    {
        CurrentReplyChances = basicStatPresset.BasicReplyChances;
    }

    #endregion

    #region:methods

    #endregion
}