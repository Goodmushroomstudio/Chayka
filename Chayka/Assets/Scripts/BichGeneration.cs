using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BichGeneration : MonoBehaviour {
    public GameObject middleEarth;
    public GameObject endEarth;
	// Use this for initialization
	void Start () {
        int r = Random.Range(4, 10);
        GameObject last = Instantiate(endEarth, new Vector3(GetComponent<SpriteRenderer>().bounds.max.x + (middleEarth.GetComponent<SpriteRenderer>().bounds.size.x * r - 1) + endEarth.GetComponent<SpriteRenderer>().bounds.size.x/2, -2.8f),Quaternion.identity);
        GameObject first = Instantiate(middleEarth, new Vector3(GetComponent<SpriteRenderer>().bounds.max.x + (middleEarth.GetComponent<SpriteRenderer>().bounds.size.x) / 2, -2.8f), Quaternion.identity);
        first.transform.parent = last.transform;
        transform.parent = last.transform;
        for (int i = 1; i < r; i++)
        {
           GameObject mid = Instantiate(middleEarth, new Vector3(GetComponent<SpriteRenderer>().bounds.max.x + middleEarth.GetComponent<SpriteRenderer>().bounds.size.x * i-1 + (middleEarth.GetComponent<SpriteRenderer>().bounds.size.x)/2, -2.8f), Quaternion.identity);
           mid.transform.parent = last.transform;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
