using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isBuff : Mixin {
    
    public float buffPercentage;
    public float timer;
    public float time;

    List<float> times = new List<float>();
    List<GameObject> hasBuffed = new List<GameObject>();
    bool buffed;
    isStats stats;
    public void Buff(isStats s)
    {
        stats = s;
        stats.BuffStat(Name, buffPercentage);
        buffed = true;
    }

    public void AreaBuff()
    {
        if (hasBuffed.Contains(recipient))
        {
            return;
        }
        else
        {
            stats = recipient.GetComponent<isStats>();
            if (stats != null)
            {
                stats.BuffStat(Name, buffPercentage);
                hasBuffed.Add(recipient);
                times.Add(0.0f);
            }
        }
        
    }


    public void RemoveBuff()
    {
        if (buffed == true)
        {
            stats.LowerStat(Name, buffPercentage);
            buffed = false;
        }
    }

    public void removeAreaBuff(GameObject go)
    {

        stats = go.GetComponent<isStats>();
        if (stats != null)
        {
            stats.LowerStat(Name, buffPercentage);
            buffed = false;
        }
    }

    public void Update()
    {
        int i = -1;
        foreach(float t in times)
        {
            i++;
            times[i] += Time.deltaTime;
            if(t > timer)
            {
                removeAreaBuff(hasBuffed[i]);
                hasBuffed.RemoveAt(i);
                times.RemoveAt(i);
                break; 
            }
        }   
    }

}
