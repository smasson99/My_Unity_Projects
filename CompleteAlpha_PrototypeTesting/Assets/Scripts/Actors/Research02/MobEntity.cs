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
    private UpdateHealthBar healthBar;

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
    private bool canAttack;
    public bool CanAttack
    {
        get { return canAttack; }
        set { canAttack = value; }
    }
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
    private float[] buffGrid;
    private float[] debuffGrid;
    private float maxHealth;
    [SerializeField]
    [Tooltip("The time between every attack.")]
    private float attackDelay = 1.00f;
    private float attackWait;
    private enum DamageType
    {
        PHYSICAL,
        MAGICAL,
        CRITICAL,
        FIRE,
        WATHER,
        EARTH,
        AIR
    }
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
        healthBar = GetComponentInChildren<UpdateHealthBar>();
    }
    void Start()
    {
        //Subscribe to the events
        targetDetector.PotentialTargetFound += InspectPotentialTarget;
        targetLostDetector.OnTargetLost += LoseTarget;
        //Instantiate values
        currentStats = stats.AllStats;
        buffGrid = new float[stats.NumStats];
        debuffGrid = new float[stats.NumStats];
        maxHealth = currentStats[(int)StatType.HEALTH];
        attackWait = Time.time;

    }
    private void FixedUpdate()
    {
        HitZone hitPoint;
        //Make sure the entity is going to its target
        if (hasTarget && priorityToTarget || hasObjective == false && hasTarget)
        {
            hitPoint = target.GetComponentInChildren<HitZone>();
            agent.SetDestination(hitPoint.transform.position);
            //Wait for the moment to come, then attack!!!
            if (attackWait <= Time.time && canAttack)
            {
                DealDamage(StatType.MELEE_DAMAGE, target.GetComponentInParent<MobEntity>());
                attackWait = Time.time + attackDelay;
            }
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
        healthBar.UpdateVisual(currentStats[(int)StatType.HEALTH], maxHealth);
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
        if (hasTarget == false && isAlly == false && priorityToTarget)
        {
            
            if (isTargeted == false && potentialTarget.GetComponentInParent<MobEntity>() != null)
            {
                Target = potentialTarget;
                potentialTarget.GetComponentInParent<MobEntity>().IsTargeted = true;
                potentialTarget.GetComponentInParent<MobEntity>().Target = transform.gameObject;
            }
            else
            {
                Target = potentialTarget;
            }
        }
    }

    private void DealDamage(StatType damageTypeName, MobEntity target)
    {
        float basicDamage = currentStats[(int)damageTypeName];
        target.TakeDamage(basicDamage, StatType.PHYSICAL_RESISTANCE);
        if (Random.Range(1, 100 + 1) <= currentStats[(int)StatType.CRITICAL_CHANCES])
        {
            target.TakeDamage((basicDamage) * (0.5f), StatType.CRITICAL_RESISTANCE);
        }
    }
    #endregion
}