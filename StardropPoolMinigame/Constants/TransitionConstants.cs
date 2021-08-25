using Microsoft.Xna.Framework;
using StardropPoolMinigame.Helpers;
using StardropPoolMinigame.Render;
using StardropPoolMinigame.Render.Filters;
using System;

namespace StardropPoolMinigame.Constants
{
    class TransitionConstants
    {
        public static IFilter MainMenuSceneButtonEnteringTransition(int buttonNum) {
            return new SlideIn(
                30,
                40 + (buttonNum * 4),
                true,
                new Vector2(0, 8));
        }

        public static IFilter MainMenuScenePortraitEnteringTransition()
        {
            return new SlideIn(
                30,
                (int)Math.Round(Helpers.Random.Fraction() * 10),
                false,
                new Vector2(0, Textures.PORTRAIT_SAM_DEFAULT_BOUNDS.Height / 2));
        }

        public static IFilter MainMenuSceneGameTitleEnteringTransition()
        {
            return new SlideIn(
                60, 
                true, 
                new Vector2(0, -25));
        }
    }
}
