using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Magnit : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("col");
        if (collision.gameObject.CompareTag("coin"))
        {
            
            collision.gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }
    }

    

}
