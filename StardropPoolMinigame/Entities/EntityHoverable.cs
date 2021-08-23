using Microsoft.Xna.Framework;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Controller;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Primitives;
using StardropPoolMinigame.Render.Drawers;

namespace StardropPoolMinigame.Entities
{
    class EntityHoverable : IEntity
    {
        protected string _id;

        private Origin _origin;

        private Vector2 _anchor;

        private bool _isHovered;

        public EntityHoverable(Origin origin, Vector2 anchor)
        {
            this._id = System.Guid.NewGuid().ToString();
            this._origin = origin;
            this._anchor = anchor;
            this._isHovered = false;
        }

        public virtual void Update()
        {
            
        }

        public Origin GetOrigin()
        {
            return this._origin;
        }

        public Vector2 GetAnchor()
        {
            return this._anchor;
        }

        public bool IsHovered()
        {
            return this._isHovered;
        }

        public Primitives.Rectangle GetBoundary()
        {
            return new Primitives.Rectangle(this.GetTopLeft(), this.GetTotalWidth(), this.GetTotalHeight());
        }

        public Primitives.Rectangle GetRawBoundary()
        {
            Vector2 topLeft = this.GetTopLeft();

            return new Primitives.Rectangle(
                new Vector2(
                    topLeft.X * RenderConstants.TileScale(),
                    topLeft.Y * RenderConstants.TileScale()),
                this.GetTotalWidth() * RenderConstants.TileScale(), 
                this.GetTotalHeight() * RenderConstants.TileScale());
        }

        public virtual string GetId()
        {
            return $"generic-hoverable-entity-{this._id}";
        }

        public virtual IDrawer GetDrawer()
        {
            return null;
        }

        public virtual float GetTotalWidth()
        {
            return 0;
        }

        public virtual float GetTotalHeight()
        {
            return 0;
        }

        public Vector2 GetTopLeft()
        {
            if (this.GetOrigin() == Origin.TopLeft)
            {
                return this._anchor;
            }
            if (this.GetOrigin() == Origin.TopCenter)
            {
                return new Vector2(this._anchor.X - (this.GetTotalWidth() / 2), this._anchor.Y);
            }
            if (this.GetOrigin() == Origin.TopRight)
            {
                return new Vector2(this._anchor.X - this.GetTotalWidth(), this._anchor.Y);
            }
            if (this.GetOrigin() == Origin.CenterLeft)
            {
                return new Vector2(this._anchor.X, this._anchor.Y - (this.GetTotalHeight() / 2));
            }
            if (this.GetOrigin() == Origin.CenterCenter)
            {
                return new Vector2(this._anchor.X - (this.GetTotalWidth() / 2), this._anchor.Y - (this.GetTotalHeight() / 2));
            }
            if (this.GetOrigin() == Origin.CenterRight)
            {
                return new Vector2(this._anchor.X - this.GetTotalWidth(), this._anchor.Y - (this.GetTotalHeight() / 2));
            }
            if (this.GetOrigin() == Origin.BottomLeft)
            {
                return new Vector2(this._anchor.X, this._anchor.Y - this.GetTotalHeight());
            }
            if (this.GetOrigin() == Origin.BottomCenter)
            {
                return new Vector2(this._anchor.X - (this.GetTotalWidth() / 2), this._anchor.Y - this.GetTotalHeight());
            }
            if (this.GetOrigin() == Origin.BottomRight)
            {
                return new Vector2(this._anchor.X - this.GetTotalWidth(), this._anchor.Y - this.GetTotalHeight());
            }
            return this._anchor;
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
