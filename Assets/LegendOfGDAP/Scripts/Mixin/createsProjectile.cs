using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createsProjectile : Mixin {


    public isEquipSlot.eSlotType slotType;
    public string collectionName;
    FloatData coins;
    public int cost;


    public GameObject projectile;
    GameObject proj;
    public void Spawn()
    {
        if (coins.data >= cost)
        {
            proj = Instantiate(projectile, Vector3.zero, Quaternion.identity);
            isEquipSlot[] eqSlots = GetRecipient().GetComponentsInChildren<isEquipSlot>();

            foreach (isEquipSlot iseqs in eqSlots)
            {
                // slot type matches
                if (iseqs.slotType == slotType)
                {
                    // turn off active weapon

                    proj.transform.parent = iseqs.transform;
                    proj.transform.localPosition = Vector3.zero;
                    proj.transform.localRotation = Quaternion.identity;


                }
            }
        }
   }

    public void Fire()
    {
        if (coins.data >= cost)
        {
            proj.transform.parent = null;
            Vector3 rot = proj.transform.rotation.eulerAngles;
            rot.x = 0;
            rot.z = 0;
            proj.transform.eulerAngles = rot;
            Rigidbody rb = proj.GetComponent<Rigidbody>();
            rb.useGravity = true;
            rb.AddRelativeForce(0.0f, 150.0f, 500.0f);


            if (coins != null)
            {
                coins.data -= cost;
            }
        }
        
    }
    // Use this for initialization
    public void Start()
    {
        SetRecipient(GameObject.Find("Player"));
        FloatData[] datas = recipient.GetComponents<FloatData>();
        foreach(FloatData data in datas)
        {
            if(data.Name == collectionName)
            {
                coins = data;
            }
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
