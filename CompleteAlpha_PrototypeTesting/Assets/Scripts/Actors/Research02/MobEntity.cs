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
    private Stats stats;
    #endregion
    #region:values
    private bool hasTarget;
    private bool hasObjective;
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

    [Tooltip("If the entity priorise the target over the objective when having a target.")]
    [SerializeField]
    private bool priorityToTarget = true;
    #endregion

    void Awake()
    {
        //Instantiate event handlers
        targetDetector = GetComponentInChildren<OnTargetFoundHandler>();
        //Instantiate components
        team = GetComponent<Team>();
        stats = GetComponent<Stats>();
        agent = GetComponent<NavMeshAgent>();
    }
    void Start()
    {
        targetDetector.PotentialTargetFound += InspectPotentialTarget;
        targetLostDetector.OnTargetLost += LoseTarget;
    }

    void FixedUpdate()
    {
        if (hasTarget && priorityToTarget)
        {
            agent.SetDestination(target.GetComponentInChildren<HitZone>().transform.position);
        }
        else if (hasObjective)
        {
            agent.SetDestination(objective.transform.position);
        }
    }

    private void LoseTarget()
    {
        hasTarget = false;
    }

    private void InspectPotentialTarget(GameObject potentialTarget, bool isAlly)
    {
        if (hasTarget == false && isAlly == false)
        {
            Target = potentialTarget;
        }
    }
}