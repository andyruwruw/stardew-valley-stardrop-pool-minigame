using StardewValley;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StardropPoolMinigame.Scenes
{
    class SummaryScene : IScene
    {
        public SummaryScene()
        {

        }

        public void Start()
        {
            Game1.changeMusicTrack("poppy");
        }
    }
}
