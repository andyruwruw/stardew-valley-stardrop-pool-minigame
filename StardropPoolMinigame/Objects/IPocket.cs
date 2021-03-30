using StardropPoolMinigame.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StardropPoolMinigame
{
    interface IPocket
    {
        bool IsPocketed(IBall ball);

        int GetId();

        Circle GetBoundary();
    }
}
