using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eat : MonoBehaviour
{
    public float f_reload;
    public float f_timer;
    public float f_impulse;
    private Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        f_timer = f_reload;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        f_timer -= 1 * Time.deltaTime;
        f_impulse = Random.Range(8f, 12f);
        f_reload = Random.Range(1f, 3f);
        if (f_timer <= 0 && GetComponent<Rigidbody2D>().gravityScale==0)
        {
            GetComponent<Rigidbody2D>().gravityScale = 1;
            rb.AddForce(new Vector2(0,f_impulse),ForceMode2D.Impulse);
            f_timer = f_reload;
        }
        if (GetComponent<Rigidbody2D>().gravityScale == 1)
        {
            Quaternion newRotation = Quaternion.LookRotation(transform.GetChild(0).localPosition - new Vector3(GetComponent<Rigidbody2D>().velocity.x - 5, GetComponent<Rigidbody2D>().velocity.y,0), Vector3.forward);
            newRotation.x = 0;
            newRotation.y = 0;
            transform.GetChild(0).localRotation = Quaternion.Slerp(transform.localRotation, newRotation, Time.deltaTime * 100);
        }
        if (transform.position.y < Camera.main.ScreenToWorldPoint(Vector3.zero).y - 15)
        {
            GenerationEat();
            Destroy(this.gameObject);
        }



    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bird"))
        {
            GenerationEat();
            GameData.gd.f_currentsp += 0.1f;
            GameData.gd.f_currenthp += 0.05f;
            
        }
        
            
        
    }

    public void GenerationEat()
    {
        transform.position = new Vector3(Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,0,0)).x + 5,Camera.main.ScreenToWorldPoint(Vector3.zero).y +Random.Range(0.1f,1f)) ;
        rb.gravityScale = 0;
        rb.velocity =Vector2.zero;
        rb.angularVelocity = 0;
        transform.GetChild(0).localRotation = new Quaternion(0,0,90,100);
    }
}
