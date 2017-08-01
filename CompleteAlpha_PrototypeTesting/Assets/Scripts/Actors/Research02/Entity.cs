using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    #region:bools
    protected bool canAttack;
    public virtual bool CanAttack
    {
        get { return canAttack; }
        set { canAttack = value; }
    }
    #endregion
    #region:destinations
    protected GameObject target;
    public virtual GameObject Target
    {
        get
        {
            return target;
        }
        protected set
        {
            target = value;
        }
    }
    #endregion
    #region:values
    protected enum DamageType
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

    #region:protectedFunctionalities
    protected virtual void DealDamage(StatType damageTypeName, Entity target)
    {
        //Will be override
    }
    #endregion

    #region:publicFunctionalities
    public virtual void TakeDamage(float damagePoints, StatType damageResistName)
    {
        //Will be override
    }
    #endregion
}
