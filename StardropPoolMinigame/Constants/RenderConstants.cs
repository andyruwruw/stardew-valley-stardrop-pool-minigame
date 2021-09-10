using Microsoft.Xna.Framework;
using StardewValley;

namespace StardropPoolMinigame.Constants
{
    class RenderConstants
    {
        /// <summary>
        /// Tile size on tile sheet.
        /// </summary>
        public static int TILE_SIZE = 16;

        /// <summary>
        /// Stardew Valley zoom settings.
        /// </summary>
        public static float PixelZoomAdjustement()
        {
            return 1f / Game1.options.zoomLevel;
        }

        /// <summary>
        /// Tile size and pixel zoom adjustment.
        /// </summary>
        /// <returns>Multiplier value</returns>
        public static float TileScale()
        {
            return 4 * PixelZoomAdjustement();
        }

        /// <summary>
        /// Dimensions of the Stardew Valley window.
        /// </summary>
        public class Viewport
        {
            /// <summary>
            /// The height of the Stardew Valley window.
            /// </summary>
            public static int Height()
            {
                return Game1.game1.localMultiplayerWindow.Height;
            }

            /// <summary>
            /// The width of the Stardew Valley window.
            /// </summary>
            public static int Width()
            {
                return Game1.game1.localMultiplayerWindow.Width;
            }

            /// <summary>
            /// Gets center of the Stardew Valley window.
            /// </summary>
            public static Vector2 GetCenter()
            {
                return Vector2.Divide(new Vector2(Viewport.Width(), Viewport.Height()), 2);
            }
        }

        /// <summary>
        /// Dimensions of the minigame window.
        /// </summary>
        public class MinigameScreen
        {
            /// <summary>
            /// The height of the minigame window.
            /// </summary>
            public static int HEIGHT = 224;

            /// <summary>
            /// The width of the minigame window.
            /// </summary>
            public static int WIDTH = 400;
        }

        /// <summary>
        /// Dimensions of the minigame window adjusted with zoom settings and tile scale.
        /// </summary>
        public class AdjustedScreen
        {
            /// <summary>
            /// The height of the minigame window adjusted with zoom settings and tile scale.
            /// </summary>
            public static float Height()
            {
                return MinigameScreen.HEIGHT * TileScale();
            }

            /// <summary>
            /// The width of the minigame window adjusted with zoom settings and tile scale.
            /// </summary>
            public static float Width()
            {
                return MinigameScreen.WIDTH * TileScale();
            }

            /// <summary>
            /// Gets center of minigame window adjusted with zoom settings and tile scale.
            /// </summary>
            public static Vector2 GetCenter()
            {
                return Vector2.Divide(new Vector2(AdjustedScreen.Width(), AdjustedScreen.Height()), 2);
            }

            /// <summary>
            /// Gets top-left of minigame window adjusted with zoom settings and tile scale.
            /// </summary>
            public static Vector2 GetNorthWest()
            {
                return new Vector2(Margin.Width(), Margin.Height());
            }

            /// <summary>
            /// Gets top-right of minigame window adjusted with zoom settings and tile scale.
            /// </summary>
            public static Vector2 GetNorthEast()
            {
                return new Vector2(Viewport.Width() - Margin.Width(), Margin.Height());
            }

            /// <summary>
            /// Gets bottom-left of minigame window adjusted with zoom settings and tile scale.
            /// </summary>
            public static Vector2 GetSouthWest()
            {
                return new Vector2(Margin.Width(), Viewport.Height() - Margin.Height());
            }

            /// <summary>
            /// Gets bottom-right of minigame window adjusted with zoom settings and tile scale.
            /// </summary>
            public static Vector2 GetSouthEast()
            {
                return new Vector2(Viewport.Width() - Margin.Width(), Viewport.Height() - Margin.Height());
            }

