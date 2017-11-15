using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishgenered : MonoBehaviour {
    public GameObject fish;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        int r = Random.Range(0,10);
        if (r == 10)
        {
            FishGeneration();
        }
		
	}
    public void FishGeneration()
    {
        Vector3 coord = new Vector3(Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0)).x + 10, -5);
        Instantiate(fish, coord, Quaternion.identity, transform);

    }
}
