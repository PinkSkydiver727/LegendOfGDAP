using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isHurtBox : MonoBehaviour {

    public Collider hurtBox;
    public int damage;
    
    [HideInInspector]
    public float damageBuff;

    public int force;
    public GameObject coin;
    public int numCoins;
    public bool active;
    public bool equipped;
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
            Transform rootTransform = this.transform.root;
            if (other.gameObject != rootTransform.gameObject)
            {

                if (rootTransform.GetComponent<isPlayer>())
                {
                    rootTransform.GetComponent<isPlayer>().ApplyBuff();
                }
                FloatData[] stats = other.GetComponents<FloatData>();
                foreach (FloatData stat in stats)
                {
                    if (stat.Name == "Health")
                    {
                        if (other.GetComponent<Rigidbody>())
                        {
                            other.GetComponent<Rigidbody>().AddForce(rootTransform.forward * force);
                        }
                        stat.data -= damage * damageBuff;
                        print("hit " + other.name + " with " + this.gameObject.name);

                        if(numCoins > 0)
                        {
                            for(int i = 0; i <= numCoins; i++)
                            {
                                Instantiate(coin, other.transform.position, Quaternion.identity);
                            }
                        }
                        //hurtBox.enabled = false;
                        
                    }
                }
            }
        }
    }

    void OnEnable()
    {
        //Physics.IgnoreCollision(hurtBox, GameObject.Find("Player").GetComponent<CapsuleCollider>());
        
    }

    

    





}
