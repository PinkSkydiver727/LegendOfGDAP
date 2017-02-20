using UnityEngine;
using System.Collections;

public class SmoothFollow : Mixin
{
    public GameObject lookObj;
    public GameObject DestObj;
    public float t = 0.0f;
    public float kh = 2.0f;
    public float speed = 1.0f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        t = (Time.deltaTime);
        transform.position += kh * (DestObj.transform.position - transform.position) * t;
        //transform.LookAt(lookObj.transform.position);

    }
}
