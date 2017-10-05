using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Mob : MonoBehaviour {
    public float hitCount;
    public float oldHit;
    public GameObject combo;
    public GameObject newcombo;
    bool spawn;
    GameObject canvas;
    Vector3 comboPlace;
    Vector3 centrMass;
    public float f_alpha;
    public bool bich;
    public bool ship;
    public float f_strength;
    public float hp;


    // Use this for initialization
    void Start () {
        if (ship)
        {
            hp = GetComponent<SpriteRenderer>().bounds.size.y;
        }
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
                if (hitCount > oldHit && hitCount > 5)
                {

                    Combo();

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
            if (GameData.gd.i_currentMission == 3 && GameData.gd.b_m_missions[GameData.gd.i_currentMission, GameData.gd.i_currentLvl])
            {
                GameData.gd.f_currentmissionResult++;

            }

        }
        oldHit = hitCount;
        if(hp<=0 && ship )
        {
            transform.position -= new Vector3(0, 3) * Time.deltaTime;
            if (GameData.gd.i_currentMission == 5 && GameData.gd.b_m_missions[GameData.gd.i_currentMission, GameData.gd.i_currentLvl])
            {
                GameData.gd.f_currentmissionResult++;

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



}
