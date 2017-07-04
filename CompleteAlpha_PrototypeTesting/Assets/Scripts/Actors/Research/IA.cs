using UnityEngine;
using UnityEngine.AI;

public class IA : Character
{
    #region:instances
    protected static NavMeshAgent agent;
    #endregion

    #region:objectives
    public bool HasObjective { get; protected set; }

    [Tooltip("If the Character priorise potential encouters or the objective of the Character.")]
    [SerializeField]
    protected bool priorityToTarget = true;
    public bool PriorityToTarget { get { return priorityToTarget; } private set { priorityToTarget = value; } }

    [Tooltip("The main Objective of the Character.")] [SerializeField] protected GameObject objective;
    protected GameObject target;
    #endregion

    #region:basicFunctions
    void Start()
    {
        //Set the basic status of the mob by updating the objectives status
        ResetObjectiveStatus();

        //If the entity has an objective, then tell the navmesh agent to go to it
        if (HasObjective)
        {
            agent.SetDestination(objective.transform.position);
        }
    }
    public IA(CharacterStatPresset statPresset, HealthPresset healthPresset)
        :base(statPresset, healthPresset)
    {
        //Instantiate the values of the IA
        agent = GetComponentInParent<NavMeshAgent>();
        agent.speed = CurrentSpeed * CurrentSpeedBonus;
    }

    void FixedUpdate()
    {
        ResetObjectiveStatus();
    }
    #endregion

    #region:basicFunctionalites
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
    #endregion
}
