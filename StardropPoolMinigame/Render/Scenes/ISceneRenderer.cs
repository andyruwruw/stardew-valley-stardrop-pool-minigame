using StardropPoolMinigame.Render.Drawers;
using StardropPoolMinigame.Scenes;
using System.Collections.Generic;

namespace StardropPoolMinigame.Render.Scenes
{
    interface ISceneRenderer
    {
        IList<IDrawer> GetEntities();
    }
}
