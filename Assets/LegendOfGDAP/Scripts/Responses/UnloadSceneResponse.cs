using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnloadSceneResponse : Response {

    public GameObject recipient;
    RoomManager roomManager;
    BoolData isMoving;
    void Start()
    {
        roomManager = recipient.GetComponent<RoomManager>();
        isMoving = recipient.GetComponent<BoolData>();
    }

    public override void Execute()
    {
        isMoving.data = false;

        roomManager.unloadPrevious();
    }
}
