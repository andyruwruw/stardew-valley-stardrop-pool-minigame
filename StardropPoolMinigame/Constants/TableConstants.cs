using Microsoft.Xna.Framework;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Render;
using System.Collections.Generic;

namespace StardropPoolMinigame.Constants
{
    internal class TableConstants
    {
        public static Vector2 GetCueBallStart(TableType type)
        {
            switch (type)
            {
                case TableType.Classic:
                    return Classic.CUE_BALL_START;
                default:
                    return Classic.CUE_BALL_START;
            }
        }

        public static Vector2 GetFootSpot(TableType type)
        {
            switch (type)
            {
                case TableType.Classic:
                    return Classic.FOOT_SPOT;
                default:
                    return Classic.FOOT_SPOT;
            }
        }

        public static Primitives.Rectangle GetKitchen(TableType type)
        {
            switch (type)
            {
                case TableType.Classic:
                    return Classic.KITCHEN;
                default:
                    return Classic.KITCHEN;
            }
        }

        public static IList<IList<TableSegmentType>> GetLayout(TableType type)
        {
            switch (type)
            {
                case TableType.Classic:
                    return Classic.LAYOUT;
                case TableType.Crammed:
                    return Crammed.LAYOUT;
                case TableType.Goalkeeper:
                    return Goalkeeper.LAYOUT;
                case TableType.SingleLane:
                    return SingleLane.LAYOUT;
                case TableType.TugOfWar:
                    return TugOfWar.LAYOUT;
                default:
                    return Classic.LAYOUT;
            }
        }

        public static Vector2 GetPlayer1CueBallStart(TableType type)
        {
            switch (type)
            {
                case TableType.Classic:
                    return Classic.PLAYER1_CUE_BALL_START;
                default:
                    return Classic.PLAYER1_CUE_BALL_START;
            }
        }

        public static Vector2 GetPlayer2CueBallStart(TableType type)
        {
            switch (type)
            {
                case TableType.Classic:
                    return Classic.PLAYER2_CUE_BALL_START;
                default:
                    return Classic.PLAYER2_CUE_BALL_START;
            }
        }

        public static Direction GetRackOrientation(TableType type)
        {
            switch (type)
            {
                case TableType.Classic:
                    return Classic.RACK_ORIENTATION;
                default:
                    return Classic.RACK_ORIENTATION;
            }
        }

        public class Classic
        {
            /// <summary>
            /// Location of the cue ball in classic gamemodes
            /// </summary>
            public static Vector2 CUE_BALL_START = new Vector2(
                ((LAYOUT[0].Count * Textures.Table.Edge.Back.NORTH.Width - (2 * (RenderConstants.Entities.TableSegment.MARGIN + RenderConstants.Entities.TableSegment.BORDER))) / 8 * 2) + (RenderConstants.Entities.TableSegment.MARGIN + RenderConstants.Entities.TableSegment.BORDER),
                LAYOUT.Count * Textures.Table.Edge.Back.NORTH.Width / 2);

            /// <summary>
            /// Starting place to rack the balls
            /// </summary>
            public static Vector2 FOOT_SPOT = new Vector2(
                ((LAYOUT[0].Count * Textures.Table.Edge.Back.NORTH.Width - (2 * (RenderConstants.Entities.TableSegment.MARGIN + RenderConstants.Entities.TableSegment.BORDER))) / 8 * 6) + (RenderConstants.Entities.TableSegment.MARGIN + RenderConstants.Entities.TableSegment.BORDER),
                LAYOUT.Count * Textures.Table.Edge.Back.NORTH.Width / 2);

            /// <summary>
            /// Area in which ball in hand shots can be made from
            /// </summary>
            public static Primitives.Rectangle KITCHEN = new Primitives.Rectangle(
                new Vector2(
                    RenderConstants.Entities.TableSegment.MARGIN + RenderConstants.Entities.TableSegment.BORDER,
                    RenderConstants.Entities.TableSegment.MARGIN + RenderConstants.Entities.TableSegment.BORDER),
                ((LAYOUT[0].Count * Textures.Table.Edge.Back.NORTH.Width - (2 * (RenderConstants.Entities.TableSegment.MARGIN + RenderConstants.Entities.TableSegment.BORDER))) / 8 * 2) + (RenderConstants.Entities.TableSegment.MARGIN + RenderConstants.Entities.TableSegment.BORDER),
                (LAYOUT.Count * Textures.Table.Edge.Back.NORTH.Width - (2 * (RenderConstants.Entities.TableSegment.MARGIN + RenderConstants.Entities.TableSegment.BORDER))) + (RenderConstants.Entities.TableSegment.MARGIN + RenderConstants.Entities.TableSegment.BORDER));

