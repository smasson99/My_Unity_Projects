using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Constraints;
using UnityEditor;
using UnityEngine;

[AddComponentMenu("IA/Entity")]
public class IAEntity : MonoBehaviour
{
    [Tooltip("The team of this IA entity")] [SerializeField] public Team team = Team.TEAM1;
    [Tooltip("Represent the max health of the entity")] [SerializeField] private int maxHealth = 100;
    [Tooltip("Represent the health bar of the entity")] [SerializeField] private GameObject healthBar;
    [Tooltip("The maximum health regen rate of the entity")] [SerializeField] private int maxHealthRegen = 5;
    [Tooltip("If the entity can regen his health IN combat")] [SerializeField] private bool canRegenHealthInCombat;
    [Tooltip("If the entity can regen his health OUT OF combat")] [SerializeField] private bool canRegenHealth = true;
    [Tooltip("The value of basic damages (MIN)")] [SerializeField] private int basicDamageMin = 5;
    [Tooltip("The value of basic damages (MAX)")] [SerializeField] private int basicDamageMax = 15;
    [Tooltip("The numeric number in percent of critical damages chances")] [SerializeField] private float criticalChances = 20.00f;
    [Tooltip("The numeric number in percent of the damages bonus to critical attacks. 1 equals 0 of bonus (multiplicator).")]
    [SerializeField] private float criticalDamageBonus = 1.00f;
    [Tooltip("If the entity can respawn")] [SerializeField] private bool canRespawn = true;
    [Tooltip("The respawn MIN delay of the entity after death in seconds")] [SerializeField] private float minDelayRespawn = 5;
    [Tooltip("The respawn MAX delay of the entity after death in seconds")] [SerializeField] private float maxDelayRespawn = 15;
    [Tooltip("The prefab of the entity, used when respawn")] [SerializeField] private GameObject prefab;
    [Tooltip("The respawn point of the entity")] [SerializeField] private GameObject spawnPoint;

    private const int NB_SCECONDS_REGEN_DELAY = 2;

    private float regenDelay;
    private float respawnDelay;
    private SpriteRenderer spriteVisual;
    private Rigidbody2D body2D;
    private Vector2 direction;
    private Direction pointer;
    private Color defaultColor;
    private bool isAttacking;
    private int currentHealth;
    private int currentHealthRegen;
    private bool isDead;
    private bool isInCombat;

    public int CurrentHealth
    {
        get { return currentHealth; }
    }
    public int MaxHealth
    {
        get { return maxHealth; }
    }

    public float MaxHealthRegen
    {
        get { return maxHealthRegen; }
    }

    public float CriticalChances
    {
        get { return criticalChances; }
    }
    public bool IsInCombat
    {
        get { return isInCombat; }
        set { isInCombat = value; }
    }
    public bool IsDead
    {
        get { return isDead; }
    }
    public bool IsAttacking
    {
        get { return isAttacking; }
        set { isAttacking = value; }
    }
    public enum Team
    {
        TEAM1,
        TEAM2
    }
    private enum Direction
    {
        FRONT,
        RIGHT,
        LEFT
    }

    private string[] spriteLinks =
    {
        @"Assets/Visuals/Actors/Positions/front_sprite.png",
        @"Assets/Visuals/Actors/Positions/right_sprite.png",
        @"Assets/Visuals/Actors/Positions/left_sprite.png"
    };

    /// <summary>
    /// The awake function of the object that declares every default variables
    /// </summary>
    void Awake()
    {
        //Instantiate default values
        isDead = false;
        currentHealth = maxHealth;
        currentHealthRegen = maxHealthRegen;
        UpdateHealthBar();
        transform.position = spawnPoint.gameObject.transform.position;
        spriteVisual = GetComponentInChildren<SpriteRenderer>();
        body2D = GetComponentInChildren<Rigidbody2D>();
        pointer = Direction.FRONT;
        defaultColor = spriteVisual.color;
    }

    void Update()
    {
        //Make shure to regen health based on parameters
        if (isInCombat == false && isDead == false)
        {
            if (Time.time > regenDelay && canRegenHealth)
            {
                RegenHealth();
                StartRegen();
            }
        }
        else
        {
            if (Time.time > regenDelay && canRegenHealthInCombat)
            {
                RegenHealth();
                StartRegen();
            }
        }
        //If the entity can respawn, then respawn after the wait!
        if (isDead && canRespawn)
        {
            if (Time.time > respawnDelay)
            {
                //Goto the spawn position
                //transform.position = spawnPoint.transform.position;
                Instantiate(prefab);
                //Reset Health
                ResetHealth();
                ResetHealthRegen();
                //Reset movements
                EnableMovements(false);
                //Reset status
                transform.gameObject.GetComponentInChildren<GoToTarget>().Target.GetComponentInChildren<GoToTarget>()
                    .CanMove = true;
                Destroy(transform.gameObject);
            }
        }
    }

