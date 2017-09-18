using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour {

    public int layer;
    public float speed;
    float min, max;
    bool up;
    public bool move;
	// Use this for initialization
	void Start () {
        min = transform.position.y - 0.2f;
        max = transform.position.y + 0.2f;
	}
	
	// Update is called once per frame
	void Update () {
        if (move)
        {
            transform.position -= new Vector3(speed * GameData.gd.f_speed, 0, 0) * Time.deltaTime;

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
        }
        if (!move)
        {
            if (transform.position.x < Camera.main.ScreenToWorldPoint(Vector3.zero).x - 13)
            {
                transform.position += new Vector3(57.6f, 0, 0);
            }
        }
        else
        {
            if (transform.position.x < Camera.main.ScreenToWorldPoint(Vector3.zero).x - 13)
            {
                transform.localPosition += new Vector3(57.6f, 0, 0);
                transform.GetChild(0).position -= new Vector3(57.6f, 0, 0);
                transform.GetChild(1).position -= new Vector3(57.6f, 0, 0);
            }
        }
	}
}
