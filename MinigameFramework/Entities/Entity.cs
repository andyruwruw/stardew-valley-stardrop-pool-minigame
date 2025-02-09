using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MinigameFramework.Enums;
using MinigameFramework.Controls;
using MinigameFramework.Helpers;
using MinigameFramework.Render.Filters;
using MinigameFramework.Render.Filters.Transitions;
using MinigameFramework.Constants;
using MinigameFramework.Render;
using MinigameFramework.Structures.Primitives;

namespace MinigameFramework.Entities
{
    /// <inheritdoc cref="IEntity"/>
    abstract class Entity : IEntity
    {
        /// <summary>
		/// <see cref="IEntity">IEntity's</see> anchor, or position.
		/// </summary>
		protected Vector2 _anchor;

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
		/// Whether the <see cref="Entity"/> is being hovered by the cursor.
		/// </summary>
		protected bool _isHovered;

        /// <summary>
        /// <see cref="IEntity">IEntity's</see> unique identifier.
        /// </summary>
        protected string _id;

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
		/// <param name="anchor"><see cref="Entity">Entity's</see> anchor, or position<inheritdoc cref="_anchor"/></param>
		/// <param name="layerDepth"><see cref="Entity">Entity's</see> layer depth for rendering</param>
		/// <param name="origin">Anchor's relation to <see cref="Entity">Entity's</see> position</param>
		/// <param name="enteringTransition"><see cref="Entity">Entity's</see> entering <see cref="Transition"/></param>
		/// <param name="exitingTransition"><see cref="Entity">Entity's</see> exiting <see cref="Transition"/></param>
		public Entity(
            Vector2 anchor,
            float layerDepth = 0,
            Origin origin = Origin.TopLeft,
            IFilter? enteringTransition = null,
            IFilter? exitingTransition = null
        ) {
            _anchor = anchor;
            _layerDepth = layerDepth;
            _origin = origin;
            _enteringTransition = enteringTransition;
            _exitingTransition = exitingTransition;
            
            _id = Guid.NewGuid().ToString();
            _isHovered = false;

            InitializeFilters();
            InitializeTransitionState();
        }

        /// <inheritdoc cref="IEntity.Draw"/>
        public virtual void Draw(
            SpriteBatch batch,
            Vector2? overrideDestination = null,
            Microsoft.Xna.Framework.Rectangle? overrideSource = null,
            Color? overrideColor = null,
            float? overrideRotation = null,
            Vector2? overrideOrigin = null,
            float? overrideScale = null,
            SpriteEffects? overrideEffects = null,
            float? overrideLayerDepth = null
        )
        {
            batch.Draw(
                GetTileset(),
                GetDestination(overrideDestination),
                GetSource(overrideSource),
                GetColor(overrideColor),
                GetRotation(overrideRotation),
                GetOrigin(overrideOrigin),
                GetScale(overrideScale),
                GetEffects(overrideEffects),
                GetLayerDepth(overrideLayerDepth)
            );

            if (DevConstants.DebugVisuals)
            {
                DrawDebug(batch);
            }
        }

        /// <inheritdoc cref="IEntity.GetAnchor"/>
		public virtual Vector2 GetAnchor()
        {
            return _anchor;
        }

        /// <inheritdoc cref="IEntity.GetBoundary"/>
		public virtual IRange GetBoundary()
        {
            Vector2 topLeft = GetTopLeft();

            return new Structures.Primitives.Rectangle(
                topLeft,
                GetWidth(),
                GetHeight()
            );
        }

        /// <inheritdoc cref="IEntity.GetCenter"/>
		public virtual Vector2 GetCenter()
        {
            if (GetOrigin() == Origin.TopLeft)
                return Vector2.Add(_anchor, new Vector2(GetWidth() / 2, GetHeight() / 2));

            if (GetOrigin() == Origin.TopCenter) return Vector2.Add(_anchor, new Vector2(0, GetHeight() / 2));

            if (GetOrigin() == Origin.TopRight)
                return Vector2.Add(_anchor, new Vector2(GetWidth() / -2, GetHeight() / 2));

            if (GetOrigin() == Origin.CenterLeft) return Vector2.Add(_anchor, new Vector2(GetWidth() / 2, 0));

            if (GetOrigin() == Origin.CenterCenter) return _anchor;

            if (GetOrigin() == Origin.CenterRight) return Vector2.Add(_anchor, new Vector2(GetWidth() / -2, 0));

            if (GetOrigin() == Origin.BottomLeft)
                return Vector2.Add(_anchor, new Vector2(GetWidth() / 2, GetHeight() / -2));

            if (GetOrigin() == Origin.BottomCenter) return Vector2.Add(_anchor, new Vector2(0, GetHeight() / -2));

            if (GetOrigin() == Origin.BottomRight)
                return Vector2.Add(_anchor, new Vector2(GetWidth() / -2, GetHeight() / -2));

            return _anchor;
        }

