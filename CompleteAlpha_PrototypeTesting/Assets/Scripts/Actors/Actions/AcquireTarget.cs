using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AcquireTarget : MonoBehaviour
{
    private CharacterEntity entity;
    private NavMeshAgent agent;

    void Start()
    {
        entity = GetComponentInParent<CharacterEntity>();
        agent = GetComponentInParent<NavMeshAgent>();
    }

    public void AcquireTargetAs(GameObject target)
    {
        entity.HasTarget = true;
        if (entity.HasObjective && entity.PriorityToTarget)
            agent.SetDestination(target.transform.position);
    }

}
