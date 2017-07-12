using System;
using UnityEngine;
using UnityEngine.AI;

[AddComponentMenu("Scripts/Entitys/MobEntity")]
public class MobEntity : MonoBehaviour
{
    #region:eventHandlers
    private OnTargetFoundHandler targetDetector;
    private OnTargetLostHandler targetLostDetector;
    #endregion
    #region:components
    private Team team;

    public Team.TeamName Team
    {
        get { return team.CurrentTeam; }
        set
        {
            team.CurrentTeam = value;
        }
    }
    private Stats stats;
    #endregion
    #region:bools
    [Tooltip("If the entity priorise the target over the objective when having a target.")]
    [SerializeField]
    private bool priorityToTarget = true;
    private bool isTargeted;
    public bool IsTargeted
    {
        get
        {
            return isTargeted;
        }
        set
        {
            isTargeted = value;
            agent.isStopped = true;
        }
    }
    private bool hasTarget;
    private bool hasObjective;
    #endregion
    #region:destinations
    private GameObject objective;
    public GameObject Objective
    {
        get { return objective; }
        set
        {
            objective = value;
            hasObjective = true;
        }
    }

    private NavMeshAgent agent;

    private GameObject target;
    public GameObject Target
    {
        get { return target; }
        private set
        {
            target = value;
            hasTarget = true;
        }
    }
    #endregion

    #region:values
    private float[] currentStats;
    private float maxHealth;
    #endregion

    #region:basicMethods
    void Awake()
    {
        //Instantiate event handlers
        targetDetector = GetComponentInChildren<OnTargetFoundHandler>();
        targetLostDetector = GetComponentInChildren<OnTargetLostHandler>();
        //Instantiate components
        team = GetComponent<Team>();
        stats = GetComponent<Stats>();
        agent = GetComponent<NavMeshAgent>();
    }
    void Start()
    {
        //Subscribe to the events
        targetDetector.PotentialTargetFound += InspectPotentialTarget;
        targetLostDetector.OnTargetLost += LoseTarget;
        //Instantiate values
        currentStats = stats.AllStats;
        //maxHealth = currentStats[(int)StatType.HEALTH];
    }
    private void FixedUpdate()
    {
        if (hasTarget && priorityToTarget || hasObjective == false && hasTarget)
        {
            HitZone hitPoint = target.GetComponentInChildren<HitZone>();
            //if (transform.position.x > hitPoint.transform.position.x - 0.25 && transform.position.x < hitPoint.transform.position.x + 0.25
            //    && transform.position.z > hitPoint.transform.position.z - 0.25 && transform.position.z < hitPoint.transform.position.z + 0.25)
            //{
            //agent.isStopped = true;
            //}
            //else
            //{
            agent.SetDestination(hitPoint.transform.position);
            //agent.isStopped = false;
            //}
        }
    }
    #endregion

    #region:publicFunctionalities
    public void TakeDamage(float damagePoints, StatType damageResistName)
    {
        currentStats[(int)StatType.HEALTH] -= damagePoints;
        if (currentStats[(int)StatType.HEALTH] < 0)
        {
            currentStats[(int)StatType.HEALTH] = 0;
        }
        //Update the health bar here...
    }
    #endregion

    #region:privateFunctionalities
    private void LoseTarget()
    {
        hasTarget = false;
        if (hasObjective)
        {
            agent.SetDestination(new Vector3(0, 0, 0));
        }
    }

    private void InspectPotentialTarget(GameObject potentialTarget, bool isAlly)
    {
        if (hasTarget == false && isAlly == false && isTargeted == false && priorityToTarget)
        {
            BoxCollider hitPoint = potentialTarget.GetComponentInChildren<BoxCollider>();
            agent.SetDestination(hitPoint.transform.position);
            Target = potentialTarget;
            potentialTarget.GetComponentInParent<MobEntity>().IsTargeted = true;
        }
    }
    #endregion
}