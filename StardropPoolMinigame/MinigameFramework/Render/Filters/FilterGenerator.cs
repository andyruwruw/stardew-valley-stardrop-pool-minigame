using Microsoft.Xna.Framework;
using MinigameFramework.Enums;
using MinigameFramework.Helpers;
using MinigameFramework.Render.Filters;
using MinigameFramework.Render.Filters.Transitions;

namespace StardopPoolMinigame.MinigameFramework.Render.Filters
{
    static class FilterGenerator
    {
        /// <summary>
        /// Creates a new slide in transition.
        /// </summary>
        public static IFilter CreateSlideTransition(
            Vector2 difference,
            int index = 0,
            int indexDelay = 4,
            int duration = 30,
            bool keyframeOpacity = true,
            int delay = 30,
            bool delayOnce = false,
            bool randomDelay = false,
            int maxRandomDelay = 10,
            int minRandomDelay = 0,
            TransitionState type = TransitionState.Entering
        ) {
            int random = 0;

            if (randomDelay)
            {
                random = (int)Math.Round(MiscellaneousHelpers.Random() * (maxRandomDelay - minRandomDelay)) + minRandomDelay;
            }

            return new SlideIn(
                duration,
                keyframeOpacity,
                type,
                (index * indexDelay) + delay + random,
                difference,
                delayOnce
            );
        }
    }
}
