using Microsoft.Xna.Framework;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Controller;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Render.Drawers;
using StardropPoolMinigame.Render.Filters;
using System.Collections.Generic;

namespace StardropPoolMinigame.Entities
{
    /// <inheritdoc cref="IEntity"/>
    internal abstract class Entity : IEntity
    {
        /// <summary>
        /// <see cref="IEntity">IEntity's</see> anchor, or position.
        /// </summary>
        protected Vector2 _anchor;

        /// <summary>
        /// <see cref="IEntity">IEntity's</see> <see cref="IDrawer"/> for rendering.
        /// </summary>
        protected IDrawer _drawer;

        /// <summary>
        /// <see cref="IEntity">IEntity's</see> entering <see cref="Transition"/>.
        /// </summary>
        protected IFilter _enteringTransition;

        /// <summary>
        /// <see cref="IEntity">IEntity's</see> exiting <see cref="Transition"/>.
        /// </summary>
        protected IFilter _exitingTransition;

        /// <summary>
        /// <see cref="IEntity">IEntity's</see> perminant <see cref="IFilter">IFilters</see>.
        /// </summary>
        protected IList<IFilter> _filters;

        /// <summary>
        /// <see cref="IEntity">IEntity's</see> unique identifier.
        /// </summary>
        protected string _id;

        /// <summary>
        /// Whether the <see cref="Entity"/> is being hovered by the cursor.
        /// </summary>
        protected bool _isHovered;

        /// <summary>
        /// <see cref="IEntity">IEntity's</see> layer depth for rendering.
        /// </summary>
        protected float _layerDepth;

        /// <summary>
        /// Anchor's relation to <see cref="IEntity">IEntity's</see> position.
        /// </summary>
        protected Origin _origin;

        /// <summary>
        /// <see cref="IEntity">IEntity's</see> current <see cref="TransitionState"/>.
        /// </summary>
        protected TransitionState _transitionState;

        /// <summary>
        /// <para>Instantiates an <see cref="Entity"/>.</para>
        /// </summary>
        /// <param name="origin">Anchor's relation to <see cref="IEntity">IEntity's</see> position</param>
        /// <param name="anchor"><see cref="IEntity">IEntity's</see> anchor, or position<inheritdoc cref="_anchor"/></param>
        /// <param name="layerDepth"><see cref="IEntity">IEntity's</see> layer depth for rendering</param>
        /// <param name="enteringTransition"><see cref="IEntity">IEntity's</see> entering <see cref="Transition"/></param>
        /// <param name="exitingTransition"><see cref="IEntity">IEntity's</see> exiting <see cref="Transition"/></param>
        public Entity(
            Origin origin,
            Vector2 anchor,
            float layerDepth,
            IFilter enteringTransition,
            IFilter exitingTransition)
        {
            this._anchor = anchor;
            this._drawer = null;
            this._enteringTransition = enteringTransition;
            this._exitingTransition = exitingTransition;
            this._isHovered = false;
            this._id = System.Guid.NewGuid().ToString();
            this._layerDepth = layerDepth;
            this._origin = origin;

            this.InicializeFilters();
            this.InicializeTransitionState();
        }

        /// <inheritdoc cref="IEntity.ClickCallback"/>
        public virtual void ClickCallback()
        {
        }

        /// <inheritdoc cref="IEntity.GetAnchor"/>
        public virtual Vector2 GetAnchor()
        {
            return this._anchor;
        }

        /// <inheritdoc cref="IEntity.GetCenter"/>
        public virtual Primitives.Rectangle GetBoundary()
        {
            return new Primitives.Rectangle(
                this.GetTopLeft(),
                this.GetTotalWidth(),
                this.GetTotalHeight());
        }

