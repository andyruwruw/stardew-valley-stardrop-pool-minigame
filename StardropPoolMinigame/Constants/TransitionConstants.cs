using Microsoft.Xna.Framework;
using StardewValley;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Render;
using StardropPoolMinigame.Render.Filters;
using System;

namespace StardropPoolMinigame.Constants
{
    class TransitionConstants
    {
        public class MainMenu
        {
            public class Button
            {
                public static IFilter Entering(int buttonNum)
                {
                    return new SlideIn(
                        30,
                        true,
                        TransitionState.Entering,
                        30 + (buttonNum * 4),
                        new Vector2(0, 8));
                }

                public static IFilter Exiting(int buttonNum)
                {
                    return new SlideIn(
                        30,
                        true,
                        TransitionState.Exiting,
                        buttonNum * -4,
                        new Vector2(0, 8));
                }
            }

            public class Portrait
            {
                public static IFilter Entering()
                {
                    return new SlideIn(
                        30,
                        false,
                        TransitionState.Entering,
                        (int)Math.Round(Helpers.Random.Fraction() * 10),
                        new Vector2(0, Textures.Portrait.Sam.DEFAULT.Height / 2));
                }

                public static IFilter Exiting()
                {
                    return new SlideIn(
                        1,
                        false,
                        TransitionState.Exiting,
                        45,
                        new Vector2(0, 0));
                }
            }

            public class GameTitle
            {
                public static IFilter Entering()
                {
                    return new SlideIn(
                        60,
                        true,
                        TransitionState.Entering,
                        new Vector2(0, -25));
                }

                public static IFilter Exiting()
                {
                    return new SlideIn(
                        30,
                        true,
                        TransitionState.Exiting,
                        new Vector2(0, -25));
                }
            }
        }

        public class CharacterSelect
        {
            public class PageTitle
            {
                public static IFilter Entering()
                {
                    return new SlideIn(
                        40,
                        true,
                        TransitionState.Entering,
                        20,
                        new Vector2(0, -25));
                }
            }

            public class Portrait
            {
                public static IFilter Entering()
                {
                    return new SlideIn(
                        25,
                        true,
                        TransitionState.Entering,
                        20,
                        new Vector2(0, 0));
                }

                public static IFilter Exiting()
                {
                    return new SlideIn(
                        30,
                        true,
                        TransitionState.Exiting,
                        (int)Math.Round(Helpers.Random.Fraction() * 10),
                        new Vector2(0, Textures.Portrait.Sam.DEFAULT.Height / 2));
                }

                public static IFilter ActiveExiting()
                {
                    return new SlideIn(
                        30,
                        true,
                        TransitionState.Exiting,
                        60,
                        new Vector2(0, Textures.Portrait.Sam.DEFAULT.Height / 2));
                }
            }

            public class OpponentName
            {
                public static IFilter Entering()
                {
                    return new SlideIn(
                        20,
                        true,
                        TransitionState.Entering,
                        30,
                        new Vector2(0, 8),
                        true);
                }
            }

            public static IFilter Exiting()
            {
                return new SlideIn(
                    10,
                    true,
                    TransitionState.Exiting,
                    90,
                    new Vector2(0, 0));
            }
        }

        public class Dialog
        {
            public class Portrait
            {
                public static IFilter Entering()
                {
                    return new SlideIn(
                        40,
                        true,
                        TransitionState.Entering,
                        130,
                        new Vector2(0, -25));
                }
            }

            public class Text
            {
                public static IFilter FirstEntering()
                {
                    return new SlideIn(
                       15,
                       true,
                       TransitionState.Entering,
                       170,
                       new Vector2(0, 5));
                }

                public static IFilter Entering()
                {
                    return new SlideIn(
                       15,
                       true,
                       TransitionState.Entering,
                       15,
                       new Vector2(0, 5));
                }

                public static IFilter Exiting()
                {
                    return new SlideIn(
                       15,
                       true,
                       TransitionState.Exiting,
                       0,
                       new Vector2(0, -5));
                }
            }
        }

        public class Game
        {
            public class FadeIn
            {
                public static IFilter Exiting()
                {
                    return new SlideIn(
                        80,
                        true,
                        TransitionState.Exiting,
                        20,
                        new Vector2(0, 0));
                }
            }

            public class PocketedBalls
            {
                public static IFilter Entering()
                {
                    return new SlideIn(
                        60,
                        true,
                        TransitionState.Entering,
                        20,
                        new Vector2(0, -50));
                }
            }

            public class Portrait
            {
                public static IFilter Entering()
                {
                    return new SlideIn(
                        80,
                        true,
                        TransitionState.Entering,
                        40,
                        new Vector2(Textures.Portrait.Sam.DEFAULT.Width, 0));
                }
            }
        }
    }
}
