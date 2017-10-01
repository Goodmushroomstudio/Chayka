using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {
    public Text t_scoreText;
    public Text t_currentScoreText;
    public Text t_coinText;
    public Text t_currentCoinText;

    void Start () {
        
        
	}

    // Update is called once per frame
    void Update()
    {
        if(GameData.gd.death)
        {
            transform.GetChild(6).GetComponent<Animator>().Play("board");
        }
        SetCurrentScoreText();
    }
    void SetCurrentScoreText()
    {
            t_currentScoreText.text = GameData.gd.f_currentScore.ToString();
    }


    public void HpUp()
    {
        if(GameData.gd.hpLevel+1 <= GameData.gd.f_hp.Length)
        {
            GameData.gd.hpLevel++;
            transform.GetChild(6).GetChild(0).GetChild(1).GetComponent<Image>().fillAmount = (float)GameData.gd.hpLevel / 10;
            Debug.Log(GameData.gd.f_hp[GameData.gd.hpLevel] + " Level: " + GameData.gd.hpLevel);
            SaveLoad.Save();
        }
    }
    public void SpUp()
    {
        if (GameData.gd.spLevel + 1 < GameData.gd.f_sp.Length)
        {
            GameData.gd.spLevel += 1;
            transform.GetChild(6).GetChild(1).GetChild(0).GetComponent<Text>().text = GameData.gd.spLevel.ToString();
            SaveLoad.Save();
        }
    }

    public void MassUp()
    {
        if (GameData.gd.massFecalLevel + 1 < GameData.gd.massFecal.Length)
        {
            GameData.gd.massFecalLevel += 1;
            transform.GetChild(6).GetChild(2).GetChild(0).GetComponent<Text>().text = GameData.gd.massFecalLevel.ToString();
            SaveLoad.Save();
        }
    }

    public void HealUp()
    {
        if (GameData.gd.jeludokLevel + 1 < GameData.gd.jeludok.Length)
        {
            GameData.gd.jeludokLevel += 1;
            transform.GetChild(6).GetChild(3).GetChild(0).GetComponent<Text>().text = GameData.gd.jeludokLevel.ToString();
            SaveLoad.Save();
        }
    }

    public void ArmorUp()
    {
        if (GameData.gd.armorLevel + 1 < GameData.gd.armor.Length)
        {
            GameData.gd.armorLevel += 1;
            transform.GetChild(6).GetChild(4).GetChild(0).GetComponent<Text>().text = GameData.gd.armorLevel.ToString();
            SaveLoad.Save();
        }
    }

    public void SpeedUp()
    {
        if (GameData.gd.birdSpeedLevel + 1 < GameData.gd.birdSpeed.Length)
        {
            GameData.gd.birdSpeedLevel += 1;
            transform.GetChild(6).GetChild(5).GetChild(0).GetComponent<Text>().text = GameData.gd.birdSpeedLevel.ToString();
            SaveLoad.Save();
        }
    }

    public void KishkaUp()
    {
        if (GameData.gd.kishechnikLevel + 1 < GameData.gd.kishechnik.Length)
        {
            GameData.gd.kishechnikLevel += 1;
            transform.GetChild(6).GetChild(6).GetChild(0).GetComponent<Text>().text = GameData.gd.kishechnikLevel.ToString();
            SaveLoad.Save();
        }
    }

    public void ReloadUp()
    {
        if (GameData.gd.fecalReloadLevel + 1 < GameData.gd.fecalReload.Length)
        {
            GameData.gd.fecalReloadLevel += 1;
            transform.GetChild(6).GetChild(7).GetChild(0).GetComponent<Text>().text = GameData.gd.fecalReloadLevel.ToString();
            SaveLoad.Save();
        }
    }

    public void ManeurUp()
    {
        if (GameData.gd.maneurLevel + 1 < GameData.gd.maneur.Length)
        {
            GameData.gd.maneurLevel += 1;
            transform.GetChild(6).GetChild(8).GetChild(0).GetComponent<Text>().text = GameData.gd.maneurLevel.ToString();
            SaveLoad.Save();
        }
    }
    public void CurrentCoinText()
    {
        t_currentCoinText.text = GameData.gd.currentCoin.ToString();
    }
    public void CoinText()
    {
        t_coinText.text = GameData.gd.coin.ToString();
    }
    
}

