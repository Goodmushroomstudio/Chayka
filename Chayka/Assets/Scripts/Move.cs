﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {
    public float speed;
	// Use this for initialization
	void Start () {
        
	}

    // Update is called once per frame
    void Update() {
        Moves();

	}
    public void Moves()
    {
        transform.position -= new Vector3(speed * GameData.gd.f_speed, 0, 0) * Time.deltaTime;
        if (transform.position.x < Camera.main.ScreenToWorldPoint(Vector3.zero).x - 15 || transform.position.y < Camera.main.ScreenToWorldPoint(Vector3.zero).y - 15)
        {
            Destroy(this.gameObject);
        }
    }
}
