﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpMp : MonoBehaviour
{


    public Image img_hp;
    public Image img_sp;
    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        //убывание хп
        GameData.gd.f_currenthp = Mathf.Clamp(GameData.gd.f_currenthp, 0, 1);
        float f_scalexhp = GameData.gd.f_currenthp / GameData.gd.f_hp[GameData.gd.i_currentChar];
        img_hp.GetComponent<Image>().fillAmount = f_scalexhp;
        if (f_scalexhp<=0)
        {
            GameData.gd.death = true;
        }
        //убывание сп
        GameData.gd.f_currentsp = Mathf.Clamp(GameData.gd.f_currentsp, 0, 1);
        float f_scalesp = GameData.gd.f_currentsp / GameData.gd.f_sp[GameData.gd.i_currentChar];

        img_sp.GetComponent<Image>().fillAmount = f_scalesp; 
        GameData.gd.f_currenthp -=0.01f *GameData.gd.f_speed * Time.deltaTime;






    }
}
