using UnityEngine;

[AddComponentMenu("Scripts/Destroyables/HitZone")]
public class HitZone : MonoBehaviour
{
    #region:values
    private Entity entity;
    private bool delayStarted;
    private float startAttackDelay;
    private float delayLength;
    private GameObject targetCurrentParent;
    #endregion

    #region:basicFunctions
    private void Awake()
    {
        entity = GetComponentInParent<MobEntity>();
        if (entity == null)
        {
            entity = GetComponentInParent<DestroyableEntity>();
        }
    }

    private void Start()
    {
        delayStarted = false;
        delayLength = 1;
    }

    private void FixedUpdate()
    {
        if (delayStarted && startAttackDelay <= Time.time)
        {
            entity.CanAttack = true;
            entity.Target.GetComponentInParent<Entity>().CanAttack = true;
            delayStarted = false;
        }
    }
    #endregion

    #region:functionnalities
    private void OnTriggerEnter(Collider collision)
    {
        if (entity != null && collision.gameObject == entity.Target)
        {
            if (targetCurrentParent == null || collision.gameObject != targetCurrentParent)
            {
                targetCurrentParent = collision.gameObject;
                startAttackDelay = Time.time + delayLength;
                delayStarted = true;
            }
        }
    }
    #endregion
}