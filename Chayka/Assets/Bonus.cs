﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour {
    public GameObject coinOff;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.position += new Vector3(0, 1, 0)*Time.deltaTime*10;
        if (transform.position.y >= 0)
        {
            Destroy(this.gameObject);
            Instantiate(coinOff, transform.position, Quaternion.identity);
        }
    }
}
