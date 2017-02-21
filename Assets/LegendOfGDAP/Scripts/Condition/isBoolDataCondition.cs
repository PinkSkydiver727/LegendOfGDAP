using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isBoolDataCondition : Condition {
    public BoolData boolData;
    // Use this for initialization
    public override bool Eval()
    {
        return boolData.data;
    }
}
