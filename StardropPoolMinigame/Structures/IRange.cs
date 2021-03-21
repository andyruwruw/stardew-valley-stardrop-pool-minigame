using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StardropPoolMinigame.Structures
{
    interface IRange
    {
        bool Intersects(IRange range);

        bool Contains(Vector2 point);
    }
}
