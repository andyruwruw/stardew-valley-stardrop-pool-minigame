using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MinigameFramework.Constants;
using MinigameFramework.Entities;
using MinigameFramework.Entities.UI.Buttons;
using MinigameFramework.Enums;
using MinigameFramework.Render.Filters;
using MinigameFramework.Utilities;
using StardewModdingAPI;
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
            string text,
            Vector2 anchor,
            int number = 0,
            float layerDepth = 0,
            Origin origin = Origin.TopLeft,
            IFilter enteringTransition = null,
            IFilter exitingTransition = null,
            float maxWidth = float.MaxValue,
            float scale = 1f,
            bool isCentered = false
        ) : base(
            anchor,
            layerDepth,
            origin,
            enteringTransition,
            exitingTransition
        ) {
            _button = new Button(
                text,
                anchor: new Vector2(
                    this.GetTopLeft().X + (GameConstants.Ball.Radius * 2) + RenderConstants.Entities.BallButton.InnerPadding,
                    this.GetTopLeft().Y
                ),
                layerDepth,
                Origin.TopLeft,
                enteringTransition,
                exitingTransition,
                maxWidth,
                scale,
                isCentered
            );
            _ball = new Ball(
                new Vector2(
                    this.GetTopLeft().X + GameConstants.Ball.Radius,
                    this.GetTopLeft().Y + (_button.GetHeight() / 2)
                ),
                number,
                layerDepth,
                Origin.CenterCenter,
                enteringTransition,
                exitingTransition
            );
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
            this._button.Disable();
        }

        /// <summary>
        /// Enable the button manually.
        /// </summary>
        public void Enable()
        {
            this._button.Enable();
        }

        /// <summary>
        /// Retrieves the ball entity.
        /// </summary>
        public Ball GetBall()
        {
            return this._ball;
        }

        /// <summary>
        /// Retrieves the button entity.
        /// </summary>
        public Button GetButton()
        {
            return _button;
        }

        /// <inheritdoc cref="IEntity.GetEntities"/>
        public override IList<IEntity> GetEntities()
        {
            return new List<IEntity> {
                _ball,
                _button,
            };
        }

        /// <inheritdoc cref="IEntity.GetHeight"/>
        public override float GetHeight()
        {
            return Math.Max(
                _ball.GetHeight(),
                _button.GetHeight()
            );
        }

        /// <inheritdoc cref="Entity.GetId"/>
        public override string GetId()
        {
            return $"ball-button-{_id}";
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

        /// <inheritdoc cref="Entity.HandleLeftClick"/>
        public override void HandleLeftClick()
        {
            Sounds.PlaySound(GenericSoundConstants.ButtonClick);
        }

        /// <summary>
        /// Whether the button is currently disabled.
        /// </summary>
        public bool isDisabled()
        {
            return _button.isDisabled();
        }
    }
}
