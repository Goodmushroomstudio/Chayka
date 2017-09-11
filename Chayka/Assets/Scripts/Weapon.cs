using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    GameObject player;
    public GameObject garpun;
    public GameObject fog;
    public float f_reload;
    public float f_timer;
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
            transform.GetComponent<Animation>().Play("boom");
            GameObject bullet = Instantiate(garpun, transform.position, transform.localRotation);
            float vX = Mathf.Clamp(((player.transform.position - transform.position) * 3).x, -15, 15);
            float vY = Mathf.Clamp(((player.transform.position - transform.position) * 3).y, -15, 15);
            bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(vX, vY), ForceMode2D.Impulse);
            GameObject newfog = Instantiate(fog, transform.position, new Quaternion (0,0,transform.rotation.z+30,100));
            f_timer = f_reload;


        }
        Quaternion newRotation = Quaternion.LookRotation(transform.position - new Vector3(player.transform.position.x,player.transform.position.y), Vector3.forward);
        newRotation.x = 0;
        newRotation.y = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 100);
	}
}
