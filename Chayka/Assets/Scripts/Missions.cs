using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public static class Missions {
    public static List<int> missionsLeft; // список миссий, которые остались
    public static List<int> currentMissions; // три текущих миссии или одна уникальная
    public static List<bool> bCurrentMissons; // Пройдены или нет текущие
    public static List<float> progress; // прогресс текущих
    public static int missionRang; // уровень сложности миссий
    public static float[,] f_m_missions; // массив значений
    public static bool[] b_m_missions; // булевый общий массив
    public static string[] missionHead; // названия миссий
    public static string[] missionBody;

    static Missions()
    {
        currentMissions = new List<int>();
        bCurrentMissons = new List<bool>();
        progress = new List<float>() {0,0,0,0,0,0,0,0,0};
        missionRang = 0;
        missionsLeft = new List<int>();
        f_m_missions = new float[9, 3] { { 5, 200, 300 }, { 5, 200, 300 }, { 100, 2000, 3000 }, { 3, 50, 100 }, { 3, 50, 100 }, { 5, 50, 100 }, { 100, 2000, 3000 }, {6,7,8}, {50,200,300}};
        b_m_missions = new bool[9];
        missionHead = new string[] { "Собрать ", "Собрать ", "Пролететь ", "Испачкать ", "Испачкать ",  "Потопить ", "Набрать ", "Сделать х", "Пролететь "};
        missionBody = new string[] { " монет", " рыб", " метров", " кораблей", " человек", " кораблей", " очков", " комбо" , " метров без повреждений"};
        for (int i = 0; i < GameData.gd.f_m_missions.GetLength(0); i++)
        {
            missionsLeft.Add(i);
        }
    }

    public static void RandomMission()
    {
        currentMissions = new List<int>();
        if (GameData.gd.missionsLeft != null)
        {
            missionsLeft = GameData.gd.missionsLeft;
        }
        for (int i = 0; i < 3; i++)
        {
            Debug.Log(missionsLeft.Count);
            int r = missionsLeft[Random.Range(0, missionsLeft.Count)];
            currentMissions.Add(r);
            missionsLeft.RemoveAt(missionsLeft.IndexOf(r));
        }
        GameData.gd.currentMissions = currentMissions;
        GameData.gd.missionsLeft = missionsLeft;
    }
}