            /// <summary>
            /// Classic layout
            /// </summary>
            public static IList<IList<TableSegmentType>> LAYOUT = new List<IList<TableSegmentType>>{
                new List<TableSegmentType>{
                    TableSegmentType.NorthWestPocket,
                    TableSegmentType.NorthEdge,
                    TableSegmentType.NorthEdge,
                    TableSegmentType.NorthEdge,
                    TableSegmentType.NorthPocket,
                    TableSegmentType.NorthEdge,
                    TableSegmentType.NorthEdge,
                    TableSegmentType.NorthEdge,
                    TableSegmentType.NorthEastPocket,
                },
                new List<TableSegmentType>{
                    TableSegmentType.WestEdge,
                    TableSegmentType.Felt,
                    TableSegmentType.Felt,
                    TableSegmentType.Felt,
                    TableSegmentType.Felt,
                    TableSegmentType.Felt,
                    TableSegmentType.Felt,
                    TableSegmentType.Felt,
                    TableSegmentType.EastEdge,
                },
                new List<TableSegmentType>{
                    TableSegmentType.WestEdge,
                    TableSegmentType.Felt,
                    TableSegmentType.Felt,
                    TableSegmentType.Felt,
                    TableSegmentType.Felt,
                    TableSegmentType.Felt,
                    TableSegmentType.Felt,
                    TableSegmentType.Felt,
                    TableSegmentType.EastEdge,
                },
                new List<TableSegmentType>{
                    TableSegmentType.WestEdge,
                    TableSegmentType.Felt,
                    TableSegmentType.Felt,
                    TableSegmentType.Felt,
                    TableSegmentType.Felt,
                    TableSegmentType.Felt,
                    TableSegmentType.Felt,
                    TableSegmentType.Felt,
                    TableSegmentType.EastEdge,
                },
                new List<TableSegmentType>{
                    TableSegmentType.SouthWestPocket,
                    TableSegmentType.SouthEdge,
                    TableSegmentType.SouthEdge,
                    TableSegmentType.SouthEdge,
                    TableSegmentType.SouthPocket,
                    TableSegmentType.SouthEdge,
                    TableSegmentType.SouthEdge,
                    TableSegmentType.SouthEdge,
                    TableSegmentType.SouthEastPocket,
                }};

            /// <summary>
            /// Location of first cue ball in gamemodes where there are two balls
            /// </summary>
            public static Vector2 PLAYER1_CUE_BALL_START = new Vector2(
                ((LAYOUT[0].Count * Textures.Table.Edge.Back.NORTH.Width - (2 * (RenderConstants.Entities.TableSegment.MARGIN + RenderConstants.Entities.TableSegment.BORDER))) / 8 * 2) + (RenderConstants.Entities.TableSegment.MARGIN + RenderConstants.Entities.TableSegment.BORDER),
                LAYOUT.Count * Textures.Table.Edge.Back.NORTH.Width / 4 * 1);

            /// <summary>
            /// Location of second cue ball in gamemodes where there are two balls
            /// </summary>
            public static Vector2 PLAYER2_CUE_BALL_START = new Vector2(
                ((LAYOUT[0].Count * Textures.Table.Edge.Back.NORTH.Width - (2 * (RenderConstants.Entities.TableSegment.MARGIN + RenderConstants.Entities.TableSegment.BORDER))) / 8 * 2) + (RenderConstants.Entities.TableSegment.MARGIN + RenderConstants.Entities.TableSegment.BORDER),
                LAYOUT.Count * Textures.Table.Edge.Back.NORTH.Width / 4 * 3);

            /// <summary>
            /// Direction the balls are oriented when racked
            /// </summary>
            public static Direction RACK_ORIENTATION = Direction.East;
        }

        public class Crammed
        {
            /// <summary>
            /// Location of the cue ball in classic gamemodes
            /// </summary>
            public static Vector2 CUE_BALL_START = new Vector2(
                LAYOUT[0].Count * Textures.Table.Edge.Back.NORTH.Width - (2 * (RenderConstants.Entities.TableSegment.MARGIN + RenderConstants.Entities.TableSegment.BORDER)) / 4,
                LAYOUT.Count * Textures.Table.Edge.Back.NORTH.Width / 2);

