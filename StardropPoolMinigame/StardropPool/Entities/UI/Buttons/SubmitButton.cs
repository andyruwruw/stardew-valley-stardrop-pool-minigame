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
