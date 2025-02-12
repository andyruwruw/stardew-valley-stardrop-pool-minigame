using Microsoft.Xna.Framework;
using MinigameFramework.Constants;
using MinigameFramework.Entities.UI.Buttons;
using MinigameFramework.Enums;
using MinigameFramework.Render.Filters;
using MinigameFramework.Utilities;

namespace StardopPoolMinigame.Entities.UI.Buttons
{
    class SubmitButton : Button
    {
        /// <summary>
        /// Instantiates a <see cref="SubmitButton"/>. It has a different sound! Yay!
        /// </summary>
        /// <param name="origin">Anchor's relation to <see cref="IEntity">IEntity's</see> position</param>
        /// <param name="anchor"><see cref="IEntity">IEntity's</see> anchor, or position<inheritdoc cref="_anchor"/></param>
        /// <param name="layerDepth"><see cref="IEntity">IEntity's</see> layer depth for rendering</param>
        /// <param name="enteringTransition"><see cref="IEntity">IEntity's</see> entering <see cref="Transition"/></param>
        /// <param name="exitingTransition"><see cref="IEntity">IEntity's</see> exiting <see cref="Transition"/></param>
        /// <param name="text"><see cref="Text"/> displayed for <see cref="Button"/></param>
        /// <param name="maxWidth">Max width of <see cref="Text"/> to break lines</param>
        /// <param name="isCentered">Whether the <see cref="Text"/> is centered</param>
        public SubmitButton(
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
            text,
            anchor,
            layerDepth,
            origin,
            enteringTransition,
            exitingTransition,
            maxWidth,
            scale,
            isCentered
        )
        {
        }

        /// <inheritdoc cref="Button.ClickCallback"/>
        public override void HandleClick()
        {
            Sounds.PlaySound(GenericSoundConstants.SubmitClick);
            Sounds.StopMusic();
        }

        /// <inheritdoc cref="Button.GetName"/>
        public override string GetName()
        {
            return $"submit-button-{_key}";
        }
    }
}
