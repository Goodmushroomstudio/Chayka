using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += new Vector3(0, 1) * Time.deltaTime;
        if (transform.position.y >= -3)
        {
            Destroy(this.gameObject);
        }
	}
}
