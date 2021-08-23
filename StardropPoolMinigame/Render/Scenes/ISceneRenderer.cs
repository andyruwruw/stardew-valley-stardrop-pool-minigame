using Microsoft.Xna.Framework.Graphics;
using StardropPoolMinigame.Entities;
using System.Collections.Generic;

namespace StardropPoolMinigame.Render.Scenes
{
    interface ISceneRenderer
    {
        void Draw(SpriteBatch batch);

        IList<IEntity> GetEntities();
    }
}
