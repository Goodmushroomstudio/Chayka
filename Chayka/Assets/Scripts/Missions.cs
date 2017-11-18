using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public static class Missions {
    public static List<int> missionsLeft; // список миссий, которые остались
    public static List<int> currentMissions; // три текущих миссии или одна уникальная
    public static List<bool> bCurrentMissons; // Пройдены или нет текущие
    public static List<float> progress; // прогресс текущих
    public static float[,] f_m_missions; // массив значений
    public static bool[] b_m_missions; // булевый общий массив
    public static string[] missionHead; // названия миссий
    public static string[] uniqueBody; // названия уникальных миссий.
    public static string[] missionBody;//

    static Missions()
    {
        currentMissions = new List<int>();
        bCurrentMissons = new List<bool>();
        progress = new List<float>() {0,0,0,0,0,0,0,0,0};
        missionsLeft = new List<int>();
        f_m_missions = new float[9, 3] { { 1, 2, 3 }, { 1, 2, 3 }, { 1, 2, 3 }, { 1, 2, 3 }, { 1, 2, 3 }, { 1, 2, 3 }, { 1, 2, 3 }, {1,2,3}, {1,2,3}};
        b_m_missions = new bool[9];
        missionHead = new string[] { Loc.l[GameData.gd.locNum, 0], Loc.l[GameData.gd.locNum, 0], Loc.l[GameData.gd.locNum, 1], Loc.l[GameData.gd.locNum, 2], Loc.l[GameData.gd.locNum, 2], Loc.l[GameData.gd.locNum, 3], Loc.l[GameData.gd.locNum, 4], Loc.l[GameData.gd.locNum, 5], Loc.l[GameData.gd.locNum, 6] };
        missionBody = new string[] { Loc.l[GameData.gd.locNum, 7], Loc.l[GameData.gd.locNum, 8], Loc.l[GameData.gd.locNum, 9], Loc.l[GameData.gd.locNum, 10], Loc.l[GameData.gd.locNum, 11], Loc.l[GameData.gd.locNum, 10], Loc.l[GameData.gd.locNum, 12], Loc.l[GameData.gd.locNum, 13], Loc.l[GameData.gd.locNum, 14] };
        uniqueBody = new string[] { Loc.l[GameData.gd.locNum, 15], Loc.l[GameData.gd.locNum, 16], Loc.l[GameData.gd.locNum, 17] };
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
            int r = missionsLeft[Random.Range(0, missionsLeft.Count)];
            currentMissions.Add(r);
            missionsLeft.RemoveAt(missionsLeft.IndexOf(r));
        }
        GameData.gd.currentMissions = currentMissions;
        GameData.gd.missionsLeft = missionsLeft;
    }

    public static void UniqueMission()
    {
        currentMissions = new List<int>();
        currentMissions.Add(GameData.gd.uniqueRang);
    }
}