using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isStorable : Mixin {

    // Use this for initialization
    void Store()
    {
        FloatData[] sdata = GetRecipient().GetComponents<FloatData>();

        foreach (FloatData store in sdata)
        {
            // insert
            if (store.Name == Name)
            {
                store.data++;
                Destroy(this.gameObject);
            }
        }
    }
	
	// Update is called once per frame
	void Start ()
    {
        SetRecipient(GameObject.Find("Player"));
    }
}
