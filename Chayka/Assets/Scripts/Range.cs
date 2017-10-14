using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Range : MonoBehaviour {
    public Vector3 v1pos;
    public Vector3 v2pos;
    public Vector3 v3pos;

    public float speed;
	// Use this for initialization
	void Start () {
        v1pos = transform.GetChild(0).position;
        v2pos = transform.GetChild(1).position;
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position -= new Vector3(speed * GameData.gd.f_speed, 0, 0) * Time.deltaTime;
        if (transform.GetChild(1).position.x <= v1pos.x)
        {
            transform.GetChild(0).position = v2pos;
            transform.GetChild(0).SetAsLastSibling();
        }
    }
}
