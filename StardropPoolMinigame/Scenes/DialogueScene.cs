using StardewValley;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StardropPoolMinigame.Scenes
{
    class DialogueScene : Scene
    {
        public DialogueScene() : base()
        {

        }

        public override void Start()
        {
            Game1.changeMusicTrack("poppy");
        }

        public override void ReceiveLeftClick(int x, int y, bool playSound = true)
        {
        }
    }
}
