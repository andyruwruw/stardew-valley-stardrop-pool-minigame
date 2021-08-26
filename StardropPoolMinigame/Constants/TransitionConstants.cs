using Microsoft.Xna.Framework;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Render;
using StardropPoolMinigame.Render.Filters;
using System;

namespace StardropPoolMinigame.Constants
{
    class TransitionConstants
    {
        public static IFilter CharacterSelectScenePageTitleEnteringTransition()
        {
            return new SlideIn(
                40,
                true,
                TransitionState.Entering,
                20,
                new Vector2(0, -25));
        }

        public static IFilter CharacterSelectSceneOpponentButtonEnteringTransition()
        {
            return new SlideIn(
                30,
                true,
                TransitionState.Entering,
                20,
                new Vector2(0, Textures.PORTRAIT_SAM_DEFAULT_BOUNDS.Height / 2));
        }

        public static IFilter CharacterSelectScenePortraitFadeInTransition()
        {
            return new SlideIn(
                25,
                true,
                TransitionState.Entering,
                20,
                new Vector2(0, 0));
        }

        public static IFilter CharacterSelectSceneOpponentNameEnteringTransition()
        {
            return new SlideIn(
                20,
                true,
                TransitionState.Entering,
                30,
                new Vector2(0, 8),
                true);
        }

        public static IFilter CharacterSelectScenePortraitExitingTransition()
        {
            return new SlideIn(
                30,
                true,
                TransitionState.Exiting,
                (int)Math.Round(Helpers.Random.Fraction() * 10),
                new Vector2(0, Textures.PORTRAIT_SAM_DEFAULT_BOUNDS.Height / 2));
        }

        public static IFilter CharacterSelectSceneActivePortraitExitingTransition()
        {
            return new SlideIn(
                30,
                true,
                TransitionState.Exiting,
                60,
                new Vector2(0, Textures.PORTRAIT_SAM_DEFAULT_BOUNDS.Height / 2));
        }

        public static IFilter MainMenuSceneButtonEnteringTransition(int buttonNum) {
            return new SlideIn(
                30,
                true,
                TransitionState.Entering,
                30 + (buttonNum * 4),
                new Vector2(0, 8));
        }

        public static IFilter MainMenuSceneButtonExitingTransition(int buttonNum)
        {
            return new SlideIn(
                30,
                true,
                TransitionState.Exiting,
                buttonNum * -4,
                new Vector2(0, 8));
        }

        public static IFilter MainMenuScenePortraitEnteringTransition()
        {
            return new SlideIn(
                30,
                false,
                TransitionState.Entering,
                (int)Math.Round(Helpers.Random.Fraction() * 10),
                new Vector2(0, Textures.PORTRAIT_SAM_DEFAULT_BOUNDS.Height / 2));
        }

        public static IFilter MainMenuSceneGameTitleEnteringTransition()
        {
            return new SlideIn(
                60, 
                true,
                TransitionState.Entering,
                new Vector2(0, -25));
        }

        public static IFilter MainMenuSceneGameTitleExitingTransition()
        {
            return new SlideIn(
                30,
                true,
                TransitionState.Exiting,
                new Vector2(0, -25));
        }

        public static IFilter MainMenuSceneActivePortraitExitingTransition()
        {
            return new SlideIn(
                1,
                false,
                TransitionState.Exiting,
                45,
                new Vector2(0, 0));
        }
    }
}
