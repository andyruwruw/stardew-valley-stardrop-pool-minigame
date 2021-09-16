using System.Collections.Generic;

namespace StardropPoolMinigame.Constants
{
    internal class StringConstants
    {
        public class Buttons
        {
            public class CharacterSelect
            {
                public static string Challenge = "menu.button.character-select.play";
            }

            public class MainMenu
            {
                public static string Gallery = "menu.button.main.gallery";

                public static string Multiplayer = "menu.button.main.multiplayer";

                public static string Play = "menu.button.main.play";

                public static string Settings = "menu.button.main.settings";
            }
        }

        public class Entities
        {
            public class CharacterSelect
            {
                public static string AbigailPortrait = "character-select-abigail-portrait";

                public static string BarShelves = "character-select-bar-shelves";

                public static string BottomBackground = "character-select-bottom-background";

                public static string ChallengeButton = "character-select-challenge-button";

                public static string Cursor = "character-select-cursor";

                public static string GusPortrait = "character-select-gus-portrait";

                public static string PageTitle = "character-select-page-title";

                public static IList<string> Portraits = new List<string> {
                    SamPortrait,
                    SebastianPortrait,
                    AbigailPortrait,
                    GusPortrait };

                public static string SamPortrait = "character-select-sam-portrait";

                public static string SebastianPortrait = "character-select-sebastian-portrait";

                public static string SelectedName = "character-select-selected-name";
            }

            public class Dialog
            {
                public static string Portrait = "dialog-portrait";

                public static string Text = "dialog-text";
            }

            public class Gallery
            {
            }

            public class Game
            {
                public static string FadeIn = "game-fade-in";

                public static string FloorTiles = "game-floor-tiles";

                public static string PocketedBallsPlayer1 = "game-pocketed-balls-player-2";

                public static string PocketedBallsPlayer2 = "game-pocketed-balls-player-1";

                public static string Portrait = "game-portrait";

                public static string QuadTree = "game-quad-tree";

                public static string Table = "game-table";
            }

            public class MainMenu
            {
                public static string AbigailPortrait = "main-menu-abigail-portrait";

                public static string BarShelves = "main-menu-bar-shelves";

                public static IList<string> Buttons = new List<string> {
                    PlayButton,
                    MultiplayerButton,
                    GalleryButton,
                    SettingsButton };

                public static string GalleryButton = "main-menu-gallery-button";

                public static string GameTitle = "main-menu-game-title";

                public static string GusPortrait = "main-menu-gus-portrait";

                public static string MultiplayerButton = "main-menu-multiplayer-button";

                public static string PlayButton = "main-menu-play-button";

                public static string SamPortrait = "main-menu-sam-portrait";

                public static string SebastianPortrait = "main-menu-sebastian-portrait";

                public static string SettingsButton = "main-menu-settings-button";
            }

            public class Multiplayer
            {
            }

            public class Settings
            {
            }

            public class Summary
            {
            }
        }

        public class General
        {
            public static string MinigameName = "StardewPoolMinigame";
        }

        public class Popups
        {
            public static string BallPocketed = "game.popup.ball-pocketed";

            public static string Combo = "game.popup.combo";

            public static string Defeat = "game.popup.defeat";

            public static string OpponentTurn = "game.popup.opponent-turn";

            public static string Scratch = "game.popup.scratch";

            public static string Victory = "game.popup.victory";

            public static string YourTurn = "game.popup.your-turn";
        }

        public class Quotes
        {
            public class CharacterSelect
            {
                public class Abigail
                {
                    public class Confident
                    {
                        public static string Variation1 = "abigail.character-select.confident.variation-1";
                    }

                    public class Default
                    {
                        public static string Variation1 = "abigail.character-select.default.variation-1";
                    }

                    public class Discouraged
                    {
                        public static string Variation1 = "abigail.character-select.discouraged.variation-1";
                    }

                    public class Hopeless
                    {
                        public static string Variation1 = "abigail.character-select.hopeless.variation-1";
                    }
                }

                public class Gus
                {
                    public class Confident
                    {
                        public static string Variation1 = "gus.character-select.confident.variation-1";
                    }

                    public class Default
                    {
                        public static string Variation1 = "gus.character-select.default.variation-1";
                    }

                    public class Discouraged
                    {
                        public static string Variation1 = "gus.character-select.discouraged.variation-1";
                    }

                    public class Hopeless
                    {
                        public static string Variation1 = "gus.character-select.hopeless.variation-1";
                    }
                }

                public class Sam
                {
                    public class Confident
                    {
                        public static string Variation1 = "sam.character-select.confident.variation-1";
                    }

                    public class Default
                    {
                        public static string Variation1 = "sam.character-select.default.variation-1";
                    }

                    public class Discouraged
                    {
                        public static string Variation1 = "sam.character-select.discouraged.variation-1";
                    }

                    public class Hopeless
                    {
                        public static string Variation1 = "sam.character-select.hopeless.variation-1";
                    }
                }

