using UnityEngine;

public class Mob : IA
{
    #region components
    [Tooltip("The basic Character Stats presset of teh Character")]
    [SerializeField]
    private CharacterStatPresset statPresset;

    private static CharacterStatPresset tempStatPresset;

    [Tooltip("The health relied stats of the Character")]
    [SerializeField]
    private static HealthPresset healthPresset;

    private static HealthPresset tempHealthPresset;

    #endregion

    void Start()
    {
        tempStatPresset = statPresset;
        tempHealthPresset = healthPresset;
    }

    public Mob()
        : base(tempStatPresset, tempHealthPresset)
    {
        
    }
}
