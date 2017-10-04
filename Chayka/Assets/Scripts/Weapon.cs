using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    GameObject player;
    public GameObject garpun;
    public GameObject fog;
    public float f_reload;
    public float f_timer;
    Vector3 upper;
    // Use this for initialization
    void Start () {
        f_timer = f_reload;
        player = GameObject.Find("Bird");
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x > (Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0)).x / 2))
        {
            if (transform.position.x < (Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0)).x))
            {
                f_timer -= 1 * Time.deltaTime;
            }
            Quaternion newRotation = Quaternion.LookRotation(transform.position - upper, Vector3.forward);
            newRotation.x = 0;
            newRotation.y = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 100);
        }
        

        if (f_timer <= 0)
        {
            upper = new Vector3(Camera.main.ScreenToWorldPoint(Vector3.zero).x, Random.Range(Camera.main.ScreenToWorldPoint(Vector3.zero).y, Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height)).y));
            GameObject bullet = Instantiate(garpun, transform.position, transform.localRotation);
            float vX = Mathf.Clamp(((upper - transform.position) * 1.8f).x, -16, 16);
            float vY = Mathf.Clamp(((upper - transform.position) * 1.8f).y, -14, 14);
            bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(vX,vY), ForceMode2D.Impulse);
            GameObject newfog = Instantiate(fog, transform.position, new Quaternion(0, 0, transform.rotation.z+10, 100));
            f_timer = f_reload;
        }
	}
}
