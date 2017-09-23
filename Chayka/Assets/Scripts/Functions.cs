using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Functions : MonoBehaviour {

    public void StartGame()
    {
        GameData.gd = new GameData();
        SceneManager.LoadScene("Main");
    }
}	

