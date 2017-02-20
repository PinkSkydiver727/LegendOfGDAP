using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// manager class for a collection of logic
// evalutes and executes them...
public class DecisionMgr : MonoBehaviour {

	public List<Logic>	logicList;

	public void DecisionMgrUpdate()
	{
		foreach (Logic l in logicList) {

			l.Evaluate ();
		}
	}

	public void Populate()
	{

	}

	public void OnEnable()
	{
		//logicList.Clear ();
		//Populate ();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		DecisionMgrUpdate ();
	}
}
