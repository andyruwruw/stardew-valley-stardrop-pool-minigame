using Microsoft.Xna.Framework.Graphics;
using StardropPoolMinigame.Scenes;

namespace StardropPoolMinigame.Render
{
    interface IRenderer
    {
        void Draw(SpriteBatch batch, IScene scene);
    }
}
