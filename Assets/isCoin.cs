using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isCoin : Mixin
{
    Rigidbody rb;
	// Use this for initialization
	void Start ()
    {
        amIDead[] enemies = FindObjectsOfType<amIDead>();
        foreach(amIDead enemy in enemies)
        {
            Physics.IgnoreCollision(GetComponent<BoxCollider>(), enemy.GetComponent<CapsuleCollider>());

        }


        rb = GetComponent<Rigidbody>();
        if(rb == null)
        {
            return;
        }
        Vector3 force = new Vector3(Random.Range(-200,200), Random.Range(100, 400), Random.Range(-200, 200));
        Vector3 position = new Vector3(1.0f, 0.0f, 1.0f);
        rb.AddForceAtPosition(force, position);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
