using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missions : MonoBehaviour {
	// Use this for initialization
	void Start () {
        for (int i = 0; i < GameData.gd.b_m_missions.GetLength(0); i++)
        {
            if (!GameData.gd.b_m_missions[i, GameData.gd.i_currentLvl])
            {
                GameData.gd.i_currentMission = i;
                i = GameData.gd.b_m_missions.GetLength(0);
            }
        }

    }
	
	// Update is called once per frame
	void Update () {

	}
}
