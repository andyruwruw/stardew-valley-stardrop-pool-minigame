using Microsoft.Xna.Framework;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Render.Drawers;
using StardropPoolMinigame.Render.Filters;
using StardropPoolMinigame.Utilities;

namespace StardropPoolMinigame.Entities
{
    internal class Button : Entity
    {
        /// <summary>
        /// Whether the <see cref="Button"/> is disabled.
        /// </summary>
        private bool _disabled;

        /// <summary>
        /// <see cref="Text"/> displayed for <see cref="Button"/>.
        /// </summary>
        private Text _text;

        /// <summary>
        /// Instantiates <see cref="Button"/>.
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
            Origin origin,
            Vector2 anchor,
            float layerDepth,
            IFilter enteringTransition,
            IFilter exitingTransition,
            string text,
            int maxWidth = int.MaxValue,
            bool isCentered = true
        ) : base(
            origin,
            anchor,
            layerDepth,
            enteringTransition,
            exitingTransition)
        {
            this._disabled = false;

            this._text = new Text(
                origin,
                anchor,
                layerDepth,
                enteringTransition,
                exitingTransition,
                text,
                maxWidth,
                1f,
                isCentered,
                true);

            this.SetDrawer(new ButtonDrawer(this));
        }

        /// <inheritdoc cref="Entity.ClickCallback"/>
        public override void ClickCallback()
        {
            Sound.PlaySound(SoundConstants.Feedback.BottonPress);
        }

        /// <inheritdoc cref="Entity.GetId"/>
        public override string GetId()
        {
            return $"basic-button-{this._id}";
        }

        /// <summary>
        /// Retrieves <see cref="Text"/> displayed for button.
        /// </summary>
        /// <returns><see cref="Text"/> displayed for button</returns>
        public Text GetText()
        {
            return this._text;
        }

        /// <inheritdoc cref="Entity.GetTotalHeight"/>
        public override float GetTotalHeight()
        {
            return this._text.GetTotalHeight();
        }

        /// <inheritdoc cref="Entity.GetTotalWidth"/>
        public override float GetTotalWidth()
        {
            return this._text.GetTotalWidth();
        }

        /// <inheritdoc cref="Entity.HoverCallback"/>
        public override void HoverCallback()
        {
            Sound.PlaySound(SoundConstants.Feedback.ButtonHover);
        }

        /// <summary>
        /// Whether the <see cref="Button"/> is disabled.
        /// </summary>
        /// <returns>Whether the <see cref="Button"/> is disabled</returns>
        public bool IsDisabled()
        {
            return this._disabled;
        }

        /// <summary>
        /// Sets whether the <see cref="Button"/> is disabled.
        /// </summary>
        /// <param name="state">Whether the <see cref="Button"/> is disabled</param>
        public void SetDisabled(bool state)
        {
            this._disabled = state;
        }

        /// <inheritdoc cref="Entity.SetTransitionState"/>
        public override void SetTransitionState(TransitionState transitionState, bool start = false)
        {
            base.SetTransitionState(transitionState, start);
            this._text.SetTransitionState(transitionState, true);
        }
    }
}