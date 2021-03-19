using StardewValley;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StardropPoolMinigame.Scenes
{
    class TitleScene : IScene
    {
        public TitleScene()
        {

        }

        public void Start()
        {
            Console.Info("Starting");
            Game1.changeMusicTrack("poppy", track_interruptable: false, Game1.MusicContext.MiniGame);
        }
    }
}
