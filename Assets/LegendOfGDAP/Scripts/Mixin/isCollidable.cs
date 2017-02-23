using UnityEngine;
using System.Collections;

// physical contact between some object and this object
public class isCollidable : Mixin
{

    public string OnCollideCB;    // send this event, when touch happens

    public void OnCollisionEnter(Collision col)
    {
        if (GetRecipient() == col.gameObject)
        {
            GameObject go = col.gameObject;

            isCollectible isCol = GetComponent<isCollectible>();
            if (isCol != null)
            {
                isCol.SetRecipient(col.gameObject);
            }

            // send a response
            if (OnCollideCB != "")
                SendMessage(OnCollideCB);

            //this.enabled = false;
            GetComponent<BoxCollider>().enabled = false;
        }
    }
    public void DebugMsg()
    {
        Debug.Log("MIXINS OMG!!!");
    }

    // Use this for initialization
    void Start()
    {
        SetRecipient(GameObject.Find("Player"));
    }

    // Update is called once per frame

}
