using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isHurtBox : MonoBehaviour {

    public BoxCollider hurtBox;
    public int damage;
    public int force;
    public bool active;
    bool equipped;
    public enum hurtType
    {
        RightHand,
        LeftHand,
    };

    public hurtType slotType;

    void OnTriggerEnter(Collider other)
    {
        if (equipped)
        {
            if (other.gameObject != this.transform.root.gameObject)
            {
                FloatData[] stats = other.GetComponents<FloatData>();
                foreach (FloatData stat in stats)
                {
                    if (stat.Name == "Health")
                    {
                        if (other.GetComponent<Rigidbody>())
                        {
                            other.GetComponent<Rigidbody>().AddForce(transform.root.transform.forward * force);
                        }
                        stat.data -= damage;
                        print("hit " + other.name + " with " + this.gameObject.name);
                        hurtBox.enabled = false;
                        
                    }
                }
            }
        }
    }

    void OnEnable()
    {
        //Physics.IgnoreCollision(hurtBox, GameObject.Find("Player").GetComponent<CapsuleCollider>());
        
    }

    void Start()
    {
        equipped = true;
        
    }

    





}
