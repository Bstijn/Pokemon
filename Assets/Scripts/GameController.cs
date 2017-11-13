using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public static GameController instance;
    public GameObject Red;
    public float encounterRate;

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
            Instantiate(Red, new Vector3(9.5f, 6.5f, -1f), new Quaternion());
        }
    }
}