            /// <summary>
            /// Starting place to rack the balls
            /// </summary>
            public static Vector2 FOOT_SPOT = new Vector2(
                LAYOUT[0].Count * Textures.Table.Edge.Back.NORTH.Width - (2 * (RenderConstants.Entities.TableSegment.MARGIN + RenderConstants.Entities.TableSegment.BORDER)) / 2,
                LAYOUT.Count * Textures.Table.Edge.Back.NORTH.Width / 2);

            /// <summary>
            /// Area in which ball in hand shots can be made from
            /// </summary>
            public static Primitives.Rectangle KITCHEN = new Primitives.Rectangle(
                new Vector2(
                    RenderConstants.Entities.TableSegment.MARGIN + RenderConstants.Entities.TableSegment.BORDER,
                    RenderConstants.Entities.TableSegment.MARGIN + RenderConstants.Entities.TableSegment.BORDER),
                LAYOUT[0].Count * Textures.Table.Edge.Back.NORTH.Width - (2 * (RenderConstants.Entities.TableSegment.MARGIN + RenderConstants.Entities.TableSegment.BORDER)) / 4,
                LAYOUT.Count * Textures.Table.Edge.Back.NORTH.Width - (2 * (RenderConstants.Entities.TableSegment.MARGIN + RenderConstants.Entities.TableSegment.BORDER)));

            public static IList<IList<TableSegmentType>> LAYOUT = new List<IList<TableSegmentType>>{
                new List<TableSegmentType>{
                    TableSegmentType.NorthWestPocket,
                    TableSegmentType.NorthEdge,
                    TableSegmentType.NorthEdge,
                    TableSegmentType.NorthEdge,
                    TableSegmentType.NorthEastPocket,
                },
                new List<TableSegmentType>{
                    TableSegmentType.WestEdge,
                    TableSegmentType.Felt,
                    TableSegmentType.Felt,
                    TableSegmentType.Felt,
                    TableSegmentType.EastEdge,
                },
                new List<TableSegmentType>{
                    TableSegmentType.WestEdge,
                    TableSegmentType.Felt,
                    TableSegmentType.Felt,
                    TableSegmentType.Felt,
                    TableSegmentType.EastEdge,
                },
                new List<TableSegmentType>{
                    TableSegmentType.WestEdge,
                    TableSegmentType.Felt,
                    TableSegmentType.Felt,
                    TableSegmentType.Felt,
                    TableSegmentType.EastEdge,
                },
                new List<TableSegmentType>{
                    TableSegmentType.SouthWestPocket,
                    TableSegmentType.SouthEdge,
                    TableSegmentType.SouthEdge,
                    TableSegmentType.SouthEdge,
                    TableSegmentType.SouthEastPocket,
                }};

            /// <summary>
            /// Location of first cue ball in gamemodes where there are two balls
            /// </summary>
            public static Vector2 PLAYER1_CUE_BALL_START = new Vector2(
                LAYOUT[0].Count * Textures.Table.Edge.Back.NORTH.Width - (2 * (RenderConstants.Entities.TableSegment.MARGIN + RenderConstants.Entities.TableSegment.BORDER)) / 4,
                LAYOUT.Count * Textures.Table.Edge.Back.NORTH.Width / 4 * 1);

            /// <summary>
            /// Location of second cue ball in gamemodes where there are two balls
            /// </summary>
            public static Vector2 PLAYER2_CUE_BALL_START = new Vector2(
                LAYOUT[0].Count * Textures.Table.Edge.Back.NORTH.Width - (2 * (RenderConstants.Entities.TableSegment.MARGIN + RenderConstants.Entities.TableSegment.BORDER)) / 4,
                LAYOUT.Count * Textures.Table.Edge.Back.NORTH.Width / 4 * 3);

            /// <summary>
            /// Direction the balls are oriented when racked
            /// </summary>
            public static Direction RACK_ORIENTATION = Direction.East;
        }

