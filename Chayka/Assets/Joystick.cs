using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick : MonoBehaviour {
    float f_startPoint,f_endPoint,f_resultPoint;
    
	void Start () {
        f_startPoint = 0;
        f_endPoint = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
        {
            f_startPoint = GetWorldPositionOnPlane(Input.mousePosition, transform.position.z).y;


        }
        if (Input.GetMouseButton(0))
        {
            f_endPoint= GetWorldPositionOnPlane(Input.mousePosition, transform.position.z).y;
            f_resultPoint = f_endPoint - f_startPoint;
        }
        else
        {
            f_resultPoint -= 0.03f * f_resultPoint;
        }
        
        transform.position += new Vector3(0, f_resultPoint, 0)*-1;
        transform.localPosition = new Vector3(transform.localPosition.x, Mathf.Clamp(transform.localPosition.y, -150, 150), transform.localPosition.z);

        GameData.gd.f_axisY = this.transform.localPosition.y;
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

