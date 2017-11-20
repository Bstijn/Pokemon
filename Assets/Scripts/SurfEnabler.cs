using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurfEnabler : MonoBehaviour {
    public string surfDirections;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameController.instance.Red.GetComponent<Player>().surfing)
        {
            GameController.instance.Red.GetComponent<Player>().surfing = false;
            GameController.instance.surfEnabler = null;
            GameController.instance.surfEnabled = false;
            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("WaterBlock"))
            {
                obj.layer = 4;
            }
        }
        else
        {
            GameController.instance.surfEnabler = this;
            GameController.instance.surfEnabled = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        GameController.instance.surfEnabler = null;
        GameController.instance.surfEnabled = false;
    }
}