                public class Sebastian
                {
                    public class Confident
                    {
                        public static string Variation1 = "sebastian.character-select.confident.variation-1";
                    }

                    public class Default
                    {
                        public static string Variation1 = "sebastian.character-select.default.variation-1";
                    }

                    public class Discouraged
                    {
                        public static string Variation1 = "sebastian.character-select.discouraged.variation-1";
                    }

                    public class Hopeless
                    {
                        public static string Variation1 = "sebastian.character-select.hopeless.variation-1";
                    }
                }
            }

            public class Dialog
            {
                public class Abigail
                {
                    public class Confident
                    {
                        public class Variation1
                        {
                            public static string Line1 = "abigail.dialog.confident.variation-1.line-1";
                        }
                    }

                    public class Default
                    {
                        public class Variation1
                        {
                            public static string Line1 = "abigail.dialog.default.variation-1.line-1";
                        }
                    }

                    public class Discouraged
                    {
                        public class Variation1
                        {
                            public static string Line1 = "abigail.dialog.discouraged.variation-1.line-1";
                        }
                    }

                    public class Hopeless
                    {
                        public class Variation1
                        {
                            public static string Line1 = "abigail.dialog.hopeless.variation-1.line-1";
                        }
                    }
                }

                public class Gus
                {
                    public class Confident
                    {
                        public class Variation1
                        {
                            public static string Line1 = "gus.dialog.confident.variation-1.line-1";
                        }
                    }

                    public class Default
                    {
                        public class Variation1
                        {
                            public static string Line1 = "gus.dialog.default.variation-1.line-1";
                        }
                    }

                    public class Discouraged
                    {
                        public class Variation1
                        {
                            public static string Line1 = "gus.dialog.discouraged.variation-1.line-1";
                        }
                    }

                    public class Hopeless
                    {
                        public class Variation1
                        {
                            public static string Line1 = "gus.dialog.hopeless.variation-1.line-1";
                        }
                    }
                }

                public class Sam
                {
                    public class Confident
                    {
                        public class Variation1
                        {
                            public static string Line1 = "sam.dialog.confident.variation-1.line-1";
                        }
                    }

                    public class Default
                    {
                        public class Variation1
                        {
                            public static string Line1 = "sam.dialog.default.variation-1.line-1";
                        }
                    }

                    public class Discouraged
                    {
                        public class Variation1
                        {
                            public static string Line1 = "sam.dialog.discouraged.variation-1.line-1";
                        }
                    }

                    public class Hopeless
                    {
                        public class Variation1
                        {
                            public static string Line1 = "sam.dialog.hopeless.variation-1.line-1";
                        }
                    }
                }

                public class Sebastian
                {
                    public class Confident
                    {
                        public class Variation1
                        {
                            public static string Line1 = "sebastian.dialog.confident.variation-1.line-1";
                        }
                    }

                    public class Default
                    {
                        public class Variation1
                        {
                            public static string Line1 = "sebastian.dialog.default.variation-1.line-1";
                        }
                    }

                    public class Discouraged
                    {
                        public class Variation1
                        {
                            public static string Line1 = "sebastian.dialog.discouraged.variation-1.line-1";
                        }
                    }

                    public class Hopeless
                    {
                        public class Variation1
                        {
                            public static string Line1 = "sebastian.dialog.hopeless.variation-1.line-1";
                        }
                    }
                }
            }

            public class Interact
            {
                public class Abigail
                {
                }

                public class Gus
                {
                }

                public class Sam
                {
                }

                public class Sebastian
                {
                }
            }

            public class Introduction
            {
                public class Abigail
                {
                    public static string Line1 = "abigail.introduction.line-1";

                    public static string Line2 = "abigail.introduction.line-2";

                    public static string Line3 = "abigail.introduction.line-3";
                }

                public class Gus
                {
                    public static string Line1 = "gus.introduction.line-1";

                    public static string Line2 = "gus.introduction.line-2";

                    public static string Line3 = "gus.introduction.line-3";

                    public static string Line4 = "gus.introduction.line-3";
                }

                public class Sam
                {
                    public static string Line1 = "sam.introduction.line-1";

                    public static string Line2 = "sam.introduction.line-2";

                    public static string Line3 = "sam.introduction.line-3";

                    public static string Line4 = "sam.introduction.line-4";

                    public static string Line5 = "sam.introduction.line-5";

                    public static string Line6 = "sam.introduction.line-6";

                    public static string Line7 = "sam.introduction.line-7";
                }

                public class Sebastian
                {
                    public static string Line1 = "sebastian.introduction.line-1";

                    public static string Line2 = "sebastian.introduction.line-2";

                    public static string Line3 = "sebastian.introduction.line-3";

                    public static string Line4 = "sebastian.introduction.line-4";
                }
            }

            public class Reveal
            {
                public class Abigail
                {
                    public static string Line1 = "abigail.reveal.line-1";

