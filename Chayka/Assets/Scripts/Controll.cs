using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;

public class Controll : MonoBehaviour
{

    Touch left, right;
    bool l, r;
    Vector3 currentPosition, deltaPositon, lastPositon, f_focusPoint;
    public GameObject cacula;
    public GameObject coinOff;
    public GameObject bang;
    public Sprite[] puzo;
    float screenExt;
    float timer;
    float movement;
    bool anal;

    // Use this for initialization
    void Start()
    {
        GameData.gd.massFecalLevel = 9;
        GameData.gd.fecalReloadLevel = 9;
        GameData.gd.f_currenthp = GameData.gd.f_hp[GameData.gd.hpLevel];
        GameData.gd.f_currentsp = GameData.gd.f_sp[GameData.gd.spLevel];
        //GameData.gd.f_currenthp = 0.01f;
        f_focusPoint = new Vector3(-6, 0, 0);
        screenExt = Screen.width / Screen.height;

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
                        r = false;
                    }
                    if (Input.touches[i].position.x >= Screen.width/2)
                    {
                        right = Input.touches[i];
                        r = true;
                        l = false;
                    }
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

                if (GameData.gd.f_currentsp > 0.03f && timer == 0)
                {
                    Pocaculki();
                }
            }

            if (r)
            {
                // transform.position = new Vector3(transform.position.x, GetWorldPositionOnPlane(right.position, transform.position.z).y, transform.position.z);
                if (right.phase == TouchPhase.Began)
                {
                    if (deltaPositon.x < 0.1 && deltaPositon.y < 0.1)
                    {
                        f_focusPoint += new Vector3(2, 0, 0);
                        GameData.gd.f_speed += 0.5f;
                    }
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
                    f_focusPoint += new Vector3(0, deltaPositon.y);
                    f_focusPoint = new Vector3(f_focusPoint.x, Mathf.Clamp(f_focusPoint.y, -3.5f, 8.5f));
                    if (deltaPositon.x < 0)
                    {
                        f_focusPoint += new Vector3(deltaPositon.x, 0);
                    }
                }
            }
        }
        if (GameData.gd.f_currentsp >= 0 && GameData.gd.f_currentsp < 0.2f)
        {
            GetComponent<SpriteRenderer>().sprite = puzo[0];
            movement = 0.04f + GameData.gd.maneur[GameData.gd.maneurLevel]; ;
        }
        else if (GameData.gd.f_currentsp >= 0.2f && GameData.gd.f_currentsp < 0.4f)
        {
            GetComponent<SpriteRenderer>().sprite = puzo[1];
            movement = 0.035f + GameData.gd.maneur[GameData.gd.maneurLevel]; ;
        }
        else if (GameData.gd.f_currentsp >= 0.4f && GameData.gd.f_currentsp < 0.6f)
        {
            GetComponent<SpriteRenderer>().sprite = puzo[2];
            movement = 0.03f + GameData.gd.maneur[GameData.gd.maneurLevel]; ;
        }
        else if (GameData.gd.f_currentsp >= 0.6f && GameData.gd.f_currentsp < 0.75f)
        {
            GetComponent<SpriteRenderer>().sprite = puzo[3];
            movement = 0.02f + GameData.gd.maneur[GameData.gd.maneurLevel]; ;
        }
        else if (GameData.gd.f_currentsp >= 0.75f && GameData.gd.f_currentsp < 3f)
        {
            GetComponent<SpriteRenderer>().sprite = puzo[4];
            movement = 0.01f + GameData.gd.maneur[GameData.gd.maneurLevel];
        }
        timer -= 1 * Time.deltaTime;
        timer = Mathf.Clamp(timer, 0, GameData.gd.fecalReload[GameData.gd.fecalReloadLevel]);
        GameData.gd.f_magnY = f_focusPoint.y - transform.position.y;
        GameData.gd.f_magnX = f_focusPoint.x - transform.position.x;
        GameData.gd.f_speed -= 1f*Time.deltaTime;
        GameData.gd.f_speed = Mathf.Clamp(GameData.gd.f_speed, 1, GameData.gd.birdSpeed[GameData.gd.birdSpeedLevel]);
        transform.position = new Vector3(Mathf.Lerp(transform.position.x, f_focusPoint.x, movement), Mathf.Lerp(transform.position.y, f_focusPoint.y, movement), transform.position.z);
        //transform.position = new Vector3(Mathf.Clamp(transform.position.x, Camera.main.ScreenToWorldPoint(new Vector3(0, 0)).x + 2, 0f), Mathf.Clamp(transform.position.y, -3.5f, 8.5f), transform.position.z);
        transform.rotation = new Quaternion(0, 0, GameData.gd.f_axisY * -(Mathf.Abs(GameData.gd.f_magnY * 8)), 100f);
        Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, Camera.main.orthographicSize+transform.position.y, Time.deltaTime*2);
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, 5, 8);
        Camera.main.transform.position = new Vector3(Mathf.Lerp(Camera.main.transform.position.x, (Camera.main.orthographicSize*screenExt - 5), Time.deltaTime * 10), Mathf.Lerp(Camera.main.transform.position.y, (Camera.main.orthographicSize - 5), Time.deltaTime * 2));
        Camera.main.transform.position = new Vector3(Mathf.Clamp(Camera.main.transform.position.x, 0, 3*screenExt), Mathf.Clamp(Camera.main.transform.position.y, 0, 3), -10);

        if (GameData.gd.f_magnY < -1)
        {
            transform.GetChild(0).GetComponent<Anim>().i_currentFrame = 0;
            transform.GetChild(1).GetComponent<Anim>().i_currentFrame = 0;
        }

        if (GameData.gd.f_magnY > 1)
        {
            transform.GetChild(0).GetComponent<Anim>().f_maxTime /= (GameData.gd.f_magnY / 2);
            transform.GetChild(1).GetComponent<Anim>().f_maxTime /= (GameData.gd.f_magnY / 2);
        }
        if (GameData.gd.f_magnX > 1)
        {
            transform.GetChild(0).GetComponent<Anim>().f_maxTime = 0.05f;
            transform.GetChild(1).GetComponent<Anim>().f_maxTime = 0.05f;
        }

        if (GameData.gd.f_speed>1f)
        {
            transform.GetChild(0).GetComponent<Anim>().f_maxTime = 0.05f;
            transform.GetChild(1).GetComponent<Anim>().f_maxTime = 0.05f;
        }
        else
        {
            transform.GetChild(0).GetComponent<Anim>().f_maxTime = 0.1f;
            transform.GetChild(1).GetComponent<Anim>().f_maxTime = 0.1f;

        }

