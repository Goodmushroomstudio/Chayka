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
        SetScoreText();
    }
       void SetScoreText()
        {
            t_scoreText.text = "score:"+GameData.gd.f_score.ToString();
            
        }
    
}

