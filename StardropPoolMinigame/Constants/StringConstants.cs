using System.Collections.Generic;

namespace StardropPoolMinigame.Constants
{
    internal class StringConstants
    {
        public class Buttons
        {
            public class CharacterSelect
            {
                public static string CHALLENGE = "menu.button.character-select.play";
            }

            public class MainMenu
            {
                public static string GALLERY = "menu.button.main.gallery";

                public static string MULTIPLAYER = "menu.button.main.multiplayer";

                public static string PLAY = "menu.button.main.play";

                public static string SETTINGS = "menu.button.main.settings";
            }
        }

        public class Entities
        {
            public class CharacterSelect
            {
                public static string ABIGAIL_PORTRAIT = "character-select-abigail-portrait";

                public static string BAR_SHELVES = "character-select-bar-shelves";

                public static string BOTTOM_BACKGROUND = "character-select-bottom-background";

                public static string CHALLENGE_BUTTON = "character-select-challenge-button";

                public static string CURSOR = "character-select-cursor";

                public static string GUS_PORTRAIT = "character-select-gus-portrait";

                public static string PAGE_TITLE = "character-select-page-title";

                public static IList<string> PORTRAITS = new List<string> {
                    SAM_PORTRAIT,
                    SEBASTIAN_PORTRAIT,
                    ABIGAIL_PORTRAIT,
                    GUS_PORTRAIT };

                public static string SAM_PORTRAIT = "character-select-sam-portrait";

                public static string SEBASTIAN_PORTRAIT = "character-select-sebastian-portrait";

                public static string SELECTED_NAME = "character-select-selected-name";
            }

            public class Dialog
            {
                public static string PORTRAIT = "dialog-portrait";

                public static string TEXT = "dialog-text";
            }

            public class Gallery
            {
            }

            public class Game
            {
                public static string FADE_IN = "game-fade-in";

                public static string FLOOR_TILES = "game-floor-tiles";

                public static string POCKETED_BALLS_PLAYER1 = "game-pocketed-balls-player-2";

                public static string POCKETED_BALLS_PLAYER2 = "game-pocketed-balls-player-1";

                public static string PORTRAIT = "game-portrait";

                public static string QUAD_TREE = "game-quad-tree";

                public static string TABLE = "game-table";
            }

            public class MainMenu
            {
                public static string ABIGAIL_PORTRAIT = "main-menu-abigail-portrait";

                public static string BAR_SHELVES = "main-menu-bar-shelves";

                public static IList<string> BUTTONS = new List<string> {
                    PLAY_BUTTON,
                    MULTIPLAYER_BUTTON,
                    GALLERY_BUTTON,
                    SETTINGS_BUTTON };

                public static string GALLERY_BUTTON = "main-menu-gallery-button";

                public static string GAME_TITLE = "main-menu-game-title";

                public static string GUS_PORTRAIT = "main-menu-gus-portrait";

                public static string MULTIPLAYER_BUTTON = "main-menu-multiplayer-button";

                public static string PLAY_BUTTON = "main-menu-play-button";

                public static string SAM_PORTRAIT = "main-menu-sam-portrait";

                public static string SEBASTIAN_PORTRAIT = "main-menu-sebastian-portrait";

                public static string SETTINGS_BUTTON = "main-menu-settings-button";
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
            public static string MINIGAME_NAME = "StardewPoolMinigame";
        }

        public class Popups
        {
            public static string BALL_POCKETED = "game.popup.ball-pocketed";

            public static string COMBO = "game.popup.combo";

            public static string DEFEAT = "game.popup.defeat";

            public static string OPPONENT_TURN = "game.popup.opponent-turn";

            public static string SCRATCH = "game.popup.scratch";

            public static string VICTORY = "game.popup.victory";

            public static string YOUR_TURN = "game.popup.your-turn";
        }

        public class Quotes
        {
            public class CharacterSelect
            {
                public class Abigail
                {
                    public class Confident
                    {
                        public static string VARIATION1 = "abigail.character-select.confident.variation-1";
                    }

                    public class Default
                    {
                        public static string VARIATION1 = "abigail.character-select.default.variation-1";
                    }

                    public class Discouraged
                    {
                        public static string VARIATION1 = "abigail.character-select.discouraged.variation-1";
                    }

                    public class Hopeless
                    {
                        public static string VARIATION1 = "abigail.character-select.hopeless.variation-1";
                    }
                }

                public class Gus
                {
                    public class Confident
                    {
                        public static string VARIATION1 = "gus.character-select.confident.variation-1";
                    }

                    public class Default
                    {
                        public static string VARIATION1 = "gus.character-select.default.variation-1";
                    }

                    public class Discouraged
                    {
                        public static string VARIATION1 = "gus.character-select.discouraged.variation-1";
                    }

                    public class Hopeless
                    {
                        public static string VARIATION1 = "gus.character-select.hopeless.variation-1";
                    }
                }

                public class Sam
                {
                    public class Confident
                    {
                        public static string VARIATION1 = "sam.character-select.confident.variation-1";
                    }

