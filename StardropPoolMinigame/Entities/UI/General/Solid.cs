using Microsoft.Xna.Framework;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Render.Drawers;
using StardropPoolMinigame.Render.Filters;

namespace StardropPoolMinigame.Entities
{
    internal class Solid : Entity
    {
        private Color _color;

        private Primitives.Rectangle _destination;

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

        public Color GetColor()
        {
            return this._color;
        }

        public Primitives.Rectangle GetDestination()
        {
            return this._destination;
        }

        public override string GetId()
        {
            return $"solid-{this._id}";
        }

        public Rectangle GetRawXnaDestination()
        {
            return this._destination.GetRawXnaRectangle();
        }

        public override float GetTotalHeight()
        {
            return this._destination.GetHeight();
        }

        public override float GetTotalWidth()
        {
            return this._destination.GetWidth();
        }

        public Rectangle GetXnaDestination()
        {
            return this._destination.GetXnaRectangle();
        }

        public bool IsRawCoords()
        {
            return this._isRawCoords;
        }
    }
}