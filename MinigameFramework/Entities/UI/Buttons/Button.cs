using Microsoft.Xna.Framework;
using MinigameFramework.Constants;
using MinigameFramework.Enums;
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
            Vector2 anchor,
            float layerDepth = 0,
            Origin origin = Origin.TopLeft,
            IFilter? enteringTransition = null,
            IFilter? exitingTransition = null,
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
            _disabled = false;

            _text = text;
            _content = new Text.Text(
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

        /// <inheritdoc cref="IEntity.GetEntities"/>
        public override IList<IEntity> GetEntities()
        {
            return new List<IEntity>{ _content };
        }

        /// <inheritdoc cref="IEntity.GetHeight"/>
        public override float GetHeight()
        {
            return _content.GetHeight();
        }

        /// <inheritdoc cref="Entity.GetId"/>
        public override string GetId()
        {
            return $"basic-button-{_id}";
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
            return _content.GetWidth();
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
            return _disabled;
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
            this._content.SetTransitionState(
                transitionState,
                true
            );
        }
    }
}
