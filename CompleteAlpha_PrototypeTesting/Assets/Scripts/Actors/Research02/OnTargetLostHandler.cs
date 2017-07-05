using UnityEngine;

public delegate void VisualLost();
[AddComponentMenu("Scripts/Events/OnTargetLostHandler")]
public class OnTargetLostHandler : MonoBehaviour
{
    public event VisualLost OnTargetLost;
    private MobEntity parentEntity;

    void Awake()
    {
        parentEntity = GetComponentInParent<MobEntity>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (parentEntity.Target == other.gameObject)
        {
            OnTargetLost();
        }
    }
}
