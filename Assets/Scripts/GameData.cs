using UnityEngine;

public class GameData
{
    public static readonly Vector2 ScreenXRange = new (0, 6);
    public static int PlayerY = 3;
    public static int CurrentLevel = 1;
    public static int PlayerLives = 3;
    public static readonly int WorldDepth = 100;

    public static bool IsAlive()
    {
        return PlayerLives != 0;
    }
}
