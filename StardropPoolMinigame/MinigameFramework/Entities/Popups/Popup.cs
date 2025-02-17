using Microsoft.Xna.Framework;
using MinigameFramework.Entities.UI;
using MinigameFramework.Enums;
using MinigameFramework.Render.Filters;

namespace MinigameFramework.Entities.Popups
{
    /// <summary>
    /// A general popup, any entities that appear for a short time over everything else.
    /// </summary>
    class Popup : Section
    {
        /// <summary>
        /// Delay before showing the popup.
        /// </summary>
        protected float _delay = 0;

        /// <summary>
        /// How long to show before disappearing.
        /// </summary>
        protected int _lifetime = 100;

        /// <summary>
        /// Whether to show the popup instantly.
        /// </summary>
        protected bool _visible = false;

        /// <summary>
        /// Whether the popup can be dismissed.
        /// </summary>
        protected bool _dismissable = true;

        /// <summary>
        /// Instantiates a new <see cref="Popup"/>.
        /// </summary>
        public Popup(
            IEntity? parent = null,
            string? key = null,
            Vector2? anchor = null,
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
            bool? fixedPosition = true,
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
            float? width = -1f,
            bool? visible = false,
            int? delay = 0,
            int? lifetime = 100,
            bool? dismissable = true
        ) : base(
            parent,
            key,
            anchor,
            children,
            layerDepth,
            isHoverable,
            isInteractable,
            enteringTransition,
            exitingTransition,
            isRow,
            centerContent,
            center,
            contentOffset,
            fixedPosition,
            gap,
            height,
            margin,
            marginBottom,
            marginLeft,
            marginRight,
            marginTop,
            maxHeight,
            maxWidth,
            minHeight,
            minWidth,
            overflow,
            padding,
            paddingBottom,
            paddingLeft,
            paddingRight,
            paddingTop,
            width
        )
        {
            _delay = delay ?? 0;
            _lifetime = lifetime ?? 100;
            _visible = visible ?? false;
            _dismissable = dismissable ?? true;
        }

        /// <summary>
        /// Closes the popup.
        /// </summary>
        public void Dismiss() {
            _visible = false;

            SetTransitionState(TransitionState.Exiting);
        }

        /// <inheritdoc cref="IEntity.GetName"/>
        public override string GetName()
        {
            return $"popup-{_key}";
        }

        /// <summary>
        /// Whether the popup is dismissable.
        /// </summary>
        public bool IsDismissable() {
            return _dismissable;
        }

        /// <summary>
        /// Whether the popup is visible.
        /// </summary>
        public bool IsVisible() {
            return _visible;
        }

        /// <inheritdoc cref="IEntity.ShouldDrawChildren"/>
        public override bool ShouldDrawChildren()
        {
            return true;
        }

        /// <inheritdoc cref="IEntity.ShouldDrawSelf"/>
        public override bool ShouldDrawSelf()
        {
            return false;
        }

        /// <summary>
        /// Shows the popup.
        /// </summary>
        public void Show() {
            _visible = true;

            SetTransitionState(TransitionState.Entering);
        }
    }
}
