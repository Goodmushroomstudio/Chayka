using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour {
    public GameObject cloud;
    public GameObject fish;
    public GameObject coin;
    public Sprite[] cloudSprites;
    public GameObject water;
    [Range(0,100)]
    public float f_speed;
    public float cloudChanse;
    public float fishChanse;
    [Range(0, 50000)]
    public int randomChanse;
    public int coinChanse;


    // Use this for initialization
    void Start () {
        GameData.gd.f_speed = f_speed;
        CloudGeneration();
	}
	
	// Update is called once per frame
	void Update () {
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
		
	}
    public void CloudGeneration()
    {
        Vector3 coord = new Vector3(Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height)).x + 10, Random.Range(1f, 5), 0);
        GameObject newCloud = Instantiate(cloud, coord, Quaternion.identity, transform);
        newCloud.GetComponent<SpriteRenderer>().sprite = cloudSprites[Random.Range(0, cloudSprites.Length)];
        int r = Random.Range(-15,-5);
        newCloud.GetComponent<SpriteRenderer>().sortingOrder = r;
        newCloud.GetComponent<Move>().speed = GameData.gd.f_speed / Mathf.Abs(r) *5;
        float size = 1-((Mathf.Abs(r)/100)*2);
        newCloud.transform.localScale = new Vector3(size, size, size);
    }
    public void GenerationWater(Vector3 pos)
    {
        Vector3 coordW = new Vector3(pos.x+36, pos.y, 0);
        Instantiate(water, coordW, Quaternion.identity, transform);
    }

    public void FishGeneration()
    {
        Vector3 coord = new Vector3(Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height)).x + 10, Random.Range(-5, -4.5f), 0);
        GameObject newFish = Instantiate(fish, coord, Quaternion.identity, transform);
        newFish.GetComponent<Eat>().f_reload = Random.Range(5, 8);
        
    }
    public void CoinGeneration()
    {
        Vector3 coord = new Vector3(Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height)).x + 10, Random.Range(-1, 3.2f), 0);
        GameObject newCoin = Instantiate(coin, coord, Quaternion.identity, transform);
        newCoin.GetComponent<Move>().speed = Random.Range(3, 7);
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