            /// <summary>
            /// Difference between the <see cref="Viewport"/> and <see cref="AdjustedScreen"/>.
            /// </summary>
            public class Difference
            {
                /// <summary>
                /// Difference in height between the <see cref="Viewport"/> and <see cref="AdjustedScreen"/>.
                /// </summary>
                public static float Height()
                {
                    return Viewport.Height() - AdjustedScreen.Height();
                }

                /// <summary>
                /// Difference in width between the <see cref="Viewport"/> and <see cref="AdjustedScreen"/>.
                /// </summary>
                public static float Width()
                {
                    return Viewport.Width() - AdjustedScreen.Width();
                }
            }

            /// <summary>
            /// Space between <see cref="Viewport"/> and <see cref="AdjustedScreen"/>.
            /// </summary>
            public class Margin
            {
                /// <summary>
                /// Space between top of <see cref="Viewport"/> and top of <see cref="AdjustedScreen"/>.
                /// </summary>
                public static float Height()
                {
                    return AdjustedScreen.Difference.Height() / 2;
                }

                /// <summary>
                /// Space between left of <see cref="Viewport"/> and left of <see cref="AdjustedScreen"/>.
                /// </summary>
                public static float Width()
                {
                    return AdjustedScreen.Difference.Width() / 2;
                }
            }
        }

        /// <summary>
        /// Converts <see cref="Vector2"/> coordinates relative to <see cref="AdjustedScreen"/>, to <see cref="Vector2"/> relative to <see cref="Viewport"/>.
        /// </summary>
        /// <param name="point"><see cref="Vector2"/> relative to <see cref="AdjustedScreen"/></param>
        /// <returns><see cref="Vector2"/> relative to <see cref="Viewport"/></returns>
        public static Vector2 ConvertAdjustedScreenToRaw(Vector2 point)
        {
            return Vector2.Add(
                Vector2.Multiply(
                    point,
                    TileScale()),
                AdjustedScreen.GetNorthWest());
        }

        /// <summary>
        /// Converts <see cref="Vector2"/> coordinates relative to <see cref="Viewport"/>, to <see cref="Vector2"/> relative to <see cref="AdjustedScreen"/>.
        /// </summary>
        /// <param name="point"><see cref="Vector2"/> relative to <see cref="Viewport"/></param>
        /// <returns><see cref="Vector2"/> relative to <see cref="AdjustedScreen"/></returns>
        public static Vector2 ConvertRawToAdjustedScreen(Vector2 point)
        {
            return Vector2.Divide(
                Vector2.Subtract(
                    point,
                    AdjustedScreen.GetNorthWest()),
                TileScale());
        }

        /// <summary>
        /// <see cref="Character"/> Font related render constants.
        /// </summary>
        public class Font
        {
            /// <summary>
            /// Height of each <see cref="Character"/>.
            /// </summary>
            public static int CHARACTER_HEIGHT = 13;

            /// <summary>
            /// Space between each <see cref="Character"/>.
            /// </summary>
            public static int SPACE_BETWEEN_CHARACTERS = 1;

            /// <summary>
            /// Space between each <see cref="Character"/> on tilesheet.
            /// </summary>
            public static int SPACE_BETWEEN_CHARACTERS_ON_TILESET = 1;

            /// <summary>
            /// Width of a space <see cref="Character"/>.
            /// </summary>
            public static int SPACE_WIDTH = 4;

            /// <summary>
            /// Spacing between lines
            /// </summary>
            public static int LINE_SPACING = 3;

            /// <summary>
            /// Amount to offset characters in the Y direction to account for <see href="https://en.wikipedia.org/wiki/Descender">descenders</see>.
            /// </summary>
            public static int Y_OFFSET = 1;
        }

        /// <summary>
        /// <see cref="Entities.IEntity"/> related render constants
        /// </summary>
        public class Entities
        {
            /// <summary>
            /// <see cref="Entities.Ball"/> related render constants
            /// </summary>
            public class Ball
            {
                public static float MARGIN_LEFT = 3f;

