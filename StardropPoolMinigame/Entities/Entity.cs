using Microsoft.Xna.Framework;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Render.Drawers;

namespace StardropPoolMinigame.Entities
{
    class Entity : IEntity
    {
        protected string _id;

        protected Origin _origin;

        protected Vector2 _anchor;

        public Entity(Origin origin, Vector2 anchor)
        {
            this._id = System.Guid.NewGuid().ToString();
            this._origin = origin;
            this._anchor = anchor;
        }

        public virtual void Update()
        {

        }

        public virtual string GetId()
        {
            return $"generic-entity-{this._id}";
        }

        public Origin GetOrigin()
        {
            return this._origin;
        }

        public Vector2 GetAnchor()
        {
            return this._anchor;
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
    }
}
