using UnityEngine;

public delegate void VisualDetection(GameObject potentialTarget, bool isAlly);
[AddComponentMenu("Scripts/Events/OnTargetFoundHandler")]
public class OnTargetFoundHandler : MonoBehaviour
{
    public event VisualDetection PotentialTargetFound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<Team>().CurrentTeam != GetComponentInParent<Team>().CurrentTeam)
        {
            PotentialTargetFound(other.gameObject, false);
        }
        else if (other.GetComponentInParent<Team>())
        {
            PotentialTargetFound(other.gameObject, true);
        }
    }
}
