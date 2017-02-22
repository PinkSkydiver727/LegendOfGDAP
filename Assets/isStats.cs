using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isStats : MonoBehaviour {

    public List<FloatData> Stats;
    public string BuffCB;

	public void BuffStat(string statName, float buff)
    {
        foreach(FloatData stat in Stats)
        {
            if(stat.Name == statName)
            {
                stat.data += (buff / 100);
            }
        }

        SendMessage(BuffCB);

    }

    public void LowerStat(string statName, float buff)
    {
        foreach (FloatData stat in Stats)
        {
            if (stat.Name == statName)
            {
                stat.data -= (buff / 100);
            }
        }
        SendMessage(BuffCB);
    }
}
