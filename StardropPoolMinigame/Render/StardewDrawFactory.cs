using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StardropPoolMinigame.Render
{
    class StardewDrawFactory : IDrawFactory
    {
        public StardewDrawFactory() { }

        public IDraw GetTitleSceneDrawer()
        {
            return new StardewDrawTitleScreen();
        }

        public IDraw GetDialogueSceneDrawer()
        {
            return new StardewDrawDialogueScene();
        }

        public IDraw GetGameSceneDrawer()
        {
            return new StardewDrawGameScene();
        }

        public IDraw GetSummarySceneDrawer()
        {
            return new StardewDrawSummaryScene();
        }
    }
}
