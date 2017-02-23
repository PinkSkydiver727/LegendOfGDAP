using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour {

    RoomManager roomMgr;
    void UseKey()
    {
        if (GetComponentInChildren<isKey>() != null )
        {
            GetComponentInChildren<isKey>().UseKey();
        }
    }
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

    void Dead()
    {
        Destroy(GameObject.Find("Directional Light"));
        Destroy(GameObject.Find("GameManager"));
        Destroy(GameObject.Find("CameraLoc"));
        GameObject cam = Camera.main.gameObject;
        roomMgr = cam.GetComponent<RoomManager>();
        
        roomMgr.LoadNextLevel("Lobby");
        Destroy(cam);

        Destroy(this.gameObject);
    }
}
