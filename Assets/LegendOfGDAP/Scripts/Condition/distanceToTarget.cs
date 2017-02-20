using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class distanceToTarget : Condition {
    public GameObject target;
    public GameObject recipient;
    public float distance;
	override public bool  Eval()
    {
        bool value = false;
        float dist = Vector3.Distance(target.transform.position, transform.position);
        if (dist < distance)
        {
            value = true;
        }

        return value;
    }
}
