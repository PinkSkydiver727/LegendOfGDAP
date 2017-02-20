using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackResponse : Response
{
    public GameObject player;
    public Animator anim;
    public isEquipSlot.eSlotType slotType;

    public override void Execute()
    {
        isEquipSlot[] eqSlots = player.GetComponentsInChildren<isEquipSlot>();

        foreach (isEquipSlot iseqs in eqSlots)
        {
            // slot type matches
            if (iseqs.slotType == slotType)
            {
                // turn off active weapon
                if (iseqs.obj == null)
                {
                    return;
                }
                AnimatorOverrideController animOverride = iseqs.obj.GetComponent<isAttackable>().animOverride;
                if(animOverride != null)
                {
                    anim.runtimeAnimatorController = animOverride;
                    anim.SetTrigger("attack");
                }
            }
        }

    }


}
