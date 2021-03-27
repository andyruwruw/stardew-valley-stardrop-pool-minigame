using StardewValley;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StardropPoolMinigame.Scenes
{
    class SummaryScene : Scene
    {
        public SummaryScene() : base()
        {

        }

        public override void Start()
        {
            Game1.changeMusicTrack("poppy");
        }

        public override void Update()
        {

        }

        public override void ReceiveLeftClick(int x, int y, bool playSound = true)
        {
        }
    }
}
