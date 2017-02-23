using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// TODO MAKE THIS A DECISION MANAGER
public class amIDead : MonoBehaviour {
    public FloatData health;
    bool isDead;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(health.data <= 0 && !isDead)
        {
            GetComponent<Animator>().SetTrigger("die");
            isDead = true;
            //GetComponent<isPersistent>().isDead();
        }
	}
}
