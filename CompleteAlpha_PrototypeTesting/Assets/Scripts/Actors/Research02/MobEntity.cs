using UnityEngine;
using UnityEngine.AI;

[AddComponentMenu("Scripts/Entitys/MobEntity")]
public class MobEntity : Entity
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
    #endregion
    #region:destinations
    private GameObjective gameObjectives;
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

    public override GameObject Target
    {
        get { return target; }
        protected set
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
    #endregion

    #region:basicFunctionalities
    void Awake()
    {
        //Instantiate event handlers
        targetDetector = GetComponentInChildren<OnTargetFoundHandler>();
        targetLostDetector = GetComponentInChildren<OnTargetLostHandler>();
        //Instantiate components
        gameObjectives = GetComponent<GameObjective>();
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
        gameObjectives.HasNoObj += ReactToNoGoal;
        //Instantiate values
        currentStats = stats.AllStats;
        buffGrid = new float[stats.NumStats];
        debuffGrid = new float[stats.NumStats];
        maxHealth = currentStats[(int)StatType.HEALTH];

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
            if (canAttack && attackWait <= Time.time)
            {
                DealDamage(StatType.MELEE_DAMAGE, target.GetComponent<Entity>());
                attackWait = Time.time + attackDelay;
            }
        }
        else if (hasObjective && !priorityToTarget || hasObjective && !hasTarget)
        {
            agent.SetDestination(Objective.transform.position);
            hitPoint = Objective.GetComponentInChildren<HitZone>();
            //Wait for the moment to come, then attack!!!
            if (canAttack && attackWait <= Time.time)
            {
                DealDamage(StatType.MELEE_DAMAGE, target.GetComponent<DestroyableEntity>());
                attackWait = Time.time + attackDelay;
            }
        }
    }
    #endregion

    #region:publicFunctionalities
    public override void TakeDamage(float damagePoints, StatType damageResistName)
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
            agent.SetDestination(GetCurrentObjective().transform.position);
        }
    }

    private GameObject GetCurrentObjective()
    {
        return gameObjectives.Objectives[0];
    }

    private void ReactToNoGoal()
    {
        hasObjective = false;
    }

    private void InspectPotentialTarget(GameObject potentialTarget, bool isAlly)
    {
        if (hasTarget == false && isAlly == false && priorityToTarget)
        {

            if (isTargeted == false && potentialTarget.GetComponentInParent<MobEntity>() != null)
            {
                potentialTarget.GetComponentInParent<MobEntity>().IsTargeted = true;
                potentialTarget.GetComponentInParent<MobEntity>().Target = transform.gameObject;
            }
            Target = potentialTarget;
            attackWait = Time.time + attackDelay;
        }
    }

    protected override void DealDamage(StatType damageTypeName, Entity target)
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