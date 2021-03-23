using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;
using StardropPoolMinigame.Objects;
using StardropPoolMinigame.Scenes;
using System.Collections.Generic;

namespace StardropPoolMinigame.Render
{
    class StardewDrawGameScene : IDraw
    {
        public StardewDrawGameScene() { }

        public void Draw(IScene scene, SpriteBatch batch)
        {
            ((GameScene)scene).GetTable().Draw(batch);

            IList<IBall> balls = ((GameScene)scene).GetBalls();

            foreach (IBall ball in balls)
            {
                ball.Draw(batch);
            }
        }
    }
}
