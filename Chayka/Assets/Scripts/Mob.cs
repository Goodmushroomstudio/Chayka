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
    public float f_alpha;

	// Use this for initialization
	void Start () {
        canvas = GameObject.Find("WorldCanvas");
        comboPlace = GetComponent<SpriteRenderer>().bounds.max;
        f_alpha = 1;
        for (int i = 0; i < transform.GetChild(transform.childCount - 1).childCount; i++)
        {
            transform.GetChild(transform.childCount - 1).GetChild(i).GetComponent<Anim>().f_interval = Random.Range(5, 10);
        }

    }
	
	// Update is called once per frame
	void Update () {
        if (hitCount > oldHit && hitCount>5)
        {

            Combo();
            
        }

        oldHit = hitCount;
        if (spawn)
        {
            newcombo.GetComponent<Text>().color -= new Color(0, 0, 0, f_alpha) * Time.deltaTime; 
        }

        
    }
    
   public void Combo()
    {
        if (!spawn)
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
