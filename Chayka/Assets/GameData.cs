[System.Serializable]
public class GameData
{
    public static GameData gd = new GameData();
    public float f_axisY; // в Joystick

    public GameData()
    {

        f_axisY = 0;

    }

}
