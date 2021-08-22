using StardropPoolMinigame.Render.Drawers;
using StardropPoolMinigame.Scenes;
using System.Collections.Generic;

namespace StardropPoolMinigame.Render.Scenes
{
    class MenuSceneRenderer : ISceneRenderer
    {
        private IScene _scene;

        public MenuSceneRenderer(IScene scene)
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
