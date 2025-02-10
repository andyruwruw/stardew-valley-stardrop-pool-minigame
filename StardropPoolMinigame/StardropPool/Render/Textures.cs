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
            public static Texture2D? Default;
        }

        /// <summary>
		/// Loads tilesheets.
		/// </summary>
		public static void LoadTextures()
        {
            Logger.Debug("StardropPoolMinigame: Loading Tilesets");

            Tileset.Default = Game1.content.Load<Texture2D>("Minigames\\StardropPoolMinigame");
        }

        /// <summary>
        /// Retrives ball core texture based on orientation.
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
        /// Retrives <see cref="Entities.Ball"/> stripes texture based on <see cref="Orientation"/>.
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
        /// Retrieves <see cref="Entities.Ball"/> base texture based on <see cref="BallColor"/>.
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static Rectangle GetBallBase(BallColor color)
        {
            switch (color)
            {
                case BallColor.Yellow:
                    return TextureConstants.Ball.Base.Yellow;
                case BallColor.Blue:
                    return TextureConstants.Ball.Base.Blue;
                case BallColor.Red:
                    return TextureConstants.Ball.Base.Red;
                case BallColor.Purple:
                    return TextureConstants.Ball.Base.Purple;
                case BallColor.Orange:
                    return TextureConstants.Ball.Base.Orange;
                case BallColor.Green:
                    return TextureConstants.Ball.Base.Green;
                case BallColor.Maroon:
                    return TextureConstants.Ball.Base.Maroon;
                case BallColor.Black:
                    return TextureConstants.Ball.Base.Black;
                default:
                    return TextureConstants.Ball.Base.White;
            }
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
                    return TextureConstants.Table.Edge.Back.North;
                case TableSegmentType.SouthEdge:
                    return TextureConstants.Table.Edge.Back.South;
                case TableSegmentType.WestEdge:
                    return TextureConstants.Table.Edge.Back.West;
                case TableSegmentType.EastEdge:
                    return TextureConstants.Table.Edge.Back.East;
                case TableSegmentType.NorthWestEdge:
                    return TextureConstants.Table.Edge.Back.NorthWest;
                case TableSegmentType.NorthEastEdge:
                    return TextureConstants.Table.Edge.Back.NorthEast;
                case TableSegmentType.SouthWestEdge:
                    return TextureConstants.Table.Edge.Back.SouthWest;
                case TableSegmentType.SouthEastEdge:
                    return TextureConstants.Table.Edge.Back.SouthEast;
                case TableSegmentType.NorthWestCorner:
                    return TextureConstants.Table.Corner.Back.NorthWest;
                case TableSegmentType.NorthEastCorner:
                    return TextureConstants.Table.Corner.Back.NorthEast;
                case TableSegmentType.SouthWestCorner:
                    return TextureConstants.Table.Corner.Back.SouthWest;
                case TableSegmentType.SouthEastCorner:
                    return TextureConstants.Table.Corner.Back.SouthEast;
                case TableSegmentType.NorthPocket:
                    return TextureConstants.Table.Pocket.Back.North;
                case TableSegmentType.SouthPocket:
                    return TextureConstants.Table.Pocket.Back.South;
                case TableSegmentType.WestPocket:
                    return TextureConstants.Table.Pocket.Back.West;
                case TableSegmentType.EastPocket:
                    return TextureConstants.Table.Pocket.Back.East;
                case TableSegmentType.NorthWestPocket:
                    return TextureConstants.Table.Pocket.Back.NorthWest;
                case TableSegmentType.NorthEastPocket:
                    return TextureConstants.Table.Pocket.Back.NorthEast;
                case TableSegmentType.SouthWestPocket:
                    return TextureConstants.Table.Pocket.Back.SouthWest;
                case TableSegmentType.SouthEastPocket:
                    return TextureConstants.Table.Pocket.Back.SouthEast;
                default:
                    return TextureConstants.Table.Felt;
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
                    return TextureConstants.Table.Edge.Front.North;
                case TableSegmentType.SouthEdge:
                    return TextureConstants.Table.Edge.Front.South;
                case TableSegmentType.WestEdge:
                    return TextureConstants.Table.Edge.Front.West;
                case TableSegmentType.EastEdge:
                    return TextureConstants.Table.Edge.Front.East;
                case TableSegmentType.NorthWestEdge:
                    return TextureConstants.Table.Edge.Front.NorthWest;
                case TableSegmentType.NorthEastEdge:
                    return TextureConstants.Table.Edge.Front.NorthEast;
                case TableSegmentType.SouthWestEdge:
                    return TextureConstants.Table.Edge.Front.SouthWest;
                case TableSegmentType.SouthEastEdge:
                    return TextureConstants.Table.Edge.Front.SouthEast;
                case TableSegmentType.NorthWestCorner:
                    return TextureConstants.Table.Corner.Front.NorthWest;
                case TableSegmentType.NorthEastCorner:
                    return TextureConstants.Table.Corner.Front.NorthEast;
                case TableSegmentType.SouthWestCorner:
                    return TextureConstants.Table.Corner.Front.SouthWest;
                case TableSegmentType.SouthEastCorner:
                    return TextureConstants.Table.Corner.Front.SouthEast;
                case TableSegmentType.NorthPocket:
                    return TextureConstants.Table.Pocket.Front.North;
                case TableSegmentType.SouthPocket:
                    return TextureConstants.Table.Pocket.Front.South;
                case TableSegmentType.WestPocket:
                    return TextureConstants.Table.Pocket.Front.West;
                case TableSegmentType.EastPocket:
                    return TextureConstants.Table.Pocket.Front.East;
                case TableSegmentType.NorthWestPocket:
                    return TextureConstants.Table.Pocket.Front.NorthWest;
                case TableSegmentType.NorthEastPocket:
                    return TextureConstants.Table.Pocket.Front.NorthEast;
                case TableSegmentType.SouthWestPocket:
                    return TextureConstants.Table.Pocket.Front.SouthWest;
                case TableSegmentType.SouthEastPocket:
                    return TextureConstants.Table.Pocket.Front.SouthEast;
                default:
                    return TextureConstants.Table.Felt;
            }
        }
    }
}
