using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StardropPoolMinigame.Helpers
{
    class Operators
    {
        public static float Modulo(float a, float b)
        {
            return (float)(a - b * Math.Floor(a / b));
        }
    }
}
