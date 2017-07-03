using UnityEngine;

public class IA : Character
{
    #region:objectives
    public bool HasObjective { get; protected set; }
    public bool HasTarget { get; set; }

    [Tooltip("If the Character priorise potential encouters or the objective of the Character.")]
    [SerializeField]
    protected bool priorityToTarget = true;
    public bool PriorityToTarget { get { return priorityToTarget; } private set { priorityToTarget = value; } }

    [Tooltip("The main Objective of the Character.")] [SerializeField] protected GameObject objective;
    protected GameObject target;
    #endregion

    void Start()
    {
        ResetObjectiveStatus();
    }
    public IA(CharacterStatPresset statPresset, HealthPresset healthPresset)
        :base(statPresset, healthPresset)
    {
        
    }

    void FixedUpdate()
    {
        ResetObjectiveStatus();
    }

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
}
