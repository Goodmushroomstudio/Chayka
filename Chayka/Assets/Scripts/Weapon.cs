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
        if (transform.position.x > (Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0)).x / 2) && !GameData.gd.boss)
        {
            if (transform.position.x < (Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0)).x) && !GameData.gd.boss)
            {
                f_timer -= 1 * Time.deltaTime;
            }
            Quaternion newRotation = Quaternion.LookRotation(transform.position - player.transform.position, Vector3.forward);
            newRotation.x = 0;
            newRotation.y = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 100);
        }
        if (GameData.gd.boss)
        {
            if (transform.position.x < (Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0)).x) && transform.position.x > (Camera.main.ScreenToWorldPoint(new Vector3(0, 0)).x))
            {
                f_timer -= 1 * Time.deltaTime;
                Quaternion newRotation = Quaternion.LookRotation(transform.position - player.transform.position, Vector3.forward);
                newRotation.x = 0;
                newRotation.y = 0;
                transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 100);
            }
        }
        

        if (f_timer <= 0)
        {
            upper = new Vector3(Random.Range(player.transform.position.x-1, player.transform.position.x + 1), Random.Range(player.transform.position.y+1, player.transform.position.y + 2));
            GameObject bullet = Instantiate(garpun, transform.GetChild(0).transform.position, transform.localRotation);
            float vX = Mathf.Clamp(((upper - transform.position)).x, -16, 16);
            float vY = Mathf.Clamp(((upper - transform.position)).y, -14, 14);
            bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(vX,vY), ForceMode2D.Impulse);
            Instantiate(fog, transform.position, new Quaternion(0, 0, transform.rotation.z+10, 100));
            f_timer = f_reload;
        }
	}
}
