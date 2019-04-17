using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour {

    private BoxCollider2D groundcollider;
    private float groundhorizantallength;

	// Use this for initialization
	void Start () {
        groundcollider = GetComponent<BoxCollider2D>();
        groundhorizantallength = groundcollider.size.x;
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x < -groundhorizantallength)
        {
            RepositionBackground();
        }
	}

    private void RepositionBackground()
    {
        Vector2 groundoffset = new Vector2(groundhorizantallength * 2f, 0);
        transform.position = (Vector2)transform.position + groundoffset;
    }
}
