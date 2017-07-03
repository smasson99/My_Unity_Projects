using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollision : MonoBehaviour {

    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "wood_box")
        {
            Destroy(col.gameObject);
        }
    }
}
