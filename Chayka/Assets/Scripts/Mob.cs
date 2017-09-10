using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour {

    public float f_value;
 


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
            
            Instantiate(collision.gameObject.GetComponent<Cacula>().kaki[Random.Range(0, collision.gameObject.GetComponent<Cacula>().kaki.Length)], collision.contacts[0].point, Quaternion.identity, transform);
            Destroy(collision.gameObject);
            GameData.gd.f_score += f_value;
        }
    }
}
