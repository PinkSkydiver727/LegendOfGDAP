using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isPlayerDead : MonoBehaviour {
    public GameObjectData player;
    BoolData isDead;
	// Use this for initialization
	void Start () {
        isDead = player.data.GetComponent<BoolData>();
	}
	
	// Update is called once per frame
	void Update () {
		if(isDead.data)
        {
            GetComponent<Animator>().SetTrigger("taunt");
        }
	}
}