        /// <inheritdoc cref="IEntity.GetEnteringTransition"/>
		public virtual IFilter GetEnteringTransition()
        {
            return _enteringTransition;
        }

        /// <inheritdoc cref="IEntity.GetEntities"/>
        public virtual IList<IEntity> GetEntities()
        {
            return new List<IEntity>();
        }

        /// <inheritdoc cref="IEntity.GetExitingTransition"/>
        public virtual IFilter GetExitingTransition()
        {
            return _exitingTransition;
        }

        /// <inheritdoc cref="IEntity.GetFilters"/>
		public virtual IList<IFilter> GetFilters()
        {
            IList<IFilter> filters = new List<IFilter>();

            if (GetTransitionState() == TransitionState.Exiting && _exitingTransition != null)
                filters.Add(_exitingTransition);

            if (GetTransitionState() == TransitionState.Entering && _enteringTransition != null)
                filters.Add(_enteringTransition);

            foreach (var filter in _filters) filters.Add(filter);

            return filters;
        }

        /// <inheritdoc cref="IEntity.GetHeight"/>
		public abstract float GetHeight();

        /// <inheritdoc cref="IEntity.GetId"/>
        public abstract string GetId();

        /// <inheritdoc cref="IEntity.GetLayerDepth"/>
        public virtual float GetLayerDepth()
        {
            return _layerDepth;
        }

        /// <inheritdoc cref="IEntity.GetOrigin"/>
        public virtual Origin GetOrigin()
        {
            return _origin;
        }

        /// <inheritdoc cref="IEntity.GetRawBoundary"/>
		public virtual Structures.Primitives.Rectangle GetRawBoundary()
        {
            var topLeft = GetTopLeft();

            return new Structures.Primitives.Rectangle(
                new Vector2(
                    topLeft.X * RenderHelpers.TileScale() + RenderHelpers.AdjustedScreen.Margin.Width(),
                    topLeft.Y * RenderHelpers.TileScale() + RenderHelpers.AdjustedScreen.Margin.Height()),
                GetWidth() * RenderHelpers.TileScale(),
                GetHeight() * RenderHelpers.TileScale());
        }

        /// <inheritdoc cref="IEntity.GetRawSource"/>
        public virtual Microsoft.Xna.Framework.Rectangle GetRawSource()
        {
            return new Microsoft.Xna.Framework.Rectangle(
                0,
                0,
                1,
                1
            );
        }

        /// <inheritdoc cref="IEntity.GetTopLeft"/>
		public virtual Vector2 GetTopLeft()
        {
            switch (GetOrigin())
            {
                case Origin.TopCenter:
                    return new Vector2(
                        _anchor.X - GetWidth() / 2,
                        _anchor.Y
                    );
                case Origin.TopRight:
                    return new Vector2(
                        _anchor.X - GetWidth(),
                        _anchor.Y
                    );
                case Origin.CenterLeft:
                    return new Vector2(
                        _anchor.X,
                        _anchor.Y - GetHeight() / 2
                    );
                case Origin.CenterCenter:
                    return new Vector2(
                        _anchor.X - GetWidth() / 2,
                        _anchor.Y - GetHeight() / 2
                    );
                case Origin.CenterRight:
                    return new Vector2(
                        _anchor.X - GetWidth(),
                        _anchor.Y - GetHeight() / 2
                    );
                case Origin.BottomLeft:
                    return new Vector2(
                        _anchor.X,
                        _anchor.Y - GetHeight()
                    );
                case Origin.BottomCenter:
                    return new Vector2(
                        _anchor.X - GetWidth() / 2,
                        _anchor.Y - GetHeight()
                    );
                case Origin.BottomRight:
                    return new Vector2(
                        _anchor.X - GetWidth(),
                        _anchor.Y - GetHeight()
                    );
                case Origin.TopLeft:
                default:
                    return _anchor;
            }
        }

        /// <inheritdoc cref="IEntity.GetTransitionState"/>
		public virtual TransitionState GetTransitionState()
        {
            return _transitionState;
        }

        /// <inheritdoc cref="IEntity.GetWidth"/>
        public abstract float GetWidth();

        /// <inheritdoc cref="IEntity.HandleHover"/>
		public virtual void HandleHover()
        {
        }

        /// <inheritdoc cref="IEntity.HandleLeftClick"/>
		public virtual void HandleLeftClick()
        {
        }

