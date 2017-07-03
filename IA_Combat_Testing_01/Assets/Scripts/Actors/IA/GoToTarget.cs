using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("IA/GoToTarget")]
public class GoToTarget : MonoBehaviour
{
    [Tooltip("The color to set the GameObject when it is going to a target")]
    [SerializeField]
    private Color displacementColorAnim = Color.white;
    [Tooltip("The GameObject that has the detection trigger")]
    [SerializeField]
    private GameObject triggerParent;
    [Tooltip("The speed of the object to displace")]
    [SerializeField]
    private float speedDisplacement = 10.00f;

    private GameObject target;
    private bool targetAcquired;
    private bool canMove = true;
    private IAEntity entity;

    public bool CanMove
    {
        get { return canMove; }
        set { canMove = value; }
    }
    public bool TargetAcquired
    {
        get { return targetAcquired; }
        set { targetAcquired = value; }
    }

    public GameObject Target
    {
        get { return target; }
    }

    void Awake()
    {
        entity = triggerParent.GetComponent<IAEntity>();
    }

    void Update()
    {
        if (targetAcquired && canMove)
        {
            entity.GoToTarget(target, speedDisplacement);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!targetAcquired && collision.gameObject.GetComponentInParent<IAEntity>() && collision.gameObject.GetComponentInParent<IAEntity>().team != entity.team && canMove)
            AcquireTarget(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (target == collision.gameObject.transform.parent.gameObject)
        {
            targetAcquired = false;
            entity.IsInCombat = false;
            entity.ResetColor();
        }
    }

    private void AcquireTarget(Collider2D collision)
    {
        target = collision.transform.parent.gameObject;
        entity.ChangeColorTo(displacementColorAnim);
        targetAcquired = true;
        entity.IsInCombat = true;
    }
}
