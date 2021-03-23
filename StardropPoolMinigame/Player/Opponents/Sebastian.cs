using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StardropPoolMinigame.Players
{
    class Sebastian : Player
    {
        public Sebastian() : base("Sebastian", false, true, Multiplayer.helper.Multiplayer.GetNewID(), "crane_game") { }
    }
}
