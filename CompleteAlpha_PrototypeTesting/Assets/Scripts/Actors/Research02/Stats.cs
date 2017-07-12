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
    void Start()
    {
        //Instantiate values
        stats = new float[NumStats];
        //Call the functions
        LaunchTheStatData(ref stats);
    }
    #endregion
    #region:functionalities
    private void LaunchTheStatData(ref float[] tab)
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
    #endregion
}