using StardropPoolMinigame.Controller;
using StardropPoolMinigame.Primitives;

namespace StardropPoolMinigame.Behaviors.Attributes
{
    class Hoverable
    {
        private bool _isHovered;

        private Rectangle _boundary;

        public Hoverable(Rectangle boundary)
        {
            this._boundary = boundary;
            this._isHovered = false;
        }

        public void UpdateHoverable()
        {
            if (this._boundary.Contains(Cursor.Position))
            {
                this._isHovered = true;
            } else if (this._isHovered)
            {
                this._isHovered = false;
            }
        }

        public bool IsHovered()
        {
            return this._isHovered;
        }
    }
}
