using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Messages : MonoBehaviour {

    private float first;
    private float second;
    private float third;
    private float fourth;
    private float fifth;

    private bool firstDone = false;
    private bool secondDone = false;
    private bool thirdDone = false;
    private bool fourthDone = false;
    private bool fifthDone = false;

    public float messageTime = 5f;
    private float startTime;
    private float iniTime;
    public float cycleTime;

    public GameObject marsMessage;
    public GameObject jupMessage;
    public GameObject satMessage;
    public GameObject urMessage;
    public GameObject nepMessage;




    // Use this for initialization
    void Start () {
        first = Planetrun.marsTime;
        second = Planetrun.jupTime;
        marsMessage = GameObject.FindGameObjectWithTag("marsText");
        jupMessage = GameObject.FindGameObjectWithTag("jupText");
        StartCoroutine(EnableMars());
        StartCoroutine(EnableJupiter());

    }

    // Update is called once per frame
    void Update () {
    }

    IEnumerator EnableMars()
    {
        yield return new WaitForSeconds(first);
        marsMessage.GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(5);
        marsMessage.GetComponent<SpriteRenderer>().enabled = false;
    }
    IEnumerator EnableJupiter()
    {
        yield return new WaitForSeconds(second);
        jupMessage.GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(5);
        jupMessage.GetComponent<SpriteRenderer>().enabled = false;
    }
    IEnumerator EnableSaturn()
    {
        yield return new WaitForSeconds(third);
        satMessage.GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(5);
        satMessage.GetComponent<SpriteRenderer>().enabled = false;
    }
    IEnumerator EnableUranus()
    {
        yield return new WaitForSeconds(fourth);
        urMessage.GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(5);
        urMessage.GetComponent<SpriteRenderer>().enabled = false;
    }
    IEnumerator EnableNeptune()
    {
        yield return new WaitForSeconds(fifth);
        nepMessage.GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(5);
        nepMessage.GetComponent<SpriteRenderer>().enabled = false;
    }


}
