using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StardropPoolMinigame.Helpers
{
    class Distance
    {
        public static double Between(Vector2 point1, Vector2 point2)
        {
            return Pythagorean(point1, point2);
        }

        public static double Pythagorean(Vector2 point1, Vector2 point2)
        {
            return Math.Sqrt(Math.Pow(point1.X - point2.X, 2) + Math.Pow(point1.Y - point2.Y, 2));
        }

        public static double Manhattan(Vector2 point1, Vector2 point2)
        {
            return (point1.X - point2.X) + (point1.Y - point2.Y);
        }
    }
}
