using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using StardewValley;
using MinigameFramework.Enums;
using MinigameFramework.Controls;
using MinigameFramework.Render.Filters;
using MinigameFramework.Render.Filters.Transitions;
using MinigameFramework.Constants;
using MinigameFramework.Structures.Primitives;

namespace MinigameFramework.Entities
{
    /// <inheritdoc cref="IEntity"/>
    abstract class Entity : IEntity
    {
        /// <summary>
        /// On click handler.
        /// </summary>
        protected event EventHandler<string>? OnClick;

        /// <summary>
        /// On click handler.
        /// </summary>
        protected event EventHandler<string>? OnClickHeld;

        /// <summary>
        /// On click handler.
        /// </summary>
        protected event EventHandler<string>? OnClickReleased;

        /// <summary>
        /// On hover handler.
        /// </summary>
        protected event EventHandler<string>? OnHover;

        /// <summary>
        /// On key press handler.
        /// </summary>
        protected event EventHandler<string>? OnKeyPress;

        /// <summary>
        /// On key press handler.
        /// </summary>
        protected event EventHandler<string>? OnKeyRelease;

        /// <summary>
        /// On right-click handler.
        /// </summary>
        protected event EventHandler<string>? OnRightClick;

        /// <summary>
        /// On right-click handler.
        /// </summary>
        protected event EventHandler<string>? OnRightClickHeld;

        /// <summary>
        /// On right-click handler.
        /// </summary>
        protected event EventHandler<string>? OnRightClickReleased;

        /// <summary>
        /// On unhover handler.
        /// </summary>
        protected event EventHandler<string>? OnUnhover;

        /// <summary>
        /// Last know location of this element.
        /// </summary>
        protected Vector2 _anchor = Vector2.Zero;

        /// <summary>
        /// Whether children should be centered.
        /// </summary>
        protected bool _centerContent = false;

        /// <summary>
        /// Whether this item should be centered.
        /// </summary>
        protected bool _center = false;

        /// <summary>
        /// Used for scrolling.
        /// </summary>
        protected Vector2 _scroll = Vector2.Zero;

        /// <summary>
        /// Whether to care about sibling entities.
        /// </summary>
        protected bool _fixed = false;

        /// <summary>
        /// Gap between children.
        /// </summary>
        protected float _gap = 0f;

        /// <summary>
        /// Children of this entity.
        /// </summary>
        protected IList<IEntity> _children;

        /// <summary>
		/// <see cref="IEntity">IEntity's</see> entering <see cref="Transition"/>.
		/// </summary>
		protected IFilter? _enteringTransition;

        /// <summary>
        /// <see cref="IEntity">IEntity's</see> exiting <see cref="Transition"/>.
        /// </summary>
        protected IFilter? _exitingTransition;

        /// <summary>
        /// <see cref="IEntity">IEntity's</see> perminant <see cref="IFilter">IFilters</see>.
        /// </summary>
        protected IList<IFilter>? _filters;

        /// <summary>
        /// Percentage of parent to occupy.
        /// <para>Default is -1f which just follows content.</para>
        /// </summary>
        protected float _height = -1f;

        /// <summary>
        /// Can this item be hovered?
        /// </summary>
        protected bool _isHoverable = false;

        /// <summary>
        /// Can this item be clicked?
        /// </summary>
        protected bool _isInteractable = false;

        /// <summary>
		/// Whether the <see cref="Entity"/> is being hovered by the cursor.
		/// </summary>
		protected bool _isHovered = false;

        /// <summary>
		/// Whether the <see cref="Entity"/> is being clicked.
		/// </summary>
		protected bool _isSelected = false;

        /// <summary>
        /// <see cref="IEntity">IEntity's</see> unique identifier.
        /// </summary>
        protected string _key;

        /// <summary>
		/// <see cref="IEntity">IEntity's</see> layer depth for rendering.
		/// </summary>
		protected float _layerDepth;

        /// <summary>
        /// <see cref="Entity">Entity's</see> bottom margin.
        /// </summary>
        protected float _marginBottom = 0f;

        /// <summary>
        /// <see cref="Entity">Entity's</see> left margin.
        /// </summary>
        protected float _marginLeft = 0f;

        /// <summary>
        /// <see cref="Entity">Entity's</see> right margin.
        /// </summary>
        protected float _marginRight = 0f;

