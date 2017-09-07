using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    GameObject player;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("07");
	}
	
	// Update is called once per frame
	void Update () {
        Quaternion newRotation = Quaternion.LookRotation(transform.position - player.transform.position, Vector3.forward);
        newRotation.x = 0;
        newRotation.y = 0;
        transform.localRotation = Quaternion.Slerp(transform.localRotation, newRotation, Time.deltaTime * 100);
	}
}
