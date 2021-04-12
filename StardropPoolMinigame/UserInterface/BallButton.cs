using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;
using StardropPoolMinigame.Objects;
using StardropPoolMinigame.Render;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StardropPoolMinigame.UserInterface
{
    class BallButton : Button
    {
        private string _text;

        private Color _color;

        private bool _stripped;

        private int _xOrientation;

        private int _yOrientation;

        public BallButton(int id, Vector2 position, string text, Color color, bool stripped) : base(id, position)
        {
            this._text = text;
            this._color = color;
            this._stripped = stripped;

            this._xOrientation = 0;
            this._yOrientation = 0;
        }

        public override void Draw(SpriteBatch batch)
        {
            this.DrawText(batch);
            this.DrawBall(batch);

            if (this._isHovered)
            {
                this.DrawCue(batch);
            }
        }

        private void DrawText(SpriteBatch batch)
        {
            batch.DrawString(Game1.dialogueFont, this._text, new Vector2(0, 0), Color.Black);
        }

        private void DrawBall(SpriteBatch batch)
        {
            int scale = (int)Math.Round(Ball.Radius * 3 * DrawMath.PixelZoomAdjustement);
            Rectangle destination = new Microsoft.Xna.Framework.Rectangle((int)(this._position.X - Ball.Radius * 1.615), (int)(this._position.Y - Ball.Radius * 1.465), scale, scale);

            // Base Color
            batch.Draw(Textures.TileSheet, destination, Textures.GetBallBaseTexture(this._color), Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.0020f);

            // Core
            batch.Draw(Textures.TileSheet, destination, Textures.GetBallCoreTexture((int)Math.Round(this._xOrientation / Feel.OrientationChange), (int)Math.Round(this._yOrientation / Feel.OrientationChange)), Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.0021f);

            if (this._stripped)
            {
                batch.Draw(Textures.TileSheet, destination, Textures.GetBallStripeTexture((int)Math.Round(this._xOrientation / Feel.OrientationChange), (int)Math.Round(this._yOrientation / Feel.OrientationChange)), Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.0021f);
            }

            // Shadow
            batch.Draw(Textures.TileSheet, destination, Textures.BallShadows, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.0022f);
        }

        protected override void GenerateBoundary()
        {
            this._boundary = new Structures.Rectangle(this._position.X, this._position.Y, Ball.Radius * 3 * DrawMath.PixelZoomAdjustement, Ball.Radius * 3 * DrawMath.PixelZoomAdjustement);
        }

        private void DrawCue(SpriteBatch batch)
        {

        }

        public bool isHovered()
        {
            return this._isHovered;
        }

        public int GetId()
        {
            return this._id;
        }

        public void Update(int x, int y)
        {
            if (this._boundary.Contains(new Vector2(x, y)))
            {
                this._isHovered = true;
            } else if (this._isHovered)
            {
                this._isHovered = false;
            }
        }
    }
}