        /// <inheritdoc cref="IEntity.HandleRightClick"/>
		public virtual void HandleRightClick()
        {
        }

        /// <inheritdoc cref="IEntity.IsHovered"/>
		public virtual bool IsHovered()
        {
            return _isHovered;
        }

        /// <inheritdoc cref="IEntity.SetAnchor"/>
		public virtual void SetAnchor(Vector2 anchor)
        {
            _anchor = anchor;
        }

        /// <inheritdoc cref="IEntity.SetEnteringTransition"/>
        public virtual void SetEnteringTransition(IFilter transition)
        {
            _enteringTransition = transition;
        }

        /// <inheritdoc cref="IEntity.SetExitingTransition"/>
        public virtual void SetExitingTransition(IFilter transition)
        {
            _exitingTransition = transition;
        }

        /// <inheritdoc cref="IEntity.GetTransitionState"/>
        public virtual void SetTransitionState(
            TransitionState state,
            bool start = false
        ) {
            _transitionState = state;

            if (_transitionState == TransitionState.Entering
                && _enteringTransition != null
                && start)
            {
                ((Transition)_enteringTransition).ResetTransition();
                ((Transition)_enteringTransition).SetKey(_id);
                ((Transition)_enteringTransition).Start();
            }

            if (_transitionState == TransitionState.Exiting
                && _exitingTransition != null
                && start)
            {
                ((Transition)_exitingTransition).ResetTransition();
                ((Transition)_exitingTransition).SetKey(_id);
                ((Transition)_exitingTransition).Start();
            }
        }

        /// <inheritdoc cref="IEntity.ShouldDraw"/>
        public virtual bool ShouldDraw()
        {
            return GetTransitionState() != TransitionState.Dead;
        }

        /// <inheritdoc cref="IEntity.Update"/>
		public virtual void Update(GameTime time)
        {
            UpdateTransitionState();
            UpdateHover();
        }

        /// <summary>
        /// Draws debug visuals if turned on.
        /// </summary>
        protected virtual void DrawDebug(SpriteBatch batch) { }

        /// <summary>
        /// Retrieves color after filters for drawing.
        /// </summary>
        /// <param name="overrideColor">Custom override for color.</param>
        protected Color GetColor(Color? overrideColor = null)
        {
            Color color = overrideColor == null ? GetRawColor() : (Color)overrideColor;

            IList<IFilter> filters = GetFilters();

            foreach (IFilter filter in filters)
            {
                color = filter.GetColor(color);
            }

            return color;
        }

        /// <summary>
        /// Retrieves destination after filters for drawing.
        /// </summary>
        /// <param name="overrideDestination">Custom override for destination.</param>
        protected virtual Vector2 GetDestination(Vector2? overrideDestination = null)
        {
            Vector2 destination = overrideDestination == null ? GetAnchor() : (Vector2)overrideDestination;

            IList<IFilter> filters = GetFilters();

            foreach (IFilter filter in filters)
            {
                destination = filter.GetDestination(destination);
            }

            return destination;
        }

        /// <summary>
        /// Retrieves effects after filters for drawing.
        /// </summary>
        /// <param name="overrideEffects">Custom override for effects.</param>
        protected SpriteEffects GetEffects(SpriteEffects? overrideEffects = null)
        {
            SpriteEffects effects = overrideEffects == null ? GetRawEffects() : (SpriteEffects)overrideEffects;

            IList<IFilter> filters = GetFilters();

            foreach (IFilter filter in filters)
            {
                effects = filter.GetEffects(effects);
            }

            return effects;
        }

        /// <summary>
        /// Retrieves layer depth after filters for drawing.
        /// </summary>
        /// <param name="overrideLayerDepth">Custom override for layer depth.</param>
        protected float GetLayerDepth(float? overrideLayerDepth = null)
        {
            float layerDepth = overrideLayerDepth == null ? _layerDepth : (float)overrideLayerDepth;

            IList<IFilter> filters = GetFilters();

            foreach (IFilter filter in filters)
            {
                layerDepth = filter.GetLayerDepth(layerDepth);
            }

            return layerDepth;
        }

        /// <summary>
        /// Color before filters.
        /// </summary>
        protected virtual Color GetRawColor()
        {
            return Color.White;
        }

        /// <summary>
        /// Retrieves the raw scale before filters.
        /// </summary>
        protected virtual SpriteEffects GetRawEffects()
        {
            return SpriteEffects.None;
        }

        /// <summary>
        /// Retrieves the raw origin before filters.
        /// </summary>
        protected virtual Vector2 GetRawOrigin()
        {
            return new Vector2(
                0,
                0
            );
        }

