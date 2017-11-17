using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public static class Loc
{
    public static string[,] l;

    static Loc()
    {
        l = new string[,]
        {
            {
                "Собрать ", //0
                "Пролететь ", //1
                "Испачкать ",  //2
                "Потопить ", //3
                "Набрать ", //4
                "Сделать х", //5
                "", //6
                " монет", //7 
                " рыб", //8
                " метров", //9
                " кораблей", //10
                " человек", //11
                " очков", //12
                " комбо" , //13
                " метров без урона",//14
                "Увидеть все виды кораблей",//15 
                "Приобрести все улучшения", //16
                "Потопить босса"//17
            }
        };
    }

}