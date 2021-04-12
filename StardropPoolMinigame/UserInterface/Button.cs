using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StardropPoolMinigame.UserInterface
{
    abstract class Button : IButton
    {
        protected int _id;

        protected Vector2 _position;

        protected Structures.Rectangle _boundary;

        protected bool _isHovered;

        public Button(int id, Vector2 position)
        {
            this._id = id;
            this._position = position;
            this._isHovered = false;
            GenerateBoundary();
        }

        public abstract void Draw(SpriteBatch batch);

        protected abstract void GenerateBoundary();

        public void Update()
        {
            if (this._boundary.Contains(new Vector2(Game1.getMousePosition().X, Game1.getMousePosition().Y)))
            {
                this._isHovered = true;
            } else
            {
                this._isHovered = false;
            }
        }
    }
}