    /// <summary>
    /// Function that the objective is to change the current color of the object
    /// </summary>
    /// <param name="color">The color to change</param>
    public void ChangeColorTo(Color color)
    {
        spriteVisual.color = color;
    }

    public void UpdateCurrentHealthRegenTo(int newHealthRegen)
    {
        currentHealthRegen = newHealthRegen;
    }

    public void RegenHealth()
    {
        if (currentHealth + currentHealthRegen > maxHealth)
        {
            currentHealth = maxHealth;
            UpdateHealthBar();
        }
        else
        {
            currentHealth += currentHealthRegen;
            UpdateHealthBar();
        }
    }

    /// <summary>
    /// Function that the role is to reset the color othe the object to his default one
    /// </summary>
    public void ResetColor()
    {
        spriteVisual.color = defaultColor;
    }

    public void ResetHealth()
    {
        currentHealth = maxHealth;
    }

    public void ResetHealthRegen()
    {
        currentHealthRegen = maxHealthRegen;
    }

    public void GoToTarget(GameObject target, float speed)
    {
        //Update direction
        direction = GetDirectionTo(target);
        UpdateVisual();
        //AddForce to the object
        body2D.AddForce(direction * speed * Time.deltaTime, ForceMode2D.Impulse);
    }

    private Vector2 GetDirectionTo(GameObject target)
    {
        if (gameObject.transform.position.x < target.transform.position.x)
        {
            pointer = Direction.RIGHT;
            return Vector2.right;
        }
        else if (gameObject.transform.position.x > target.transform.position.x)
        {
            pointer = Direction.LEFT;
            return Vector2.left;
        }
        else
        {
            pointer = Direction.FRONT;
            return Vector2.zero;
        }
    }

    public int GetDealedDamage()
    {
        int damagePoints = Random.Range(basicDamageMin, basicDamageMax + 1);
        if (criticalChances <= Random.Range(0, criticalChances))
        {
            damagePoints += (int)(damagePoints * 0.50f * criticalDamageBonus);
        }
        return damagePoints;
    }
    public void TakeDamage(int damagePoints)
    {
        if (currentHealth - damagePoints <= 0)
        {
            currentHealth = 0;
            healthBar.transform.localScale = new Vector3(0.001f,
                transform.localScale.y, transform.localScale.z);
            Die();
        }
        else
        {
            currentHealth -= damagePoints;
            UpdateHealthBar();
        }
    }

    public void UpdateHealthBar()
    {
        healthBar.transform.localScale = new Vector3(transform.localScale.x * currentHealth / maxHealth,
            transform.localScale.y, transform.localScale.z);
    }

    public void UpdateHealthBarColor(Color color)
    {
        healthBar.transform.GetComponent<SpriteRenderer>().color = color;
    }

    public void UpdateVisual()
    {
        spriteVisual.sprite = AssetDatabase.LoadAssetAtPath<Sprite>(spriteLinks[(int)pointer]);
    }

    public void StartRegen()
    {
        regenDelay = Time.time + NB_SCECONDS_REGEN_DELAY;
    }

    public void DisableMovements()
    {
        transform.gameObject.GetComponentInChildren<AttackTarget>().CanAttack = false;
        transform.gameObject.GetComponentInChildren<GoToTarget>().CanMove = false;
    }

    public void EnableMovements(bool canAttack)
    {
        transform.gameObject.GetComponentInChildren<AttackTarget>().CanAttack = canAttack;
        transform.gameObject.GetComponentInChildren<GoToTarget>().CanMove = true;
    }
    public void Respawn()
    {
        respawnDelay = Random.Range(minDelayRespawn, maxDelayRespawn + 1) + Time.time;
    }

    public void Die()
    {
        //UpdateHealthBar
        healthBar.transform.localScale = new Vector3(0.001f,
            transform.localScale.y, transform.localScale.z);
        //UpdateStatus:
        isDead = true;
        isInCombat = false;
        //Disable movements:
        DisableMovements();
        //UpdateVisuals:
        ResetColor();
        //UpdatePhysics:
        ResetForces();
        //Repawn, if we can!
        if (canRespawn)
        {
            Respawn();
        }
    }

    public void ResetForces()
    {
        body2D.velocity = Vector2.zero;
    }
}
