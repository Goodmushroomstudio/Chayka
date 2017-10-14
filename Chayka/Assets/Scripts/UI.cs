using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour {
    public Text t_scoreText;
    public Text t_currentScoreText;
    public Text t_coinText;
    public Text t_currentCoinText;
    int oldCoin;
    public int childPanel;

    void Start()
    {
        oldCoin = 0;
        transform.GetChild(childPanel).GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>().fillAmount = (float)GameData.gd.hpLevel / 10;
        transform.GetChild(childPanel).GetChild(0).GetChild(1).GetChild(0).GetComponent<Image>().fillAmount = (float)GameData.gd.spLevel / 10;
        transform.GetChild(childPanel).GetChild(0).GetChild(2).GetChild(0).GetComponent<Image>().fillAmount = (float)GameData.gd.massFecalLevel / 10;
        transform.GetChild(childPanel).GetChild(0).GetChild(3).GetChild(0).GetComponent<Image>().fillAmount = (float)GameData.gd.jeludokLevel / 10;
        transform.GetChild(childPanel).GetChild(0).GetChild(4).GetChild(0).GetComponent<Image>().fillAmount = (float)GameData.gd.armorLevel / 10;
        transform.GetChild(childPanel).GetChild(0).GetChild(5).GetChild(0).GetComponent<Image>().fillAmount = (float)GameData.gd.birdSpeedLevel / 10;
        transform.GetChild(childPanel).GetChild(0).GetChild(6).GetChild(0).GetComponent<Image>().fillAmount = (float)GameData.gd.kishechnikLevel / 10;
        transform.GetChild(childPanel).GetChild(0).GetChild(7).GetChild(0).GetComponent<Image>().fillAmount = (float)GameData.gd.fecalReloadLevel / 10;
        transform.GetChild(childPanel).GetChild(0).GetChild(8).GetChild(0).GetComponent<Image>().fillAmount = (float)GameData.gd.maneurLevel / 10;
        for (int i = 0; i < 3; i++)
        {
            transform.GetChild(childPanel).GetChild(7).GetChild(i).GetComponent<Text>().text = Missions.missionHead[GameData.gd.currentMissions[i]] + Missions.f_m_missions[GameData.gd.currentMissions[i], Missions.missionRang] + Missions.missionBody[GameData.gd.currentMissions[i]];
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }

        if(GameData.gd.death)
        {
            transform.GetChild(childPanel).GetComponent<Animator>().Play("board");
        }
        SetCurrentScoreText();
        CurrentCoinText();
        CoinText();

        if (GameData.gd.f_currentmissionResult >= GameData.gd.f_m_missions[GameData.gd.i_currentMission, GameData.gd.i_currentMissionLvl] && !GameData.gd.b_m_missions[GameData.gd.i_currentMission, GameData.gd.i_currentMissionLvl])
        {
            MissionLabel("Миссия выполнена!!!");
            GameData.gd.b_m_missions[GameData.gd.i_currentMission, GameData.gd.i_currentMissionLvl] = true;
            SaveLoad.Save();
        }
        if(GameData.gd.currentCoin>oldCoin)
        {
            GameData.gd.coin++;
            oldCoin++;
        }
    }
    void SetCurrentScoreText()
    {
            t_currentScoreText.text = GameData.gd.f_currentScore.ToString();
    }


    public void HpUp()
    {
        if (GameData.gd.hpLevel + 1 < GameData.gd.f_hp.Length && GameData.gd.coin >= 5 * (GameData.gd.hpLevel + 1))
        {
            GameData.gd.coin -= 5 * (GameData.gd.hpLevel + 1);
            GameData.gd.hpLevel++;
            transform.GetChild(childPanel).GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>().fillAmount = (float)GameData.gd.hpLevel / 10;
            SaveLoad.Save();
        }
    }
    public void SpUp()
    {
        if (GameData.gd.spLevel + 1 < GameData.gd.f_sp.Length && GameData.gd.coin >= 5 * (GameData.gd.spLevel + 1))
        {
            GameData.gd.coin -= 5 * (GameData.gd.spLevel + 1);
            GameData.gd.spLevel += 1;
            transform.GetChild(childPanel).GetChild(0).GetChild(1).GetChild(0).GetComponent<Image>().fillAmount = (float)GameData.gd.spLevel / 10;
            SaveLoad.Save();
        }
    }

    public void MassUp()
    {
        if (GameData.gd.massFecalLevel + 1 < GameData.gd.massFecal.Length && GameData.gd.coin >= 5 * (GameData.gd.massFecalLevel + 1))
        {
            GameData.gd.coin -= 5 * (GameData.gd.massFecalLevel + 1);
            GameData.gd.massFecalLevel += 1;
            transform.GetChild(childPanel).GetChild(0).GetChild(5).GetChild(0).GetComponent<Image>().fillAmount = (float)GameData.gd.massFecalLevel / 10;
            SaveLoad.Save();
        }
    }

    public void HealUp()
    {
        if (GameData.gd.jeludokLevel + 1 < GameData.gd.jeludok.Length && GameData.gd.coin >= 5 * (GameData.gd.jeludokLevel + 1))
        {
            GameData.gd.coin -= 5 * (GameData.gd.jeludokLevel + 1);
            GameData.gd.jeludokLevel += 1;
            transform.GetChild(childPanel).GetChild(0).GetChild(3).GetChild(0).GetComponent<Image>().fillAmount = (float)GameData.gd.jeludokLevel / 10;
            SaveLoad.Save();
        }
    }

    public void ArmorUp()
    {
        if (GameData.gd.armorLevel + 1 < GameData.gd.armor.Length && GameData.gd.coin >= 5 * (GameData.gd.armorLevel + 1))
        {
            GameData.gd.coin -= 5 * (GameData.gd.armorLevel + 1);
            GameData.gd.armorLevel += 1;
            transform.GetChild(childPanel).GetChild(0).GetChild(2).GetChild(0).GetComponent<Image>().fillAmount = (float)GameData.gd.armorLevel / 10;
            SaveLoad.Save();
        }
    }

    public void SpeedUp()
    {
        if (GameData.gd.birdSpeedLevel + 1 < GameData.gd.birdSpeed.Length && GameData.gd.coin >= 5 * (GameData.gd.birdSpeedLevel + 1))
        {
            GameData.gd.coin -= 5 * (GameData.gd.birdSpeedLevel + 1);
            GameData.gd.birdSpeedLevel += 1;
            transform.GetChild(childPanel).GetChild(0).GetChild(6).GetChild(0).GetComponent<Image>().fillAmount = (float)GameData.gd.birdSpeedLevel / 10;
            SaveLoad.Save();
        }
    }

    public void KishkaUp()
    {
        if (GameData.gd.kishechnikLevel + 1 < GameData.gd.kishechnik.Length && GameData.gd.coin >= 5 * (GameData.gd.kishechnikLevel + 1))
        {
            GameData.gd.coin -= 5 * (GameData.gd.kishechnikLevel + 1);
            GameData.gd.kishechnikLevel += 1;
            transform.GetChild(childPanel).GetChild(0).GetChild(4).GetChild(0).GetComponent<Image>().fillAmount = (float)GameData.gd.kishechnikLevel / 10;
            SaveLoad.Save();
        }
    }

    public void ReloadUp()
    {
        if (GameData.gd.fecalReloadLevel + 1 < GameData.gd.fecalReload.Length && GameData.gd.coin >= 5 * (GameData.gd.fecalReloadLevel + 1))
        {
            GameData.gd.coin -= 5 * (GameData.gd.fecalReloadLevel + 1);
            GameData.gd.fecalReloadLevel += 1;
            transform.GetChild(childPanel).GetChild(0).GetChild(8).GetChild(0).GetComponent<Image>().fillAmount = (float)GameData.gd.fecalReloadLevel / 10;
            SaveLoad.Save();
        }
    }

    public void ManeurUp()
    {
        if (GameData.gd.maneurLevel + 1 < GameData.gd.maneur.Length && GameData.gd.coin >= 5 * (GameData.gd.maneurLevel + 1))
        {
            GameData.gd.coin -= 5 * (GameData.gd.maneurLevel + 1);
            GameData.gd.maneurLevel += 1;
            transform.GetChild(childPanel).GetChild(0).GetChild(7).GetChild(0).GetComponent<Image>().fillAmount = (float)GameData.gd.maneurLevel / 10;
            SaveLoad.Save();
        }
    }

    public void SetCoinBuster()
    {
        if (GameData.gd.coinBuster)
        {
            GameData.gd.coinBuster = false;
            transform.GetChild(childPanel).GetChild(4).GetComponent<Outline>().enabled = false;
        }
        else
        {
            GameData.gd.coinBuster = true;
            transform.GetChild(childPanel).GetChild(4).GetComponent<Outline>().enabled = true;
        }
    }

    public void SetFishBuster()
    {
        if (GameData.gd.fishBuster)
        {
            GameData.gd.fishBuster = false;
            transform.GetChild(childPanel).GetChild(3).GetComponent<Outline>().enabled = false;
        }
        else
        {
            GameData.gd.fishBuster = true;
            transform.GetChild(childPanel).GetChild(3).GetComponent<Outline>().enabled = true;
        }
    }

    public void SetMagnetBuster()
    {
        if (GameData.gd.magnerBuster)
        {
            GameData.gd.magnerBuster = false;
            transform.GetChild(childPanel).GetChild(5).GetComponent<Outline>().enabled = false;
        }
        else
        {
            GameData.gd.magnerBuster = true;
            transform.GetChild(childPanel).GetChild(5).GetComponent<Outline>().enabled = true;
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

    public void MissionLabel(string l)
    {
        transform.GetChild(5).GetChild(0).GetComponent<Text>().text = l;
        transform.GetChild(5).GetComponent<Animator>().Play("label");
    }
    
}

