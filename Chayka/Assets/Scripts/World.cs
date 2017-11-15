using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class World : MonoBehaviour {
    public GameObject cloud;
    public GameObject fish;
    public GameObject coin;
    public GameObject backGround;
    public GameObject line;
    public GameObject[] ships;
    bool[] shipsUnique;
    public GameObject bich;
    public Sprite[] cloudSprites;
    public GameObject textPrefab;
    [Range(0,100)]

    public float f_speed;
    public float cloudChanse;
    public float fishChanse;
    public float lineChanse;
    public float f_timerBackGround;
    public float f_reloadBacground;
    public float f_timerShips;
    public float f_reloadships;
    public float f_timerCoin;
    public float f_reloadCoin;
    float range;
    [Range(0, 50000)]
    public int randomChanse;
    public int coinChanse;
    int schetchik;
    public Sprite[] back;
    GameObject canvas;

    void Awake()
    {
        SaveLoad.Load();
        if (GameData.gd.currentMissions == null)
        {
            Missions.RandomMission();
            SaveLoad.Save();
        }
        else
        {
            int c = 0;
            for (int i = 0; i < GameData.gd.bMissions.Length; i++)
            {
                if (GameData.gd.bMissions[i])
                    c++;
            }
            if (c == 3)
            {
                int a = 0;
                for (int i = 0; i < 3; i++)
                {
                    if (GameData.gd.bMissions[GameData.gd.currentMissions[i]])
                    {
                        a++;
                    }
                    if (a == 3)
                    {
                        Missions.RandomMission();
                        SaveLoad.Save();
                    }
                }

                
            }
            else if (c == 6)
            {
                int a = 0;
                for (int i = 0; i < 3; i++)
                {
                    if (GameData.gd.bMissions[GameData.gd.currentMissions[i]])
                    {
                        a++;
                    }
                    if (a == 3)
                    {
                        Missions.RandomMission();
                        SaveLoad.Save();
                    }
                }
            }
            else if (c == 9 && !GameData.gd.unique)
            {
                GameData.gd.unique = true;
                Missions.UniqueMission();
            }
        }
        GameData.gd.death = false;
        GameData.gd.f_currenthp = GameData.gd.f_hp[GameData.gd.hpLevel];
        GameData.gd.f_currentsp = GameData.gd.f_sp[GameData.gd.spLevel];
        GameData.gd.f_currentScore = 0;
        GameData.gd.f_magnY = 0;
        GameData.gd.f_speed = 1;
        GameData.gd.f_range = 0;
        GameData.gd.currentCoin = 0;
        GameData.gd.f_currentmissionResult = 0;
        GameData.gd.hit = false;
        Missions.progress = new List<float>() { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        if (GameData.gd.coinBuster)
        {
            f_reloadCoin = 1.5f;
            GameData.gd.coinBuster = false;
        }
        else
        {
            f_reloadCoin = 3;
        }
        if (GameData.gd.fishBuster)
        {
            fishChanse = 2;
            GameData.gd.fishBuster = false;
        }
        else
        {
            fishChanse = 1;
        }
    }

    // Use this for initialization
    void Start () {
        f_timerBackGround = f_reloadBacground;
        f_timerShips = f_reloadships;
        GameData.gd.f_speed = f_speed;
        CloudGeneration();
        canvas = GameObject.Find("Canvas");
        range = 0;
        shipsUnique = new bool[9];
        CheckUniqueShipMission();
	}

    // Update is called once per frame
    void Update()
    {
        range -= 3 * GameData.gd.f_speed * Time.deltaTime;
        GameData.gd.f_range += 3 * GameData.gd.f_speed * Time.deltaTime;
        if (!GameData.gd.bMissions[2])
        {
            if (GameData.gd.currentMissions[0] == 2 || GameData.gd.currentMissions[1] == 2 || GameData.gd.currentMissions[2] == 2)
            {
                Missions.progress[2] = GameData.gd.f_range;
                if (Missions.progress[2] >= Missions.f_m_missions[2, GameData.gd.missionRang])
                {
                    GameData.gd.bMissions[2] = true;
                    SaveLoad.Save();
                    Debug.Log("Расстояние пройдено");
                }
            }
        }
        if (!GameData.gd.bMissions[6])
        {
            if (GameData.gd.currentMissions[0] == 6 || GameData.gd.currentMissions[1] == 6 || GameData.gd.currentMissions[2] == 6)
            {
                Missions.progress[6] = GameData.gd.f_currentScore;
                if (Missions.progress[6] >= Missions.f_m_missions[6, GameData.gd.missionRang])
                {
                    GameData.gd.bMissions[6] = true;
                    SaveLoad.Save();
                    Debug.Log("Очки набраны");
                }
            }
        }
        if (!GameData.gd.bMissions[8])
        {
            if (GameData.gd.currentMissions[0] == 8 || GameData.gd.currentMissions[1] == 8 || GameData.gd.currentMissions[2] == 8)
            {
                if (!GameData.gd.hit)
                {
                    Missions.progress[8] = GameData.gd.f_range;
                }
                if (Missions.progress[8] >= Missions.f_m_missions[8, GameData.gd.missionRang])
                {
                    GameData.gd.bMissions[8] = true;
                    SaveLoad.Save();
                    Debug.Log("Расстояние без повреждений пройдено");
                }
            }
        }


        if (range <= 0)
        {
            range = 10 - Mathf.Abs(range);
            GameObject txtRange = Instantiate(textPrefab,  canvas.transform.GetChild(1).transform);
            txtRange.GetComponent<Text>().text = Mathf.CeilToInt(GameData.gd.f_range-0.5f +10).ToString() + "m";
        }
        if (GameData.gd.f_speed != 0)
        {
            if (Chanse(cloudChanse))
            {
                CloudGeneration();
            }
            if (Chanse(fishChanse))
            {
                FishGeneration();
            }
            f_timerCoin -= 1 * Time.deltaTime;
            if (f_timerCoin <= 0)
            {
                CoinGeneration();
                f_timerCoin = f_reloadCoin;

            }

            if (GameData.gd.f_speed > 2 && Chanse(lineChanse))
            {
                LineGeneration();
            }

            f_timerBackGround -= 1 * Time.deltaTime;
            if (f_timerBackGround <= 0)
            {
                BackGroundGeneration();
                f_reloadBacground = Random.Range(3, 10);
                f_timerBackGround = f_reloadBacground;
            }
            f_timerShips -= 1 * Time.deltaTime;
            if (f_timerShips <= 0 && !GameData.gd.bichGenered)
            {
                ShipsGeheration();
                f_reloadships = Random.Range(3, 5);
                f_timerShips = f_reloadships;
            }
            if (GameData.gd.f_range >= schetchik * 500)
            {
                schetchik++;
                GameData.gd.bichGenered = true;
                BichGeneration();
                
            }
        }

    }
    public void CloudGeneration()
    {
        Vector3 coord = new Vector3(Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height)).x + 10, Random.Range(1f, 5), 0);
        GameObject newCloud = Instantiate(cloud, coord, Quaternion.identity, transform);
        int r = Random.Range(0, 3);
        switch (r)
        { 
            case 0:
                newCloud.GetComponent<SpriteRenderer>().sortingOrder = -5;
                newCloud.GetComponent<Move>().speed = 2.5f;
                newCloud.GetComponent<SpriteRenderer>().sprite = cloudSprites[Random.Range(5, 8)];
                return;
            case 1:
                newCloud.GetComponent<SpriteRenderer>().sortingOrder = -10;
                newCloud.GetComponent<Move>().speed = 1.5f;
                newCloud.GetComponent<SpriteRenderer>().sprite = cloudSprites[Random.Range(3, 5)];
                return;
            case 2:
                newCloud.GetComponent<SpriteRenderer>().sortingOrder = -15;
                newCloud.GetComponent<Move>().speed = 0.5f;
                newCloud.GetComponent<SpriteRenderer>().sprite = cloudSprites[Random.Range(0, 3)];
                return;
        }
    }

    public void FishGeneration()
    {
        Vector3 coord = new Vector3(Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,0)).x+10,-5);
        Instantiate(fish, coord, Quaternion.identity, transform);
        
    }
    public void CoinGeneration()
    {
        Vector3 coord = new Vector3(Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height)).x + 10, Random.Range(-1, 6.5f), 0);
        GameObject newCoin = Instantiate(coin, coord, Quaternion.identity, transform);
        newCoin.GetComponent<Move>().speed = Random.Range(3, 7);
    }
    public void BackGroundGeneration()
    {
        Vector3 coord = new Vector3(Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height)).x + 10, -4.3f);
        GameObject newBackround = Instantiate(backGround, coord, Quaternion.identity, transform);
        newBackround.GetComponent<SpriteRenderer>().sprite = back[Random.Range(0, 4)];
    }
    public void ShipsGeheration()
    {
        Vector3 coord = new Vector3(Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height)).x + 5, -3.2f);
        if (GameData.gd.f_range > 0 && GameData.gd.f_range<200)
        {
            int r = Random.Range(0, 3);
            Instantiate(ships[r], coord, Quaternion.identity, transform);
            shipsUnique[r] = true;
            
        }
        else if (GameData.gd.f_range>200 && GameData.gd.f_range < 1000)
        {
            int r = Random.Range(0, 5);
            Instantiate(ships[r], coord, Quaternion.identity, transform);
            shipsUnique[r] = true;
        }
        else if(GameData.gd.f_range > 1000 && GameData.gd.f_range < 1500)
        {
            int r = Random.Range(0, 7);
            Instantiate(ships[r], coord, Quaternion.identity, transform);
            shipsUnique[r] = true;
        }
        else if (GameData.gd.f_range > 1500 && GameData.gd.f_range < 2000)
        {
            int r = Random.Range(0, ships.Length);
            Instantiate(ships[r], coord, Quaternion.identity, transform);
            shipsUnique[r] = true;
        }
        CheckUniqueShipMission();
        
        
    }

    public void LineGeneration()
    {
        Vector3 coord = new Vector3(Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height)).x + 10, Random.Range(-3,5));
        Instantiate(line, coord,Quaternion.identity);
    }
    public void BichGeneration()
    {
        Vector3 coord = new Vector3(Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height)).x + 10, -2.8f);
        Instantiate(bich, coord, Quaternion.identity, transform);
    }

    public bool Chanse(float c)
    {
        int r = Random.Range(0, randomChanse);
        if (r <= c)
            return true;
        else
            return false;
    }

    void CheckUniqueShipMission()
    {
        if (GameData.gd.unique && GameData.gd.uniqueRang == 0)
        {
            int c = 0;
            for (int i = 0; i < shipsUnique.Length; i++)
            {
                if (shipsUnique[i])
                {
                    c++;
                    
                }
                Debug.Log(c.ToString() + " count; " + i.ToString() + " i;" + shipsUnique[i].ToString());
            }
            GameData.gd.uniqueShipsCurrent = c;
            if (c == shipsUnique.Length)
            {
                GameData.gd.unique = false;
                GameData.gd.uniqueRang = 1;
                GameData.gd.missionRang++;
                GameData.gd.bMissions = new bool[9];
                for (int i = 0; i < GameData.gd.f_m_missions.GetLength(0); i++)
                {
                    GameData.gd.missionsLeft.Add(i);
                }
                Missions.RandomMission();
                SaveLoad.Save();
            }
        }
    }


}
