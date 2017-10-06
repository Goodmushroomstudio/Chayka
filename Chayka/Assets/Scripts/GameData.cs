using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class GameData
{
    public static GameData gd = new GameData();
    public float f_axisY; // в Joystick
    public float f_axysX;
    public float f_speed;
    public float f_currenthp;
    public float f_currentsp;
    public float f_magnY;
    public float f_magnX;
    public float f_currentPosition;
    public float f_deltaPosition;
    public float f_lastPosition;
    public float[] f_hp;
    public float[] f_sp;
    public float f_range;
    public float f_massFecal;
    public int i_currentChar;
    public float f_score;
    public float f_currentScore;
    public float[,] f_m_missions;
    public bool[,] b_m_missions;
    public float f_currentmissionResult;
    public int i_currentMission;
    public int i_currentLvl;
    public bool death;
    public bool bichGenered;
    public float[] jeludok;
    public float[] kishechnik;
    public float[] birdSpeed;
    public float[] maneur;
    public float[] massFecal;
    public float[] fecalReload;
    public float[] armor;
    public int hpLevel;
    public int spLevel;
    public int jeludokLevel;
    public int kishechnikLevel;
    public int birdSpeedLevel;
    public int maneurLevel;
    public int massFecalLevel;
    public int fecalReloadLevel;
    public int armorLevel;
    public int coin;
    public int currentCoin;
    public bool music;
    public bool coinBuster;
    public bool fishBuster;
    public bool magnerBuster;
    public GameData()
    {
        i_currentChar = 0;
        f_axisY = 0;
        f_speed = 0;
        f_m_missions = new float[7, 3] { { 100, 200, 300 }, { 100, 200, 300 } , { 1000, 2000, 3000 } , { 25, 50, 100 } , { 25, 50, 100 } , { 25, 50, 100 } , { 1000, 2000, 3000 } };
        b_m_missions = new bool[7, 3];
        f_hp = new float[] { 1, 1.10f, 1.20f, 1.30f, 1.40f, 1.50f, 1.60f, 1.70f, 1.80f, 2f, 2.5f };
        f_sp = new float[] { 1, 1.1f, 1.2f, 1.3f, 1.4f, 1.5f, 1.6f, 1.7f, 1.8f, 2f, 2.5f };
        jeludok = new float[] { 0.05f, 0.06f, 0.07f, 0.08f, 0.9f, 0.1f, 0.11f, 0.12f, 0.13f, 0.14f, 0.15f };
        kishechnik = new float[] { 0.2f, 0.205f, 0.21f, 0.215f, 0.22f, 0.225f, 0.23f, 0.235f, 0.24f, 0.245f, 0.25f };
        birdSpeed = new float[] { 1.5f, 1.6f, 1.7f, 1.8f, 1.9f, 2, 2.1f, 2.2f, 2.3f, 2.4f, 2.5f };
        maneur = new float[] { 0, 0.001f, 0.002f, 0.003f, 0.004f, 0.005f, 0.006f, 0.007f, 0.008f, 0.009f, 0.01f };
        massFecal = new float[] { 0.05f, 0.1f, 0.2f, 0.3f, 0.4f, 0.5f, 0.6f, 0.7f, 0.8f, 0.9f, 1f };
        fecalReload = new float[] { 0.3f, 0.28f, 0.26f, 0.24f, 0.22f, 0.2f, 0.18f, 0.16f, 0.14f, 0.12f, 0.1f };
        armor = new float[] { 1, 0.97f, 0.95f, 0.92f, 0.9f, 0.87f, 0.85f, 0.82f, 0.80f, 0.77f, 0.75f };
        f_currenthp = 1;
        f_currentsp = 1;
        f_magnY = 0;
        f_magnX = 0;
        f_currentPosition = 0;
        f_deltaPosition = 0;
        f_lastPosition = 0;
        f_range = 0;
        f_massFecal = 0.5f;
        currentCoin = 0;
        coin = 0;
        music = true;
    }
    

}
