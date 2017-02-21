using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class isCollectionView : MonoBehaviour {

    public List<isInventorySlot> slots;
    public FloatData collectionSize;
    float currentSize;
    // Use this for initialization
    void Start () {


        isInventorySlot[] sls = this.gameObject.GetComponentsInChildren<isInventorySlot>();
        foreach (isInventorySlot s in sls)
        {
            slots.Add(s);
        }

    }
	
	// Update is called once per frame
	void Update () {
		if(currentSize != collectionSize.data)
        {
            int i  = 1;
            foreach(isInventorySlot slot in slots)
            {
                if(i <= collectionSize.data)
                {
                    slot.GetComponent<Image>().enabled = true;
                }
                else
                {
                    slot.GetComponent<Image>().enabled = false;
                }
                i++;
            }
            currentSize = collectionSize.data;
        }
	}
}
