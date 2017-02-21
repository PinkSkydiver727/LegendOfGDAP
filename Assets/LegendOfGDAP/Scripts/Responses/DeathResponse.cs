using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathResponse : Response {
    public BoolData isDead;
    public Animator anim;
    public override void Execute()
    {
        isDead.data = true;
        anim.SetBool("die", true);
        print("dead");
    }

}
