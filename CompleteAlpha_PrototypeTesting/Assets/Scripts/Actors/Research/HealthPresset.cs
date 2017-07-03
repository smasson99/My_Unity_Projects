using UnityEngine;

[CreateAssetMenu]
[AddComponentMenu("Pressets/HealthPresset")]
public class HealthPresset : ScriptableObject
{
    #region:values
    [Tooltip("The basic health of the Character, without any bonus.")]
    [SerializeField] private float basicHealth = 100;

    public float BasicHealth
    {
        get { return basicHealth; }
    }

    [Tooltip("The basic health regen of the Character out of combat, without any bonus.")]
    [SerializeField]
    private float basicPassiveHealthRegen = 5;

    public float BasicPassiveHealthRegen
    {
        get { return basicPassiveHealthRegen; }
    }

    [Tooltip("The basic health regen of the Character on combat, without any bonus.")]
    [SerializeField]
    private float basicCombatHealthRegen = 2.5f;

    public float BasicCombatHealthRegen
    {
        get { return basicCombatHealthRegen; }
    }
    #endregion
}