        public class Goalkeeper
        {
            public static IList<IList<TableSegmentType>> LAYOUT = new List<IList<TableSegmentType>>{
                new List<TableSegmentType>{
                    TableSegmentType.NorthWestEdge,
                    TableSegmentType.NorthEdge,
                    TableSegmentType.NorthEdge,
                    TableSegmentType.NorthEdge,
                    TableSegmentType.NorthEdge,
                    TableSegmentType.NorthEdge,
                    TableSegmentType.NorthEastEdge,
                },
                new List<TableSegmentType>{
                    TableSegmentType.WestPocket,
                    TableSegmentType.Felt,
                    TableSegmentType.Felt,
                    TableSegmentType.Felt,
                    TableSegmentType.Felt,
                    TableSegmentType.Felt,
                    TableSegmentType.EastPocket,
                },
                new List<TableSegmentType>{
                    TableSegmentType.SouthWestEdge,
                    TableSegmentType.SouthEdge,
                    TableSegmentType.SouthEdge,
                    TableSegmentType.SouthEdge,
                    TableSegmentType.SouthEdge,
                    TableSegmentType.SouthEdge,
                    TableSegmentType.SouthEastEdge,
                }};
        }

        public class SingleLane
        {
            /// <summary>
            /// Location of the cue ball in classic gamemodes
            /// </summary>
            public static Vector2 CUE_BALL_START = new Vector2(
                LAYOUT[0].Count * Textures.Table.Edge.Back.NORTH.Width - (2 * (RenderConstants.Entities.TableSegment.MARGIN + RenderConstants.Entities.TableSegment.BORDER)) / 8 * 2,
                LAYOUT.Count * Textures.Table.Edge.Back.NORTH.Width / 2);

            /// <summary>
            /// Starting place to rack the balls
            /// </summary>
            public static Vector2 FOOT_SPOT = new Vector2(
                LAYOUT[0].Count * Textures.Table.Edge.Back.NORTH.Width - (2 * (RenderConstants.Entities.TableSegment.MARGIN + RenderConstants.Entities.TableSegment.BORDER)) / 8 * 6,
                LAYOUT.Count * Textures.Table.Edge.Back.NORTH.Width / 2);

            /// <summary>
            /// Area in which ball in hand shots can be made from
            /// </summary>
            public static Primitives.Rectangle KITCHEN = new Primitives.Rectangle(
                new Vector2(
                    RenderConstants.Entities.TableSegment.MARGIN + RenderConstants.Entities.TableSegment.BORDER,
                    RenderConstants.Entities.TableSegment.MARGIN + RenderConstants.Entities.TableSegment.BORDER),
                LAYOUT[0].Count * Textures.Table.Edge.Back.NORTH.Width - (2 * (RenderConstants.Entities.TableSegment.MARGIN + RenderConstants.Entities.TableSegment.BORDER)) / 8 * 2,
                LAYOUT.Count * Textures.Table.Edge.Back.NORTH.Width - (2 * (RenderConstants.Entities.TableSegment.MARGIN + RenderConstants.Entities.TableSegment.BORDER)));

            public static IList<IList<TableSegmentType>> LAYOUT = new List<IList<TableSegmentType>>{
                new List<TableSegmentType>{
                    TableSegmentType.NorthWestEdge,
                    TableSegmentType.NorthPocket,
                    TableSegmentType.NorthEastEdge,
                    TableSegmentType.Empty,
                    TableSegmentType.Empty,
                    TableSegmentType.Empty,
                    TableSegmentType.NorthWestEdge,
                    TableSegmentType.NorthPocket,
                    TableSegmentType.NorthEastEdge,
                },
                new List<TableSegmentType>{
                    TableSegmentType.WestEdge,
                    TableSegmentType.Felt,
                    TableSegmentType.NorthEastCorner,
                    TableSegmentType.NorthEdge,
                    TableSegmentType.NorthEdge,
                    TableSegmentType.NorthEdge,
                    TableSegmentType.NorthWestCorner,
                    TableSegmentType.Felt,
                    TableSegmentType.EastEdge,
                },
                new List<TableSegmentType>{
                    TableSegmentType.WestEdge,
                    TableSegmentType.Felt,
                    TableSegmentType.Felt,
                    TableSegmentType.Felt,
                    TableSegmentType.Felt,
                    TableSegmentType.Felt,
                    TableSegmentType.Felt,
                    TableSegmentType.Felt,
                    TableSegmentType.EastEdge,
                },
                new List<TableSegmentType>{
                    TableSegmentType.WestEdge,
                    TableSegmentType.Felt,
                    TableSegmentType.SouthEastCorner,
                    TableSegmentType.SouthEdge,
                    TableSegmentType.SouthEdge,
                    TableSegmentType.SouthEdge,
                    TableSegmentType.SouthWestCorner,
                    TableSegmentType.Felt,
                    TableSegmentType.EastEdge,
                },
                new List<TableSegmentType>{
                    TableSegmentType.SouthWestEdge,
                    TableSegmentType.SouthPocket,
                    TableSegmentType.SouthEastCorner,
                    TableSegmentType.Empty,
                    TableSegmentType.Empty,
                    TableSegmentType.Empty,
                    TableSegmentType.SouthWestCorner,
                    TableSegmentType.SouthPocket,
                    TableSegmentType.SouthEastEdge,
                }};

