using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floatDataCondition : Condition
{
    public FloatData floatdata;
    float target;
    public checkFor compare;
    public enum checkFor
    {
        equal,
        less,
        greater
    }

    // Use this for initialization
    override public bool Eval()
    {
        if (compare == checkFor.equal)
        {
            if (floatdata.data == target)
            {
                return true;
            }
        }
        else if (compare == checkFor.less)
        {
            if (floatdata.data <= target)
            {
                return true;
            }
        }
        else if (compare == checkFor.greater)
        {
            if (floatdata.data >= target)
            {
                return true;
            }
        }

        return false;
    }

}
