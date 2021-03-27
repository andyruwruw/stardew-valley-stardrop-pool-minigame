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
            this.DrawBackground(scene, batch);
            this.DrawTable(scene, batch);
            this.DrawBalls(scene, batch);
            this.DrawCue(scene, batch);
        }

        private void DrawBackground(IScene scene, SpriteBatch batch)
        {
            batch.Draw(Game1.staminaRect, new Rectangle((int)DrawMath.GetGameDisplayNorthWest().X, (int)DrawMath.GetGameDisplayNorthWest().Y, (int)DrawMath.AdjustedScreenWidth, (int)DrawMath.AdjustedScreenHeight), Game1.staminaRect.Bounds, Color.LightGoldenrodYellow, 0f, Vector2.Zero, SpriteEffects.None, 0.0001f);
        }

        private void DrawTable(IScene scene, SpriteBatch batch)
        {
            ((GameScene)scene).GetTable().Draw(batch);
        }

        private void DrawBalls(IScene scene, SpriteBatch batch)
        {
            IList<IBall> balls = ((GameScene)scene).GetBalls();

            foreach (IBall ball in balls)
            {
                ball.Draw(batch);
            }
        }

        private void DrawCue(IScene scene, SpriteBatch batch)
        {
            if (((GameScene)scene).GetTurnState() == TurnState.SelectingAngle ||
                ((GameScene)scene).GetTurnState() == TurnState.SelectingPower ||
                ((GameScene)scene).GetTurnState() == TurnState.MovingBalls)
            {
                Point mouse = Game1.getMousePositionRaw();

                ((GameScene)scene).GetCurrentPlayer().GetCue().Draw(batch, mouse.X, mouse.Y);
            }
        }
    }
}
