﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Functions : MonoBehaviour {

    public void StartGame()
    {
            SaveLoad.Save();
            SceneManager.LoadScene("Main");
            /*
        else
        {
            SaveLoad.Save();
            SceneManager.LoadScene("boss");
        }
             */
    }
    public void Menu()
    {
        SceneManager.LoadScene("menu");
    }

    public void MusicOfOn()
    {
        if (GameData.gd.music)
        {
            GameData.gd.music = false;
            GameObject.Find("MainTheme").GetComponent<AudioSource>().mute = false;
        }
        else
        {
            GameData.gd.music = true;
            GameObject.Find("MainTheme").GetComponent<AudioSource>().mute = true;
        }
    }
    public void LoadShop()
    {
        SceneManager.LoadScene("MenuV");
    }
}	