        /// <summary>
        /// <see cref="Entity">Entity's</see> top margin.
        /// </summary>
        protected float _marginTop = 0f;

        /// <summary>
        /// Maximum height this element can be.
        /// <para>Default is -1f which sets no limit.</para>
        /// </summary>
        protected float _maxHeight = -1f;

        /// <summary>
        /// Maximum width this element can be.
        /// <para>Default is -1f which sets no limit.</para>
        /// </summary>
        protected float _maxWidth = -1f;

        /// <summary>
        /// Minimum height this element can be.
        /// </summary>
        protected float _minHeight = -1f;
        /// <para>Default is -1f which sets no limit.</para>

        /// <summary>
        /// Minimum width this element can be.
        /// </summary>
        protected float _minWidth = -1f;
        /// <para>Default is -1f which sets no limit.</para>

        /// <summary>
        /// Whether to show overflow.
        /// </summary>
        protected bool _overflow = false;

        /// <summary>
        /// <see cref="Entity">Entity's</see> bottom padding.
        /// </summary>
        protected float _paddingBottom = 0f;

        /// <summary>
        /// <see cref="Entity">Entity's</see> left padding.
        /// </summary>
        protected float _paddingLeft = 0f;

        /// <summary>
        /// <see cref="Entity">Entity's</see> right padding.
        /// </summary>
        protected float _paddingRight = 0f;

        /// <summary>
        /// <see cref="Entity">Entity's</see> top padding.
        /// </summary>
        protected float _paddingTop = 0f;

        /// <summary>
        /// Entity's parent entity.
        /// </summary>
        protected IEntity? _parent = null;

        /// <summary>
        /// How to position the entity relative to its parent.
        /// </summary>
        protected Position? _position = Position.Relative;

        /// <summary>
        /// Unused :)
        /// </summary>
        protected float _rotation = 0f;

        /// <summary>
        /// Whether this item display children in a row.
        /// </summary>
        protected bool _row = false;

        /// <summary>
        /// Unused :)
        /// </summary>
        protected float _scale = 0f;

        /// <summary>
		/// <see cref="IEntity">IEntity's</see> current <see cref="TransitionState"/>.
		/// </summary>
		protected TransitionState _transitionState;

        /// <summary>
        /// Percentage of parent to occupy.
        /// <para>Default is -1f which just follows content.</para>
        /// </summary>
        protected float _width = -1f;

        /// <summary>
		/// <para>Instantiates an <see cref="Entity"/>.</para>
		/// </summary>
		public Entity(
            IEntity? parent = null,
            string? key = null,
            Vector2? anchor = null,
            Position? position = Position.Relative,
            IList<IEntity>? children = null,
            float? layerDepth = null,
            bool? isHoverable = false,
            bool? isInteractable = false,
            IFilter? enteringTransition = null,
            IFilter? exitingTransition = null,
            bool? isRow = false,
            bool? centerContent = false,
            bool? center = false,
            Vector2? contentOffset = null,
            bool? fixedPosition = false,
            float? gap = 0f,
            float? height = -1f,
            float? margin = 0f,           
            float? marginBottom = 0f,
            float? marginLeft = 0f,
            float? marginRight = 0f,
            float? marginTop = 0f,
            float? maxHeight = -1f,
            float? maxWidth = -1f,
            float? minHeight = -1f,
            float? minWidth = -1f,
            bool? overflow = false,
            float? padding = 0f,
            float? paddingBottom = 0f,
            float? paddingLeft = 0f,
            float? paddingRight = 0f,
            float? paddingTop = 0f,
            float? width = -1f
        ) {
            _parent = parent ?? null;
            _key = key ?? Guid.NewGuid().ToString();
            _anchor = anchor ?? Vector2.Zero;
            _position = position ?? Position.Relative;
            _children = children ?? new List<IEntity>();
            _layerDepth = layerDepth ?? 0.001f;
            _isHoverable = isHoverable ?? false;
            _isInteractable = isInteractable ?? false;
            _enteringTransition = enteringTransition;
            _exitingTransition = exitingTransition;
            _row = isRow ?? false;
            _centerContent = centerContent ?? false;
            _center = center ?? false;
            _scroll = contentOffset ?? Vector2.Zero;
            _fixed = fixedPosition ?? false;
            _gap = gap ?? 0f;
            _height = height ?? 1f;
            _marginBottom = marginBottom ?? margin ?? 0f;
            _marginLeft = marginLeft ?? margin ?? 0f;
            _marginRight = marginRight ?? margin ?? 0f;
            _marginTop = marginTop ?? margin ?? 0f;
            _maxHeight = maxHeight ?? -1f;
            _maxWidth = maxWidth ?? -1f;
            _minHeight = minHeight ?? -1f;
            _minWidth = minWidth ?? -1f;
            _overflow = overflow ?? false;
            _paddingBottom = paddingBottom ?? padding ?? 0f;
            _paddingLeft = paddingLeft ?? padding ?? 0f;
            _paddingRight = paddingRight ?? padding ?? 0f;
            _paddingTop = paddingTop ?? padding ?? 0f;
            _width = width ?? 1f;

            InitializeFilters();
            InitializeTransitionState();

            HandleChildUpdate();
        }

