using Classes.Repos;
using Classes;
using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public static GameController instance;
    public GameObject Red;
    public float encounterRate;
    public bool surfEnabled;

    Classes.Player dummy;

    public GameObject loadingScreen;
    //public GameObject loadingEventSystem;
    //LocationRepository repo;
    string checkDir;
    public SurfEnabler surfEnabler;

    public GameObject load;
    int frame;
    void Awake()
    {
        //If we don't currently have a game control...
        if (instance == null)
            //...set this one to be it...
            instance = this;
        //...otherwise...
        else if (instance != this)
            //...destroy this one because it is a duplicate.
            Destroy(gameObject);
        DontDestroyOnLoad(this);
        if (GameObject.FindWithTag("Player"))
        {

        }
        else
        {
            StartCoroutine("InstantiateStuff");
        }
    }

    private void Update()
    {
        if(surfEnabler)
        {
            switch(Red.GetComponent<Player>().dir)
            {
                case Direction.Up:
                    checkDir = "n";
                    break;
                case Direction.Left:
                    checkDir = "w";
                    break;
                case Direction.Down:
                    checkDir = "s";
                    break;
                case Direction.Right:
                    checkDir = "e";
                    break;
            }
            if(Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Return))
            {
                if(surfEnabler.surfDirections.Contains(checkDir))
                {
                    //Go Surf
                    foreach(GameObject obj in GameObject.FindGameObjectsWithTag("WaterBlock"))
                    {
                        obj.layer = 2;
                    }
                    Red.GetComponent<Player>().GoSurf(checkDir);
                    Debug.Log("Went Surfing");
                }
            }
        }

        if (frame <= 25)
        {
            frame++;
        }
    }

    IEnumerator InstantiateStuff()
    {
        frame = 0;
        Instantiate(Red, new Vector3(9.5f, 5.5f, -1f), new Quaternion());
        load = Instantiate(loadingScreen);
        //GameObject eventsys = Instantiate(loadingEventSystem);
        yield return new WaitUntil(() => frame >= 25);
        EnableLoadingScreen(false);
        //eventsys.SetActive(false);
        DontDestroyOnLoad(load);
        //DontDestroyOnLoad(eventsys);
    }

    public void EnableLoadingScreen(bool enable)
    {
        load.SetActive(enable);
    }
}