                    public class Default
                    {
                        public static string VARIATION1 = "sam.character-select.default.variation-1";
                    }

                    public class Discouraged
                    {
                        public static string VARIATION1 = "sam.character-select.discouraged.variation-1";
                    }

                    public class Hopeless
                    {
                        public static string VARIATION1 = "sam.character-select.hopeless.variation-1";
                    }
                }

                public class Sebastian
                {
                    public class Confident
                    {
                        public static string VARIATION1 = "sebastian.character-select.confident.variation-1";
                    }

                    public class Default
                    {
                        public static string VARIATION1 = "sebastian.character-select.default.variation-1";
                    }

                    public class Discouraged
                    {
                        public static string VARIATION1 = "sebastian.character-select.discouraged.variation-1";
                    }

                    public class Hopeless
                    {
                        public static string VARIATION1 = "sebastian.character-select.hopeless.variation-1";
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
                            public static string LINE1 = "abigail.dialog.confident.variation-1.line-1";
                        }
                    }

                    public class Default
                    {
                        public class Variation1
                        {
                            public static string LINE1 = "abigail.dialog.default.variation-1.line-1";
                        }
                    }

                    public class Discouraged
                    {
                        public class Variation1
                        {
                            public static string LINE1 = "abigail.dialog.discouraged.variation-1.line-1";
                        }
                    }

                    public class Hopeless
                    {
                        public class Variation1
                        {
                            public static string LINE1 = "abigail.dialog.hopeless.variation-1.line-1";
                        }
                    }
                }

                public class Gus
                {
                    public class Confident
                    {
                        public class Variation1
                        {
                            public static string LINE1 = "gus.dialog.confident.variation-1.line-1";
                        }
                    }

                    public class Default
                    {
                        public class Variation1
                        {
                            public static string LINE1 = "gus.dialog.default.variation-1.line-1";
                        }
                    }

                    public class Discouraged
                    {
                        public class Variation1
                        {
                            public static string LINE1 = "gus.dialog.discouraged.variation-1.line-1";
                        }
                    }

                    public class Hopeless
                    {
                        public class Variation1
                        {
                            public static string LINE1 = "gus.dialog.hopeless.variation-1.line-1";
                        }
                    }
                }

                public class Sam
                {
                    public class Confident
                    {
                        public class Variation1
                        {
                            public static string LINE1 = "sam.dialog.confident.variation-1.line-1";
                        }
                    }

                    public class Default
                    {
                        public class Variation1
                        {
                            public static string LINE1 = "sam.dialog.default.variation-1.line-1";
                        }
                    }

                    public class Discouraged
                    {
                        public class Variation1
                        {
                            public static string LINE1 = "sam.dialog.discouraged.variation-1.line-1";
                        }
                    }

                    public class Hopeless
                    {
                        public class Variation1
                        {
                            public static string LINE1 = "sam.dialog.hopeless.variation-1.line-1";
                        }
                    }
                }

                public class Sebastian
                {
                    public class Confident
                    {
                        public class Variation1
                        {
                            public static string LINE1 = "sebastian.dialog.confident.variation-1.line-1";
                        }
                    }

                    public class Default
                    {
                        public class Variation1
                        {
                            public static string LINE1 = "sebastian.dialog.default.variation-1.line-1";
                        }
                    }

                    public class Discouraged
                    {
                        public class Variation1
                        {
                            public static string LINE1 = "sebastian.dialog.discouraged.variation-1.line-1";
                        }
                    }

                    public class Hopeless
                    {
                        public class Variation1
                        {
                            public static string LINE1 = "sebastian.dialog.hopeless.variation-1.line-1";
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
                    public static string LINE1 = "abigail.introduction.line-1";

                    public static string LINE2 = "abigail.introduction.line-2";

                    public static string LINE3 = "abigail.introduction.line-3";
                }

                public class Gus
                {
                    public static string LINE1 = "gus.introduction.line-1";

                    public static string LINE2 = "gus.introduction.line-2";

                    public static string LINE3 = "gus.introduction.line-3";

                    public static string LINE4 = "gus.introduction.line-3";
                }

                public class Sam
                {
                    public static string LINE1 = "sam.introduction.line-1";

                    public static string LINE2 = "sam.introduction.line-2";

                    public static string LINE3 = "sam.introduction.line-3";

                    public static string LINE4 = "sam.introduction.line-4";

                    public static string LINE5 = "sam.introduction.line-5";

                    public static string LINE6 = "sam.introduction.line-6";

                    public static string LINE7 = "sam.introduction.line-7";
                }

                public class Sebastian
                {
                    public static string LINE1 = "sebastian.introduction.line-1";

                    public static string LINE2 = "sebastian.introduction.line-2";

                    public static string LINE3 = "sebastian.introduction.line-3";

                    public static string LINE4 = "sebastian.introduction.line-4";
                }
            }

            public class Reveal
            {
                public class Abigail
                {
                    public static string LINE1 = "abigail.reveal.line-1";

