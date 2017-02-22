using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isThrowable : Mixin {
    public List<Mixin> turnOff;
    public string OnThrowCB;
    isThrowable nextThrowable;
    public isEquipSlot throwSlot;
	public void Throw()
    {
        foreach(Mixin m in turnOff)
        {
            Destroy(m);
        }

        CollectionData[] cdatas = transform.root.GetComponents<CollectionData>();

        foreach (CollectionData cd in cdatas)
        {
            // insert
            if (cd.Name == Name)
            {
                cd.Remove(this.gameObject);
                if(cd.GetGameObjectCount(this.gameObject) > 0)
                {
                    isThrowable[] throws = transform.parent.GetComponentsInChildren<isThrowable>(true);
                    foreach(isThrowable throwable in throws)
                    {
                        if(throwable.Name == Name && throwable != this)
                        {
                            nextThrowable = throwable;
                            break;
                        }
                    }
                }
            }
        }
        GetComponent<BoxCollider>().enabled = true;

        this.transform.parent = null;
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.useGravity = true;
        rb.isKinematic = false;
        rb.AddRelativeForce(100.0f, 60.0f, 0.0f);
        throwSlot.obj = null;
        if (nextThrowable != null)
        {
            nextThrowable.gameObject.SetActive(true);
            nextThrowable.enableNext();
        }

    }

    public void enableNext()
    {
        SendMessage(OnThrowCB);
    }
}
