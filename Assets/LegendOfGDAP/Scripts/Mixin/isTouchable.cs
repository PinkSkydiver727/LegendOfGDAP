using UnityEngine;
using System.Collections;

// physical contact between some object and this object
public class isTouchable : Mixin {

	public string OnTouchCB;	// send this event, when touch happens

	public void OnCollisionEnter(Collision other)
	{
		GameObject go = other.gameObject;

		//isConsumable isC = GetComponent<isConsumable> ();
		//if (isC != null)
		//{
		//	isC.SetRecipient (other.gameObject);
		//}

		//isEquipable isEq = GetComponent<isEquipable> ();
		//if (isEq != null)
		//{
		//	isEq.SetRecipient (other.gameObject);
		//}

		isCollectible isCol = GetComponent<isCollectible> ();
		if (isCol != null)
		{
			isCol.SetRecipient (other.gameObject);
		}

		// send a response
		if (OnTouchCB != "")
			SendMessage (OnTouchCB);

        //this.enabled = false;
	}
		
	public void DebugMsg()
	{
		Debug.Log ("MIXINS OMG!!!");
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
