using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cacula : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
  
    }
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y < Camera.main.ScreenToWorldPoint(Vector3.zero).y - 15)
        {
            Destroy(this.gameObject);
        }
        

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("lodka"))
        {

            collision.transform.position += new Vector3(50, 0, 0);
        }
    }
}
