using Microsoft.Xna.Framework;
using StardropPoolMinigame.Controller;
using StardropPoolMinigame.Enums;

namespace StardropPoolMinigame.Entities
{
    class EntityHoverable : Entity
    {
        private bool _isHovered;

        public EntityHoverable(Origin origin, Vector2 anchor, float layerDepth) : base(origin, anchor, layerDepth)
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

        protected void UpdateHoverable()
        {
            if (this.GetRawBoundary().Contains(Cursor.Position))
            {
                this._isHovered = true;
            }
            else if (this._isHovered)
            {
                this._isHovered = false;
            }
        }
    }
}
