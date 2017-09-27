using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cacula : MonoBehaviour {
    public GameObject shlep;
    public GameObject textMesh;
    public float massEffect;
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
