using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class isCountText : MonoBehaviour {

    public FloatData count;
    Text text;
	void Start ()
    {
        text = GetComponent<Text>();
	}

    // Update is called once per frame
    void Update()
    {
        if (count.data == 0)
        {
            text.text = "";
        }
        else
        {
            text.text = (count.data).ToString();
        }
    }
}
