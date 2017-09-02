using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick : MonoBehaviour {
    float currentPosition, deltaPositon, lastPositon;


	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        currentPosition = Input.mousePosition.y;
        deltaPositon = currentPosition - lastPositon;
        lastPositon = currentPosition;
        if (Input.GetMouseButton(0))
        {
            if (deltaPositon != 0)
            {
                transform.position -= new Vector3(0, deltaPositon, 0);
                transform.localPosition = new Vector3(transform.localPosition.x, Mathf.Clamp(transform.localPosition.y, -240, 240), transform.localPosition.z);
            }
        }
        GameData.gd.f_axisY = transform.localPosition.y / 240;
	}
    
    public Vector3 GetWorldPositionOnPlane(Vector3 screenPosition, float z)
    {
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);
        Plane xy = new Plane(Vector3.forward, new Vector3(0, 0, z));
        float distance;
        xy.Raycast(ray, out distance);
        return ray.GetPoint(distance);
    }
    
}

