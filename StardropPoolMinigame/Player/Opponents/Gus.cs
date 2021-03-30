using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StardropPoolMinigame.Players
{
    class Gus : Player
    {
        public Gus() : base("Gus", false, true, Multiplayer.helper.Multiplayer.GetNewID(), Sounds.GusTheme) { }
    }
}
