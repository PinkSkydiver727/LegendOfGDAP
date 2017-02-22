using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isHurtBoxTimer : MonoBehaviour {

    public Collider hurtbox;
    float time = 0.0f;
    public float timer;

	// Use this for initialization
	void Start () {
        GetComponent<isHurtBox>().damageBuff = GameObject.Find("Player").GetComponent<isPlayer>().damageBuff.data;
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if (time > timer)
        {
            if(hurtbox != null)
            {
                hurtbox.enabled = false;
            }
        }
	}
}
