using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isDoor : MonoBehaviour {

    float time = 0.0f;
    public float openTime;
    bool opening = false;
    Vector3 endPos;
    Vector3 startPos;
	void Open()
    {
        opening = true;
        endPos.y = -0.5f;
        startPos = transform.localPosition;
        endPos.x = startPos.x;
        endPos.z = startPos.z;
    }

    void Update()
    {
        if(opening == true)
        {
            time += Time.deltaTime;
            transform.position = Vector3.Lerp(startPos, endPos, time);
            if(time > 1.0f)
            {
                opening = false;
            }
        }
    }
}
