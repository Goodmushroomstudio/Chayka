using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour {
    public float f_reload;
    public float f_timer;

	// Use this for initialization
	void Start () {
        f_timer = f_reload;
	}
	
	// Update is called once per frame
	void Update () {
        f_timer -= 1 * Time.deltaTime;
        if (f_timer <= 0)
        {
            transform.GetChild(0).GetComponent<Animation>().Play("Boom");
            f_timer = f_reload;
        }
		
	}
}
