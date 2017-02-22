using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CollectionData : Data
{
    public bool StackCollectables;
    public List<List<GameObject>> data = new List<List<GameObject>>();

    public isInventoryView inventory;
    public GameObject GetDataItem(int i)
    {
        GameObject rval = null;
        if (i < data.Count)
            rval = data[i][0];

        return rval;
    }

    public int GetDataCount(int i)
    {
        int rval = 0;
        if (i < data.Count)
            rval = data[i].Count;

        return rval;
    }

    public int GetGameObjectCount(GameObject go)
    {
        foreach (List<GameObject> objs in data)
        {
            if (objs.Contains(go))
            {
                return objs.Count;
            }

        }

        return 0;

    }


    public void Insert(GameObject go)
    {
        if (StackCollectables)
        {
            int i = 0;
            foreach (List<GameObject> objs in data)
            {
                foreach (GameObject obj in objs)
                {
                    string goName = go.GetComponent<isCollectible>().Name;
                    string objName = obj.GetComponent<isCollectible>().Name;
                    if (goName == objName)
                    {
                        objs.Add(go);
                        if (inventory != null)
                        {
                            inventory.isInventoryViewUpdate();
                        }
                        return;
                    }
                    i++;
                }
            }
        }
        List<GameObject> newObjs = new List<GameObject>();
        newObjs.Add(go);
        data.Add(newObjs);
        inventory.isInventoryViewUpdate();
    }

    public void Remove(GameObject go)
    {
       
        foreach (List<GameObject> objs in data)
        {
            if (objs.Contains(go))
            {
                objs.Remove(go);
                if(objs.Count == 0)
                {
                    data.Remove(objs);
                }
            }
                 
            if (inventory != null)
            {
                inventory.isInventoryViewUpdate();
            }
            return;
        }
    }

    public GameObject RemoveAndReturn(GameObject go)
    {

        foreach (List<GameObject> objs in data)
        {
            if (objs.Contains(go))
            {
                objs.Remove(go);
                if (objs.Count == 0)
                {
                    data.Remove(objs);
                    {
                        inventory.isInventoryViewUpdate();
                    }
                    return null;
                }
                if (inventory != null)
                {
                    inventory.isInventoryViewUpdate();
                }
                return objs[0];
            }

            
        }
        return null;
    }


    public bool Contains(GameObject go)
    {
        foreach (List<GameObject> objs in data)
        {
            if (objs.Contains(go))
            {
                return true;
            }
        }
        return false;
    }

}
