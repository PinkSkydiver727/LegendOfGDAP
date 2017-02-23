using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RoomManager : MonoBehaviour
{

    static RoomManager This;
    public string NextLevelName;  //gameplay level to load

    public Scene currentScene;
    public Scene prevScene;

    public bool LoadLevel;    //debug way to trigger level load...

    public void OnEnable()
    {
        // grab the first instance no matter what...
        if (This == null)
            This = this;

        // connect delegate function callbacks!
        SceneManager.sceneLoaded += OnLevelLoaded;
        SceneManager.sceneUnloaded += OnLevelUnloaded;
        SceneManager.LoadSceneAsync(NextLevelName, LoadSceneMode.Additive);

    }

    public static RoomManager GetThis()
    {
        return This;
    }

    // Use this for initialization
    void Start()
    {

    }

    public void OnLevelUnloaded(Scene scene)
    {
        Debug.Log("Scene unloaded, 8(");
    }

    public void OnLevelLoaded(Scene scene, LoadSceneMode lsm)
    {
        prevScene = currentScene;
        currentScene = scene;
        //    if (currentScene.name != null)
        //        SceneManager.UnloadSceneAsync(currentScene);
        //    prevScene = currentScene;
        //    currentScene = scene;

        //    Debug.Log("Scene loaded, w00t!");
    }

    public void unloadPrevious()
    {
            if (prevScene.name != null)
                SceneManager.UnloadSceneAsync(prevScene);

    }

    public void LoadNextLevel(string roomName)
    {
        NextLevelName = roomName;
        // 2 choices in the field
        // Application.LoadLevel...
        //  there used to be no way to know what scene file a gameobject came from
        //  when you loaded asyncadditive...
        //   [ 1 ]
        //      -> gameobject1
        //      -> gameobject2
        //      -> ...
        //

        // load addively async
        SceneManager.LoadSceneAsync(NextLevelName, LoadSceneMode.Additive);

    }

    public void LevelMgrUpdate()
    {
        //trigger a scenefile load
        if (LoadLevel == true)
        {
            LoadLevel = false;
            LoadNextLevel(NextLevelName);
        }
    }

    // Update is called once per frame
    void Update()
    {

        SceneManager.SetActiveScene(currentScene);
        LevelMgrUpdate();
    }
}
