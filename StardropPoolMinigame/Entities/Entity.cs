using Microsoft.Xna.Framework;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Render.Drawers;
using StardropPoolMinigame.Render.Filters;
using System.Collections.Generic;

namespace StardropPoolMinigame.Entities
{
    abstract class Entity : IEntity
    {
        protected string _id;

        protected Origin _origin;

        protected Vector2 _anchor;

        protected float _layerDepth;

        protected IFilter _enteringTransition;

        protected IFilter _exitingTransition;

        protected TransitionState _transitionState;

        protected IList<IFilter> _filters;

        protected IDrawer _drawer;

        public Entity(
            Origin origin,
            Vector2 anchor,
            float layerDepth,
            IFilter enteringTransition,
            IFilter exitingTransition)
        {
            this._id = System.Guid.NewGuid().ToString();
            this._origin = origin;
            this._anchor = anchor;
            this._layerDepth = layerDepth;
            this._enteringTransition = enteringTransition;
            this._exitingTransition = exitingTransition;
            this._drawer = null;

            this.InicializeFilters();

            if (this._enteringTransition != null)
            {
                this._transitionState = TransitionState.Entering;
                ((Transition)this._enteringTransition).StartTransition(this._id);
            } else
            {
                this._transitionState = TransitionState.Present;
            }
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

        public TransitionState GetTransitionState()
        {
            return this._transitionState;
        }

        public IFilter GetEnteringTransition()
        {
            return this._enteringTransition;
        }

        public IFilter GetExitingTransition()
        {
            return this._exitingTransition;
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

        public void UpdateTransitionState()
        {
            if (this._transitionState == TransitionState.Present || this._transitionState == TransitionState.Dead)
            {
                return;
            }

            if (this._transitionState == TransitionState.Entering
                && this._enteringTransition != null
                && ((Transition)this._enteringTransition).IsFinished())
            {
                this._transitionState = TransitionState.Present;
            } else if (this._transitionState == TransitionState.Exiting
                && this._exitingTransition != null
                && ((Transition)this._exitingTransition).IsFinished())
            {
                this._transitionState = TransitionState.Dead;
            }
        }

        public void SetDrawer(IDrawer drawer)
        {
            this._drawer = drawer;
        }

        public virtual IList<IFilter> GetFilters()
        {
            IList<IFilter> filters = new List<IFilter>();

            if (this.GetTransitionState() == TransitionState.Exiting)
            {
                filters.Add(this._exitingTransition);
            }
            if (this.GetTransitionState() == TransitionState.Entering)
            {
                filters.Add(this._enteringTransition);
            }

            foreach (IFilter filter in this._filters)
            {
                filters.Add(filter);
            }

            return filters;
        }

        public abstract void Update();

        public abstract string GetId();

        public abstract IDrawer GetDrawer();

        public abstract float GetTotalWidth();

        public abstract float GetTotalHeight();

        protected virtual void InicializeFilters()
        {
            this._filters = new List<IFilter>();
        }
    }
}
