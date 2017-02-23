using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public class isPersistent : Mixin {

    public string guid;
    public static int counter;
    CollectionString persistanceBuffer;

    [ContextMenu("GenerateUID")]
    void GenerateUID()
    {
        //getGuid = Camera.main.GetComponent<IntData>();
        guid = (EditorSceneManager.GetActiveScene().name + counter);
        counter++;
    }



    // Use this for initialization
    void Awake()
    {
        persistanceBuffer = GameObject.Find("GameManager").GetComponent<CollectionString>();
        foreach (string id in persistanceBuffer.data)
        {
            if (id == guid)
            {
                Destroy(this.gameObject);
            }
        }
    }
    public void isPickedUp() {
        persistanceBuffer.Insert(guid);
	}
    public void isDead()
    {
        persistanceBuffer.Insert(guid);
    }


}