        /// <inheritdoc cref="IEntity.GetCenter"/>
        public virtual Vector2 GetCenter()
        {
            if (this.GetOrigin() == Origin.TopLeft)
            {
                return Vector2.Add(this._anchor, new Vector2(this.GetTotalWidth() / 2, this.GetTotalHeight() / 2));
            }
            if (this.GetOrigin() == Origin.TopCenter)
            {
                return Vector2.Add(this._anchor, new Vector2(0, this.GetTotalHeight() / 2));
            }
            if (this.GetOrigin() == Origin.TopRight)
            {
                return Vector2.Add(this._anchor, new Vector2(this.GetTotalWidth() / -2, this.GetTotalHeight() / 2));
            }
            if (this.GetOrigin() == Origin.CenterLeft)
            {
                return Vector2.Add(this._anchor, new Vector2(this.GetTotalWidth() / 2, 0));
            }
            if (this.GetOrigin() == Origin.CenterCenter)
            {
                return this._anchor;
            }
            if (this.GetOrigin() == Origin.CenterRight)
            {
                return Vector2.Add(this._anchor, new Vector2(this.GetTotalWidth() / -2, 0));
            }
            if (this.GetOrigin() == Origin.BottomLeft)
            {
                return Vector2.Add(this._anchor, new Vector2(this.GetTotalWidth() / 2, this.GetTotalHeight() / -2));
            }
            if (this.GetOrigin() == Origin.BottomCenter)
            {
                return Vector2.Add(this._anchor, new Vector2(0, this.GetTotalHeight() / -2));
            }
            if (this.GetOrigin() == Origin.BottomRight)
            {
                return Vector2.Add(this._anchor, new Vector2(this.GetTotalWidth() / -2, this.GetTotalHeight() / -2));
            }
            return this._anchor;
        }

        /// <inheritdoc cref="IEntity.GetDrawer"/>
        public virtual IDrawer GetDrawer()
        {
            return this._drawer;
        }

        /// <inheritdoc cref="IEntity.GetEnteringTransition"/>
        public virtual IFilter GetEnteringTransition()
        {
            return this._enteringTransition;
        }

        /// <inheritdoc cref="IEntity.GetExitingTransition"/>
        public virtual IFilter GetExitingTransition()
        {
            return this._exitingTransition;
        }

        /// <inheritdoc cref="IEntity.GetFilters"/>
        public virtual IList<IFilter> GetFilters()
        {
            IList<IFilter> filters = new List<IFilter>();

            if (this.GetTransitionState() == TransitionState.Exiting && this._exitingTransition != null)
            {
                filters.Add(this._exitingTransition);
            }
            if (this.GetTransitionState() == TransitionState.Entering && this._enteringTransition != null)
            {
                filters.Add(this._enteringTransition);
            }

            foreach (IFilter filter in this._filters)
            {
                filters.Add(filter);
            }

            return filters;
        }

        /// <inheritdoc cref="IEntity.GetId"/>
        public abstract string GetId();

        /// <inheritdoc cref="IEntity.GetLayerDepth"/>
        public virtual float GetLayerDepth()
        {
            return this._layerDepth;
        }

        /// <inheritdoc cref="IEntity.GetOrigin"/>
        public virtual Origin GetOrigin()
        {
            return this._origin;
        }

        /// <inheritdoc cref="IEntity.GetRawBoundary"/>
        public virtual Primitives.Rectangle GetRawBoundary()
        {
            Vector2 topLeft = this.GetTopLeft();

            return new Primitives.Rectangle(
                new Vector2(
                    topLeft.X * RenderConstants.TileScale() + RenderConstants.AdjustedScreen.Margin.Width(),
                    topLeft.Y * RenderConstants.TileScale() + RenderConstants.AdjustedScreen.Margin.Height()),
                this.GetTotalWidth() * RenderConstants.TileScale(),
                this.GetTotalHeight() * RenderConstants.TileScale());
        }

        /// <inheritdoc cref="IEntity.GetTopLeft"/>
        public virtual Vector2 GetTopLeft()
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

        /// <inheritdoc cref="IEntity.GetTotalWidth"/>
        public abstract float GetTotalHeight();

        /// <inheritdoc cref="IEntity.GetTotalHeight"/>
        public abstract float GetTotalWidth();

