using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;
using MinigameFramework.Utilities;
using StardopPoolMinigame.Constants;
using StardopPoolMinigame.Enums;

namespace StardopPoolMinigame.Render
{
    class Textures
    {
        /// <summary>
        /// References to tilesets.
        /// </summary>
        public class Tileset
        {
            public static Texture2D Default;

            public static Texture2D PortraitAbigail;

            public static Texture2D PortraitGus;

            public static Texture2D PortraitSam;

            public static Texture2D PortraitSebastian;
        }

        /// <summary>
		/// Loads tilesheets.
		/// </summary>
		public static void LoadTextures()
        {
            Logger.Info("Loading Tilesets");

            Tileset.Default = Game1.content.Load<Texture2D>("Minigames\\stardropPool");
            Tileset.PortraitAbigail = Game1.content.Load<Texture2D>("Portraits\\Abigail");
            Tileset.PortraitGus = Game1.content.Load<Texture2D>("Portraits\\Gus");
            Tileset.PortraitSam = Game1.content.Load<Texture2D>("Portraits\\Sam");
            Tileset.PortraitSebastian = Game1.content.Load<Texture2D>("Portraits\\Sebastian");
        }

        /// <summary>
        /// Retrives ball core texture based on orientation
        /// </summary>
        /// <param name="orientation">Polar coordinate <see cref="Vector2"/></param>
        /// <returns>Ball core texture</returns>
        public static Rectangle GetBallCoreBounds(Vector2 orientation)
        {
            if (orientation.Y == 90)
            {
                return TextureConstants.Ball.Core.CORE_0_90;
            }

            if (orientation.Y == 60)
            {
                if (orientation.X == 0)
                {
                    return TextureConstants.Ball.Core.CORE_0_60;
                }
                if (orientation.X == 45)
                {
                    return TextureConstants.Ball.Core.CORE_45_60;
                }
                if (orientation.X == 90)
                {
                    return TextureConstants.Ball.Core.CORE_90_60;
                }
                if (orientation.X == 135)
                {
                    return TextureConstants.Ball.Core.CORE_135_60;
                }
            }

            if (orientation.Y == 30)
            {
                if (orientation.X == 0) {
                    return TextureConstants.Ball.Core.CORE_0_30;
                }
                if (orientation.X == 30) {
                    return TextureConstants.Ball.Core.CORE_30_30;
                }
                if (orientation.X == 60) {
                    return TextureConstants.Ball.Core.CORE_60_30;
                }
                if (orientation.X == 90) {
                    return TextureConstants.Ball.Core.CORE_90_30;
                }
                if (orientation.X == 120) {
                    return TextureConstants.Ball.Core.CORE_120_30;
                }
                if (orientation.X == 150) {
                    return TextureConstants.Ball.Core.CORE_150_30;
                }
            }

            if (orientation.Y == 0)
            {
                if (orientation.X == 0) {
                    return TextureConstants.Ball.Core.CORE_0_0;
                }
                if (orientation.X == 30) {
                    return TextureConstants.Ball.Core.CORE_30_0;
                }
                if (orientation.X == 60) {
                    return TextureConstants.Ball.Core.CORE_60_0;
                }
                if (orientation.X == 90) {
                    return TextureConstants.Ball.Core.CORE_90_0;
                }
                if (orientation.X == 120) {
                    return TextureConstants.Ball.Core.CORE_120_0;
                }
                if (orientation.X == 150) {
                    return TextureConstants.Ball.Core.CORE_150_0;
                }
            }

            if (orientation.Y == -30)
            {
                if (orientation.X == 0) {
                    return TextureConstants.Ball.Core.CORE_0_N30;
                }

                if (orientation.X == 30) {
                    return TextureConstants.Ball.Core.CORE_30_N30;
                }

                if (orientation.X == 60) {
                    return TextureConstants.Ball.Core.CORE_60_N30;
                }
                if (orientation.X == 90) {
                    return TextureConstants.Ball.Core.CORE_90_N30;
                }
                if (orientation.X == 120) {
                    return TextureConstants.Ball.Core.CORE_120_N30;
                }
                if (orientation.X == 150) {
                    return TextureConstants.Ball.Core.CORE_150_N30;
                }
            }

            if (orientation.Y == -60)
            {
                if (orientation.X == 0) {
                    return TextureConstants.Ball.Core.CORE_0_N60;
                }
                if (orientation.X == 45) {
                    return TextureConstants.Ball.Core.CORE_45_N60;
                }
                if (orientation.X == 90) {
                    return TextureConstants.Ball.Core.CORE_90_N60;
                }
                if (orientation.X == 135) {
                    return TextureConstants.Ball.Core.CORE_135_N60;
                }
            }

            return TextureConstants.Ball.Core.CORE_0_0;
        }

