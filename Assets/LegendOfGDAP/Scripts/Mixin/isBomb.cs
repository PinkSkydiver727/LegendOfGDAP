using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isBomb : MonoBehaviour {

    public float timer;
    float time = 0.0f;
    public bool isThrown;
    public GameObject explosion;
    BoxCollider col;

	// Use this for initialization
	void Start () {
        col = GetComponent<BoxCollider>();
	}

    // Update is called once per frame
    void Update()
    {

        if (isThrown == false && col.isTrigger == false)
        {
            isThrown = true;
        }
        if(isThrown == true)
        {
            time += Time.deltaTime;
            if(time > timer)
            {
                Instantiate(explosion, this.transform.position, explosion.transform.rotation);
                Destroy(this.gameObject);
            }
        }

    }
}