        /// <inheritdoc cref="IEntity.AddOnClickHandler"/>
        public virtual void AddOnClickHandler(EventHandler<string> handler)
        {
            OnClick += handler;
        }

        /// <inheritdoc cref="IEntity.AddOnClickHeldHandler"/>
        public virtual void AddOnClickHeldHandler(EventHandler<string> handler)
        {
            OnClickHeld += handler;
        }

        /// <inheritdoc cref="IEntity.AddOnClickReleasedHandler"/>
        public virtual void AddOnClickReleasedHandler(EventHandler<string> handler)
        {
            OnClickReleased += handler;
        }

        /// <inheritdoc cref="IEntity.AddOnHoverHandler"/>
        public virtual void AddOnHoverHandler(EventHandler<string> handler)
        {
            OnHover += handler;
        }

        /// <inheritdoc cref="IEntity.AddOnKeyPressHandler"/>
        public virtual void AddOnKeyPressHandler(EventHandler<string> handler)
        {
            OnKeyPress += handler;
        }

        /// <inheritdoc cref="IEntity.AddOnKeyReleaseHandler"/>
        public virtual void AddOnKeyReleaseHandler(EventHandler<string> handler)
        {
            OnKeyRelease += handler;
        }

        /// <inheritdoc cref="IEntity.AddOnRightClickHandler"/>
        public virtual void AddOnRightClickHandler(EventHandler<string> handler)
        {
            OnRightClick += handler;
        }

        /// <inheritdoc cref="IEntity.AddOnRightClickHeldHandler"/>
        public virtual void AddOnRightClickHeldHandler(EventHandler<string> handler)
        {
            OnRightClickHeld += handler;
        }

        /// <inheritdoc cref="IEntity.AddOnRightClickReleasedHandler"/>
        public virtual void AddOnRightClickReleasedHandler(EventHandler<string> handler)
        {
            OnRightClickReleased += handler;
        }

        /// <inheritdoc cref="IEntity.AddOnUnhoverHandler"/>
        public virtual void AddOnUnhoverHandler(EventHandler<string> handler)
        {
            OnUnhover += handler;
        }

        /// <inheritdoc cref="IEntity.Clear"/>
        public virtual void Clear() {
            _children.Clear();

            HandleChildUpdate();
        }

