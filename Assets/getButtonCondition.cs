using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getButtonCondition : Condition
{

    public string button;
    public float cooldown;
    float time;
    // returns true if it's down, false otherwise
    override public bool Eval()
    {
        time += Time.deltaTime;

        if(Input.GetButton(button) && time > cooldown)
        {
            time = 0;
            return true;
        }
        return false;
    }
}
