using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public bool core;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y < Camera.main.ScreenToWorldPoint(Vector3.zero).y)
        {
            Destroy(this.gameObject);
        }
        if (!core)
        {
            Quaternion newRotation = Quaternion.LookRotation(transform.GetChild(0).localPosition - new Vector3(GetComponent<Rigidbody2D>().velocity.x - 5, GetComponent<Rigidbody2D>().velocity.y, 0), Vector3.forward);
            newRotation.x = 0;
            newRotation.y = 0;
            transform.GetChild(0).rotation = Quaternion.Slerp(transform.GetChild(0).rotation, newRotation, Time.deltaTime * 100);
        }
	}
    void OnTriggerEnter2D(Collider2D collision)
    { 
        if(collision.gameObject.CompareTag("facebird"))
        {
            GameData.gd.f_currenthp -= 0.15f*GameData.gd.armor[GameData.gd.armorLevel];
            collision.GetComponent<Controll>().Bang();
            Destroy(this.gameObject);
            GameData.gd.hit = true;
        }
    }
}
