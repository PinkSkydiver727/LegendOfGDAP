using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isPlayer : MonoBehaviour {

    public FloatData damageBuff;
    public FloatData sizeBuff;
    Vector3 initScale; 
    // Use this for initialization
    void Start () {
        initScale = transform.localScale;
	}

    // Update is called once per frame
    

    public void ApplyBuff()
    {
        isHurtBox[] hurtBoxs = GetComponentsInChildren<isHurtBox>();
        foreach(isHurtBox hurtBox in hurtBoxs)
        {
            hurtBox.damageBuff = damageBuff.data;
        }

        transform.localScale = initScale * sizeBuff.data;

    }
}
