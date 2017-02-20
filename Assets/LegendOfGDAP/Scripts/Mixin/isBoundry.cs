using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isBoundry : Mixin {

    RoomManager roomManager;
    GameObject cameraLoc;
    Vector3 cameraPos;
    BoolData isMoving;
    string nextRoom;
    void Start()
    {
        cameraLoc = GameObject.Find("CameraLoc");
        SetRecipient(Camera.main.gameObject);
        roomManager = recipient.GetComponent<RoomManager>();
        isMoving = recipient.GetComponent<BoolData>();
        nextRoom = GetComponent<StringData>().data;
        cameraPos = GetComponent<Vector3Data>().data;

    }

    public void Load()
    {
        print("I would load");
        roomManager.LoadNextLevel(nextRoom);
        cameraLoc.transform.position = cameraPos;
        isMoving.data = true;
    }
}