        /// <inheritdoc cref="IEntity.Draw"/>
        public virtual Vector2 Draw(
            SpriteBatch batch,
            Vector2? offset = null,
            Color? color = null,
            float? rotation = null,
            Vector2? origin = null,
            float? scale = 1f,
            SpriteEffects? effects = null,
            float? layerDepth = null
        )
        {
            // Resolve offset, set to zero if unknown.
            // This offset represents our displacement from the parent's anchor.
            // Not this is not true coordinates of where to draw.
            Vector2 resolvedOffset = offset != null ? (Vector2)offset : Vector2.Zero;

            // Set our own anchor to the parent's anchor if fixed.
            // Nested ternary... I know. Outside just ensures our parent exists.
            _anchor = _parent != null ? IsFixed() ? _parent.GetAnchor() : Vector2.Add(
                _parent.GetAnchor(),
                resolvedOffset
            ) : Vector2.Zero;

            // If we are not visible, return no displacement.
            if (!ShouldDraw())
            {
                return Vector2.Zero;
            }

            // Scale effects children offset.
            // Typically only one element will be scaled, meaning all others
            // are passing it down or returning 1f.
            // Ignoring scale for now...the width and center of our sections
            // isn't a guaranteed value at first draw.
            // float resolvedScale = FilterScale(scale ?? 1f);

            // Figure out where we can draw content given margins.
            Vector2 contentOffset = GetContentOffset(resolvedOffset);

            // Check if we should draw children.
            if (ShouldDrawChildren())
            {
                // Apply padding and figure out offset.
                Vector2 childrenOffset = GetChildrenOffset(
                    resolvedOffset,
                    contentOffset
                );
                
                // Run through children adding their displacement.
                foreach (IEntity entity in GetChildren())
                {
                    // Draw a child.
                    Vector2 displacement = entity.Draw(
                        batch,
                        FilterDestination(childrenOffset),
                        FilterColor(color ?? Color.White),
                        FilterRotation(rotation ?? 0f),
                        FilterOrigin(origin ?? Vector2.Zero),
                        FilterScale(scale ?? 1f),
                        FilterEffects(effects ?? SpriteEffects.None),
                        FilterLayerDepth(layerDepth + 0.002f ?? 0f)
                    );
                    
                    // Add their width or height to the offset.
                    if (!entity.IsFixed()) {
                        if (IsRow())
                        {
                            childrenOffset.X += displacement.X + _gap;
                        }
                        else
                        {
                            childrenOffset.Y += displacement.Y + _gap;
                        }
                    }
                }
            }

            if (ShouldDrawSelf()) {
                DrawSelf(
                    batch,
                    FilterDestination(contentOffset),
                    FilterSource(GetSource()),
                    FilterColor(color ?? Color.White),
                    FilterRotation(rotation ?? 0f),
                    FilterOrigin(origin ?? Vector2.Zero),
                    FilterScale(scale ?? 1f),
                    FilterEffects(effects ?? SpriteEffects.None),
                    FilterLayerDepth(layerDepth + 0.001f ?? 0f)
                );
            }

            if (DevConstants.DebugVisuals)
            {
                DrawDebug(batch);
            }

            return new Vector2(
                GetWidth(),
                GetHeight()
            );
        }

        /// <inheritdoc cref="IEntity.Equals"/>
        public override bool Equals(object? obj)
        {
            return obj != null
                && obj.GetType() != GetType()
                && (ReferenceEquals(this, obj)
                || GetName() == ((Entity)obj).GetName());
        }

        /// <inheritdoc cref="IEntity.GetAnchor"/>
        public virtual Vector2 GetAnchor()
        {
            return _anchor;
        }

        /// <inheritdoc cref="IEntity.GetBoundary"/>
		public virtual IRange GetBoundary()
        {
            return new Structures.Primitives.Rectangle(
                GetAnchor(),
                GetWidth(),
                GetHeight()
            );
        }

        /// <inheritdoc cref="IEntity.GetCenter"/>
		public virtual Vector2 GetCenter()
        {
            return new Vector2(
                GetAnchor().X + GetWidth() / 2,
                GetAnchor().Y + GetHeight() / 2
            );
        }

        /// <inheritdoc cref="IEntity.GetChildren"/>
        public virtual IList<IEntity> GetChildren()
        {
            return _children;
        }

        /// <inheritdoc cref="IEntity.GetEnteringTransition"/>
		public virtual IFilter? GetEnteringTransition()
        {
            return _enteringTransition;
        }

        /// <inheritdoc cref="IEntity.GetExitingTransition"/>
        public virtual IFilter? GetExitingTransition()
        {
            return _exitingTransition;
        }

        /// <inheritdoc cref="IEntity.GetHeight"/>
		public virtual float GetHeight() {
            return 0;
            // Fix
        }
        
        /// <inheritdoc cref="IEntity.GetHashCode"/>
        public override int GetHashCode()
        {
            return _key.GetHashCode();
        }

        /// <inheritdoc cref="IEntity.GetKey"/>
        public virtual string GetKey()
        {
            return _key;
        }

        /// <inheritdoc cref="IEntity.GetLayerDepth"/>
        public virtual float GetLayerDepth()
        {
            return _layerDepth;
        }

        /// <inheritdoc cref="IEntity.GetName"/>
        public abstract string GetName();

        /// <inheritdoc cref="IEntity.GetName"/>
        public virtual float GetMarginBottom()
        {
            return _marginBottom;
        }

