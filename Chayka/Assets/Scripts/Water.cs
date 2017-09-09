using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour {

    public int layer;
    public float speed;
    float min, max;
    bool up;
	// Use this for initialization
	void Start () {
        min = transform.position.y - 0.2f;
        max = transform.position.y + 0.2f;
        switch (layer)
        { 
            case 1:
                GetComponent<SpriteRenderer>().sortingOrder = 7;
                return;
            case 2:
                GetComponent<SpriteRenderer>().sortingOrder = -1;
                return;
            case 3:
                GetComponent<SpriteRenderer>().sortingOrder = -2;
                return;
        }
	}
	
	// Update is called once per frame
	void Update () {
        transform.position -= new Vector3(speed, 0, 0) * Time.deltaTime;

        if (transform.position.y < max && up)
        {
            transform.position += new Vector3(0, speed / 5, 0) * Time.deltaTime;
            if (transform.position.y > max)
                up = false;
        }
        else if (transform.position.y > min && !up)
        {
            transform.position -= new Vector3(0, speed / 5, 0) * Time.deltaTime;
            if (transform.position.y < min)
                up = true;
        }
        if (transform.position.x < Camera.main.ScreenToWorldPoint(Vector3.zero).x - 10)
        {
            transform.position += new Vector3(38.4f, 0, 0);
        }
	}
}
