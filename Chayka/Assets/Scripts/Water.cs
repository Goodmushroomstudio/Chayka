using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour {

    public float speed;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
    void Update()
    {

        transform.position -= new Vector3(speed * GameData.gd.f_speed, 0, 0) * Time.deltaTime;


        if (transform.position.x < Camera.main.ScreenToWorldPoint(Vector3.zero).x - 13)
        {
            transform.position += new Vector3(GetComponent<SpriteRenderer>().bounds.size.x*9, 0, 0);
        }

    }
}
