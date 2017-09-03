﻿[System.Serializable]
public class GameData
{
    public static GameData gd = new GameData();
    public float f_axisY; // в Joystick
    public float f_speed;
    public float f_currenthp;
    public float f_currentsp;
    public float[] f_sp;
    public float[] f_hp;
    public int i_currentChar;

    public GameData()
    {
        i_currentChar = 0;
        f_axisY = 0;
        f_speed = 0;
        f_sp = new float[] { 1 };
        f_hp = new float[] { 1 };
        f_currenthp = 1;
        f_currentsp = 1;
    }

}
