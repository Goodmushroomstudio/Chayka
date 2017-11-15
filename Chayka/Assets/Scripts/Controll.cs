using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;

public class Controll : MonoBehaviour
{

    Touch left, right;
    bool l, r;
    Vector3 currentPosition, deltaPositon, lastPositon;
    public Vector3 f_focusPoint;
    public GameObject cacula;
    public GameObject coinOff;
    public GameObject bang;
    public Sprite[] puzo;
    float minX;
    float maxX;
    float screenExt;
    float timer;
    float movement;
    float tapTimer;
    bool anal;

    // Use this for initialization
    void Start()
    {
        GameData.gd.f_currenthp = GameData.gd.f_hp[GameData.gd.hpLevel];
        f_focusPoint = new Vector3(-4, 0, 0);
        screenExt = (float)Screen.width / (float)Screen.height;
        if (GameData.gd.magnerBuster)
        {
            transform.GetChild(3).GetComponent<PointEffector2D>().enabled = true;
            GameData.gd.magnerBuster = false;
        }
        else
        {
            transform.GetChild(3).GetComponent<PointEffector2D>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameData.gd.death)
        {
            if (Input.touchCount != 0)
            {
                float touchMaxX = 0;
                for (int i = 0; i < Input.touchCount; i++)
                {
                    if (Input.touches[i].position.x > touchMaxX)
                    {
                        right = Input.touches[i];
                        touchMaxX = Input.touches[i].position.x;
                        r = true;
                    }
                }
            }

            if (r)
            {
                // transform.position = new Vector3(transform.position.x, GetWorldPositionOnPlane(right.position, transform.position.z).y, transform.position.z);
                if (right.phase == TouchPhase.Began)
                {
                    Tap();
                    deltaPositon = Vector3.zero;
                    lastPositon = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    GameData.gd.f_lastPosition = right.position.y;
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
                    if (Vector3.Magnitude(deltaPositon) > 3)
                    {
                        deltaPositon = Vector3.zero;
                    }
                    f_focusPoint += new Vector3(0, deltaPositon.y);
                    f_focusPoint = new Vector3(f_focusPoint.x, Mathf.Clamp(f_focusPoint.y, -3.5f, 7.5f));
                    if (deltaPositon.x != 0)
                    {
                        f_focusPoint += new Vector3(deltaPositon.x, 0);
                    }
                }
            }
            if (GameData.gd.fireButton && GameData.gd.f_currentsp > 0.20f && timer == 0)
            {
                Pocaculki();
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
            movement = 0.037f + GameData.gd.maneur[GameData.gd.maneurLevel]; ;
        }
        else if (GameData.gd.f_currentsp >= 0.4f && GameData.gd.f_currentsp < 0.6f)
        {
            GetComponent<SpriteRenderer>().sprite = puzo[2];
            movement = 0.035f + GameData.gd.maneur[GameData.gd.maneurLevel]; ;
        }
        else if (GameData.gd.f_currentsp >= 0.6f && GameData.gd.f_currentsp < 0.75f)
        {
            GetComponent<SpriteRenderer>().sprite = puzo[3];
            movement = 0.032f + GameData.gd.maneur[GameData.gd.maneurLevel]; ;
        }
        else if (GameData.gd.f_currentsp >= 0.75f && GameData.gd.f_currentsp < 3f)
        {
            GetComponent<SpriteRenderer>().sprite = puzo[4];
            movement = 0.03f + GameData.gd.maneur[GameData.gd.maneurLevel];
        }
        tapTimer -= 1 * Time.deltaTime;
        tapTimer = Mathf.Clamp(tapTimer, 0, 0.3f);
        timer -= 1 * Time.deltaTime;
        timer = Mathf.Clamp(timer, 0, GameData.gd.fecalReload[GameData.gd.fecalReloadLevel]);
        minX = Camera.main.ScreenToWorldPoint(new Vector3(0, 0)).x + 2*screenExt;
        maxX = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 4 * 3 , 0)).x;
        GameData.gd.f_magnY = f_focusPoint.y - transform.position.y;
        GameData.gd.f_magnX = f_focusPoint.x - transform.position.x;
        GameData.gd.f_speed -= 1f*Time.deltaTime;
        GameData.gd.f_speed = Mathf.Clamp(GameData.gd.f_speed, 1, GameData.gd.birdSpeed[GameData.gd.birdSpeedLevel]);
        transform.position = new Vector3(Mathf.Lerp(transform.position.x, f_focusPoint.x, movement), Mathf.Lerp(transform.position.y, f_focusPoint.y, movement), transform.position.z);
        //transform.position = new Vector3(Mathf.Clamp(transform.position.x, Camera.main.ScreenToWorldPoint(new Vector3(0, 0)).x + 2, 0f), Mathf.Clamp(transform.position.y, -3.5f, 8.5f), transform.position.z);
        transform.rotation = new Quaternion(0, 0, (f_focusPoint.y - transform.position.y)*5, 100f);
        Camera.main.orthographicSize += (f_focusPoint.y - transform.position.y)/2 * Time.deltaTime;
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, 5, 8);
        Camera.main.transform.position = new Vector3( (Camera.main.orthographicSize-5)*screenExt ,Camera.main.orthographicSize - 5);
        Camera.main.transform.position = new Vector3(Mathf.Clamp(Camera.main.transform.position.x, 0, 3*screenExt), Mathf.Clamp(Camera.main.transform.position.y, 0, 3), -10);


        if (f_focusPoint.y - transform.position.y > 0.8f)
        {
            transform.GetChild(0).GetComponent<Anim>().f_maxTime = 0.05f;
            transform.GetChild(1).GetComponent<Anim>().f_maxTime = 0.05f;
        }
        else if (f_focusPoint.x - transform.position.x > 0.8f)
        {
            transform.GetChild(0).GetComponent<Anim>().f_maxTime = 0.04f;
            transform.GetChild(1).GetComponent<Anim>().f_maxTime = 0.04f;
        }
        else if (f_focusPoint.y - transform.position.y < -0.8f)
        {
            transform.GetChild(0).GetComponent<Anim>().i_currentFrame = 0;
            transform.GetChild(1).GetComponent<Anim>().i_currentFrame = 0;
        }
        else if (GameData.gd.f_speed > 1f)
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
        if (Input.GetMouseButton(1) && GameData.gd.f_currentsp > 0.20f && timer == 0)
        {
            Pocaculki();
        }
        if(Input.GetMouseButtonDown(0))
        {
            deltaPositon = Vector3.zero;
            lastPositon = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, lastPositon.y);
            Tap();
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
                f_focusPoint = new Vector3(f_focusPoint.x, Mathf.Clamp(f_focusPoint.y, -3.5f, 7.5f));
                if (deltaPositon.x != 0)
                {
                    f_focusPoint += new Vector3(deltaPositon.x, 0);
                }
            }
        }

        


