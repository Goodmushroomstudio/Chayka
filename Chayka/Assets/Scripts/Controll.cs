using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controll : MonoBehaviour
{

    Touch left, right;
    bool l, r;
    Vector3 currentPosition, deltaPositon, lastPositon;
    public GameObject cacula;
    public GameObject coinOff;
    public GameObject bang;
    bool anal;

    // Use this for initialization
    void Start()
    {
        GameData.gd.death = false;
        GameData.gd.f_focusPoint = new Vector3(-6, 0, 0);
        GameData.gd.f_magnY = 0;
        GameData.gd.f_speed = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameData.gd.death)
        {
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
            }
            if (l)
            {
                if (left.phase == TouchPhase.Began)
                {
                    Pocaculki();
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
                    GameData.gd.f_focusPoint += new Vector3(2, 0, 0);
                }

                else if (right.phase == TouchPhase.Ended)
                {
                    r = false;
                }
                GameData.gd.f_currentPosition = right.position.y;
                currentPosition = Camera.main.ScreenToWorldPoint(right.position);
                deltaPositon = currentPosition - lastPositon;
                lastPositon = currentPosition;
                if (deltaPositon != Vector3.zero)
                {
                    GameData.gd.f_focusPoint += deltaPositon;
                    GameData.gd.f_focusPoint = new Vector3(GameData.gd.f_focusPoint.x, Mathf.Clamp(GameData.gd.f_focusPoint.y, -3.5f, 8.5f));
                }
                if (transform.position.x > -2)
                {
                    GameData.gd.f_speed += 0.5f;
                }
            }
        }
        GameData.gd.f_magnY = GameData.gd.f_focusPoint.y - transform.position.y;
        GameData.gd.f_magnX = GameData.gd.f_focusPoint.x - transform.position.x;
        GameData.gd.f_speed -= 1f*Time.deltaTime;
        GameData.gd.f_speed = Mathf.Clamp(GameData.gd.f_speed, 1, 2.5f);
        transform.position = new Vector3(Mathf.Lerp(transform.position.x, GameData.gd.f_focusPoint.x, 0.03f), Mathf.Lerp(transform.position.y, GameData.gd.f_focusPoint.y, 0.03f), transform.position.z);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, Camera.main.ScreenToWorldPoint(new Vector3(0, 0)).x + 2, 0f), Mathf.Clamp(transform.position.y, -3.5f, 8.5f), transform.position.z);
        transform.rotation = new Quaternion(0, 0, GameData.gd.f_axisY * -(Mathf.Abs(GameData.gd.f_magnY * 8)), 100f);
        Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, Camera.main.orthographicSize + (transform.position.y / 2), Time.deltaTime);
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, 5, 8);
        Camera.main.transform.position = new Vector3(0, Mathf.Lerp(Camera.main.transform.position.y, transform.position.y/2, Time.deltaTime));
        Camera.main.transform.position = new Vector3(0, Mathf.Clamp(Camera.main.transform.position.y, 0, 3), -10);

        if (GameData.gd.f_magnY < -1)
        {
            GetComponent<Anim>().i_currentFrame = 6;
        }

        if (GameData.gd.f_magnY > 1)
        {
            GetComponent<Anim>().f_maxTime /= (GameData.gd.f_magnY / 2);
        }
        if (GameData.gd.f_magnX > 1)
        {
            GetComponent<Anim>().f_maxTime = 0.05f;
        }

        if (GameData.gd.f_speed>1f)
        {
            GetComponent<Anim>().f_maxTime = 0.05f;
        }
        else
        {
            GetComponent<Anim>().f_maxTime = 0.1f;
        }

#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(1))
        {
            Pocaculki();
        }
        if(Input.GetMouseButton(0))
        {
            GameData.gd.f_currentPosition = Input.mousePosition.y;
            currentPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            deltaPositon = currentPosition - lastPositon;
            lastPositon = currentPosition;
            if (deltaPositon != Vector3.zero)
            {
                GameData.gd.f_focusPoint += deltaPositon;
                GameData.gd.f_focusPoint = new Vector3(GameData.gd.f_focusPoint.x, Mathf.Clamp(GameData.gd.f_focusPoint.y, -3.5f, 8.5f));
            }
        }
        if(Input.GetMouseButtonDown(0))
        {
            GameData.gd.f_focusPoint += new Vector3(2, 0, 0);
            if (transform.position.x > -2)
            {
                GameData.gd.f_speed += 0.5f;
            }

        }


#endif
        GameData.gd.f_focusPoint -= new Vector3(4, 0, 0) * Time.deltaTime;
        GameData.gd.f_focusPoint = new Vector3(Mathf.Clamp(GameData.gd.f_focusPoint.x, Camera.main.ScreenToWorldPoint(new Vector3(0, 0)).x + 2, -1), GameData.gd.f_focusPoint.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("coin"))
        {
            Destroy(collision.gameObject);
            Instantiate(coinOff,collision.transform.position,Quaternion.identity);
            GameData.gd.f_score += 10;
        }
    }
    void Pocaculki()
    {
        GameData.gd.f_currentsp -= 0.1f;
        GameObject clone = Instantiate(cacula, new Vector3(transform.position.x, transform.position.y - 0.3f), Quaternion.identity);
        //cacula.transform.position = new Vector3(transform.position.x, transform.position.y * f_speed * Time.deltaTime, 0);
    }
    public void Bang()
    {
        transform.GetChild(1).GetComponent<Anim>().enabled = true;
        transform.GetChild(1).GetComponent<Anim>().i_currentFrame = 0;
        Instantiate(bang, transform.position, Quaternion.identity);

    }
    public void DieMotherFuckerDie()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = false;
        GameData.gd.f_speed = 0;
        transform.GetChild(1).GetComponent<BoxCollider2D>().enabled = false;
    }




}