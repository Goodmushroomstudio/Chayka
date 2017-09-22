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
    float range;
    [Range(0, 50000)]
    public int randomChanse;
    public int coinChanse;
    public Sprite[] back;
    GameObject canvas;
    


    // Use this for initialization
    void Start () {
        f_timerBackGround = f_reloadBacground;
        f_timerShips = f_reloadships;
        GameData.gd.f_speed = f_speed;
        CloudGeneration();
        canvas = GameObject.Find("Canvas");
        range = 10;
	}

    // Update is called once per frame
    void Update()
    {
        range -= 3 * GameData.gd.f_speed * Time.deltaTime;
        GameData.gd.f_range += 3 * GameData.gd.f_speed * Time.deltaTime;
        if (range <= 0)
        {
            range = 10 - Mathf.Abs(range);
            GameObject txtRange = Instantiate(textPrefab,  canvas.transform.GetChild(0).transform);
            txtRange.GetComponent<Text>().text = Mathf.CeilToInt(GameData.gd.f_range-0.5f).ToString() + "m";
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
            if (Chanse(coinChanse))
            {
                CoinGeneration();
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
            if (f_timerShips <= 0)
            {
                ShipsGeheration();
                f_reloadships = Random.Range(3, 5);
                f_timerShips = f_reloadships;
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
        Vector3 coord = new Vector3(Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,0)).x+10,Random.Range(-7,-5));
        GameObject newFish = Instantiate(fish, coord, Quaternion.identity, transform);
        newFish.GetComponent<Eat>().f_timer = Random.Range(5, 8);
        
    }
    public void CoinGeneration()
    {
        Vector3 coord = new Vector3(Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height)).x + 10, Random.Range(-1, 3.2f), 0);
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
        Vector3 coord = new Vector3(Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height)).x + 10, -3.2f);
        if (GameData.gd.f_range > 0 && GameData.gd.f_range<200)
        {
            GameObject newships = Instantiate(ships[Random.Range(0, 3)], coord, Quaternion.identity, transform);
        }
        else if (GameData.gd.f_range>200 && GameData.gd.f_range < 1000)
        {
            GameObject newships = Instantiate(ships[Random.Range(0, 5)], coord, Quaternion.identity, transform);
        }
        else if(GameData.gd.f_range > 1000 && GameData.gd.f_range < 1500)
        {
            GameObject newships = Instantiate(ships[Random.Range(0, 7)], coord, Quaternion.identity, transform);
        }
        else if (GameData.gd.f_range > 1500 && GameData.gd.f_range < 2000)
        {
            GameObject newships = Instantiate(ships[Random.Range(0, ships.Length-1)], coord, Quaternion.identity, transform);
        }

       
        
    }

    public void LineGeneration()
    {
        Vector3 coord = new Vector3(Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height)).x + 10, Random.Range(-3,5));
        Instantiate(line, coord,Quaternion.identity);
    }

    public bool Chanse(float c)
    {
        int r = Random.Range(0, randomChanse);
        if (r <= c)
            return true;
        else
            return false;
    }


}
