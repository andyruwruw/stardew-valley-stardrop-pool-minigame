using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StardropPoolMinigame.UserInterface
{
    class BallButton : IButton
    {
        private int _id;

        private Rectangle _boundary;

        private bool _isHovered;

        public BallButton(int id, Rectangle boundary)
        {
            this._id = id;
            this._boundary = boundary;
        }

        public void Draw(SpriteBatch batch)
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

        }

        private void DrawBall(SpriteBatch batch)
        {

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
            if (this._boundary.Contains(new Point(x, y)))
            {
                this._isHovered = true;
            } else if (this._isHovered)
            {
                this._isHovered = false;
            }
        }
    }
}