        /// <summary>
        /// Retrives <see cref="Entities.Ball"/> stripes texture based on <see cref="Orientation"/>
        /// </summary>
        /// <param name="orientation">Polar coordinate <see cref="Vector2"/></param>
        /// <returns><see cref="Entities.Ball"/> stripes texture bounds</returns>
        public static Rectangle GetBallStripesBounds(Vector2 orientation)
        {
            if (orientation.Y == 90)
            {
                return TextureConstants.Ball.Stripes.STRIPES_0_90;
            }
            if (orientation.Y == 60)
            {
                return TextureConstants.Ball.Stripes.STRIPES_0_60;
            }
            if (orientation.Y == 30)
            {
                return TextureConstants.Ball.Stripes.STRIPES_0_30;
            }
            if (orientation.Y == 0)
            {
                return TextureConstants.Ball.Stripes.STRIPES_0_0;
            }
            if (orientation.Y == -30)
            {
                return TextureConstants.Ball.Stripes.STRIPES_0_N30;
            }
            if (orientation.Y == -60)
            {
                return TextureConstants.Ball.Stripes.STRIPES_0_N60;
            }

            return TextureConstants.Ball.Stripes.STRIPES_0_0;
        }

        /// <summary>
        /// Retrieves <see cref="Entities.TableSegment"/> back texture based on <see cref="TableSegmentType"/>
        /// </summary>
        /// <param name="type">Type of <see cref="Entities.TableSegment"/></param>
        /// <returns>Bounds of <see cref="Entities.TableSegment"/> back</returns>
        public static Rectangle GetTableSegmentBackFromType(TableSegmentType type)
        {
            switch (type)
            {
                case TableSegmentType.NorthEdge:
                    return TextureConstants.Table.Edge.Back.NORTH;
                case TableSegmentType.SouthEdge:
                    return TextureConstants.Table.Edge.Back.SOUTH;
                case TableSegmentType.WestEdge:
                    return TextureConstants.Table.Edge.Back.WEST;
                case TableSegmentType.EastEdge:
                    return TextureConstants.Table.Edge.Back.EAST;
                case TableSegmentType.NorthWestEdge:
                    return TextureConstants.Table.Edge.Back.NORTH_WEST;
                case TableSegmentType.NorthEastEdge:
                    return TextureConstants.Table.Edge.Back.NORTH_EAST;
                case TableSegmentType.SouthWestEdge:
                    return TextureConstants.Table.Edge.Back.SOUTH_WEST;
                case TableSegmentType.SouthEastEdge:
                    return TextureConstants.Table.Edge.Back.SOUTH_EAST;
                case TableSegmentType.NorthWestCorner:
                    return TextureConstants.Table.Corner.Back.NORTH_WEST;
                case TableSegmentType.NorthEastCorner:
                    return TextureConstants.Table.Corner.Back.NORTH_EAST;
                case TableSegmentType.SouthWestCorner:
                    return TextureConstants.Table.Corner.Back.SOUTH_WEST;
                case TableSegmentType.SouthEastCorner:
                    return TextureConstants.Table.Corner.Back.SOUTH_EAST;
                case TableSegmentType.NorthPocket:
                    return TextureConstants.Table.Pocket.Back.NORTH;
                case TableSegmentType.SouthPocket:
                    return TextureConstants.Table.Pocket.Back.SOUTH;
                case TableSegmentType.WestPocket:
                    return TextureConstants.Table.Pocket.Back.WEST;
                case TableSegmentType.EastPocket:
                    return TextureConstants.Table.Pocket.Back.EAST;
                case TableSegmentType.NorthWestPocket:
                    return TextureConstants.Table.Pocket.Back.NORTH_WEST;
                case TableSegmentType.NorthEastPocket:
                    return TextureConstants.Table.Pocket.Back.NORTH_EAST;
                case TableSegmentType.SouthWestPocket:
                    return TextureConstants.Table.Pocket.Back.SOUTH_WEST;
                case TableSegmentType.SouthEastPocket:
                    return TextureConstants.Table.Pocket.Back.SOUTH_EAST;
                default:
                    return TextureConstants.Table.FELT;
            }
        }