                    public static string Line2 = "abigail.reveal.line-2";

                    public static string Line3 = "abigail.reveal.line-3";
                }

                public class Gus
                {
                    public static string Line1 = "gus.reveal.line-1";

                    public static string Line2 = "gus.reveal.line-2";

                    public static string Line3 = "gus.reveal.line-3";

                    public static string Line4 = "gus.reveal.line-3";
                }
            }

            public class Summary
            {
                public class Abigail
                {
                    public class Loss
                    {
                        public class Confident
                        {
                            public static string Variation1 = "abigail.summary.loss.confident.variation-1";
                        }

                        public class Default
                        {
                            public static string Variation1 = "abigail.summary.loss.default.variation-1";
                        }

                        public class Discouraged
                        {
                            public static string Variation1 = "abigail.summary.loss.discouraged.variation-1";
                        }

                        public class Hopeless
                        {
                            public static string Variation1 = "abigail.summary.loss.hopeless.variation-1";
                        }
                    }

                    public class Win
                    {
                        public class Confident
                        {
                            public static string Variation1 = "abigail.summary.win.confident.variation-1";
                        }

                        public class Default
                        {
                            public static string Variation1 = "abigail.summary.win.default.variation-1";
                        }

                        public class Discouraged
                        {
                            public static string Variation1 = "abigail.summary.win.discouraged.variation-1";
                        }

                        public class Hopeless
                        {
                            public static string Variation1 = "abigail.summary.win.hopeless.variation-1";
                        }
                    }
                }

                public class Gus
                {
                    public class Loss
                    {
                        public class Confident
                        {
                            public static string Variation1 = "gus.summary.loss.confident.variation-1";
                        }

                        public class Default
                        {
                            public static string Variation1 = "gus.summary.loss.default.variation-1";
                        }

                        public class Discouraged
                        {
                            public static string Variation1 = "gus.summary.loss.discouraged.variation-1";
                        }

                        public class Hopeless
                        {
                            public static string Variation1 = "gus.summary.loss.hopeless.variation-1";
                        }
                    }

                    public class Win
                    {
                        public class Confident
                        {
                            public static string Variation1 = "gus.summary.win.confident.variation-1";
                        }

                        public class Default
                        {
                            public static string Variation1 = "gus.summary.win.default.variation-1";
                        }

                        public class Discouraged
                        {
                            public static string Variation1 = "gus.summary.win.discouraged.variation-1";
                        }

                        public class Hopeless
                        {
                            public static string Variation1 = "gus.summary.win.hopeless.variation-1";
                        }
                    }
                }

                public class Sam
                {
                    public class Loss
                    {
                        public class Confident
                        {
                            public static string Variation1 = "sam.summary.loss.confident.variation-1";
                        }

                        public class Default
                        {
                            public static string Variation1 = "sam.summary.loss.default.variation-1";
                        }

                        public class Discouraged
                        {
                            public static string Variation1 = "sam.summary.loss.discouraged.variation-1";
                        }

                        public class Hopeless
                        {
                            public static string Variation1 = "sam.summary.loss.hopeless.variation-1";
                        }
                    }

                    public class Win
                    {
                        public class Confident
                        {
                            public static string Variation1 = "sam.summary.win.confident.variation-1";
                        }

                        public class Default
                        {
                            public static string Variation1 = "sam.summary.win.default.variation-1";
                        }

                        public class Discouraged
                        {
                            public static string Variation1 = "sam.summary.win.discouraged.variation-1";
                        }

                        public class Hopeless
                        {
                            public static string Variation1 = "sam.summary.win.hopeless.variation-1";
                        }
                    }
                }

                public class Sebastian
                {
                    public class Loss
                    {
                        public class Confident
                        {
                            public static string Variation1 = "sebastian.summary.loss.confident.variation-1";
                        }

                        public class Default
                        {
                            public static string Variation1 = "sebastian.summary.loss.default.variation-1";
                        }

                        public class Discouraged
                        {
                            public static string Variation1 = "sebastian.summary.loss.discouraged.variation-1";
                        }

                        public class Hopeless
                        {
                            public static string Variation1 = "sebastian.summary.loss.hopeless.variation-1";
                        }
                    }

                    public class Win
                    {
                        public class Confident
                        {
                            public static string Variation1 = "sebastian.summary.win.confident.variation-1";
                        }

                        public class Default
                        {
                            public static string Variation1 = "sebastian.summary.win.default.variation-1";
                        }

                        public class Discouraged
                        {
                            public static string Variation1 = "sebastian.summary.win.discouraged.variation-1";
                        }

                        public class Hopeless
                        {
                            public static string Variation1 = "sebastian.summary.win.hopeless.variation-1";
                        }
                    }
                }
            }
        }

        public class Titles
        {
            public static string CharacterSelect = "menu.title.character-select";

            public static string Dialog = "";
        }
    }
}