        /// <inheritdoc cref="IEntity.GetMarginLeft"/>
        public virtual float GetMarginLeft()
        {
            return _marginLeft;
        }

        /// <inheritdoc cref="IEntity.GetMarginRight"/>
        public virtual float GetMarginRight()
        {
            return _marginRight;
        }

        /// <inheritdoc cref="IEntity.GetMarginTop"/>
        public virtual float GetMarginTop()
        {
            return _marginTop;
        }

        /// <inheritdoc cref="IEntity.GetMaxHeight"/>
        public virtual float GetMaxHeight()
        {
            return _maxHeight;
        }

        /// <inheritdoc cref="IEntity.GetMaxWidth"/>
        public virtual float GetMaxWidth()
        {
            return _maxWidth;
        }

        /// <inheritdoc cref="IEntity.GetMinHeight"/>
        public virtual float GetMinHeight()
        {
            return _minHeight;
        }

        /// <inheritdoc cref="IEntity.GetMinWidth"/>
        public virtual float GetMinWidth()
        {
            return _minWidth;
        }

        /// <inheritdoc cref="IEntity.GetPaddingBottom"/>
        public virtual float GetPaddingBottom()
        {
            return _paddingBottom;
        }

        /// <inheritdoc cref="IEntity.GetPaddingLeft"/>
        public virtual float GetPaddingLeft()
        {
            return _paddingLeft;
        }

        /// <inheritdoc cref="IEntity.GetPaddingRight"/>
        public virtual float GetPaddingRight()
        {
            return _paddingRight;
        }

        /// <inheritdoc cref="IEntity.GetPaddingTop"/>
        public virtual float GetPaddingTop()
        {
            return _paddingTop;
        }

        /// <inheritdoc cref="IEntity.GetPosition"/>
        public virtual Position GetPosition()
        {
            return _position ?? Position.Relative;
        }

        /// <inheritdoc cref="IEntity.GetScroll"/>
        public virtual Vector2 GetScroll()
        {
            return _scroll;
        }

        /// <inheritdoc cref="IEntity.GetTransitionState"/>
		public virtual TransitionState GetTransitionState()
        {
            return _transitionState;
        }

        /// <inheritdoc cref="IEntity.GetWidth"/>
        public virtual float GetWidth() {
            return 0;
            // Fix
        }

        /// <inheritdoc cref="IEntity.Insert"/>
        public virtual void Insert(
            IEntity entity,
            int? index = -1
        )
        {
            if (index != null && index >= 0)
            {
                _children.Insert(
                    (int)index,
                    entity
                );
            }
            else
            {
                _children.Add(entity);
            }

            HandleChildUpdate();
        }

        /// <inheritdoc cref="IEntity.HandleChildUpdate"/>
        public virtual void HandleChildUpdate()
        {
        }

        /// <inheritdoc cref="IEntity.HandleClick"/>
		public virtual void HandleClick()
        {
            OnClick?.Invoke(
                this,
                GetKey()
            );
        }

        /// <inheritdoc cref="IEntity.HandleClickHeld"/>
		public virtual void HandleClickHeld()
        {
            OnClickHeld?.Invoke(
                this,
                GetKey()
            );
        }

        /// <inheritdoc cref="IEntity.HandleClickReleased"/>
		public virtual void HandleClickReleased()
        {
            OnClickReleased?.Invoke(
                this,
                GetKey()
            );
        }

        /// <inheritdoc cref="IEntity.HandleHover"/>
		public virtual void HandleHover()
        {
            OnHover?.Invoke(
                this,
                GetKey()
            );
        }

        /// <inheritdoc cref="IEntity.HandleKeyPress"/>
		public virtual void HandleKeyPress()
        {
            OnKeyPress?.Invoke(
                this,
                GetKey()
            );
        }

        /// <inheritdoc cref="IEntity.HandleKeyRelease"/>
		public virtual void HandleKeyRelease()
        {
            OnKeyRelease?.Invoke(
                this,
                GetKey()
            );
        }

        /// <inheritdoc cref="IEntity.HandleRightClick"/>
		public virtual void HandleRightClick()
        {
            OnRightClick?.Invoke(
                this,
                GetKey()
            );
        }

        /// <inheritdoc cref="IEntity.HandleRightClickHeld"/>
		public virtual void HandleRightClickHeld()
        {
            OnRightClickHeld?.Invoke(
                this,
                GetKey()
            );
        }

