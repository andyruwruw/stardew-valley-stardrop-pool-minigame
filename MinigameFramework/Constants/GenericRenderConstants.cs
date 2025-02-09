using StardewValley;

namespace MinigameFramework.Constants
{
    class GenericRenderConstants
    {
        /// <summary>
        /// Tile size on tile sheet.
        /// </summary>
		public static int TileSize = 16;

        /// <summary>Dimensions of the minigame window.</summary>
		public class MinigameScreen
        {
            /// <summary>The height of the minigame window.</summary>
            public static int Height = 224;

            /// <summary>The width of the minigame window.</summary>
            public static int Width = 400;
        }

        /// <summary><see cref="Character"/> Font related render constants.</summary>
		public class Font
        {
            /// <summary>Height of each <see cref="Character"/>.</summary>
            public static int CharacterHeight = 13;

            /// <summary>Spacing between lines</summary>
            public static int LineSpacing = 3;

            /// <summary>Space between each <see cref="Character"/>.</summary>
            public static int SpaceBetweenCharacters = 1;

            /// <summary>Space between each <see cref="Character"/> on tilesheet.</summary>
            public static int SpaceBetweenCharactersOnTileset = 1;

            /// <summary>Width of a space <see cref="Character"/>.</summary>
            public static int SpaceWidth = 4;

            /// <summary>
            /// Amount to offset characters in the Y direction to account for
            /// <see href="https://en.wikipedia.org/wiki/Descender">descenders</see>.
            /// </summary>
            public static int YOffset = 1;
        }
    }
}
