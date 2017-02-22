using UnityEngine;
using System.Collections;

public class isCollectible : Mixin {
    public string InventoryName;
	public void Collect()
	{
		// put me in the collection that matches my name
		// we HAVE a recipient now, cuz we updated istouchable...
		// try and insert!
		CollectionData []cdatas = GetRecipient().GetComponents<CollectionData>();

		foreach (CollectionData cd in cdatas)
		{
			// insert
			if (cd.Name == InventoryName) {
                if (!cd.Contains(this.gameObject))
                {
                    foreach(GameObject go in cd.data)
                    {
                        if(go.GetComponent<isCollectible>().Name == Name)
                        {

                        }
                    }
                    cd.Insert(this.gameObject);

                    // do some sort of disable, so we don't collect it again
                    //GetComponent<BoxCollider>().enabled = false;
   
                    if(GetComponent<isPersistent>())
                    {
                        GetComponent<isPersistent>().isPickedUp();
                    }

                    if(cd.data.Count == 1)
                    {
                        //SendMessage(OnUseCallback);
                        GetComponent<isUsable>().Use();
                    }
                    else
                    {
                        this.gameObject.SetActive(false);
                    }

                }
            }
		}

	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
