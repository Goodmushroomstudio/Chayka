using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour {
    public GameObject cloud;
    public Sprite[] cloudSprites;
    public GameObject water;
    [Range(0,100)]
    public float f_speed;
    public float cloudChanse;


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
		
	}
    public void CloudGeneration()
    {
        Vector3 coord = new Vector3(Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height)).x + 10, Random.Range(1.2f, 3), 0);
        GameObject newCloud = Instantiate(cloud, coord, Quaternion.identity, transform);
        newCloud.GetComponent<SpriteRenderer>().sprite = cloudSprites[Random.Range(0, cloudSprites.Length)];
        int r = Random.Range(-15,-5);
        newCloud.GetComponent<SpriteRenderer>().sortingOrder = r;
        newCloud.GetComponent<Move>().speed = GameData.gd.f_speed / Mathf.Abs(r) *5;
        float size = 1-(Mathf.Abs(r)*0.1f);
        newCloud.transform.localScale = new Vector3(size, size, size);
    }
    public void GenerationWater(Vector3 pos)
    {
        Vector3 coordW = new Vector3(pos.x+36, pos.y, 0);
        Instantiate(water, coordW, Quaternion.identity, transform);
    }

    public bool Chanse(float c)
    {
        int r = Random.Range(0, 100);
        if (r <= c)
            return true;
        else
            return false;
    }

}
