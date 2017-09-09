using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour {
    public float f_reload;
    public float f_timer;
    public float f_value;
    GameObject player;
    public GameObject garpun;

	// Use this for initialization
	void Start () {
        f_timer = f_reload;
        player = GameObject.Find("07");
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x > (Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0)).x / 2) && transform.position.x < (Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0)).x))
        {
            f_timer -= 1 * Time.deltaTime;
        }
        if (f_timer <= 0)
        {
            transform.GetChild(0).GetComponent<Animation>().Play("boom");
            GameObject bullet = Instantiate(garpun, transform.GetChild(0).position, transform.GetChild(0).localRotation);
            float vX = Mathf.Clamp(((player.transform.position - transform.GetChild(0).position)*3).x,-10,10);
            float vY = Mathf.Clamp(((player.transform.position - transform.GetChild(0).position)*3).y,-10,10);
            bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(vX,vY), ForceMode2D.Impulse);
            f_timer = f_reload;
        }
	}
    private void OnCollisionEnter2D(Collision2D collision)
 

    {
        if (collision.gameObject.CompareTag("kak"))
        {
            
            Instantiate(collision.gameObject.GetComponent<Cacula>().kaki[Random.Range(0, collision.gameObject.GetComponent<Cacula>().kaki.Length)], collision.contacts[0].point, Quaternion.identity, transform);
            Destroy(collision.gameObject);
            GameData.gd.f_score += f_value;
        }
    }
}
