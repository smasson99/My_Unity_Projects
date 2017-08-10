using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[AddComponentMenu("Scripts/HitBox/StopAgentOnEnter")]
public class HitBoxEnter_Stop : MonoBehaviour
{
    //Variables:
    private string stopMethodName;

    private GameObject intruder;

    private void Start()
    {
        stopMethodName = "StopAgent";
    }

    private void OnTriggerEnter(Collider other)
    {
        //Filtrer les intrus possibles:
        if (!other.isTrigger)
        {
            //Lancer le timer:
            other.gameObject.SendMessageUpwards(stopMethodName, true);
        }
    }

}
