using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveResponse : Response
{
    public float moveSpeed = 5.0f;
    public GameObject player;
    public Animator anim;
    public string animParameter;
    int isNeg = 1;
    public override void Execute()
    {
        anim.applyRootMotion = false;
        float y = Input.GetAxis("Vertical");
        float x = Input.GetAxis("Horizontal");
        if (Mathf.Abs(y) > Mathf.Abs(x))
        {
            Vector3 rot = player.transform.eulerAngles;
            float rotation; 
            if (y < 0)
            {
                //rotation = 180 +
                rot.y = 180;
            }
            else
            {
                rot.y = 0;
            }
            y = Mathf.Abs(y);
            player.transform.eulerAngles = rot;
            if (player.transform.rotation.eulerAngles.y == 90.0f || player.transform.rotation.eulerAngles.y == -90.0f)
            {
                //player.transform.Rotate(new Vector3(0, 1, 0), -90.0f * isNeg);
            }
            player.transform.position += y * this.transform.forward * moveSpeed * Time.deltaTime;
            anim.SetFloat(animParameter, y);
        }
        else
        {
            Vector3 rot = player.transform.eulerAngles;
            //float rotation; 
            if (x < 0)
            {
                //rotation = -90 +
                rot.y = -90;
            }
            else
            {
                rot.y = 90;
            }
            x = Mathf.Abs(x);
            player.transform.eulerAngles = rot;

            if (player.transform.rotation.eulerAngles.y == 0 || player.transform.rotation.eulerAngles.y == 180)
            {
               // player.transform.Rotate(new Vector3(0, 1, 0), 90.0f * isNeg);
            }
            player.transform.position += x * this.transform.forward * moveSpeed * Time.deltaTime;
            anim.SetFloat(animParameter, x);
        }
    }
}
