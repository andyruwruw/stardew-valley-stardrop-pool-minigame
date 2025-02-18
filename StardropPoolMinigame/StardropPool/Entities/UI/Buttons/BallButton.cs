using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MinigameFramework.Constants;
using MinigameFramework.Entities;
using MinigameFramework.Entities.UI.Buttons;
using MinigameFramework.Enums;
using MinigameFramework.Render.Filters;
using MinigameFramework.Utilities;
using StardopPoolMinigame.Constants;
using StardopPoolMinigame.Entities.Game;

namespace StardopPoolMinigame.Entities.UI.Buttons
{
    class BallButton : Entity
    {
        /// <summary>
        /// Ball entity of the component.
        /// </summary>
        protected Ball _ball;

        /// <summary>
        /// Button entity of the component.
        /// </summary>
        protected Button _button;

        /// <summary>
        /// Instantiates a ball themed button.
        /// </summary>
        /// <param name="text"><see cref="Text"/> displayed for <see cref="Button"/></param>
        /// <param name="anchor"><see cref="IEntity">IEntity's</see> anchor, or position<inheritdoc cref="_anchor"/></param>
        /// <param name="number">Ball number.</param>
        /// <param name="layerDepth"><see cref="IEntity">IEntity's</see> layer depth for rendering</param>
        /// <param name="origin">Anchor's relation to <see cref="IEntity">IEntity's</see> position</param>
        /// <param name="enteringTransition"><see cref="IEntity">IEntity's</see> entering <see cref="Transition"/></param>
        /// <param name="exitingTransition"><see cref="IEntity">IEntity's</see> exiting <see cref="Transition"/></param>
        /// <param name="maxWidth">Max width of <see cref="Text"/> to break lines</param>
        /// <param name="scale">Scale of the button.</param>
        /// <param name="isCentered">Whether the <see cref="Text"/> is centered</param>
        public BallButton(
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
            float? width = -1f,
            string? text = "",
            int? number = 0,
            float? scale = 1f,
            bool? isCentered = false
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
            _button = CreateButtonEntity(
                text,
                anchor,
                layerDepth,
                enteringTransition,
                exitingTransition,
                maxWidth,
                scale,
                isCentered
            );
            _ball = CreateBallEntity(
                anchor,
                number,
                layerDepth,
                enteringTransition,
                exitingTransition
            );

            SetAnchor(anchor);

            _children.Add(_ball);
            _children.Add(_button);
        }

        /// <summary>
        /// Instantiates a ball themed button.
        /// </summary>
        /// <param name="key">Specify a custom ID.</param>
        /// <param name="text"><see cref="Text"/> displayed for <see cref="Button"/></param>
        /// <param name="anchor"><see cref="IEntity">IEntity's</see> anchor, or position<inheritdoc cref="_anchor"/></param>
        /// <param name="number">Ball number.</param>
        /// <param name="layerDepth"><see cref="IEntity">IEntity's</see> layer depth for rendering</param>
        /// <param name="origin">Anchor's relation to <see cref="IEntity">IEntity's</see> position</param>
        /// <param name="enteringTransition"><see cref="IEntity">IEntity's</see> entering <see cref="Transition"/></param>
        /// <param name="exitingTransition"><see cref="IEntity">IEntity's</see> exiting <see cref="Transition"/></param>
        /// <param name="maxWidth">Max width of <see cref="Text"/> to break lines</param>
        /// <param name="scale">Scale of the button.</param>
        /// <param name="isCentered">Whether the <see cref="Text"/> is centered</param>
        public BallButton(
            string key,
            string text,
            Vector2 anchor,
            int number = 0,
            float layerDepth = 0,
            Origin origin = Origin.TopLeft,
            IFilter? enteringTransition = null,
            IFilter? exitingTransition = null,
            float maxWidth = float.MaxValue,
            float scale = 1f,
            bool isCentered = false
        ) : base(
            key,
            anchor,
            layerDepth,
            origin,
            enteringTransition,
            exitingTransition
        )
        {
            _button = CreateButtonEntity(
                text,
                anchor,
                layerDepth,
                enteringTransition,
                exitingTransition,
                maxWidth,
                scale,
                isCentered
            );
            _ball = CreateBallEntity(
                anchor,
                number,
                layerDepth,
                enteringTransition,
                exitingTransition
            );

            SetAnchor(anchor);

            _children.Add(_ball);
            _children.Add(_button);
        }

