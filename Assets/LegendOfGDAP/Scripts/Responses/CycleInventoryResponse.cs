using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CycleInventoryResponse : Response
{
    public isInventoryView inventory;

    override public void Execute()
    {
        inventory.Cycle();

    }
}
