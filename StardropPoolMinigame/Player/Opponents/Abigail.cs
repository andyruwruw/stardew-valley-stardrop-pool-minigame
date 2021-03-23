using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StardropPoolMinigame.Players
{
    class Abigail : Player
    {
        public Abigail() : base("Abigail", false, true, Multiplayer.helper.Multiplayer.GetNewID(), "cowboy_boss") { }
    }
}
