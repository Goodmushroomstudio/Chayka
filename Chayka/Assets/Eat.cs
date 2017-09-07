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
    void Update()
    {
        f_timer -= 1 * Time.deltaTime;
        if (f_timer <= 0)
        {
            GetComponent<Rigidbody2D>().gravityScale = 1;
            rb.AddForce(new Vector2(0,f_impulse),ForceMode2D.Impulse);
            f_timer = f_reload;
        }
        if (transform.position.y < Camera.main.ScreenToWorldPoint(Vector3.zero).y - 15)
        {
            GenerationEat();
            f_timer = f_reload;
            
        }
       



    }
    public void GenerationEat()
    {
        transform.position = new Vector3(Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,0,0)).x + 5,Camera.main.ScreenToWorldPoint(Vector3.zero).y +1) ;
        rb.gravityScale = 0;
        rb.velocity =Vector2.zero;
    }
}
