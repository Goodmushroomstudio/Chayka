using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUi : MonoBehaviour {
    public GameObject menu;
	// Use this for initialization
	void Start () {
        menu.GetComponent<Animator>().Play("mainAnim");

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
