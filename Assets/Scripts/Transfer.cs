using Classes;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transfer : MonoBehaviour {

    public GameObject Red;
    public string sceneName;
    public int toLocationId;

    public int targetX;
    public int targetY;

    float x;
    float y;

    Vector3 target;
    
    private void Awake()
    {
        Red = GameObject.FindGameObjectWithTag("Player");
        //passage = Red.GetComponent<Player>().GetCurrentLocation().GetPassageByCoords(Convert.ToInt32(transform.position.x), Convert.ToInt32(transform.position.y));
        x = targetX + 0.5f;
        y = targetY + 0.5f;
        target = new Vector3(x, y, -1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Red.GetComponent<Player>().moving = true;
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
            Red.transform.position = target;
            Red.GetComponent<Player>().pos = target;
            Red.GetComponent<Player>().moving = false;
            Red.GetComponent<Player>().player.GoToLocation(toLocationId);
        }
    }
}