#if UNITY_EDITOR
        if (Input.GetMouseButton(1) && GameData.gd.f_currentsp > 0.03f && timer == 0)
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
                f_focusPoint += new Vector3(0, deltaPositon.y);
                f_focusPoint = new Vector3(f_focusPoint.x, Mathf.Clamp(f_focusPoint.y, -3.5f, 8.5f));
                if (deltaPositon.x < 0)
                {
                    f_focusPoint += new Vector3(deltaPositon.x, 0);
                }
            }
        }
        if(Input.GetMouseButtonDown(0))
        {
            if (deltaPositon.x < 0.1 && deltaPositon.y < 0.1)
            {
                f_focusPoint += new Vector3(2, 0, 0);
                GameData.gd.f_speed += 0.3f;
            }
        }


#endif
        f_focusPoint -= new Vector3(4, 0, 0) * Time.deltaTime;
        f_focusPoint = new Vector3(Mathf.Clamp(f_focusPoint.x, Camera.main.ScreenToWorldPoint(new Vector3(0, 0)).x + 2, -1), f_focusPoint.y);

        if (GameData.gd.f_currenthp <= 0)
        {
            DieMotherFuckerDie();
        }


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
        GameData.gd.f_currentsp -= 0.03f;
        timer = GameData.gd.fecalReload[GameData.gd.fecalReloadLevel];
        GameObject clone = Instantiate(cacula, new Vector3(transform.position.x, transform.position.y - 0.3f), Quaternion.identity);
        //cacula.transform.position = new Vector3(transform.position.x, transform.position.y * f_speed * Time.deltaTime, 0);
    }
    public void Bang()
    {
        transform.GetChild(1).GetComponent<Anim>().enabled = true;
        transform.GetChild(1).GetComponent<Anim>().i_currentFrame = 0;
        transform.GetChild(0).GetComponent<Anim>().enabled = true;
        transform.GetChild(0).GetComponent<Anim>().i_currentFrame = 0;
        Instantiate(bang, transform.position, Quaternion.identity);
    }
    public void DieMotherFuckerDie()
    {
        SaveLoad.Save();
        GetComponent<SpriteRenderer>().enabled = false;
        transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = false;
        GameData.gd.f_speed = 0;
        transform.GetChild(0).GetComponent<BoxCollider2D>().enabled = false;
        this.gameObject.SetActive(false);
    }




}