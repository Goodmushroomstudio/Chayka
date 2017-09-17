using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick : MonoBehaviour {


	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        GameData.gd.f_deltaPosition = GameData.gd.f_currentPosition - GameData.gd.f_lastPosition;
        GameData.gd.f_lastPosition = GameData.gd.f_currentPosition;
        if (GameData.gd.f_deltaPosition != 0)
        {
            transform.position -= new Vector3(0, GameData.gd.f_deltaPosition, 0);
            transform.localPosition = new Vector3(transform.localPosition.x, Mathf.Clamp(transform.localPosition.y, -240, 240), transform.localPosition.z);
        }
        GameData.gd.f_axisY = transform.localPosition.y / 240;
	}
    
}

