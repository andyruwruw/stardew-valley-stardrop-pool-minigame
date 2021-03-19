using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StardropPoolMinigame.Rules
{
    interface IRules
    {
        IBall[] GenerateInitialBalls();

        GameEvent BallPocketed(IBall[] ball, IPocket pocket, IBall[] remaining, IPocket target = null);

        GameEvent[] NoBallHit(IBall[] remaining);
    }
}
