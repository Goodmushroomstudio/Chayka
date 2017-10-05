using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missions : MonoBehaviour {
	// Use this for initialization
	void Start () {
        for (int i = 0; i < GameData.gd.f_m_missions.Length; i++)
        {
            if (GameData.gd.b_m_missions[i, GameData.gd.i_currentLvl])
            {
                GameData.gd.i_currentMission = i;
            }
        }

    }
	
	// Update is called once per frame
	void Update () {
        if (GameData.gd.f_currentmissionResult >= GameData.gd.f_m_missions[GameData.gd.i_currentMission, GameData.gd.i_currentLvl])
        {
            Debug.Log("Mission Done");
            GameData.gd.b_m_missions[GameData.gd.i_currentMission, GameData.gd.i_currentLvl] = true;
        }
	}
}
