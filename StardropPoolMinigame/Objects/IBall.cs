using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StardropPoolMinigame
{
    interface IBall
    {
        Point GetPosition();

        Point GetMotion();

        int GetNumber();

        Color GetColor();

        BallType GetBallType();
    }
}
