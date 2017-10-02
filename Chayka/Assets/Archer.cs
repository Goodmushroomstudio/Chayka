using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : MonoBehaviour {
    public GameObject stone;
    GameObject player;
    public Vector3 upper;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Bird");
    }
	
	// Update is called once per frame
	void Update () {
        upper = new Vector3(player.transform.position.x, player.transform.position.y + (Vector3.Magnitude(player.transform.position - transform.position)) / 5.5f);
        if (transform.position.x > (Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0)).x / 2)&& transform.position.x < (Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0)).x ))
        {
            transform.GetComponent<Animator>().Play("ArcherAnim");
        }
        if (transform.position.x < (Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0)).x / 2))
        {
            transform.GetComponent<Animator>().Play("none");
        }


    }
    public void PiuPiu()
    {
       GameObject newstone = Instantiate(stone, transform.position, transform.localRotation);
        float vX = Mathf.Clamp(((upper - transform.position) * 1.5f).x, -15, 15);
        float vY = Mathf.Clamp(((upper - transform.position) * 1.5f).y, -15, 15);
        newstone.GetComponent<Rigidbody2D>().AddForce(new Vector2(vX, vY), ForceMode2D.Impulse);
    }
}
