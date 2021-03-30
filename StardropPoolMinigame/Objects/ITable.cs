using Microsoft.Xna.Framework.Graphics;
using StardropPoolMinigame.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StardropPoolMinigame
{
    interface ITable
    {
        void Draw(SpriteBatch batch);

        IList<IPocket> GetPockets();

        IList<IRange> GetBorders();
    }
}
