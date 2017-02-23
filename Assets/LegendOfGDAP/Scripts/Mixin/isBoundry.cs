using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isBoundry : Mixin {

    public enum boundSide
    {
        negZ,
        posZ,
        negX,
        posX
    }

    public boundSide Side;
    RoomManager roomManager;
    GameObject cameraLoc;
    Vector3 cameraPos;
    BoolData isMoving;
    string nextRoom;
    BoxCollider col;
    void Start()
    {
        col = GetComponent<BoxCollider>();
        cameraLoc = GameObject.Find("CameraLoc");

        GetComponent<isTriggerable>().SetRecipient(GameObject.Find("Player"));

        SetRecipient(Camera.main.gameObject);
        roomManager = recipient.GetComponent<RoomManager>();
        isMoving = recipient.GetComponent<BoolData>();
        nextRoom = GetComponent<StringData>().data;
        if(Side == boundSide.negX)
        {
            cameraPos = new Vector3(-20, 0, 0);
        }
        else if (Side == boundSide.posX)
        {
            cameraPos = new Vector3(20, 0, 0);
        }
        else if (Side == boundSide.negZ)
        {
            cameraPos = new Vector3(0, 0, -20);
        }
        else if (Side == boundSide.posZ)
        {
            cameraPos = new Vector3(0, 0, 20);
        }

    }

    public void Load()
    {
        print("I would load");
        roomManager.LoadNextLevel(nextRoom);
        cameraLoc.transform.position = cameraLoc.transform.position + cameraPos;
        isMoving.data = true;
    }

    void Update()
    {
        if (isMoving != null && col != null)
        {
            if (isMoving.data == true && col.enabled == true)
            {
                col.enabled = false;
            }
            if (isMoving.data == false)
            {
                col.enabled = true;
            }
        }

    }

}
