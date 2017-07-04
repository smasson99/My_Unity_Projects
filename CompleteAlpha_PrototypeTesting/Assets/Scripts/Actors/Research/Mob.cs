using UnityEngine;

[System.Serializable]
public class Mob
{
    #region:instances
    private IA parent_IA;
    #endregion
    #region components
    [Tooltip("The basic Character Stats presset of teh Character")]
    [SerializeField]
    private CharacterStatPresset statPresset;

    [Tooltip("The health relied stats of the Character")]
    [SerializeField]
    private HealthPresset healthPresset;
    #endregion
}
