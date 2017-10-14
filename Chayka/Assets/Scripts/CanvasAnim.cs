using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasAnim : MonoBehaviour
{
    public int i_currentFrame;
    float f_time;
    public float f_maxTime;
    [Range(0, 100)]
    public float f_interval;

    public Sprite[] spriteArray;
    public bool loop, selfDestruct, hide, mask;
    // Use this for initialization
    void Start()
    {
        i_currentFrame = 0;
        GetComponent<Image>().sprite = spriteArray[i_currentFrame];

    }

    // Update is called once per frame
    void Update()
    {
        f_time -= 1 * Time.deltaTime;
        f_time = Mathf.Clamp(f_time, 0, Mathf.Infinity);
        if (f_time == 0)
        {
            GetComponent<Image>().enabled = true;
            i_currentFrame++;
            GetComponent<Image>().sprite = spriteArray[i_currentFrame];
            if (mask)
            {
                GetComponent<Image>().sprite = spriteArray[i_currentFrame];
            }
            f_time = f_maxTime;
            if (i_currentFrame + 1 > spriteArray.Length - 1)
            {
                if (loop)
                {
                    i_currentFrame = 0;
                    if (f_maxTime < f_interval)
                    {
                        f_time = f_interval;
                        if (hide)
                        {
                            GetComponent<Image>().enabled = false;
                        }
                    }
                }
                else if (selfDestruct)
                {
                    Destroy(this.gameObject);
                }
                else
                {
                    GetComponent<Anim>().enabled = false;
                }
            }

        }

    }
}