        /// <inheritdoc cref="IEntity.HandleRightClickReleased"/>
		public virtual void HandleRightClickReleased()
        {
            OnRightClickReleased?.Invoke(
                this,
                GetKey()
            );
        }

        /// <inheritdoc cref="IEntity.HandleUnhover"/>
		public virtual void HandleUnhover()
        {
            _isHovered = false;

            OnUnhover?.Invoke(
                this,
                GetKey()
            );
        }

        /// <inheritdoc cref="IEntity.IsCentered"/>
		public virtual bool IsCentered()
        {
            return _center;
        }

        /// <inheritdoc cref="IEntity.IsContentCentered"/>
		public virtual bool IsContentCentered()
        {
            return _centerContent;
        }

        /// <inheritdoc cref="IEntity.IsFixed"/>
		public virtual bool IsFixed()
        {
            return _fixed;
        }

        /// <inheritdoc cref="IEntity.IsHoverable"/>
        public virtual bool IsHoverable()
        {
            return _isHoverable;
        }

        /// <inheritdoc cref="IEntity.IsHovered"/>
		public virtual bool IsHovered()
        {
            return _isHovered;
        }

        /// <inheritdoc cref="IEntity.IsInteractable"/>
        public virtual bool IsInteractable()
        {
            return _isInteractable;
        }

        /// <inheritdoc cref="IEntity.IsSelected"/>
		public virtual bool IsSelected()
        {
            return _isSelected;
        }

        /// <inheritdoc cref="IEntity.IsRow"/>
		public virtual bool IsRow()
        {
            return _row;
        }

        /// <inheritdoc cref="IEntity.Remove(string)"/>
        public virtual void Remove(string key)
        {
            IEntity? entity = _children.FirstOrDefault(e => e.GetKey() == key);

            if (entity != null) {
                _children.Remove(entity);
            }
        }

        /// <inheritdoc cref="IEntity.Remove(IEntity)"/>
        public virtual void Remove(IEntity entity)
        {
            _children.Remove(entity);
        }

        /// <inheritdoc cref="IEntity.SetAnchor"/>
        public virtual void SetAnchor(Vector2 anchor)
        {
            _anchor = anchor;
        }

        /// <inheritdoc cref="IEntity.SetChildren"/>
        public virtual void SetChildren(IList<IEntity> children)
        {
            _children = children;

            HandleChildUpdate();
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
                ((Transition)_enteringTransition).SetKey(GetName());
                ((Transition)_enteringTransition).Start();
            }

            if (_transitionState == TransitionState.Exiting
                && _exitingTransition != null
                && start)
            {
                ((Transition)_exitingTransition).ResetTransition();
                ((Transition)_exitingTransition).SetKey(GetName());
                ((Transition)_exitingTransition).Start();
            }
        }

        /// <inheritdoc cref="IEntity.ShouldDraw"/>
        public virtual bool ShouldDraw()
        {
            return GetTransitionState() != TransitionState.Dead;
        }

        /// <inheritdoc cref="IEntity.ShouldDrawChildren"/>
        public virtual bool ShouldDrawChildren()
        {
            return false;
        }

        /// <inheritdoc cref="IEntity.ShouldDrawSelf"/>
        public virtual bool ShouldDrawSelf()
        {
            return true;
        }

        /// <inheritdoc cref="IEntity.ShouldOverflow"/>
        public virtual bool ShouldOverflow()
        {
            return _overflow;
        }

        /// <summary>
        /// Override for ToString().
        /// </summary>
        public override string ToString()
        {
            return GetName();
        }

        /// <inheritdoc cref="IEntity.Update"/>
        public virtual void Update(GameTime time)
        {
            UpdateTransitionState();
            
            if (IsHoverable())
            {
                UpdateHover();
            }

            foreach (IEntity entity in GetChildren())
            {
                if (entity != null)
                {
                    entity.Update(time);
                }
            }
        }

        /// <summary>
        /// Updates based on an event.
        /// </summary>
        public virtual void UpdateClick()
        {
            if (!IsInteractable())
            {
                return;
            }

            if (_isHovered)
            {
                _isSelected = true;

                HandleClick();
            }
        }

        /// <summary>
        /// Updates based on an event.
        /// </summary>
        public virtual void UpdateClickHeld()
        {
        }

