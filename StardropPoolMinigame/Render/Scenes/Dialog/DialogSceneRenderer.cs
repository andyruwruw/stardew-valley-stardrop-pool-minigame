using StardropPoolMinigame.Render.Drawers;
using StardropPoolMinigame.Scenes;
using System.Collections.Generic;

namespace StardropPoolMinigame.Render.Scenes
{
    class DialogSceneRenderer : ISceneRenderer
    {
        private IScene _scene;

        public DialogSceneRenderer(IScene scene)
        {
            this._scene = scene;
        }

        public IList<IDrawer> GetEntities()
        {
            IList<IDrawer> entities = new List<IDrawer>();

            return entities;
        }
    }
}
