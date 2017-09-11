using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cacula : MonoBehaviour {


	void Start () {
  
    }
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y < Camera.main.ScreenToWorldPoint(Vector3.zero).y - 15)
        {
            Destroy(this.gameObject);
        }
        

    }
    
}
