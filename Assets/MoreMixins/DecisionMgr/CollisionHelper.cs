using UnityEngine;
using System.Collections;

public class CollisionHelper : MonoBehaviour {

	public void OnCollisionEnter(Collision other)
	{
		Debug.Log ("collided with " + other.gameObject.name);

		// both parties' other needs to be recorded
		hasCollided hc = this.gameObject.AddComponent<hasCollided> ();
		if (hc != null)
			hc.other = other.gameObject;

		hasCollided hcOther = other.gameObject.AddComponent<hasCollided> ();
		if (hcOther != null)
			hcOther.other = this.gameObject;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