                public static float MARGIN_TOP = 2f;
            }

            /// <summary>
            /// <see cref="Entities.BallButton"/> related render constants
            /// </summary>
            public class BallButton
            {
                public static float INNER_PADDING = 8f;

                public static float LEFT_OFFSET = 4f;
            }

            /// <summary>
            /// <see cref="Entities.PortraitFire"/> related render constants
            /// </summary>
            public class PortraitFire
            {
                public static int FRAMES = 8;

                public static int FRAME_DURATION = 4;
            }

            /// <summary>
            /// <see cref="Entities.TableSegment"/> related render constants
            /// </summary>
            public class TableSegment
            {
                public static int MARGIN = 3;

                public static int BORDER = 10;

                public static int LIP = 5;

                public static int PASSABLE_LIP = 2;

                public static int UNPASSABLE_LIP = 3;

                public static int SPACE_TO_BOUNCEABLE_SURFACE = MARGIN + BORDER + UNPASSABLE_LIP;

                public static int VERTICAL_POCKET_STRAIGHT_EDGE_HEIGHT = 2;

                public static int POCKET_ANGLED_EDGE_HEIGHT = 3;

                public static int FLAT_POCKET_BARE_EDGE_LENGTH = 3;

                public static int ANGLED_POCKET_BARE_EDGE_LENGTH = 6;

                public static int FLAT_POCKET_BORDER_OFFSET = -2;

                public static int ANGLED_POCKET_BORDER_OFFSET = 3;

                public static int POCKET_RADIUS = 7;
            }

            /// <summary>
            /// <see cref="Entities.PocketedBalls"/> related render constants
            /// </summary>
            public class PocketedBalls
            {
                public static float SUPPORT_UPPER_MARGIN = -3f;

                public static int SUPPORT_PADDING = 5;

                public static int PADDING = 4;
            }

            /// <summary>
            /// <see cref="Entities.Particle"/> related render constants
            /// </summary>
            public class Particle
            {
                public class Spark
                {
                    public static int FRAMES = 3;

                    public static int FRAME_DURATION = 4;

                    public static float MARGIN_LEFT = 3f;

                    public static float MARGIN_TOP = 3f;
                }
            }
        }

        /// <summary>
        /// IScene related render constants
        /// </summary>
        public class Scenes
        {
            /// <summary>
            /// General IScene related render constants
            /// </summary>
            public class General
            {
                public class LayerDepth
                {
                    public static float QUAD_TREE = 0.9000f;

                    public static float POPUP = 0.9000f;
                }
            }

            /// <summary>
            /// MainMenuScene related render constants
            /// </summary>
            public class MainMenu
            {
                public class GameTitle
                {
                    public static float TOP_MARGIN = 6f;
                }

                public class BallButton
                {
                    public static float BUTTON_MARGIN = 4f;
                }
            }

            /// <summary>
            /// CharacterSelectScene related render constants
            /// </summary>
            public class CharacterSelect
            {
                public class Cursor
                {
                    public static float BOTTOM_MARGIN = 18f;
                }

                public class SelectedName
                {
                    public static float TOP_MARGIN = 18f;
                }
            }

            /// <summary>
            /// DialogScene related render constants
            /// </summary>
            public class Dialog
            {
                public class Text
                {
                    public static int TOP_MARGIN = 15;

                    public static int MAX_WIDTH = 150;
                }
            }

            /// <summary>
            /// GameScene related render constants
            /// </summary>
            public class Game
            {
                public class LayerDepth
                {
                    public static float FADE_IN = 0.9000f;

                    public static float TABLE_FRONT = 0.0060f;

                    public static float PORTRAIT = 0.0050f;

                    public static float BALL = 0.0040f;

                    public static float TABLE = 0.0030f;

                    public static float POCKETED_BALLS = 0.0020f;

                    public static float FLOOR_TILES = 0.0005f;
                }

            }
        }
    }
}
