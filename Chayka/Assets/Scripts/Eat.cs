﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eat : MonoBehaviour
{
    public float f_impulse;
    bool inJump;
    private Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        f_impulse = Random.Range(5, 15);
    }

    void Update()
    {
        if (transform.position.y < -5)
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(new Vector2(0, f_impulse), ForceMode2D.Impulse);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!inJump)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.AddForce(new Vector2(0, f_impulse), ForceMode2D.Impulse);
            inJump = true;
        }
        if (inJump)
        {
            Quaternion newRotation = Quaternion.LookRotation(transform.GetChild(0).localPosition - new Vector3(GetComponent<Rigidbody2D>().velocity.x - 5, GetComponent<Rigidbody2D>().velocity.y,0), Vector3.forward);
            newRotation.x = 0;
            newRotation.y = 0;
            transform.GetChild(0).rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.fixedDeltaTime * 100);
            if (transform.position.y < Camera.main.ScreenToWorldPoint(Vector3.zero).y - 15)
            {
                Destroy(this.gameObject);
            }
        }




    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("facebird"))
        {
            GameData.gd.f_currentsp += 0.1f;
            GameData.gd.f_currenthp += 0.05f;
            Destroy(this.gameObject);
        }
        
            
        
    }


}
