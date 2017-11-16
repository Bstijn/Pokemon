using UnityEngine;
using UnityEngine.SceneManagement;

public class Transfer : MonoBehaviour {

    public GameObject Red;
    public string sceneName;

    public int targetX;
    public int targetY;

    float x;
    float y;

    Vector3 target;

    private void Start()
    {
        Red = GameObject.FindGameObjectWithTag("Player");
        x = targetX + 0.5f;
        y = targetY + 0.5f;
        target = new Vector3(x, y, -1f);
    }

    private void Awake()
    {
        DontDestroyOnLoad(Red);
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
        }
    }
}
