using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class isInventoryView : MonoBehaviour {

	public string Name; // name of the collection we are binding to
	private CollectionData collection;

	public List<isInventorySlot>	slots; 

	public GameObject parent;
    public GameObject highlight;
    public GameObject selector;

    public int items;
    public int selectorIndex = 0;

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
        if (collection.data.Count > items)
        {
            // map slot image thumbnails to inventory object thumbnails
            // brute force!
            if (collection != null)
            {
                int i = 0;

                foreach (isInventorySlot slot in slots)
                {
                    // what if collection.size < slots.size
                    GameObject obj = collection.GetDataItem(i);//data [i];
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
                            // if we have a thumbnail, associate this obj with our slot
                            Image slotImage = slot.gameObject.GetComponent<Image>();
                            if (slotImage != null)
                            {
                                slotImage.overrideSprite = ht.img;
                                slot.obj = obj; // keep reference to collection obj in the slot
                                if(slot.GetComponent<FloatData>() != null)
                                {
                                    slot.GetComponent<FloatData>().data = collection.GetDataCount(i);
                                }
                            }
                            if (obj.activeInHierarchy == true)
                            {
                                highlight.transform.position = slot.transform.position;
                            }
                            if (i == selectorIndex)
                            {
                                selector.transform.position = slot.transform.position;
                            }
                        }
                    }
                    i++;
                }
            }
        }
	}

    public void Cycle()
    {
        if (collection.data.Count >= 1)
        {
            selectorIndex++;
            if (selectorIndex >= collection.data.Count)
            {
                selectorIndex = 0;
            }
            GameObject obj = collection.GetDataItem(selectorIndex);//data [i];


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
        }
    }

	// Update is called once per frame
	void Update () {
	
		isInventoryViewUpdate ();
        
	}
}
