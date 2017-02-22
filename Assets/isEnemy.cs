using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class isEnemy : MonoBehaviour {

    NavMeshAgent nav;
    Animator anim;
    float initSpeed;
    float initAngluarSpeed;
    public FloatData damageBuff;
    public FloatData sizeBuff;
    public FloatData walkSpeedBuff;
    public FloatData attackSpeedBuff;
    Vector3 initScale;
    // Use this for initialization
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        initScale = transform.localScale;
        initSpeed = nav.speed;
        initAngluarSpeed = nav.angularSpeed;
    }

    // Update is called once per frame


    public void ApplyBuff()
    {
        isHurtBox[] hurtBoxs = GetComponentsInChildren<isHurtBox>();
        foreach (isHurtBox hurtBox in hurtBoxs)
        {
            hurtBox.damageBuff = damageBuff.data;
        }

        transform.localScale = initScale * sizeBuff.data;
        nav.speed = initSpeed * walkSpeedBuff.data;
        nav.angularSpeed = initAngluarSpeed * walkSpeedBuff.data;
        anim.SetFloat("attackSpeed", attackSpeedBuff.data);

    }
}
