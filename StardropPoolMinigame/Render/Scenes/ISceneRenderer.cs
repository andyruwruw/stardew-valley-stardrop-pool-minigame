using Microsoft.Xna.Framework.Graphics;
using StardropPoolMinigame.Scenes;

namespace StardropPoolMinigame.Render.Scenes
{
    interface ISceneRenderer
    {
        void Draw(SpriteBatch batch, IScene scene);
    }
}
