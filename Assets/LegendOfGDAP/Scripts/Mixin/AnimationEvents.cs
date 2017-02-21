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

    void Throw()
    {
        GetComponentInChildren<isThrowable>().Throw();
    }

    void HurtBoxEnable(int isEnabled)
    {
        isHurtBox HurtBox;

        isHurtBox[] hurtSlots = GetComponentsInChildren<isHurtBox>();

        foreach (isHurtBox ishurt in hurtSlots)
        {
            // slot type matches
            if (ishurt.active || hurtSlots.Length == 1)
            {
                HurtBox = ishurt;
                if (isEnabled == 1)
                {
                    HurtBox.hurtBox.enabled = true;
                }
                else
                {
                    HurtBox.hurtBox.enabled = false;
                }
            }
        }  
    }
}
