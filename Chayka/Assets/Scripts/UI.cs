using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {
    public Text t_scoreText;
	
	void Start () {
        
        
	}

    // Update is called once per frame
    void Update()
    {
        if(GameData.gd.death)
        {
            transform.GetChild(6).GetComponent<Animator>().Play("board");
        }
        SetScoreText();
    }
       void SetScoreText()
        {
            t_scoreText.text = GameData.gd.f_score.ToString();
            
        }
    
}

