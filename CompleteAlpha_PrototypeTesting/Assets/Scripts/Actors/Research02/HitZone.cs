using UnityEngine;

[AddComponentMenu("Scripts/Destroyables/HitZone")]
public class HitZone : MonoBehaviour
{
    #region:values
    private MobEntity entity;
    private float startAttackDelay;
    private bool timerStarted;

    [Tooltip("The length is seconds of the delay before starting the first attack of the combat")]
    [SerializeField]
    private float delayLength = 1.00f;
    #endregion

    #region:basicFunctions
    private void Awake()
    {
        entity = GetComponentInParent<MobEntity>();
    }
    private void FixedUpdate()
    {
        if (timerStarted && Time.time >= startAttackDelay)
        {
            entity.CanAttack = true;
            entity.Target.GetComponentInParent<MobEntity>().CanAttack = true;
            timerStarted = false;
        }
    }
    #endregion

    #region:functionnalities
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject == entity.Target)
        {
            startAttackDelay = Time.time + delayLength;
            timerStarted = true;
        }
    }
    #endregion
}