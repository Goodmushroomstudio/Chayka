using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {
    public GameObject cacula;
    // Use this for initialization
    void Start() {

    }
    void Pocaculki()
    {
        GameData.gd.f_currentsp -= 0.1f;
        GameObject clone = Instantiate(cacula, transform.position, transform.rotation);
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(1))
        {
            Pocaculki();
            
        }
	}
}