#endif
        if (f_focusPoint.x > minX)
        {
            f_focusPoint -= new Vector3(4, 0, 0) * Time.deltaTime;
        }
        else
        {
            f_focusPoint += new Vector3(4, 0, 0) * Time.deltaTime;
        }
        
        f_focusPoint = new Vector3(Mathf.Clamp(f_focusPoint.x, Camera.main.ScreenToWorldPoint(new Vector3(0, 0)).x, maxX), f_focusPoint.y);

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
            GameData.gd.f_currentScore += 10;
            if (!GameData.gd.bMissions[0])
            {
                if (GameData.gd.currentMissions[0] == 0 || GameData.gd.currentMissions[1] == 0 || GameData.gd.currentMissions[2] == 0)
                {
                    Missions.progress[0] += 1;
                    Debug.Log("Монетка");
                    if (Missions.progress[0] >= Missions.f_m_missions[0, GameData.gd.missionRang])
                    {
                        GameData.gd.bMissions[0] = true;
                        SaveLoad.Save();
                        Debug.Log("Сбор монет закончен");
                    }
                }
            }
        }
    }
    void Pocaculki()
    {
        GameData.gd.f_currentsp -= 0.20f;
        timer = GameData.gd.fecalReload[GameData.gd.fecalReloadLevel];
        Instantiate(cacula, new Vector3(transform.position.x, transform.position.y - 0.3f), Quaternion.identity);
        //cacula.transform.position = new Vector3(transform.position.x, transform.position.y * f_speed * Time.deltaTime, 0);
    }
    public void Bang()
    {
        transform.GetChild(1).GetComponent<Anim>().enabled = true;
        transform.GetChild(1).GetComponent<Anim>().i_currentFrame = 0;
        transform.GetChild(0).GetComponent<Anim>().enabled = true;
        transform.GetChild(0).GetComponent<Anim>().i_currentFrame = 0;
        Instantiate(bang, transform.position, Quaternion.identity);
        f_focusPoint += new Vector3(-2, 0);
    }
    public void DieMotherFuckerDie()
    {
        SaveLoad.Save();
        GetComponent<SpriteRenderer>().enabled = false;
        transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = false;
        GameData.gd.f_speed = 0;
        this.gameObject.SetActive(false);
    }

    public void FireButton()
    {
        GameData.gd.fireButton = true;
    }

    public void FireButtonOff()
    {
        GameData.gd.fireButton = false;
    }

    public void Tap()
    {
        if (tapTimer > 0 && !GameData.gd.fireButton)
        {
            GameData.gd.f_speed += 0.4f;
            f_focusPoint += new Vector3(2f, 0);
        }
        tapTimer += 0.3f;
    }

}