using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[AddComponentMenu("IA/Combat")]
public class AttackTarget : MonoBehaviour
{
    [Tooltip("The GameObject that possess the trigger")] [SerializeField] private GameObject parent;
    [Tooltip("The color to set while the attack animation")] [SerializeField] private Color colorAttackAnim = Color.white;
    [Tooltip("The length in seconds of the animation")] [SerializeField] private float secondsAnim = 1.2f;
    [Tooltip("The name of the other trigger")] [SerializeField] private string nameHitBox = "hitBox";

    private bool canAttack;
    private IAEntity entity;
    private GoToTarget status;
    private float currentDelay;
    private float animDelay;

    public bool CanAttack
    {
        get { return canAttack; }
        set { canAttack = value; }
    }

    void Awake()
    {
        entity = parent.GetComponent<IAEntity>();
        status = parent.GetComponentInChildren<GoToTarget>();
    }

    void Update()
    {
        if (!status.Target.GetComponentInParent<IAEntity>().IsDead)
        {
            if (canAttack && currentDelay < Time.time && entity.IsAttacking == false /*&& status.Target.GetComponent<IAEntity>().IsAttackin*/)
            {
                entity.IsAttacking = true;
                animDelay = Time.time + secondsAnim;
                entity.ChangeColorTo(colorAttackAnim);
            }
            else if (animDelay < Time.time && canAttack && entity.IsAttacking)
            {
                entity.ResetColor();
                status.Target.GetComponent<IAEntity>().TakeDamage(entity.GetDealedDamage());
                currentDelay = Time.time + GetRanAttackDelay();
                entity.IsAttacking = false;
            }
        }
        else
        {
            entity.IsInCombat = false;
            entity.ResetColor();
            canAttack = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartAttack(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (status.TargetAcquired && collision.transform.parent.gameObject == status.Target)
        {
            canAttack = false;
            status.CanMove = true;
        }
    }

    private void StartAttack(Collider2D collision)
    {
        if (status.TargetAcquired && collision.transform.parent.gameObject == status.Target && collision.name == nameHitBox)
        {
            canAttack = true;
            status.CanMove = false;
            entity.ResetColor();
            entity.ResetForces();
            currentDelay = Time.time + GetRanAttackDelay();
        }
    }

    private float GetRanAttackDelay()
    {
        return Random.Range(1.5f, 3.5f +1);
    }

}
