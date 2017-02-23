using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isKey : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    public void UseKey()
    {
        if(GetComponent<BoxCollider>().enabled == false)
        {
            GetComponent<BoxCollider>().enabled = true;
        }
        else if (GetComponent<BoxCollider>().enabled == true)
        {
            GetComponent<BoxCollider>().enabled = false;
        }

    }

	
	// Update is called once per frame
	void Update () {
		
	}
}
