using Microsoft.Xna.Framework.Graphics;
using StardropPoolMinigame.Entities;
using StardropPoolMinigame.Helpers;
using StardropPoolMinigame.Render.Drawers;
using StardropPoolMinigame.Scenes;
using System.Collections.Generic;

namespace StardropPoolMinigame.Render.Scenes
{
    class SceneRenderer : ISceneRenderer
    {
        protected IScene _scene;

        public SceneRenderer(IScene scene)
        {
            this._scene = scene;
        }

        public void Draw(SpriteBatch batch)
        {
            Logger.Info("Drawing Scene Entities");
            IList<IEntity> entities = this.GetEntities();

            foreach (IEntity entity in entities)
            {
                entity.GetDrawer().Draw(batch);
            }
        }

        public IList<IDrawer> GetDrawers()
        {
            IList<IDrawer> drawers = new List<IDrawer>();
            IList<IEntity> entities = this.GetEntities();

            foreach (IEntity entity in entities)
            {
                drawers.Add(entity.GetDrawer());
            }

            return drawers;
        }

        public IList<IEntity> GetEntities()
        {
            return this._scene.GetEntities();
        }
    }
}
