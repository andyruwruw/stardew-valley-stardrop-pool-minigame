using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MinigameFramework.Constants;
using MinigameFramework.Enums;
using MinigameFramework.Helpers;
using MinigameFramework.Render.Filters;
using MinigameFramework.Utilities;

namespace MinigameFramework.Entities.UI.Buttons
{
    /// <summary>
    /// Clickable fun text!
    /// </summary>
    class Button : Entity
    {
        /// <summary>
        /// Whether the <see cref="Button"/> is disabled.
        /// </summary>
        protected bool _disabled;

        /// <summary>
        /// The text displayed.
        /// </summary>
        protected string _text;

        /// <summary>
        /// <see cref="Text"/> displayed for <see cref="Button"/>.
        /// </summary>
        protected Text.Text _content;

        /// <summary>
        /// Instantiates a <see cref="Button"/>.
        /// </summary>
        /// <param name="origin">Anchor's relation to <see cref="IEntity">IEntity's</see> position</param>
        /// <param name="anchor"><see cref="IEntity">IEntity's</see> anchor, or position<inheritdoc cref="_anchor"/></param>
        /// <param name="layerDepth"><see cref="IEntity">IEntity's</see> layer depth for rendering</param>
        /// <param name="enteringTransition"><see cref="IEntity">IEntity's</see> entering <see cref="Transition"/></param>
        /// <param name="exitingTransition"><see cref="IEntity">IEntity's</see> exiting <see cref="Transition"/></param>
        /// <param name="text"><see cref="Text"/> displayed for <see cref="Button"/></param>
        /// <param name="maxWidth">Max width of <see cref="Text"/> to break lines</param>
        /// <param name="isCentered">Whether the <see cref="Text"/> is centered</param>
        public Button(
            string text,
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
            float scale = 1f
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
        ) {
            _disabled = false;

            _text = text;
            _content = CreateTextEntity(
                text,
                anchor,
                layerDepth,
                origin,
                enteringTransition,
                exitingTransition,
                maxWidth,
                scale,
                isCentered
            );

            _children.Add(_content);
        }

        /// <summary>
        /// Disable the button manually.
        /// </summary>
        public void Disable()
        {
            _disabled = true;
        }

        /// <summary>
        /// Enable the button manually.
        /// </summary>
        public void Enable()
        {
            _disabled = false;
        }

        /// <inheritdoc cref="IEntity.GetHeight"/>
        public override float GetHeight()
        {
            return _content.GetHeight();
        }

        /// <inheritdoc cref="Entity.GetName"/>
        public override string GetName()
        {
            return $"basic-button-{_key}";
        }

        /// <summary>
        /// Retrieves the text displayed.
        /// </summary>
        public string GetText()
        {
            return _text;
        }

        /// <inheritdoc cref="IEntity.GetWidth"/>
        public override float GetWidth()
        {
            return _content.GetWidth() + 2f;
        }

        /// <inheritdoc cref="Entity.HandleClick"/>
        public override void HandleClick()
        {
            Sounds.PlaySound(GenericSoundConstants.ButtonClick);
        }

        /// <inheritdoc cref="IEntity.HandleHover"/>
		public override void HandleHover()
        {
            base.HandleHover();
            _content.HandleHover();

            Sounds.PlaySound(GenericSoundConstants.ButtonHover);
        }

        /// <inheritdoc cref="IEntity.HandleUnhover"/>
		public override void HandleUnhover()
        {
            base.HandleUnhover();
            _content.HandleUnhover();
        }

        /// <summary>
        /// Whether the button is currently disabled.
        /// </summary>
        public bool isDisabled()
        {
            return _disabled;
        }

        /// <inheritdoc cref="IEntity.SetAnchor"/>
        public override void SetAnchor(Vector2 anchor)
        {
            base.SetAnchor(anchor);

            _content.SetAnchor(anchor);
        }

        /// <inheritdoc cref="Entity.SetTransitionState"/>
        public override void SetTransitionState(
            TransitionState transitionState,
            bool start = false
        ) {
            base.SetTransitionState(
                transitionState,
                start
            );
            _content.SetTransitionState(
                transitionState,
                true
            );
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
        /// Creates the text entity.
        /// </summary>
        protected Text.Text CreateTextEntity(
            string text,
            Vector2 anchor,
            float layerDepth = 0,
            Origin origin = Origin.TopLeft,
            IFilter? enteringTransition = null,
            IFilter? exitingTransition = null,
            float maxWidth = float.MaxValue,
            float scale = 1f,
            bool isCentered = false
        )
        {
            return new Text.Text(
                text,
                anchor,
                layerDepth,
                origin,
                enteringTransition,
                exitingTransition,
                maxWidth,
                scale,
                isCentered,
                true
            );
        }

        /// <inheritdoc cref="Entity.DrawDebug"/>
        protected override void DrawDebug(SpriteBatch batch)
        {
            RenderHelpers.DrawDebugRectangle(
                batch,
                GetRawBoundary()
            );
        }
    }
}
