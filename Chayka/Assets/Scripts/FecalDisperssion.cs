using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FecalDisperssion : MonoBehaviour {
    public GameObject[] kakashki;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter2D(Collision2D collision)


    {
        if (collision.gameObject.CompareTag("kak"))
        {

            Instantiate(kakashki[Random.Range(0, kakashki.Length)], collision.contacts[0].point, Quaternion.identity, transform);
            Destroy(collision.gameObject);
           
        }
    }
}
