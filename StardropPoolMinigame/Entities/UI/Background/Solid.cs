using Microsoft.Xna.Framework;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Render.Drawers;
using StardropPoolMinigame.Render.Filters;

namespace StardropPoolMinigame.Entities
{
    class Solid : EntityStatic
    {
        private Primitives.Rectangle _destination;

        private Color _color;

        public Solid(
            Origin origin,
            Vector2 anchor,
            float layerDepth,
            IFilter enteringTransition,
            IFilter exitingTransition,
            Primitives.Rectangle destination,
            Color color
        ) : base(
            origin,
            anchor,
            layerDepth,
            enteringTransition,
            exitingTransition)
        {
            this._destination = destination;
            this._color = color;

            this.SetDrawer(new SolidDrawer(this));
        }

        public override void Update()
        {
            this.UpdateTransitionState();
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

        public Color GetColor()
        {
            return this._color;
        }
    }
}
