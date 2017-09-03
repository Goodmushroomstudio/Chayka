using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controll : MonoBehaviour
{

    Touch left, right;
    float focusPoint;
    bool l, r;
    float currentPosition, deltaPositon, lastPositon;
    float magn;

    // Use this for initialization
    void Start()
    {
        focusPoint = 0;
        magn = 0;
    }

    // Update is called once per frame
    void Update()
    {
        currentPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
        deltaPositon = currentPosition - lastPositon;
        lastPositon = currentPosition;
        if (Input.touchCount != 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                if (Input.touches[i].position.x < Screen.width / 2)
                {
                    left = Input.touches[i];
                    l = true;
                }
                else
                {
                    right = Input.touches[i];
                    r = true;
                }
            }
            if (l)
            {
                if (left.phase == TouchPhase.Began)
                {

                }

                else if (left.phase == TouchPhase.Ended)
                {
                    l = false;
                }
            }

            if (r)
            {
                // transform.position = new Vector3(transform.position.x, GetWorldPositionOnPlane(right.position, transform.position.z).y, transform.position.z);
                if (right.phase == TouchPhase.Began)
                {

                }

                else if (right.phase == TouchPhase.Ended)
                {
                    r = false;
                }
            }
        }
        magn = focusPoint - transform.position.y;
        if (Input.GetMouseButton(0))
        {
            if (deltaPositon != 0)
            {
                focusPoint += deltaPositon;
                focusPoint = Mathf.Clamp(focusPoint, -3.5f, 3.5f);
            }
        }

        transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, focusPoint, 0.01f), transform.position.z);
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3.5f, 3.5f), transform.position.z);
        transform.rotation = new Quaternion(0, 0, GameData.gd.f_axisY * -(Mathf.Abs(magn * 8)), 100f);

        transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y,focusPoint,0.03f),transform.position.z);
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3.5f, 3.5f), transform.position.z);
        transform.rotation = new Quaternion(0, 0, GameData.gd.f_axisY * -(Mathf.Abs(magn*8)), 100f);

        if (magn < -1)
        {
            GetComponent<Anim>().i_currentFrame = 6;
        }



        if (magn > 2)
        {
            GetComponent<Anim>().f_maxTime /= (magn/2);
        }
        else
        {
            GetComponent<Anim>().f_maxTime = 0.1f;
        }

    }

}