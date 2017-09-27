using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour {

    public float speed;
    public bool generateBubble;
    public GameObject bubble;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
    void Update()
    {

        transform.position -= new Vector3(speed * GameData.gd.f_speed, 0, 0) * Time.deltaTime;


        if (transform.position.x < Camera.main.ScreenToWorldPoint(Vector3.zero).x - 5)
        {
            transform.position += new Vector3(GetComponent<SpriteRenderer>().bounds.size.x*11, 0, 0);
        }
        if (generateBubble)
        {
            if (transform.position.x <= Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0)).x)
            {
                if (Random.Range(0, 100) == 0)
                {
                    Instantiate(bubble, new Vector3(Random.Range(GetComponent<SpriteRenderer>().bounds.min.x, GetComponent<SpriteRenderer>().bounds.max.x), Camera.main.ScreenToWorldPoint(Vector3.zero).y - 1), Quaternion.identity, transform);
                }
            }
        }
    }
}
