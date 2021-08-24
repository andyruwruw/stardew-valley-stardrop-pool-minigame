using Microsoft.Xna.Framework;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Render.Drawers;

namespace StardropPoolMinigame.Entities
{
    class Entity : IEntity
    {
        protected string _id;

        protected Origin _origin;

        protected Vector2 _anchor;

        protected float _layerDepth;

        public Entity(Origin origin, Vector2 anchor, float layerDepth)
        {
            this._id = System.Guid.NewGuid().ToString();
            this._origin = origin;
            this._anchor = anchor;
            this._layerDepth = layerDepth;
        }

        public virtual void Update()
        {
        }

        public virtual string GetId()
        {
            return $"generic-entity-{this._id}";
        }

        public virtual IDrawer GetDrawer()
        {
            return null;
        }

        public Origin GetOrigin()
        {
            return this._origin;
        }

        public Vector2 GetAnchor()
        {
            return this._anchor;
        }

        public float GetLayerDepth()
        {
            return this._layerDepth;
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

        public Primitives.Rectangle GetBoundary()
        {
            return new Primitives.Rectangle(this.GetTopLeft(), this.GetTotalWidth(), this.GetTotalHeight());
        }

        public Primitives.Rectangle GetRawBoundary()
        {
            Vector2 topLeft = this.GetTopLeft();

            return new Primitives.Rectangle(
                new Vector2(
                    topLeft.X * RenderConstants.TileScale() + RenderConstants.AdjustedScreenWidthMargin(),
                    topLeft.Y * RenderConstants.TileScale() + RenderConstants.AdjustedScreenHeightMargin()),
                this.GetTotalWidth() * RenderConstants.TileScale(),
                this.GetTotalHeight() * RenderConstants.TileScale());
        }
    }
}
