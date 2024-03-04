using System.Collections.Generic;

namespace Assets.Scripts.ColorSystem
{
    public class ColorNames
    {
        public const string Glider = "Glider";
        public const string EnemyOne = "EnemyOne";
        public const string EnemyTwo = "EnemyTwo";
        public const string Background = "Background";
        public const string MovableBackground = "MovableBackground";
        public const string Obstacle = "Obstacle";

        private static readonly List<string> _names = new List<string>()
        {
            Glider, EnemyOne, EnemyTwo, Background, MovableBackground, Obstacle
        };

        public static IReadOnlyList<string> Names => _names;
    }
}