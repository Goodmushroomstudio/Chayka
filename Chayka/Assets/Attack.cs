using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {
    public GameObject cacula;
    public float f_speed;
    // Use this for initialization
    void Start() {
        
    }
    void Pocaculki()
    {
        GameData.gd.f_currentsp -= 0.1f;
        GameObject clone = Instantiate(cacula,transform.position, transform.rotation);
        cacula.transform.position = new Vector3(transform.position.x, transform.position.y * f_speed * Time.deltaTime, 0);
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(1))
        {
            Pocaculki();
            
        }
	}
}
