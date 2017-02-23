using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class isInventoryView : MonoBehaviour {

	public string Name; // name of the collection we are binding to
	private CollectionData collection;

	public List<isInventorySlot>	slots; 

	public GameObject parent;
    public GameObject selector;

    public int items;
    public int selectorIndex = 1;

	public void OnEnable()
	{
		// find the collection we need
		if (parent != null) {
			CollectionData[] cds = parent.GetComponentsInChildren<CollectionData> ();
			foreach (CollectionData cd in cds)
				if (cd.Name == Name)
					collection = cd;
		} else
			Debug.Log ("isInventoryView::OnEnable() ERROR PARENT IS NULL");

		// populate 
		isInventorySlot[] sls = this.gameObject.GetComponentsInChildren<isInventorySlot>();
        foreach (isInventorySlot s in sls)
        {
            slots.Add(s);
        }


	}

	// Use this for initialization
	void Start () {
	
	}

	public void isInventoryViewUpdate()
	{
 
            // map slot image thumbnails to inventory object thumbnails
            // brute force!
            if (collection != null)
            {
                int i = 0;

                foreach (isInventorySlot slot in slots)
                {
                    // what if collection.size < slots.size
                    GameObject obj = collection.GetDataItem(i); //data [i];
                            // if we have a thumbnail, associate this obj with our slot
                    Image slotImage = slot.gameObject.GetComponent<Image>();
                    if (obj != null)
                    {
                        hasThumbnail ht = obj.GetComponent<hasThumbnail>();
                        if (ht != null)
                        {
                            //int j = 0;
                            //foreach (isInventorySlot checkSlot in slots)
                            //{
                            //    if (j < i)
                            //    {
                            //        if (checkSlot.obj != null)
                            //        {
                            //            string checkName = checkSlot.obj.GetComponent<isCollectible>().Name;
                            //            string nameInSlot = obj.GetComponent<isCollectible>().Name;
                            //            if (checkName == nameInSlot)
                            //            {
                            //                print("duplicate");
                            //            }
                            //        }
                            //    }
                            //    j++;
                            //}
                            if (slotImage != null)
                            {
                                slotImage.overrideSprite = ht.img;
                                slot.obj = obj; // keep reference to collection obj in the slot
                                if(slot.GetComponent<FloatData>() != null)
                                {
                                    slot.GetComponent<FloatData>().data = collection.GetDataCount(i);
                                }

                                if (i+1 == selectorIndex)
                                {
                                    selector.transform.localPosition = slot.transform.localPosition;
                                }
                            }
                        }
                    }
                    else
                    {
                        slotImage.overrideSprite = null;
                        slot.obj = null;
                        if (slot.GetComponent<FloatData>() != null)
                        {
                            slot.GetComponent<FloatData>().data = 0;
                        }
                        //if (i != 0)
                        //{    
                        //    highlight.transform.position = slots[i - 1].transform.position;
                            
                        //    selector.transform.position = slots[i - 1].transform.position;    
                        //}
                    }
                    i++;
                }
            }
        
	}

    public void Cycle()
    {
        if (collection.data.Count >= 1)
        {
            selectorIndex++;
            if (selectorIndex > collection.data.Count)
            {
                selectorIndex = 1;
            }
            GameObject obj = collection.GetDataItem(selectorIndex - 1);//data [i];


            if (obj.GetComponent<isUsable>() != null)
            {
                isUsable iu = obj.GetComponent<isUsable>();
                // fix disabled object sendmessage failure! 
                if (obj != null)
                {
                    obj.SetActive(true);
                    //obj.GetComponent<isHurtBox>().equipped = true;
                }
                iu.Use();
            }
            isInventoryViewUpdate();
        }
        
    }

	// Update is called once per frame
	void Update () {
	
		//isInventoryViewUpdate ();
        
	}
}