        /// <summary>
        /// Retrieves the raw rotation.
        /// </summary>
        protected virtual float GetRawRotation()
        {
            return 0f;
        }

        /// <summary>
        /// Retrieves the raw scale before filters.
        /// </summary>
        protected virtual float GetRawScale()
        {
            return RenderHelpers.TileScale();
        }

        /// <summary>
        /// Retrieves rotation after filters for drawing.
        /// </summary>
        /// <param name="overrideRotation">Custom override for rotation.</param>
        protected float GetRotation(float? overrideRotation = null)
        {
            float rotation = overrideRotation == null ? GetRawRotation() : (float)overrideRotation;

            IList<IFilter> filters = GetFilters();

            foreach (IFilter filter in filters)
            {
                rotation = filter.GetRotation(rotation);
            }

            return rotation;
        }

        /// <summary>
        /// Retrieves scale after filters for drawing.
        /// </summary>
        /// <param name="overrideScale">Custom override for scale.</param>
        protected float GetScale(float? overrideScale = null)
        {
            float scale = overrideScale == null ? GetRawScale() : (float)overrideScale * RenderHelpers.TileScale();

            IList<IFilter> filters = GetFilters();

            foreach (IFilter filter in filters)
            {
                scale = filter.GetScale(scale);
            }

            if (scale == 0)
            {
                scale = 0.001f;
            }

            return scale;
        }

        /// <summary>
        /// Retrieves source after filters for drawing.
        /// </summary>
        /// <param name="overrideSource">Custom override for source.</param>
        protected Microsoft.Xna.Framework.Rectangle GetSource(Microsoft.Xna.Framework.Rectangle? overrideSource = null)
        {
            Microsoft.Xna.Framework.Rectangle source = overrideSource == null ? GetRawSource() : (Microsoft.Xna.Framework.Rectangle)overrideSource;

            IList<IFilter> filters = GetFilters();

            foreach (IFilter filter in filters)
            {
                source = filter.GetSource(source);
            }

            return source;
        }

        /// <summary>
        /// Retrieves the tileset for the sprite.
        /// </summary>
        protected virtual Texture2D GetTileset()
        {
            return GenericTextures.Tileset.Default;
        }

        /// <summary>
        /// Retrieves origin after filters for drawing.
        /// </summary>
        /// <param name="overrideOrigin">Custom override for origin.</param>
        protected Vector2 GetOrigin(Vector2? overrideOrigin = null)
        {
            Vector2 origin = overrideOrigin == null ? GetRawOrigin() : (Vector2)overrideOrigin;

            IList<IFilter> filters = GetFilters();

            foreach (IFilter filter in filters)
            {
                origin = filter.GetOrigin(origin);
            }

            return origin;
        }

        /// <summary>
		/// Initializes <see cref="_filters"/> as an empty list of <see cref="IFilter">IFilters</see>.
		/// </summary>
		protected virtual void InitializeFilters()
        {
            _filters = new List<IFilter>();
        }

        /// <summary>
		/// Initializes <see cref="_transitionState"/> based on presence of <see cref="_enteringTransition"/>.
		/// </summary>
		protected virtual void InitializeTransitionState()
        {
            if (_enteringTransition != null)
            {
                _transitionState = TransitionState.Entering;
                _enteringTransition.SetKey(_id);
                ((Transition)_enteringTransition).Start();
            }
            else
            {
                _transitionState = TransitionState.Present;
            }
        }

        /// <summary>
		/// Updates <see cref="Entity">Entity's</see> <see cref="_isHovered"/> based on <see cref="Mouse"/> position.
		/// </summary>
		protected void UpdateHover()
        {
            if (_transitionState == TransitionState.Present && GetRawBoundary().Contains(Mouse.Position))
            {
                if (!_isHovered)
                {
                    HandleHover();
                }
                _isHovered = true;
            }
            else if (_isHovered)
            {
                _isHovered = false;
            }
        }

        /// <summary>
        /// Updates <see cref="Entity">Entity's</see> <see cref="_transitionState"/> based on current <see cref="Transition"/>.
        /// </summary>
        protected void UpdateTransitionState()
        {
            if (_transitionState == TransitionState.Present || _transitionState == TransitionState.Dead) return;

            if (_transitionState == TransitionState.Entering
                && _enteringTransition != null
                && ((Transition)_enteringTransition).IsFinished())
                _transitionState = TransitionState.Present;
            else if (_transitionState == TransitionState.Exiting
                && (_exitingTransition != null && ((Transition)_exitingTransition).IsFinished()
                    || _exitingTransition == null))
                _transitionState = TransitionState.Dead;
        }
    }
}
