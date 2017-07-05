using UnityEngine;

[AddComponentMenu("Scripts/Character/Team")]
public class Team : MonoBehaviour
{
    #region:values
    public enum TeamName
    {
        NONE,
        TEAM_01,
        TEAM_02,
        TEAM_03,
        TEAM_04,
        TEAM_05,
        TEAM_06,
        TEAM_07,
        TEAM_08,
        TEAM_09,
        TEAM_10
    }

    [Tooltip("The team of the Character")]
    [SerializeField]
    private TeamName currentTeam = TeamName.NONE;

    [Tooltip("If the Character can change of team while in combat (TRUE) or not (FALSE).")]
    [SerializeField]
    private bool canChangeTeam = true;

    public TeamName CurrentTeam
    {
        get { return currentTeam; }
        set
        {
            if (canChangeTeam)
            {
                currentTeam = value;
            }
        }
    }
    #endregion
}
