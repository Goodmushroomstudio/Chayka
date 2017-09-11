using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Anim : MonoBehaviour {
    public int i_currentFrame;
    float f_time;
    public float f_maxTime;
    public Sprite[] spriteArray;
    public bool loop;
	// Use this for initialization
	void Start () {
        i_currentFrame = 0;
        GetComponent<SpriteRenderer>().sprite = spriteArray[i_currentFrame];
        
	}
	
	// Update is called once per frame
	void Update () {
        f_time -= 1 * Time.deltaTime;
        f_time = Mathf.Clamp(f_time, 0, f_maxTime);
        if(f_time==0)
        {
            i_currentFrame++;
            GetComponent<SpriteRenderer>().sprite = spriteArray[i_currentFrame];
            f_time = f_maxTime;
            if (i_currentFrame + 1 > spriteArray.Length-1)
            {
                
                if(loop)
                {
                    i_currentFrame = 0;
                }
                else
                {
                    GetComponent<Anim>().enabled = false;
                    GetComponent<SpriteRenderer>().enabled = false;
                }
            }
            
        }
        
	}
}
