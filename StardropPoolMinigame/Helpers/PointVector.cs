using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StardropPoolMinigame
{
    public class PointVector
    {
        public static Point Add(Point a, Point b)
        {
            return new Point(a.X + b.X, a.Y + b.Y);
        }
    }
}
