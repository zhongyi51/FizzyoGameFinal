using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rockrun : MonoBehaviour {
    private Rigidbody2D rb2d;
    private Rigidbody2D mars2d;
    private Rigidbody2D jup2d;

    public Text marsMessage;
    public Text jupMessage;
    private float startTime;
    private float marsTime = 10f;
    private bool marsSpawned = false;
    private float jupTime = 30f;
    private bool jupSpawned = false;
    public float textTime;

    public GameObject mars;
    public GameObject jupiter;
    private GameObject text;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(GameController.instance.rockspeed, 0);
        startTime = Time.time;
        mars = GameObject.FindGameObjectWithTag("Mars");
        mars2d = mars.GetComponent<Rigidbody2D>();
        jupiter = GameObject.FindGameObjectWithTag("Jupiter");
        jup2d = mars.GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Time.time - startTime > marsTime && marsSpawned == false)
        {
            spawnMars();
        }
        else if (Time.time - startTime > jupTime && jupSpawned == false)
        {
            spawnJupiter();
        }
    }

    void spawnMars()
    {
        textTime = Time.time;
        mars2d.velocity = new Vector2(GameController.instance.rockspeed / 2, 0);
        marsSpawned = true;
        marsMessage = GameObject.FindGameObjectWithTag("marsText").GetComponent<Text>();
        if (text != null)
        {
            print("true");

            while (Time.time - textTime < 5)
            {
                marsMessage.text = "Congratulations, you've reached Mars!";
            }

        }
    }

    void spawnJupiter()
    {
        textTime = Time.time;
        jup2d.velocity = new Vector2(GameController.instance.rockspeed / 1.3f, 0);
        jupSpawned = true;
        if (text != null)
        {
            print("true");

            while (Time.time - textTime < 5)
            {
                jupMessage.text = "Congratulations, you've reached Jupiter!";
            }

        }
    }
}
