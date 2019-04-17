using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackGround : MonoBehaviour {
    private Rigidbody2D rb2d;
    public float targettime = 0.1f;
    public float scrollspeed = -1.5f;
    public float acceleration = -0.01f;
    public float accelerationofacceleration = -0.1f;
    public float realacceleration=-1f;
    public float fakespeed=-4.0f;
    public Text speedtext;
    public float stoptime=3.0f;
    private float realtargettime;
    private float realstoptime;
    private float spareacceleration;
    private bool hitfunction=false;
    private int score = 0;

    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        realtargettime = targettime;
	}
	
	// Update is called once per frame
	void Update () {
        if (hitfunction == false)
        {
            realtargettime -= Time.deltaTime;
            if (realtargettime <= 0.0f)
            {
                scrollspeed += realacceleration;
                fakespeed += acceleration;
                speedtext.text = "Speed:" + (-fakespeed).ToString() + "   Acceleration:" + acceleration.ToString()+"   Bool:" + hitfunction.ToString();
                acceleration += accelerationofacceleration;
                realacceleration = (1 / ((1 / realacceleration) - 0.1f));
                realtargettime = targettime;
            }
        }
        else
        {
            realstoptime -= Time.deltaTime;
            if (realstoptime <= 0.0f)
            {
                hitfunction = false;
                acceleration = spareacceleration;
                fakespeed = 1.33f * fakespeed;
                realacceleration = -1.0f;
            }

        }
        if (GameController.instance.hitornot == true)
        {
            acceleration = 0;
            spareacceleration = acceleration;
            fakespeed = fakespeed * 0.75f;
            realstoptime = stoptime;
            scrollspeed = 0.25f * scrollspeed;
            hitfunction = true;
            speedtext.text = "Speed:" + (-fakespeed).ToString() + "     Acceleration:" + acceleration.ToString();
        }
        rb2d.velocity = new Vector2(scrollspeed, 0);
        score += -((int) scrollspeed);
        print(score);
    }

}
