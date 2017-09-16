using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFixed : MonoBehaviour {

    public float speed;
	// Use this for initialization
	void Start () {
        
	}

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position -= new Vector3(speed, 0, 0) * Time.fixedDeltaTime;
        if (transform.position.x < Camera.main.ScreenToWorldPoint(Vector3.zero).x - 15)
        {
            Destroy(this.gameObject);
        }
    }
}
