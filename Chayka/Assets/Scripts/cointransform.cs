using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cointransform : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height-50)), Time.deltaTime * 4);
        if (transform.position.x > Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - 100, Screen.height-100)).x)
        {
            GameData.gd.currentCoin++;
            Destroy(gameObject);
        }
        //transform.position+= Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height))*Time.deltaTime*2;
    }
}