        /// <inheritdoc cref="IEntity.Draw"/>
        public override void Draw(
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
            _button.Draw(
                batch,
                overrideDestination,
                overrideSource,
                overrideColor,
                overrideRotation,
                overrideOrigin,
                overrideScale,
                overrideEffects,
                overrideLayerDepth
            );
            _ball.Draw(
                batch,
                overrideDestination,
                overrideSource,
                overrideColor,
                overrideRotation,
                overrideOrigin,
                overrideScale,
                overrideEffects,
                overrideLayerDepth
            );
        }

        /// <summary>
        /// Disable the button manually.
        /// </summary>
        public void Disable()
        {
            _button.Disable();
        }

        /// <summary>
        /// Enable the button manually.
        /// </summary>
        public void Enable()
        {
            _button.Enable();
        }

        /// <summary>
        /// Retrieves the ball entity.
        /// </summary>
        public Ball GetBall()
        {
            return _ball;
        }

        /// <summary>
        /// Retrieves the button entity.
        /// </summary>
        public Button GetButton()
        {
            return _button;
        }

        /// <inheritdoc cref="IEntity.GetHeight"/>
        public override float GetHeight()
        {
            return Math.Max(
                _ball.GetHeight(),
                _button.GetHeight()
            );
        }

        /// <inheritdoc cref="Entity.GetName"/>
        public override string GetName()
        {
            return $"ball-button-{_key}";
        }

        /// <summary>
        /// Retrieves the text displayed.
        /// </summary>
        public string GetText()
        {
            return _button.GetText();
        }

        /// <inheritdoc cref="IEntity.GetWidth"/>
        public override float GetWidth()
        {
            return _ball.GetWidth() + RenderConstants.Entities.BallButton.InnerPadding  + _button.GetWidth();
        }

        /// <inheritdoc cref="IEntity.HandleHover"/>
		public override void HandleHover()
        {
            base.HandleHover();

            _ball.SetSpinning(true);
            _button.HandleHover();
        }

        /// <inheritdoc cref="IEntity.HandleUnhover"/>
		public override void HandleUnhover()
        {
            base.HandleUnhover();

            _ball.SetSpinning(false);
            _button.HandleUnhover();
        }

        /// <inheritdoc cref="Entity.HandleClick"/>
        public override void HandleClick()
        {
            base.HandleClick();

            Sounds.PlaySound(GenericSoundConstants.ButtonClick);
        }

        /// <summary>
        /// Whether the button is currently disabled.
        /// </summary>
        public bool isDisabled()
        {
            return _button.isDisabled();
        }

        /// <inheritdoc cref="IEntity.IsHoverable"/>
        public override bool IsHoverable()
        {
            return true;
        }

        /// <inheritdoc cref="IEntity.IsInteractable"/>
        public override bool IsInteractable()
        {
            return true;
        }

        /// <inheritdoc cref="IEntity.SetAnchor"/>
        public override void SetAnchor(Vector2 anchor)
        {
            base.SetAnchor(anchor);

            _button.SetAnchor(new Vector2(
                GetTopLeft().X + (GameConstants.Ball.Radius * 2) + RenderConstants.Entities.BallButton.InnerPadding,
                GetTopLeft().Y + ((GetHeight() - _button.GetHeight()) / 2)
            ));
            _ball.SetAnchor(new Vector2(
                GetTopLeft().X + GameConstants.Ball.Radius,
                GetTopLeft().Y + ((GetHeight() - _ball.GetHeight()) / 2)
            ));
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
        /// Creates the button entity.
        /// </summary>
        protected Button CreateButtonEntity(
            string text,
            Vector2 anchor,
            float layerDepth = 0,
            IFilter? enteringTransition = null,
            IFilter? exitingTransition = null,
            float maxWidth = float.MaxValue,
            float scale = 1f,
            bool isCentered = false
        )
        {
            return new Button(
                text,
                anchor: new Vector2(
                    anchor.X + (GameConstants.Ball.Radius * 2) + RenderConstants.Entities.BallButton.InnerPadding,
                    anchor.Y
                ),
                layerDepth,
                Origin.TopLeft,
                enteringTransition,
                exitingTransition,
                maxWidth,
                scale,
                isCentered
            );
        }

        /// <summary>
        /// Creates the ball entity.
        /// </summary>
        protected Ball CreateBallEntity(
            Vector2 anchor,
            int number = 0,
            float layerDepth = 0,
            IFilter? enteringTransition = null,
            IFilter? exitingTransition = null
        )
        {
            return new Ball(
                new Vector2(
                    anchor.X + GameConstants.Ball.Radius,
                    anchor.Y + (_button.GetHeight() / 2)
                ),
                number,
                layerDepth,
                Origin.TopLeft,
                enteringTransition,
                exitingTransition
            );
        }
    }
}