        /// <summary>
        /// Updates based on an event.
        /// </summary>
        public virtual void UpdateClickReleased()
        {
            if (!IsInteractable())
            {
                return;
            }

            if (_isSelected)
            {
                _isSelected = false;
            }
        }

        /// <summary>
		/// Updates <see cref="Entity">Entity's</see> <see cref="_isHovered"/> based on <see cref="Input"/> position.
		/// </summary>
		public void UpdateHover()
        {
            if (_isHovered && (!GetBoundary().Contains(Input.Position) || _transitionState != TransitionState.Present))
            {
                _isHovered = false;
                HandleUnhover();
            }
            else if (!_isHovered && _transitionState == TransitionState.Present && GetBoundary().Contains(Input.Position))
            {
                _isHovered = true;
                HandleHover();
            }
        }

        /// <summary>
        /// Updates based on an event.
        /// </summary>
        public virtual void UpdateKeyPress(Keys key)
        {
        }

        /// <summary>
        /// Updates based on an event.
        /// </summary>
        public virtual void UpdateKeyReleased(Keys key)
        {
        }

        /// <summary>
        /// Updates based on an event.
        /// </summary>
        public virtual void UpdateRightClick()
        {
        }

        /// <summary>
        /// Updates based on an event.
        /// </summary>
        public virtual void UpdateRightClickHeld()
        {
        }

        /// <summary>
        /// Updates based on an event.
        /// </summary>
        public virtual void UpdateRightClickReleased()
        {
        }

        /// <summary>
        /// Draws debug visuals if turned on.
        /// </summary>
        protected virtual void DrawDebug(SpriteBatch batch) { }

        /// <summary>
        /// Draws this entity. The draw function contains a lot of logic about drawing children, so this just separates out that logic.
        /// </summary>
        protected virtual void DrawSelf(
            SpriteBatch batch,
            Vector2 destination,
            Microsoft.Xna.Framework.Rectangle source,
            Color color,
            float rotation,
            Vector2 origin,
            float scale,
            SpriteEffects effects,
            float layerDepth
        )
        {
            batch.Draw(
                GetTileset(),
                destination,
                source,
                color,
                rotation,
                origin,
                scale,
                effects,
                layerDepth
            );
        }

        /// <summary>
        /// Applies filters to a color.
        /// </summary>
        /// <param name="color">Desired color.</param>
        /// <returns>Filtered color.</returns>
        protected virtual Color FilterColor(Color color)
        {
            Color filtered = new Color(
                color.R,
                color.G,
                color.B,
                color.A
            );

            foreach (IFilter filter in GetFilters())
            {
                filtered = filter.GetColor(filtered);
            }

            return filtered;
        }

        /// <summary>
        /// Applies filters to a destination vector.
        /// </summary>
        /// <param name="destination">Desired destination.</param>
        /// <returns>Filtered destination.</returns>
        protected virtual Vector2 FilterDestination(Vector2 destination)
        {
            Vector2 filtered = new Vector2(
                destination.X,
                destination.Y
            );

            foreach (IFilter filter in GetFilters())
            {
                filtered = filter.GetDestination(filtered);
            }

            return filtered;
        }

        /// <summary>
        /// Applies filters to sprite effects.
        /// </summary>
        /// <param name="effects">Desired effects.</param>
        /// <returns>Filtered effects.</returns>
        protected virtual SpriteEffects FilterEffects(SpriteEffects scale)
        {
            SpriteEffects filtered = scale;

            foreach (IFilter filter in GetFilters())
            {
                filtered = filter.GetEffects(filtered);
            }

            return filtered;
        }

        /// <summary>
        /// Applies filters to layer depth.
        /// </summary>
        /// <param name="layerDepth">Desired layer depth.</param>
        /// <returns>Filtered layer depth.</returns>
        protected virtual float FilterLayerDepth(float layerDepth)
        {
            float filtered = layerDepth;

            foreach (IFilter filter in GetFilters())
            {
                filtered = filter.GetLayerDepth(filtered);
            }

            return filtered;
        }

        /// <summary>
        /// Applies filters to a origin vector.
        /// </summary>
        /// <param name="origin">Desired origin.</param>
        /// <returns>Filtered origin.</returns>
        protected virtual Vector2 FilterOrigin(Vector2 origin)
        {
            Vector2 filtered = new Vector2(
                origin.X,
                origin.Y
            );

            foreach (IFilter filter in GetFilters())
            {
                filtered = filter.GetOrigin(filtered);
            }

            return filtered;
        }