        /// <inheritdoc cref="IEntity.GetTransitionState"/>
        public virtual TransitionState GetTransitionState()
        {
            return this._transitionState;
        }

        /// <inheritdoc cref="IEntity.HoverCallback"/>
        public virtual void HoverCallback()
        {
        }

        /// <inheritdoc cref="IEntity.IsHovered"/>
        public bool IsHovered()
        {
            return this._isHovered;
        }

        /// <inheritdoc cref="IEntity.SetAnchor(Vector2)"/>
        public virtual void SetAnchor(Vector2 anchor)
        {
            this._anchor = anchor;
        }

        /// <inheritdoc cref="IEntity.SetEnteringTransition"/>
        public void SetEnteringTransition(IFilter transition)
        {
            this._enteringTransition = transition;
        }

        /// <inheritdoc cref="IEntity.SetExitingTransition"/>
        public void SetExitingTransition(IFilter transition)
        {
            this._exitingTransition = transition;
        }

        /// <inheritdoc cref="IEntity.SetTransitionState(TransitionState, bool)"/>
        public virtual void SetTransitionState(TransitionState transitionState, bool start = false)
        {
            this._transitionState = transitionState;
            if (this._transitionState == TransitionState.Entering
                && this._enteringTransition != null
                && start)
            {
                ((Transition)this._enteringTransition).ResetTransition();
                ((Transition)this._enteringTransition).SetKey(this._id);
                ((Transition)this._enteringTransition).StartFilter();
            }
            if (this._transitionState == TransitionState.Exiting
                && this._exitingTransition != null
                && start)
            {
                ((Transition)this._exitingTransition).ResetTransition();
                ((Transition)this._exitingTransition).SetKey(this._id);
                ((Transition)this._exitingTransition).StartFilter();
            }
        }

        /// <inheritdoc cref="IEntity.Update"/>
        public virtual void Update()
        {
            this.UpdateTransitionState();
            this.UpdateHover();
        }

        /// <summary>
        /// Inicializes <see cref="_filters"/> as an empty list of <see cref="IFilter">IFilters</see>.
        /// </summary>
        protected virtual void InicializeFilters()
        {
            this._filters = new List<IFilter>();
        }

        /// <summary>
        /// Inicializes <see cref="_transitionState"/> based on presence of <see cref="_enteringTransition"/>.
        /// </summary>
        protected virtual void InicializeTransitionState()
        {
            if (this._enteringTransition != null)
            {
                this._transitionState = TransitionState.Entering;
                this._enteringTransition.SetKey(this._id);
                ((Transition)this._enteringTransition).StartFilter();
            }
            else
            {
                this._transitionState = TransitionState.Present;
            }
        }

        /// <summary>
        /// Sets <see cref="Entity">Entity's</see> <see cref="_drawer"/> for rendering.
        /// </summary>
        /// <param name="drawer"><see cref="IDrawer"/> for <see cref="Entity"/></param>
        protected virtual void SetDrawer(IDrawer drawer)
        {
            this._drawer = drawer;
        }

        /// <summary>
        /// Updates <see cref="Entity">Entity's</see> <see cref="_isHovered"/> based on <see cref="Mouse"/> position.
        /// </summary>
        protected void UpdateHover()
        {
            if (this._transitionState == TransitionState.Present && this.GetRawBoundary().Contains(Mouse.Position))
            {
                if (!this._isHovered)
                {
                    this.HoverCallback();
                }
                this._isHovered = true;
            }
            else if (this._isHovered)
            {
                this._isHovered = false;
            }
        }

        /// <summary>
        /// Updates <see cref="Entity">Entity's</see> <see cref="_transitionState"/> based on current <see cref="Transition"/>.
        /// </summary>
        protected void UpdateTransitionState()
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
            }
            else if (this._transitionState == TransitionState.Exiting
              && ((this._exitingTransition != null && ((Transition)this._exitingTransition).IsFinished())
                  || this._exitingTransition == null))
            {
                this._transitionState = TransitionState.Dead;
            }
        }
    }
}