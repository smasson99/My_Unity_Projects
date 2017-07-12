using UnityEngine;

public delegate void VisualDetection(GameObject potentialTarget, bool isAlly);
[AddComponentMenu("Scripts/Events/OnTargetFoundHandler")]
public class OnTargetFoundHandler : MonoBehaviour
{
    public event VisualDetection PotentialTargetFound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponentInParent<Team>().CurrentTeam != gameObject.GetComponentInParent<Team>().CurrentTeam)
        {
            PotentialTargetFound(other.gameObject, false);
        }
        else if (other.GetComponent<Team>())
        {
            PotentialTargetFound(other.gameObject, true);
        }
    }
}
