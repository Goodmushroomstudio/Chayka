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


        if (transform.GetChild(0).position.x < Camera.main.ScreenToWorldPoint(Vector3.zero).x - 5)
        {
            transform.GetChild(0).position += new Vector3(transform.GetChild(0).GetComponent<SpriteRenderer>().bounds.size.x * 11, 0, 0);
            transform.GetChild(0).SetAsLastSibling();
        }
        if (generateBubble)
        {
            if (transform.position.x <= Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0)).x)
            {
                if (Random.Range(0, 20) == 0)
                {
                    Instantiate(bubble, new Vector3(Random.Range(transform.GetChild(0).GetComponent<SpriteRenderer>().bounds.min.x, Mathf.Abs(transform.GetChild(transform.childCount-1).GetComponent<SpriteRenderer>().bounds.max.x)), Camera.main.ScreenToWorldPoint(Vector3.zero).y - 1), Quaternion.identity, transform);
                }
            }
        }
    }
}
