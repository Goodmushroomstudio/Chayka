using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour {
    public GameObject[] cloud;
    public GameObject water;
    public float f_speed;


    // Use this for initialization
    void Start () {
        GameData.gd.f_speed = f_speed;
        NewGeneration();
	}
	
	// Update is called once per frame
	void Update () {
        
		
	}
    public void NewGeneration()
    {
        Vector3 coord = new Vector3(Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height)).x + 10, Random.Range(1.2f, 3), 0);
        GameObject.Instantiate(cloud[Random.Range(0, 4)], coord, Quaternion.identity, transform);
        GameObject newCloud = Instantiate(cloud[Random.Range(0, 4)], coord, Quaternion.identity, transform);
    }
    public void GenerationWater(Vector3 pos)
    {
        Vector3 coordW = new Vector3(pos.x+36, pos.y, 0);
        Instantiate(water, coordW, Quaternion.identity, transform);
    }
}