        /// <summary>
        /// Retrieves <see cref="Entities.TableSegment"/> front texture based on <see cref="TableSegmentType"/>
        /// </summary>
        /// <param name="type">Type of <see cref="Entities.TableSegment"/></param>
        /// <returns>Bounds of <see cref="Entities.TableSegment"/> front</returns>
        public static Rectangle GetTableSegmentFrontFromType(TableSegmentType type)
        {
            switch (type)
            {
                case TableSegmentType.NorthEdge:
                    return TextureConstants.Table.Edge.Front.NORTH;
                case TableSegmentType.SouthEdge:
                    return TextureConstants.Table.Edge.Front.SOUTH;
                case TableSegmentType.WestEdge:
                    return TextureConstants.Table.Edge.Front.WEST;
                case TableSegmentType.EastEdge:
                    return TextureConstants.Table.Edge.Front.EAST;
                case TableSegmentType.NorthWestEdge:
                    return TextureConstants.Table.Edge.Front.NORTH_WEST;
                case TableSegmentType.NorthEastEdge:
                    return TextureConstants.Table.Edge.Front.NORTH_EAST;
                case TableSegmentType.SouthWestEdge:
                    return TextureConstants.Table.Edge.Front.SOUTH_WEST;
                case TableSegmentType.SouthEastEdge:
                    return TextureConstants.Table.Edge.Front.SOUTH_EAST;
                case TableSegmentType.NorthWestCorner:
                    return TextureConstants.Table.Corner.Front.NORTH_WEST;
                case TableSegmentType.NorthEastCorner:
                    return TextureConstants.Table.Corner.Front.NORTH_EAST;
                case TableSegmentType.SouthWestCorner:
                    return TextureConstants.Table.Corner.Front.SOUTH_WEST;
                case TableSegmentType.SouthEastCorner:
                    return TextureConstants.Table.Corner.Front.SOUTH_EAST;
                case TableSegmentType.NorthPocket:
                    return TextureConstants.Table.Pocket.Front.NORTH;
                case TableSegmentType.SouthPocket:
                    return TextureConstants.Table.Pocket.Front.SOUTH;
                case TableSegmentType.WestPocket:
                    return TextureConstants.Table.Pocket.Front.WEST;
                case TableSegmentType.EastPocket:
                    return TextureConstants.Table.Pocket.Front.EAST;
                case TableSegmentType.NorthWestPocket:
                    return TextureConstants.Table.Pocket.Front.NORTH_WEST;
                case TableSegmentType.NorthEastPocket:
                    return TextureConstants.Table.Pocket.Front.NORTH_EAST;
                case TableSegmentType.SouthWestPocket:
                    return TextureConstants.Table.Pocket.Front.SOUTH_WEST;
                case TableSegmentType.SouthEastPocket:
                    return TextureConstants.Table.Pocket.Front.SOUTH_EAST;
                default:
                    return TextureConstants.Table.FELT;
            }
        }
    }
}
