using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Mob : MonoBehaviour {
    public float hitCount;
    public float oldHit;
    public GameObject combo;
    public GameObject newcombo;
    public GameObject coinBonus;
    bool spawn;
    GameObject canvas;
    public GameObject splash;
    public bool b_splash;
    Vector3 comboPlace;
    Vector3 centrMass;
    public float f_alpha;
    public float f_time;
    public float f_reload;
    public int i_bonus;
    public bool bich;
    public bool ship;
    public float f_strength;
    public float hp;


    // Use this for initialization
    void Start () {
       
        centrMass = transform.position;
        canvas = GameObject.Find("WorldCanvas");
        comboPlace = GetComponent<SpriteRenderer>().bounds.max;
        f_alpha = 1;
        if (!bich)
        {
            for (int i = 0; i < transform.GetChild(transform.childCount - 1).childCount; i++)
            {
                transform.GetChild(transform.childCount - 1).GetChild(i).GetComponent<Anim>().f_interval = Random.Range(5, 10);
            }
        }

    }
	
	// Update is called once per frame
    void Update()
    {
        
        transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, centrMass.y, Time.deltaTime)) ;
        {
            if (!bich)
            {
                if (hitCount > oldHit)
                {
                    if (!GameData.gd.bMissions[7])
                    {
                        if (GameData.gd.currentMissions[0] == 7 || GameData.gd.currentMissions[1] == 7 || GameData.gd.currentMissions[2] == 7)
                        {
                            Missions.progress[7] = hitCount;
                            if (Missions.progress[7] >= Missions.f_m_missions[7, GameData.gd.missionRang])
                            {
                                GameData.gd.bMissions[7] = true;
                                SaveLoad.Save();
                                Debug.Log("Комбо");
                            }
                        }
                    }

                    
                    if (hitCount >= 5)
                    {
                        Combo();
                    }
                }

                
                if (spawn&&newcombo!=null)
                {
                    newcombo.GetComponent<Text>().color -= new Color(0, 0, 0, f_alpha) * Time.deltaTime;
                }
            }
        }
        if (hitCount > oldHit&&ship)
        {
            centrMass = transform.position - new Vector3(0, GameData.gd.massFecal[GameData.gd.massFecalLevel]);
            hp -= GameData.gd.massFecal[GameData.gd.massFecalLevel];
            if (!GameData.gd.bMissions[3] && ship && oldHit == 0)
            {
                if (GameData.gd.currentMissions[0] == 3 || GameData.gd.currentMissions[1] == 3 || GameData.gd.currentMissions[2] == 3)
                {
                    Missions.progress[3] += 1;
                    if (Missions.progress[3] >= Missions.f_m_missions[3, GameData.gd.missionRang])
                    {
                        GameData.gd.bMissions[3] = true;
                        SaveLoad.Save();
                        Debug.Log("Корабли засраны");
                    }
                }
            }

        }
        oldHit = hitCount;
        if(hp<=0 && ship)
        {
            transform.position -= new Vector3(0, 3) * Time.deltaTime;

            Splash();

            if(i_bonus>0 )
            { 
            f_time -= 1 * Time.deltaTime;
                if (f_time <= 0)
                {
                    f_time = f_reload;
                    i_bonus -= 1;
                    Instantiate(coinBonus, transform.position, Quaternion.identity);
                    GameData.gd.currentCoin += 1;

                }
            }
            
        }


    }
    
   public void Combo()
    {
        if (!spawn && !bich)
        {
            comboPlace = new Vector3(transform.position.x, comboPlace.y);
            newcombo = Instantiate(combo,comboPlace , Quaternion.identity,canvas.transform);
            spawn = true;
        }
        newcombo.GetComponent<Text>().text = "Combo X" + hitCount.ToString();
        newcombo.GetComponent<Text>().color = new Color32(255, 255, 0, 255);

        if (hitCount >= 5)
        {
            newcombo.GetComponent<Text>().rectTransform.localScale = new Vector3(transform.localScale.x + 0.5f, transform.localScale.y +0.5f);

        }

    }
    public void Splash()
    {
        if (!b_splash)
        {
            GameObject newSplash = Instantiate(splash, new Vector3(transform.position.x, -2.2f), Quaternion.identity);
			if (!GameData.gd.boss) 
			{
				newSplash.transform.localScale = gameObject.transform.localScale * 1.5f; 
			}
			if (GameData.gd.boss)
			{
				newSplash.transform.localScale = gameObject.transform.localScale * 2f;
				GetComponent<Animator> ().enabled = false;
			}
            b_splash = true;
            if (!GameData.gd.bMissions[5])
            {
                if (GameData.gd.currentMissions[0] == 5 || GameData.gd.currentMissions[1] == 5 || GameData.gd.currentMissions[2] == 5)
                {
                    Missions.progress[5]++;
                    Debug.Log("Потоплен");
                    if (Missions.progress[5] >= Missions.f_m_missions[5, GameData.gd.missionRang])
                    {
                        GameData.gd.bMissions[5] = true;
                        SaveLoad.Save();
                        Debug.Log("Корабли потоплены");
                    }
                }
            }
        }
    }



}
