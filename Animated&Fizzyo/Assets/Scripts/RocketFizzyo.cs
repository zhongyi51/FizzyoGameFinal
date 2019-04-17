using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fizzyo;


public class RocketFyzzo : MonoBehaviour {
        public float breathtime = 1.0f;
        public Text breathshow;
        public float unbreakabletime = 2.0f;
        private bool timeup = false;
        private Rigidbody2D rocket;
        private bool up = false;
        private Vector2 velocity = new Vector2(0, 160);
        private float timer;
        private bool isbreathing;
        private Collider2D c;
        private float unbreakable;
        private Animator anim;
        FizzyoDevice fd = new FizzyoDevice();


    // Use this for initialization
    void Start()
        {
            c = GetComponent<Collider2D>();
            rocket = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
            timer = 0.0f;
            unbreakable = 0.0f;
            FizzyoFramework.Instance.Recogniser.BreathStarted += OnBreathStarted;
            FizzyoFramework.Instance.Recogniser.BreathComplete += OnBreathEnded;
    }

        // Update is called once per frame
    void Update()
        {   

            if (timeup == false)
            {
                if (fd.ButtonDown())
                {
                    if (up == true)
                    {
                        rocket.MovePosition(rocket.position + velocity * Time.fixedDeltaTime);
                        up = false;
                    }
                    else
                    {
                        rocket.MovePosition(rocket.position - velocity * Time.fixedDeltaTime);
                        up = true;
                    }
                }
                /*if (c.enabled == true)
                {
                    if (Input.GetMouseButton(1))
                    {
                        timer += Time.deltaTime;
                        breathshow.text = "breathing";
                        isbreathing = true;
                    }
                    else if (isbreathing == true)
                    {
                        if (timer - breathtime < 0.2f && timer - breathtime > -0.2f)
                        {
                            breathshow.text = "Good breath!";
                            c.enabled = false;
                        }
                        else
                        {
                            breathshow.text = "Try again!";
                        }
                        isbreathing = false;
                        timer = 0.0f;
                    }
                }
                else
                {
                    breathshow.text = "Turbo Mode!";
                    anim.SetTrigger("Boost");
                    unbreakable += Time.deltaTime;
                    if (unbreakable >= unbreakabletime)
                    {
                        c.enabled = true;
                        breathshow.text = "Turbo over";
                        unbreakable = 0.0f;
                        anim.SetTrigger("BoostOver");
                    }
                }*/
            }
        }

    void OnCollisionEnter2D()
        {
            anim.SetTrigger("Blink");
        }

    void OnBreathStarted(object sender)
    {
        Debug.Log("Breath started");
    }


    void OnBreathEnded(object sender, ExhalationCompleteEventArgs e)
    {
        if (timeup == false)
        {
            if (c.enabled == true)
            {
                if (e.BreathQuality >= 2)
                {
                    breathshow.text = "Good breath!";
                    c.enabled = false;
                }
                else
                {
                    breathshow.text = "Try again!";
                }
            }
            else
            {
                breathshow.text = "Turbo Mode!";
                anim.SetTrigger("Boost");
                unbreakable += Time.deltaTime;
                if (unbreakable >= unbreakabletime)
                {
                    c.enabled = true;
                    breathshow.text = "Turbo over";
                    unbreakable = 0.0f;
                    anim.SetTrigger("BoostOver");
                }
            }
        }
    }
}