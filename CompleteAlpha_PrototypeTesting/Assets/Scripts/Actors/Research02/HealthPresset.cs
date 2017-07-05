using UnityEngine;

[CreateAssetMenu(menuName = "Presset/Health")]
public class HealthPresset : ScriptableObject
{
    [Tooltip("The max health of the Character, without any bonus.")]
    [SerializeField]
    private float health;

    public float Health
    {
        get { return health; }
    }

    [Tooltip("The basic health regen of the Character out of combat, without any bonus.")]
    [SerializeField]
    private float passiveHealthRegen;

    public float PassiveHealthRegen
    {
        get { return passiveHealthRegen; }
    }

    [Tooltip("The basic health regen of the Character on combat, without any bonus.")]
    [SerializeField]
    private float combatHealthRegen;

    public float CombatHealthRegen
    {
        get { return combatHealthRegen; }
    }

    private float[] compiledValues;

    public float[] CompiledValues
    {
        get { return compiledValues; }
    }

    void Start()
    {
        compiledValues = new float[] {health, passiveHealthRegen, combatHealthRegen};
    }
}
