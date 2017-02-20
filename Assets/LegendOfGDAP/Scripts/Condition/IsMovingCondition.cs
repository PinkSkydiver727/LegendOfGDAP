using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsMovingCondition : Condition {

    BoolData isMoving;
    public GameObject recipient;
	// Use this for initialization
	void Start () {
        isMoving = recipient.GetComponent<BoolData>();
	}

    public override bool Eval()
    {
        return isMoving.data;
    }
}