                    public static string LINE2 = "abigail.reveal.line-2";

                    public static string LINE3 = "abigail.reveal.line-3";
                }

                public class Gus
                {
                    public static string LINE1 = "gus.reveal.line-1";

                    public static string LINE2 = "gus.reveal.line-2";

                    public static string LINE3 = "gus.reveal.line-3";

                    public static string LINE4 = "gus.reveal.line-3";
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
                            public static string VARIATION1 = "abigail.summary.loss.confident.variation-1";
                        }

                        public class Default
                        {
                            public static string VARIATION1 = "abigail.summary.loss.default.variation-1";
                        }

                        public class Discouraged
                        {
                            public static string VARIATION1 = "abigail.summary.loss.discouraged.variation-1";
                        }

                        public class Hopeless
                        {
                            public static string VARIATION1 = "abigail.summary.loss.hopeless.variation-1";
                        }
                    }

                    public class Win
                    {
                        public class Confident
                        {
                            public static string VARIATION1 = "abigail.summary.win.confident.variation-1";
                        }

                        public class Default
                        {
                            public static string VARIATION1 = "abigail.summary.win.default.variation-1";
                        }

                        public class Discouraged
                        {
                            public static string VARIATION1 = "abigail.summary.win.discouraged.variation-1";
                        }

                        public class Hopeless
                        {
                            public static string VARIATION1 = "abigail.summary.win.hopeless.variation-1";
                        }
                    }
                }

                public class Gus
                {
                    public class Loss
                    {
                        public class Confident
                        {
                            public static string VARIATION1 = "gus.summary.loss.confident.variation-1";
                        }

                        public class Default
                        {
                            public static string VARIATION1 = "gus.summary.loss.default.variation-1";
                        }

                        public class Discouraged
                        {
                            public static string VARIATION1 = "gus.summary.loss.discouraged.variation-1";
                        }

                        public class Hopeless
                        {
                            public static string VARIATION1 = "gus.summary.loss.hopeless.variation-1";
                        }
                    }

                    public class Win
                    {
                        public class Confident
                        {
                            public static string VARIATION1 = "gus.summary.win.confident.variation-1";
                        }

                        public class Default
                        {
                            public static string VARIATION1 = "gus.summary.win.default.variation-1";
                        }

                        public class Discouraged
                        {
                            public static string VARIATION1 = "gus.summary.win.discouraged.variation-1";
                        }

                        public class Hopeless
                        {
                            public static string VARIATION1 = "gus.summary.win.hopeless.variation-1";
                        }
                    }
                }

                public class Sam
                {
                    public class Loss
                    {
                        public class Confident
                        {
                            public static string VARIATION1 = "sam.summary.loss.confident.variation-1";
                        }

                        public class Default
                        {
                            public static string VARIATION1 = "sam.summary.loss.default.variation-1";
                        }

                        public class Discouraged
                        {
                            public static string VARIATION1 = "sam.summary.loss.discouraged.variation-1";
                        }

                        public class Hopeless
                        {
                            public static string VARIATION1 = "sam.summary.loss.hopeless.variation-1";
                        }
                    }

                    public class Win
                    {
                        public class Confident
                        {
                            public static string VARIATION1 = "sam.summary.win.confident.variation-1";
                        }

                        public class Default
                        {
                            public static string VARIATION1 = "sam.summary.win.default.variation-1";
                        }

                        public class Discouraged
                        {
                            public static string VARIATION1 = "sam.summary.win.discouraged.variation-1";
                        }

                        public class Hopeless
                        {
                            public static string VARIATION1 = "sam.summary.win.hopeless.variation-1";
                        }
                    }
                }

                public class Sebastian
                {
                    public class Loss
                    {
                        public class Confident
                        {
                            public static string VARIATION1 = "sebastian.summary.loss.confident.variation-1";
                        }

                        public class Default
                        {
                            public static string VARIATION1 = "sebastian.summary.loss.default.variation-1";
                        }

                        public class Discouraged
                        {
                            public static string VARIATION1 = "sebastian.summary.loss.discouraged.variation-1";
                        }

                        public class Hopeless
                        {
                            public static string VARIATION1 = "sebastian.summary.loss.hopeless.variation-1";
                        }
                    }

                    public class Win
                    {
                        public class Confident
                        {
                            public static string VARIATION1 = "sebastian.summary.win.confident.variation-1";
                        }

                        public class Default
                        {
                            public static string VARIATION1 = "sebastian.summary.win.default.variation-1";
                        }

                        public class Discouraged
                        {
                            public static string VARIATION1 = "sebastian.summary.win.discouraged.variation-1";
                        }

                        public class Hopeless
                        {
                            public static string VARIATION1 = "sebastian.summary.win.hopeless.variation-1";
                        }
                    }
                }
            }
        }

        public class Titles
        {
            public static string CHARACTER_SELECT = "menu.title.character-select";

            public static string DIALOG = "";
        }
    }
}