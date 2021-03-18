using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StardropPoolMinigame.Render
{
    interface IDrawFactory
    {
        IDraw GetTitleSceneDrawer();

        IDraw GetDialogueSceneDrawer();

        IDraw GetGameSceneDrawer();

        IDraw GetSummarySceneDrawer();
    }
}