        /// <summary>
        /// Applies filters to a rotation.
        /// </summary>
        /// <param name="rotation">Desired rotation.</param>
        /// <returns>Filtered rotation.</returns>
        protected virtual float FilterRotation(float rotation)
        {
            float filtered = rotation;

            foreach (IFilter filter in GetFilters())
            {
                filtered = filter.GetRotation(filtered);
            }

            return filtered;
        }

        /// <summary>
        /// Applies filters to a scale.
        /// </summary>
        /// <param name="scale">Desired scale.</param>
        /// <returns>Filtered scale.</returns>
        protected virtual float FilterScale(float scale)
        {
            float filtered = scale;

            foreach (IFilter filter in GetFilters())
            {
                filtered = filter.GetScale(filtered);
            }

            return filtered;
        }

        /// <summary>
        /// Applies filters to a source bound.
        /// </summary>
        /// <param name="source">Desired source.</param>
        /// <returns>Filtered source.</returns>
        protected virtual Microsoft.Xna.Framework.Rectangle FilterSource(Microsoft.Xna.Framework.Rectangle source)
        {
            Microsoft.Xna.Framework.Rectangle filtered = new Microsoft.Xna.Framework.Rectangle(
                source.X,
                source.Y,
                source.Width,
                source.Height
            );

            foreach (IFilter filter in GetFilters())
            {
                filtered = filter.GetSource(filtered);
            }

            return filtered;
        }

        /// <summary>
        /// Retrieves where we should begin drawing children.
        /// </summary>
        /// <param name="offset">Parent content offset.</param>
        /// <param name="contentOffset">Previously calculated content offset.</param>
        protected virtual Vector2 GetChildrenOffset(
            Vector2 offset,
            Vector2? contentOffset = null
        ) {
            Vector2 resolvedContentOffset = contentOffset != null ? (Vector2)contentOffset : GetContentOffset(offset);

            return Vector2.Add(
                resolvedContentOffset,
                new Vector2(
                    _paddingLeft,
                    _paddingTop
                )
            );
        }

        /// <summary>
        /// Retrieves where we should begin drawing self.
        /// </summary>
        /// <param name="offset">Parent content offset.</param>
        protected virtual  Vector2 GetContentOffset(Vector2 offset) {
            // If fixed, offset doesn't matter.
            if (IsFixed()) {
                return Vector2.Add(
                    _parent != null ? _parent.GetAnchor() : Vector2.Zero,
                    new Vector2(
                        _marginLeft,
                        _marginTop
                    )
                );
            }
            // Add offset and margin.
            return Vector2.Add(
                Vector2.Add(
                    _parent != null ? _parent.GetAnchor() : Vector2.Zero,
                    offset
                ),
                new Vector2(
                    _marginLeft,
                    _marginTop
                )
            );
        }

        /// <inheritdoc cref="IEntity.GetFilters"/>
		protected virtual IList<IFilter> GetFilters()
        {
            IList<IFilter> filters = new List<IFilter>();

            if (GetTransitionState() == TransitionState.Exiting && _exitingTransition != null)
            {
                filters.Add(_exitingTransition);
            }

            if (GetTransitionState() == TransitionState.Entering && _enteringTransition != null)
            {
                filters.Add(_enteringTransition);
            }

            if (_filters != null && _filters.Count() > 0)
            {
                foreach (var filter in _filters)
                {
                    filters.Add(filter);
                };
            }

            return filters;
        }

        /// <summary>
        /// Retrieves source after filters for drawing.
        /// </summary>
        /// <param name="overrideSource">Custom override for source.</param>
        protected virtual Microsoft.Xna.Framework.Rectangle GetSource(Microsoft.Xna.Framework.Rectangle? overrideSource = null)
        {
            return Game1.staminaRect.Bounds;
        }

        /// <summary>
        /// Retrieves the tileset for the sprite.
        /// </summary>
        protected virtual Texture2D? GetTileset()
        {
            return Game1.staminaRect;
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
                _enteringTransition.SetKey(GetName());
                ((Transition)_enteringTransition).Start();
            }
            else
            {
                _transitionState = TransitionState.Present;
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
