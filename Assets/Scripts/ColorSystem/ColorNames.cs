
using System.Collections.Generic;

public class ColorNames
{
    public const string Glider = "Glider";
    public const string EnemyOne = "EnemyOne";
    public const string EnemieTwo = "EnemieTwo";
    public const string BackGround = "BackGround";
    public const string Obstacle = "Obstacle";

    private static List<string> _names = new List<string>()
    {
        Glider, EnemyOne, EnemieTwo, BackGround, Obstacle
    };

    public static IReadOnlyList<string> Names => _names;
}
