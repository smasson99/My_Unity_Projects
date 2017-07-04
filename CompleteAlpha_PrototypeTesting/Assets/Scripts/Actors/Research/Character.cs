using UnityEngine;

public class Character : Killable
{
    #region:basicValues

    #region:status
    public bool IsDead { get; protected set; }
    public bool IsInCombat { get; protected set; }
    #endregion

    #region:objective
    public bool HasTarget { get; protected set; }
    #endregion

    #region:healthRegen

    public float CurrentPassiveHealthRegen { get; protected set; }

    public float CurrentCombatHealthRegen { get; protected set; }
    #endregion

    #region:speed
    public float CurrentSpeed { get; protected set; }
    public float CurrentSpeedBonus { get; protected set; }
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

    void Start()
    {
        //Initialise the hole basic values of the Character:
        IsDead = false;
        IsInCombat = false;
        ResetCurrentPassiveHealthRegen();
        ResetCurrentCombatHealthRegen();
        ResetCurrentSpeed();
        ResetCurrentMeleeDamage();
        ResetCurrentRangeDamage();
        ResetCurrentCriticalChances();
        ResetCurrentDamagePenetration();
        ResetCurrentBlockChances();
        ResetCurrentDodgeChances();
        ResetCurrentReplyChances();
    }

    public Character(CharacterStatPresset statPresset, HealthPresset healthPresset)
        :base(statPresset, healthPresset)
    {
        CurrentSpeedBonus = 1;
    }

    #region:basicFunctionalities

    public void ResetCurrentPassiveHealthRegen()
    {
        CurrentPassiveHealthRegen = basicHealthPresset.PassiveHealthRegen;
    }

    public void ResetCurrentCombatHealthRegen()
    {
        CurrentCombatHealthRegen = basicHealthPresset.CombatHealthRegen;
    }

    public virtual void ResetCurrentSpeed()
    {
        CurrentSpeed = basicStatPresset.Speed;
    }

    public void ResetCurrentSpeedBonus()
    {
        CurrentSpeedBonus = 1.00f;
    }

    public void ResetCurrentMeleeDamage()
    {
        CurrentMeleeDamage = basicStatPresset.MeleeDamage;
    }

    public void ResetCurrentRangeDamage()
    {
        CurrentRangeDamage = basicStatPresset.RangeDamage;
    }

    public void ResetCurrentCriticalChances()
    {
        CurrentCriticalChances = basicStatPresset.CriticalChances;
    }

    public void ResetCurrentDamagePenetration()
    {
        CurrentDamagePenetration = basicStatPresset.DamagePenetration;
    }

    public void ResetCurrentBlockChances()
    {
        CurrentBlockChances = basicStatPresset.BlockChances;
    }

    public void ResetCurrentDodgeChances()
    {
        CurrentDodgeChances = basicStatPresset.DodgeChances;
    }

    public void ResetCurrentReplyChances()
    {
        CurrentReplyChances = basicStatPresset.ReplyChances;
    }

    #endregion

    #region:loops

    void FixedUpdate()
    {
        //Gérer les bonus
    }

    #endregion
}