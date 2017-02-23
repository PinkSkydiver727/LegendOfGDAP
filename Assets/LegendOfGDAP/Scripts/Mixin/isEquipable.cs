using UnityEngine;
using System.Collections;

public class isEquipable : Mixin
{
    public BoolData buffOnEquipOnly;
    public bool triggerOnEquip;
    public string BuffCB;
    public string UnBuffCB;
    public isEquipSlot.eSlotType slotType;

    public void Equip()
    {
        // find the first open slot of my compatible type, and 
        // equip me there!

        isEquipSlot[] eqSlots = GetRecipient().GetComponentsInChildren<isEquipSlot>();

        foreach (isEquipSlot iseqs in eqSlots)
        {
            // slot type matches
            if (iseqs.slotType == slotType)
            {
                // turn off active weapon
                if (iseqs.obj != null)
                {
                    iseqs.obj.gameObject.SetActive(false);
                    if (iseqs.obj.GetComponent<isHurtBox>() != null)
                    {
                        if (iseqs.obj.GetComponent<BoolData>() != null)
                        {
                            if (iseqs.obj.GetComponent<BoolData>().data == true)
                            {
                                iseqs.obj.GetComponent<isBuff>().RemoveBuff();
                            }
                        }
                        iseqs.obj.GetComponent<isHurtBox>().equipped = false;
                    }
                }

                Quaternion rot = this.transform.localRotation;
                // insert it!
                this.transform.parent = iseqs.transform;

                this.transform.localPosition = Vector3.zero;
                this.transform.localRotation = rot;

                // make rb enert... ug...todo
                Rigidbody rb = this.gameObject.GetComponent<Rigidbody>();

                if (rb != null)
                {
                    rb.isKinematic = true;
                }
                iseqs.obj = this.gameObject; //api!
                if (GetComponent<isHurtBox>() != null)
                {
                    GetComponent<isHurtBox>().equipped = true;
                    if (buffOnEquipOnly != null)
                    {
                        if (BuffCB != "" && buffOnEquipOnly.data == true)
                        {
                            SendMessage(BuffCB, transform.root.GetComponent<isStats>());
                        }
                    }
                }
                if(triggerOnEquip)
                {
                    GetComponent<BoxCollider>().enabled = true;
                }
                break;

            }
        }

    }

    public void Start()
    {
        SetRecipient(GameObject.Find("Player"));
    }

    // Use this for initialization
}
