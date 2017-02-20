﻿using UnityEngine;
using System.Collections;

public class CollisionCondition : Condition {

	// returns true is this object HAS collided with some other obj
	// 		   false otherwise

	public GameObject recipient;
	private CollisionHelper ch;

	override public bool Eval()
	{
		bool rval = false;

		if (ch == null) {
			if (recipient != null)
				ch = recipient.GetComponent<CollisionHelper> ();
		}

		// check for presence of hasCollided flag
		if (ch != null) {
			hasCollided hc = recipient.GetComponent<hasCollided> ();
			if (hc != null)
				rval = true;
		}

		return rval;
	}
}
