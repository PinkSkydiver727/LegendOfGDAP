using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CollectionString : Data
{

    public List<string> data;

    public string GetDataItem(int i)
    {
        string rval = null;
        if (i < data.Count)
            rval = data[i];

        return rval;
    }
    public void Insert(string id)
    {
        data.Add(id);
    }

    public void Remove(string id)
    {
        data.Remove(id);
    }

    public bool Contains(string id)
    {
        if (data.Contains(id))
        {
            return true;
        }
        return false;
    }

}