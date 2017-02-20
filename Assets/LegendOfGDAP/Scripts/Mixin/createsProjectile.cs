using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createsProjectile : Mixin {


    public isEquipSlot.eSlotType slotType;


    public GameObject projectile;
    GameObject proj;
    public void Spawn()
    {
        proj = Instantiate(projectile, Vector3.zero, Quaternion.identity);
        isEquipSlot[] eqSlots = GetRecipient().GetComponentsInChildren<isEquipSlot>();

        foreach (isEquipSlot iseqs in eqSlots)
        {
            // slot type matches
            if (iseqs.slotType == slotType)
            {
                // turn off active weapon
                if (iseqs.obj == null)
                {
                    proj.transform.parent = iseqs.transform;
                    proj.transform.localPosition = Vector3.zero;
                    proj.transform.localRotation = Quaternion.identity;

                }
            }
        }
   }

    public void Fire()
    {
        proj.transform.parent = null;
        Rigidbody rb = proj.GetComponent<Rigidbody>();
        rb.useGravity = true;
        rb.AddRelativeForce(0.0f, 150.0f, 500.0f);


    }
    // Use this for initialization
    public void Start()
    {
        SetRecipient(GameObject.Find("Player"));
    }

    // Update is called once per frame
    void Update () {
		
	}
}
