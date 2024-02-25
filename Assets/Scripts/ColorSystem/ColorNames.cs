
using System.Collections.Generic;

public class ColorNames
{
    public const string Glider = "Glider";
    public const string EnemyOne = "EnemyOne";
    public const string EnemyTwo = "EnemyTwo";
    public const string Background = "Background";
    public const string Obstacle = "Obstacle";

    private static List<string> _names = new List<string>()
    {
        Glider, EnemyOne, EnemyTwo, Background, Obstacle
    };

    public static IReadOnlyList<string> Names => _names;
}
