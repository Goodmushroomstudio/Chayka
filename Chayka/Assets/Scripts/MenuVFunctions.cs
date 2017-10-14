using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuVFunctions : MonoBehaviour {
    public Image water1;
    public Image water2;
    public bool b_water1;
    public bool b_water2;
    public bool stop;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (b_water1)
        {
            MoveUp(water1);
        }
        if(b_water2)
        {
            MoveUp(water2);
        }
       
        
	}
    void MoveUp(Image water)
    {
        if (!stop)
        {
            water.transform.position += new Vector3(0, 1.5f, 0);
        }
        if (water.GetComponent<RectTransform>().anchoredPosition.y>=0)
        {
            if (b_water1)
            {
                //SceneManager.LoadScene("");
            }
            if(b_water2)
            {
                //SceneManager.LoadScene("");
            }
            stop = true;
        }
    }
    public void Click(int button)
    {
        Debug.Log(button);
        if (button == 1)
        {
            b_water1 = true;
        }
        if (button == 2) 
        {
            b_water2 = true;
        }
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("menu");
    }
}
