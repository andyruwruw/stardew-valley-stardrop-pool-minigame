using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StardropPoolMinigame.Players
{
    class Sam : Player
    {
        public Sam() : base("Sam", false, true, Multiplayer.helper.Multiplayer.GetNewID(), Sounds.SamTheme) { }
    }
}
