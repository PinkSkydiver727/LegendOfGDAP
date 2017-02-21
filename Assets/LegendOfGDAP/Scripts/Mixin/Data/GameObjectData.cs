using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectData : MonoBehaviour {

    public GameObject data;
    public string objName;

	// Use this for initialization
	void Start () {
		if(objName != "")
        {
            data = GameObject.Find(objName);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
