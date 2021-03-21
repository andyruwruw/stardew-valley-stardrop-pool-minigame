using Microsoft.Xna.Framework.Graphics;
using StardropPoolMinigame.Scenes;
using System.Collections.Generic;

namespace StardropPoolMinigame.Render
{
    class StardewDrawGameScene : IDraw
    {
        public StardewDrawGameScene() { }

        public void draw(IScene scene, SpriteBatch batch)
        {
            IList<IBall> balls = ((GameScene)scene).GetBalls();

            foreach (IBall ball in balls)
            {
                ball.Draw(batch);
            }
        }
    }
}
