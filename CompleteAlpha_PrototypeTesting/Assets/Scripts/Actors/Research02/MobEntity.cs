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
    private Vector3 objective;
    private NavMeshAgent agent;
    private GameObject target;
    public GameObject Target
    {
        get { return target; }
        private set
        {
            target = value;
            agent.SetDestination(target.transform.position);
            hasTarget = true;
        }
    }

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

    private void LoseTarget()
    {
        agent.SetDestination(objective);
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