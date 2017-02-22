using UnityEngine;
using System.Collections;

public class isCollectible : Mixin {
    public string InventoryName;
    public string BuffCB;
    public BoolData onlyOnEquip;
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
                    
                    cd.Insert(this.gameObject);

                    // do some sort of disable, so we don't collect it again
                    //GetComponent<BoxCollider>().enabled = false;
   
                    if(GetComponent<isPersistent>())
                    {
                        GetComponent<isPersistent>().isPickedUp();
                    }

                    if (onlyOnEquip != null)
                    {
                        if (onlyOnEquip.data == false)
                        {
                            SendMessage(BuffCB, GetRecipient().GetComponent<isStats>());
                        }
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
	void Start ()
    {
        if (onlyOnEquip)
        {
            bool rand = false;
            if (Random.value >= 0.5)
            {
                rand = true;
            }
            onlyOnEquip.data = rand;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
