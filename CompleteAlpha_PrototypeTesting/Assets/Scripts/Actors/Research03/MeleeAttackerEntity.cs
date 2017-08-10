using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[AddComponentMenu("Scripts/Entity/AttackMeleeEntity")]
public class MeleeAttackerEntity : MonoBehaviour
{
    //The Objective of the Entity is to destroy the tower...

    private NavMeshAgent agent;
    [SerializeField]
    [Tooltip("The objective of the entity (TEMPORARLY)")]
    private GameObject objective = null;
    private bool hasObjective;
    private bool canAttack;

    private void Awake()
    {
        //Get the components needed:
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        hasObjective = (objective != null);
        if (hasObjective)
        {
            agent.SetDestination(objective.transform.position);
        }
    }

    private void FixedUpdate()
    {
        
    }

    private void StopAgent(bool canAttack)
    {
        agent.isStopped = true;
    }
}
