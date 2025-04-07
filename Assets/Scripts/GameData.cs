using UnityEngine;

public class GameData
{
    public static readonly Vector2 ScreenXRange = new (0, 6);
    public static int PlayerY = 3;
    public static int CurrentLevel = 1;
    public static int PlayerLives = 3;
    public static readonly int WorldDepth = 40;

    public static void ResetGame()
    {
        PlayerY = 3;
        CurrentLevel = 1;
        PlayerLives = 3;
    }
    
    public static bool IsAlive()
    {
        return PlayerLives != 0;
    }
}
