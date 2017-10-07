using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eat : MonoBehaviour
{
    public float f_impulse;
    public float f_timer;
    public float f_reload;
    bool inJump;
    private Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        f_impulse = Random.Range(8, 13);
    }

    void Update()
    {
        f_timer -= 1 * Time.deltaTime;
        f_timer = Mathf.Clamp(f_timer, 0, 1);
        if (transform.position.y < -5)
        {
            rb.velocity = Vector2.zero;
            rb.bodyType = RigidbodyType2D.Kinematic;
            if (f_timer == 0)
            {
                f_timer = f_reload;
            }
            
            if (f_timer <= 0.5f)
            {
                rb.bodyType = RigidbodyType2D.Dynamic;
                rb.AddForce(new Vector2(0, f_impulse), ForceMode2D.Impulse);
            }
            
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!inJump)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.AddForce(new Vector2(0, f_impulse), ForceMode2D.Impulse);
            inJump = true;
        }
        if (inJump)
        {
            Quaternion newRotation = Quaternion.LookRotation(transform.GetChild(0).localPosition - new Vector3(GetComponent<Rigidbody2D>().velocity.x - 5, GetComponent<Rigidbody2D>().velocity.y,0), Vector3.forward);
            newRotation.x = 0;
            newRotation.y = 0;
            transform.GetChild(0).rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.fixedDeltaTime * 100);
            if (transform.position.y < Camera.main.ScreenToWorldPoint(Vector3.zero).y - 15)
            {
                Destroy(this.gameObject);
            }
        }




    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("facebird"))
        {
            GameData.gd.f_currentsp += GameData.gd.kishechnik[GameData.gd.kishechnikLevel];
            GameData.gd.f_currenthp += GameData.gd.jeludok[GameData.gd.jeludokLevel];
            GetComponent<SpriteRenderer>().enabled = true;
            transform.rotation = new Quaternion(transform.GetChild(0).transform.rotation.x, transform.GetChild(0).transform.rotation.y, transform.GetChild(0).transform.rotation.z+45,100); 
            GetComponent<Rigidbody2D>().angularVelocity = Random.Range(-50, 50);
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<Eat>().enabled = false;
            Destroy(transform.GetChild(0).gameObject);
            if (GameData.gd.i_currentMission == 1 && !GameData.gd.b_m_missions[GameData.gd.i_currentMission, GameData.gd.i_currentMissionLvl])
            {
                GameData.gd.f_currentmissionResult++;

            }
        }
        
            
        
    }


}
