using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreControl : MonoBehaviour {
     float f_speed;
     float f_alpha;
	// Use this for initialization
	void Start () {
        f_speed = 5;
        f_alpha = 1;
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.position += new Vector3(0, f_speed)*Time.deltaTime;
        GetComponent<Text>().color -= new Color(0, 0, 0, f_alpha)*Time.deltaTime;
        if(GetComponent<Text>().color.a <= 0)
        {
            Destroy(this.gameObject);
        }

	}
}
