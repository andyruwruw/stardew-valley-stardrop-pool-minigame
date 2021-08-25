using Microsoft.Xna.Framework;
using StardropPoolMinigame.Controller;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Render.Filters;

namespace StardropPoolMinigame.Entities
{
    abstract class EntityHoverable : Entity
    {
        private bool _isHovered;

        public EntityHoverable(
            Origin origin,
            Vector2 anchor,
            float layerDepth,
            IFilter enteringTransition,
            IFilter exitingTransition
        ) : base(
            origin,
            anchor,
            layerDepth,
            enteringTransition,
            exitingTransition)
        {
            this._isHovered = false;
        }

        public bool IsHovered()
        {
            return this._isHovered;
        }

        public override string GetId()
        {
            return $"generic-hoverable-entity-{this._id}";
        }

        public virtual void ClickCallback()
        {
        }

        protected void UpdateHoverable()
        {
            if (this._transitionState == TransitionState.Present && this.GetRawBoundary().Contains(Cursor.Position))
            {
                if (!this._isHovered)
                {
                    this.HoveredCallback();
                }
                this._isHovered = true;
            }
            else if (this._isHovered)
            {
                this._isHovered = false;
            }
        }

        protected virtual void HoveredCallback()
        {
        }
    }
}
