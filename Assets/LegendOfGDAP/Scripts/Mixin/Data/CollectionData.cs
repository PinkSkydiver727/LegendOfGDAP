using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CollectionData : Data {
    public bool StackCollectables;
	public List<GameObject>	data;
    public List<int> dataCount;
    public isInventoryView inventory;
	public GameObject GetDataItem(int i)
	{
		GameObject rval = null;
		if (i < data.Count)
			rval = data [i];

		return rval;
	}

    public int GetDataCount(int i)
    {
        int rval = 0;
        if (i < data.Count)
            rval = dataCount[i];

        return rval;
    }

    public int GetGameObjectCount(GameObject go)
    {
        int i = 0;
        foreach (GameObject obj in data)
        {
            string goName = go.GetComponent<isCollectible>().Name;
            string objName = obj.GetComponent<isCollectible>().Name;
            if (goName == objName)
            {
                if (inventory != null)
                {
                    inventory.isInventoryViewUpdate();
                }
                return dataCount[i];
            }
            i++;

        }

        return 0;
        
    }


    public void Insert(GameObject go)
	{
        if (StackCollectables)
        {
            int i = 0;
            foreach (GameObject obj in data)
            {
                string goName = go.GetComponent<isCollectible>().Name;
                string objName = obj.GetComponent<isCollectible>().Name;
                if (goName == objName)
                {
                    dataCount[i]++;
                    if (inventory != null)
                    {
                        inventory.isInventoryViewUpdate();
                    }
                    return;
                }
                i++;

            }
        }
        dataCount.Add(1);
        data.Add(go);
        inventory.isInventoryViewUpdate();
	}

	public void Remove(GameObject go)
	{
        if (StackCollectables)
        {
            int i = 0;
            foreach (GameObject obj in data)
            {
                string goName = go.GetComponent<isCollectible>().Name;
                string objName = obj.GetComponent<isCollectible>().Name;
                if (goName == objName)
                {
                    dataCount[i]--;
                    if(dataCount[i] == 0)
                    {
                        data.Remove(go);
                        dataCount.RemoveAt(i);
                        
                    }
                    if (inventory != null)
                    {
                        inventory.isInventoryViewUpdate();
                    }
                    return;
                }
                i++;

            }
        }


        data.Remove(go);
        if (inventory != null)
        {
            inventory.isInventoryViewUpdate();
        }
    }

    public bool Contains(GameObject go)
    {
        if(data.Contains(go))
        {
            return true;
        }
        return false;
    }

}
