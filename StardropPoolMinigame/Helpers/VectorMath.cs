using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StardropPoolMinigame
{
    class VectorMath
    {
        public static Vector2 VectorBetweenTwoPoints(Vector2 a, Vector2 b)
        {
            return Vector2.Subtract(b, a);
        }

        public static float VectorToRadians(Vector2 vector)
        {
            return (float)Math.Atan2(vector.Y, vector.X);
        }

        public static double Modulo(double a, double b)
        {
            return a - b * Math.Floor(a / b);
        }
    }
}
