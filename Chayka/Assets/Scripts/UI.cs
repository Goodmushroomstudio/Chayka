using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {
    public Text t_scoreText;
	
	void Start () {
        
        
	}

    // Update is called once per frame
    void Update()
    {
        if(GameData.gd.death)
        {
            transform.GetChild(6).GetComponent<Animator>().Play("board");
        }
        SetScoreText();
    }
    void SetScoreText()
    {
            t_scoreText.text = GameData.gd.f_score.ToString();
    }

    public void HpUp()
    {
        if(GameData.gd.hpLevel+1 < GameData.gd.f_hp.Length)
        {
            GameData.gd.hpLevel += 1;
            transform.GetChild(6).GetChild(0).GetChild(0).GetComponent<Text>().text = GameData.gd.hpLevel.ToString();
        }
    }
    public void SpUp()
    {
        if (GameData.gd.spLevel + 1 < GameData.gd.f_sp.Length)
        {
            GameData.gd.spLevel += 1;
            transform.GetChild(6).GetChild(1).GetChild(0).GetComponent<Text>().text = GameData.gd.spLevel.ToString();
        }
    }

    public void MassUp()
    {
        if (GameData.gd.massFecalLevel + 1 < GameData.gd.massFecal.Length)
        {
            GameData.gd.massFecalLevel += 1;
            transform.GetChild(6).GetChild(2).GetChild(0).GetComponent<Text>().text = GameData.gd.massFecalLevel.ToString();
        }
    }
    
}

