using StardropPoolMinigame.Render.Drawers;
using StardropPoolMinigame.Scenes;
using System.Collections.Generic;

namespace StardropPoolMinigame.Render.Scenes
{
    class GameSceneRenderer : ISceneRenderer
    {
        private IScene _scene;

        public GameSceneRenderer(IScene scene)
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
