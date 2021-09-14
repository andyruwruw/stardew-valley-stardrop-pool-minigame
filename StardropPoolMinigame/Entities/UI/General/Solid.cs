using Microsoft.Xna.Framework;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Render.Drawers;
using StardropPoolMinigame.Render.Filters;

namespace StardropPoolMinigame.Entities
{
    class Solid : Entity
    {
        private Primitives.Rectangle _destination;

        private Color _color;

        private bool _isRawCoords;

        public Solid(
            Primitives.Rectangle destination,
            float layerDepth,
            IFilter enteringTransition,
            IFilter exitingTransition,
            Color color,
            bool isRawCoords = false
        ) : base(
            Origin.TopLeft,
            destination.GetNorthWestCorner(),
            layerDepth,
            enteringTransition,
            exitingTransition)
        {
            this._destination = destination;
            this._color = color;
            this._isRawCoords = isRawCoords;

            this.SetDrawer(new SolidDrawer(this));
        }

        public override string GetId()
        {
            return $"solid-{this._id}";
        }

        public override float GetTotalHeight()
        {
            return this._destination.GetHeight();
        }

        public override float GetTotalWidth()
        {
            return this._destination.GetWidth();
        }

        public Primitives.Rectangle GetDestination()
        {
            return this._destination;
        }

        public Rectangle GetXnaDestination()
        {
            return this._destination.GetXnaRectangle();
        }

        public Rectangle GetRawXnaDestination()
        {
            return this._destination.GetRawXnaRectangle();
        }

        public Color GetColor()
        {
            return this._color;
        }

        public bool IsRawCoords()
        {
            return this._isRawCoords;
        }
    }
}
