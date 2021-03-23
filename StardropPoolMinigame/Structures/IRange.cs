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
        /// <summary>
        /// Whether another range intersects with this range.
        /// </summary>
        /// 
        /// <param name="range">Other <see cref="IRange"/></param>
        /// <returns>Whether range intersects</returns>
        bool Intersects(IRange range);

        /// <summary>
        /// Whether a point lies within the range.
        /// </summary>
        /// 
        /// <param name="point">Point to check</param>
        /// <returns>Whether range contains</returns>
        bool Contains(Vector2 point);
    }
}
