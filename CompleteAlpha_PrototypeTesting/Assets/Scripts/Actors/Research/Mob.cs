using UnityEngine;

[System.Serializable]
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

    private void Start()
    {
        tempStatPresset = statPresset;
        tempHealthPresset = healthPresset;
    }

    public Mob()
        : base(tempStatPresset, tempHealthPresset)
    {
        
    }
}
