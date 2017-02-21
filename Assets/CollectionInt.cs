using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CollectionInt : Data
{

    public List<int> data;

    public int GetDataItem(int i)
    {
        int rval = 0;
        if (i < data.Count)
            rval = data[i];

        return rval;
    }
    public void Insert(int i)
    {
        data.Add(i);
    }

    public void Remove(int i)
    {
        data.Remove(i);
    }

    public bool Contains(int i)
    {
        if (data.Contains(i))
        {
            return true;
        }
        return false;
    }

}
