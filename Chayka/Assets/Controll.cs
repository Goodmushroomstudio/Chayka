﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controll : MonoBehaviour {

    Touch left, right;
    bool l, r;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount != 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                if (Input.touches[i].position.x < Screen.width / 2)
                {
                    left = Input.touches[i];
                    l = true;
                }
                else
                {
                    right = Input.touches[i];
                    r = true;
                }
            }
            if (l)
            {
                if (left.phase == TouchPhase.Began)
                {

                }

                else if (left.phase == TouchPhase.Ended)
                {
                    l = false;
                }
            }

            if (r)
            {
                transform.position = new Vector3(transform.position.x, Camera.main.ScreenToWorldPoint(right.position).y, transform.position.z);
                if (right.phase == TouchPhase.Began)
                {

                }

                else if (right.phase == TouchPhase.Ended)
                {
                    r = false;
                }
            }
        }
        
        if (Input.GetMouseButton(0))
        {
            transform.position = new Vector3(transform.position.x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, transform.position.z);
        }
        
    }
}
