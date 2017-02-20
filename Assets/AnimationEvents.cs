using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour {

	void Spawn()
    {
        GetComponentInChildren<createsProjectile>().Spawn();
    }

    void Fire()
    {
        GetComponentInChildren<createsProjectile>().Fire();
    }
}