            /// <summary>
            /// Location of first cue ball in gamemodes where there are two balls
            /// </summary>
            public static Vector2 PLAYER1_CUE_BALL_START = new Vector2(
                LAYOUT[0].Count * Textures.Table.Edge.Back.NORTH.Width - (2 * (RenderConstants.Entities.TableSegment.MARGIN + RenderConstants.Entities.TableSegment.BORDER)) / 8 * 2,
                LAYOUT.Count * Textures.Table.Edge.Back.NORTH.Width / 4 * 1);

            /// <summary>
            /// Location of second cue ball in gamemodes where there are two balls
            /// </summary>
            public static Vector2 PLAYER2_CUE_BALL_START = new Vector2(
                LAYOUT[0].Count * Textures.Table.Edge.Back.NORTH.Width - (2 * (RenderConstants.Entities.TableSegment.MARGIN + RenderConstants.Entities.TableSegment.BORDER)) / 8 * 2,
                LAYOUT.Count * Textures.Table.Edge.Back.NORTH.Width / 4 * 3);

            /// <summary>
            /// Direction the balls are oriented when racked
            /// </summary>
            public static Direction RACK_ORIENTATION = Direction.East;
        }

        public class TugOfWar
        {
            public static IList<IList<TableSegmentType>> LAYOUT = new List<IList<TableSegmentType>>{
                new List<TableSegmentType>{
                    TableSegmentType.NorthWestEdge,
                    TableSegmentType.NorthPocket,
                    TableSegmentType.NorthEastEdge,
                    TableSegmentType.Empty,
                    TableSegmentType.Empty,
                    TableSegmentType.Empty,
                    TableSegmentType.NorthWestEdge,
                    TableSegmentType.NorthPocket,
                    TableSegmentType.NorthEastEdge,
                },
                new List<TableSegmentType>{
                    TableSegmentType.WestEdge,
                    TableSegmentType.Felt,
                    TableSegmentType.EastEdge,
                    TableSegmentType.Empty,
                    TableSegmentType.Empty,
                    TableSegmentType.Empty,
                    TableSegmentType.WestEdge,
                    TableSegmentType.Felt,
                    TableSegmentType.EastEdge,
                },
                new List<TableSegmentType>{
                    TableSegmentType.WestEdge,
                    TableSegmentType.Felt,
                    TableSegmentType.NorthEastCorner,
                    TableSegmentType.NorthEdge,
                    TableSegmentType.NorthEdge,
                    TableSegmentType.NorthEdge,
                    TableSegmentType.NorthWestCorner,
                    TableSegmentType.Felt,
                    TableSegmentType.EastEdge,
                },
                new List<TableSegmentType>{
                    TableSegmentType.WestEdge,
                    TableSegmentType.Felt,
                    TableSegmentType.Felt,
                    TableSegmentType.Felt,
                    TableSegmentType.Felt,
                    TableSegmentType.Felt,
                    TableSegmentType.Felt,
                    TableSegmentType.Felt,
                    TableSegmentType.EastEdge,
                },
                new List<TableSegmentType>{
                    TableSegmentType.SouthWestEdge,
                    TableSegmentType.SouthEdge,
                    TableSegmentType.SouthEdge,
                    TableSegmentType.SouthEdge,
                    TableSegmentType.SouthEdge,
                    TableSegmentType.SouthEdge,
                    TableSegmentType.SouthEdge,
                    TableSegmentType.SouthEdge,
                    TableSegmentType.SouthEastEdge,
                }};
        }
    }
}