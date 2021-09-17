using System.Collections.Generic;
using Microsoft.Xna.Framework;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Render;
using Rectangle = StardropPoolMinigame.Primitives.Rectangle;

namespace StardropPoolMinigame.Constants
{
	internal class TableConstants
	{
		public static Vector2 GetCueBallStart(TableType type)
		{
			switch (type)
			{
				case TableType.Classic:
					return Classic.CueBallStart;
				default:
					return Classic.CueBallStart;
			}
		}

		public static Vector2 GetFootSpot(TableType type)
		{
			switch (type)
			{
				case TableType.Classic:
					return Classic.FootSpot;
				default:
					return Classic.FootSpot;
			}
		}

		public static Rectangle GetKitchen(TableType type)
		{
			switch (type)
			{
				case TableType.Classic:
					return Classic.Kitchen;
				default:
					return Classic.Kitchen;
			}
		}

		public static IList<IList<TableSegmentType>> GetLayout(TableType type)
		{
			switch (type)
			{
				case TableType.Classic:
					return Classic.Layout;
				case TableType.Crammed:
					return Crammed.Layout;
				case TableType.Goalkeeper:
					return Goalkeeper.Layout;
				case TableType.SingleLane:
					return SingleLane.Layout;
				case TableType.TugOfWar:
					return TugOfWar.Layout;
				default:
					return Classic.Layout;
			}
		}

		public static Vector2 GetPlayer1CueBallStart(TableType type)
		{
			switch (type)
			{
				case TableType.Classic:
					return Classic.Player1CueBallStart;
				default:
					return Classic.Player1CueBallStart;
			}
		}

		public static Vector2 GetPlayer2CueBallStart(TableType type)
		{
			switch (type)
			{
				case TableType.Classic:
					return Classic.Player2CueBallStart;
				default:
					return Classic.Player2CueBallStart;
			}
		}

		public static Direction GetRackOrientation(TableType type)
		{
			switch (type)
			{
				case TableType.Classic:
					return Classic.RackOrientation;
				default:
					return Classic.RackOrientation;
			}
		}

		public class Classic
		{
			/// <summary>
			/// Classic layout
			/// </summary>
			public static IList<IList<TableSegmentType>> Layout = new List<IList<TableSegmentType>>
			{
				new List<TableSegmentType>
				{
					TableSegmentType.NorthWestPocket,
					TableSegmentType.NorthEdge,
					TableSegmentType.NorthEdge,
					TableSegmentType.NorthEdge,
					TableSegmentType.NorthPocket,
					TableSegmentType.NorthEdge,
					TableSegmentType.NorthEdge,
					TableSegmentType.NorthEdge,
					TableSegmentType.NorthEastPocket
				},
				new List<TableSegmentType>
				{
					TableSegmentType.WestEdge,
					TableSegmentType.Felt,
					TableSegmentType.Felt,
					TableSegmentType.Felt,
					TableSegmentType.Felt,
					TableSegmentType.Felt,
					TableSegmentType.Felt,
					TableSegmentType.Felt,
					TableSegmentType.EastEdge
				},
				new List<TableSegmentType>
				{
					TableSegmentType.WestEdge,
					TableSegmentType.Felt,
					TableSegmentType.Felt,
					TableSegmentType.Felt,
					TableSegmentType.Felt,
					TableSegmentType.Felt,
					TableSegmentType.Felt,
					TableSegmentType.Felt,
					TableSegmentType.EastEdge
				},
				new List<TableSegmentType>
				{
					TableSegmentType.WestEdge,
					TableSegmentType.Felt,
					TableSegmentType.Felt,
					TableSegmentType.Felt,
					TableSegmentType.Felt,
					TableSegmentType.Felt,
					TableSegmentType.Felt,
					TableSegmentType.Felt,
					TableSegmentType.EastEdge
				},
				new List<TableSegmentType>
				{
					TableSegmentType.SouthWestPocket,
					TableSegmentType.SouthEdge,
					TableSegmentType.SouthEdge,
					TableSegmentType.SouthEdge,
					TableSegmentType.SouthPocket,
					TableSegmentType.SouthEdge,
					TableSegmentType.SouthEdge,
					TableSegmentType.SouthEdge,
					TableSegmentType.SouthEastPocket
				}
			};

			/// <summary>
			/// Location of the cue ball in classic gamemodes
			/// </summary>
			public static Vector2 CueBallStart = new Vector2(
				(Layout[0].Count * Textures.Table.Edge.Back.NORTH.Width - 2 *
					(RenderConstants.Entities.TableSegment.Margin + RenderConstants.Entities.TableSegment.Border)) / 8 *
				2 + RenderConstants.Entities.TableSegment.Margin + RenderConstants.Entities.TableSegment.Border,
				Layout.Count * Textures.Table.Edge.Back.NORTH.Width / 2);

			/// <summary>
			/// Starting place to rack the balls
			/// </summary>
			public static Vector2 FootSpot = new Vector2(
				(Layout[0].Count * Textures.Table.Edge.Back.NORTH.Width - 2 *
					(RenderConstants.Entities.TableSegment.Margin + RenderConstants.Entities.TableSegment.Border)) / 8 *
				6 + RenderConstants.Entities.TableSegment.Margin + RenderConstants.Entities.TableSegment.Border,
				Layout.Count * Textures.Table.Edge.Back.NORTH.Width / 2);

			/// <summary>
			/// Area in which ball in hand shots can be made from
			/// </summary>
			public static Rectangle Kitchen = new Rectangle(
				new Vector2(
					RenderConstants.Entities.TableSegment.Margin + RenderConstants.Entities.TableSegment.Border,
					RenderConstants.Entities.TableSegment.Margin + RenderConstants.Entities.TableSegment.Border),
				(Layout[0].Count * Textures.Table.Edge.Back.NORTH.Width - 2 *
					(RenderConstants.Entities.TableSegment.Margin + RenderConstants.Entities.TableSegment.Border)) / 8 *
				2 + RenderConstants.Entities.TableSegment.Margin + RenderConstants.Entities.TableSegment.Border,
				Layout.Count * Textures.Table.Edge.Back.NORTH.Width -
				2 * (RenderConstants.Entities.TableSegment.Margin + RenderConstants.Entities.TableSegment.Border) +
				RenderConstants.Entities.TableSegment.Margin + RenderConstants.Entities.TableSegment.Border);

			/// <summary>
			/// Location of first cue ball in gamemodes where there are two balls
			/// </summary>
			public static Vector2 Player1CueBallStart = new Vector2(
				(Layout[0].Count * Textures.Table.Edge.Back.NORTH.Width - 2 *
					(RenderConstants.Entities.TableSegment.Margin + RenderConstants.Entities.TableSegment.Border)) / 8 *
				2 + RenderConstants.Entities.TableSegment.Margin + RenderConstants.Entities.TableSegment.Border,
				Layout.Count * Textures.Table.Edge.Back.NORTH.Width / 4 * 1);

			/// <summary>
			/// Location of second cue ball in gamemodes where there are two balls
			/// </summary>
			public static Vector2 Player2CueBallStart = new Vector2(
				(Layout[0].Count * Textures.Table.Edge.Back.NORTH.Width - 2 *
					(RenderConstants.Entities.TableSegment.Margin + RenderConstants.Entities.TableSegment.Border)) / 8 *
				2 + RenderConstants.Entities.TableSegment.Margin + RenderConstants.Entities.TableSegment.Border,
				Layout.Count * Textures.Table.Edge.Back.NORTH.Width / 4 * 3);

			/// <summary>
			/// Direction the balls are oriented when racked
			/// </summary>
			public static Direction RackOrientation = Direction.East;
		}

		public class Crammed
		{
			public static IList<IList<TableSegmentType>> Layout = new List<IList<TableSegmentType>>
			{
				new List<TableSegmentType>
				{
					TableSegmentType.NorthWestPocket,
					TableSegmentType.NorthEdge,
					TableSegmentType.NorthEdge,
					TableSegmentType.NorthEdge,
					TableSegmentType.NorthEastPocket
				},
				new List<TableSegmentType>
				{
					TableSegmentType.WestEdge,
					TableSegmentType.Felt,
					TableSegmentType.Felt,
					TableSegmentType.Felt,
					TableSegmentType.EastEdge
				},
				new List<TableSegmentType>
				{
					TableSegmentType.WestEdge,
					TableSegmentType.Felt,
					TableSegmentType.Felt,
					TableSegmentType.Felt,
					TableSegmentType.EastEdge
				},
				new List<TableSegmentType>
				{
					TableSegmentType.WestEdge,
					TableSegmentType.Felt,
					TableSegmentType.Felt,
					TableSegmentType.Felt,
					TableSegmentType.EastEdge
				},
				new List<TableSegmentType>
				{
					TableSegmentType.SouthWestPocket,
					TableSegmentType.SouthEdge,
					TableSegmentType.SouthEdge,
					TableSegmentType.SouthEdge,
					TableSegmentType.SouthEastPocket
				}
			};

			/// <summary>
			/// Location of the cue ball in classic gamemodes
			/// </summary>
			public static Vector2 CueBallStart = new Vector2(
				Layout[0].Count * Textures.Table.Edge.Back.NORTH.Width - 2 *
				(RenderConstants.Entities.TableSegment.Margin + RenderConstants.Entities.TableSegment.Border) / 4,
				Layout.Count * Textures.Table.Edge.Back.NORTH.Width / 2);

			/// <summary>
			/// Starting place to rack the balls
			/// </summary>
			public static Vector2 FootSpot = new Vector2(
				Layout[0].Count * Textures.Table.Edge.Back.NORTH.Width - 2 *
				(RenderConstants.Entities.TableSegment.Margin + RenderConstants.Entities.TableSegment.Border) / 2,
				Layout.Count * Textures.Table.Edge.Back.NORTH.Width / 2);

			/// <summary>
			/// Area in which ball in hand shots can be made from
			/// </summary>
			public static Rectangle Kitchen = new Rectangle(
				new Vector2(
					RenderConstants.Entities.TableSegment.Margin + RenderConstants.Entities.TableSegment.Border,
					RenderConstants.Entities.TableSegment.Margin + RenderConstants.Entities.TableSegment.Border),
				Layout[0].Count * Textures.Table.Edge.Back.NORTH.Width - 2 *
				(RenderConstants.Entities.TableSegment.Margin + RenderConstants.Entities.TableSegment.Border) / 4,
				Layout.Count * Textures.Table.Edge.Back.NORTH.Width - 2 *
				(RenderConstants.Entities.TableSegment.Margin + RenderConstants.Entities.TableSegment.Border));

			/// <summary>
			/// Location of first cue ball in gamemodes where there are two balls
			/// </summary>
			public static Vector2 Player1CueBallStart = new Vector2(
				Layout[0].Count * Textures.Table.Edge.Back.NORTH.Width - 2 *
				(RenderConstants.Entities.TableSegment.Margin + RenderConstants.Entities.TableSegment.Border) / 4,
				Layout.Count * Textures.Table.Edge.Back.NORTH.Width / 4 * 1);

			/// <summary>
			/// Location of second cue ball in gamemodes where there are two balls
			/// </summary>
			public static Vector2 Player2CueBallStart = new Vector2(
				Layout[0].Count * Textures.Table.Edge.Back.NORTH.Width - 2 *
				(RenderConstants.Entities.TableSegment.Margin + RenderConstants.Entities.TableSegment.Border) / 4,
				Layout.Count * Textures.Table.Edge.Back.NORTH.Width / 4 * 3);

			/// <summary>
			/// Direction the balls are oriented when racked
			/// </summary>
			public static Direction RackOrientation = Direction.East;
		}

		public class Goalkeeper
		{
			public static IList<IList<TableSegmentType>> Layout = new List<IList<TableSegmentType>>
			{
				new List<TableSegmentType>
				{
					TableSegmentType.NorthWestEdge,
					TableSegmentType.NorthEdge,
					TableSegmentType.NorthEdge,
					TableSegmentType.NorthEdge,
					TableSegmentType.NorthEdge,
					TableSegmentType.NorthEdge,
					TableSegmentType.NorthEastEdge
				},
				new List<TableSegmentType>
				{
					TableSegmentType.WestPocket,
					TableSegmentType.Felt,
					TableSegmentType.Felt,
					TableSegmentType.Felt,
					TableSegmentType.Felt,
					TableSegmentType.Felt,
					TableSegmentType.EastPocket
				},
				new List<TableSegmentType>
				{
					TableSegmentType.SouthWestEdge,
					TableSegmentType.SouthEdge,
					TableSegmentType.SouthEdge,
					TableSegmentType.SouthEdge,
					TableSegmentType.SouthEdge,
					TableSegmentType.SouthEdge,
					TableSegmentType.SouthEastEdge
				}
			};
		}

		public class SingleLane
		{
			/// <summary>
			/// Location of the cue ball in classic gamemodes
			/// </summary>
			public static Vector2 CueBallStart = new Vector2(
				Layout[0].Count * Textures.Table.Edge.Back.NORTH.Width - 2 *
				(RenderConstants.Entities.TableSegment.Margin + RenderConstants.Entities.TableSegment.Border) / 8 * 2,
				Layout.Count * Textures.Table.Edge.Back.NORTH.Width / 2);

			/// <summary>
			/// Starting place to rack the balls
			/// </summary>
			public static Vector2 FootSpot = new Vector2(
				Layout[0].Count * Textures.Table.Edge.Back.NORTH.Width - 2 *
				(RenderConstants.Entities.TableSegment.Margin + RenderConstants.Entities.TableSegment.Border) / 8 * 6,
				Layout.Count * Textures.Table.Edge.Back.NORTH.Width / 2);

			/// <summary>
			/// Area in which ball in hand shots can be made from
			/// </summary>
			public static Rectangle Kitchen = new Rectangle(
				new Vector2(
					RenderConstants.Entities.TableSegment.Margin + RenderConstants.Entities.TableSegment.Border,
					RenderConstants.Entities.TableSegment.Margin + RenderConstants.Entities.TableSegment.Border),
				Layout[0].Count * Textures.Table.Edge.Back.NORTH.Width - 2 *
				(RenderConstants.Entities.TableSegment.Margin + RenderConstants.Entities.TableSegment.Border) / 8 * 2,
				Layout.Count * Textures.Table.Edge.Back.NORTH.Width - 2 *
				(RenderConstants.Entities.TableSegment.Margin + RenderConstants.Entities.TableSegment.Border));

			public static IList<IList<TableSegmentType>> Layout = new List<IList<TableSegmentType>>
			{
				new List<TableSegmentType>
				{
					TableSegmentType.NorthWestEdge,
					TableSegmentType.NorthPocket,
					TableSegmentType.NorthEastEdge,
					TableSegmentType.Empty,
					TableSegmentType.Empty,
					TableSegmentType.Empty,
					TableSegmentType.NorthWestEdge,
					TableSegmentType.NorthPocket,
					TableSegmentType.NorthEastEdge
				},
				new List<TableSegmentType>
				{
					TableSegmentType.WestEdge,
					TableSegmentType.Felt,
					TableSegmentType.NorthEastCorner,
					TableSegmentType.NorthEdge,
					TableSegmentType.NorthEdge,
					TableSegmentType.NorthEdge,
					TableSegmentType.NorthWestCorner,
					TableSegmentType.Felt,
					TableSegmentType.EastEdge
				},
				new List<TableSegmentType>
				{
					TableSegmentType.WestEdge,
					TableSegmentType.Felt,
					TableSegmentType.Felt,
					TableSegmentType.Felt,
					TableSegmentType.Felt,
					TableSegmentType.Felt,
					TableSegmentType.Felt,
					TableSegmentType.Felt,
					TableSegmentType.EastEdge
				},
				new List<TableSegmentType>
				{
					TableSegmentType.WestEdge,
					TableSegmentType.Felt,
					TableSegmentType.SouthEastCorner,
					TableSegmentType.SouthEdge,
					TableSegmentType.SouthEdge,
					TableSegmentType.SouthEdge,
					TableSegmentType.SouthWestCorner,
					TableSegmentType.Felt,
					TableSegmentType.EastEdge
				},
				new List<TableSegmentType>
				{
					TableSegmentType.SouthWestEdge,
					TableSegmentType.SouthPocket,
					TableSegmentType.SouthEastCorner,
					TableSegmentType.Empty,
					TableSegmentType.Empty,
					TableSegmentType.Empty,
					TableSegmentType.SouthWestCorner,
					TableSegmentType.SouthPocket,
					TableSegmentType.SouthEastEdge
				}
			};

			/// <summary>
			/// Location of first cue ball in gamemodes where there are two balls
			/// </summary>
			public static Vector2 Player1CueBallStart = new Vector2(
				Layout[0].Count * Textures.Table.Edge.Back.NORTH.Width - 2 *
				(RenderConstants.Entities.TableSegment.Margin + RenderConstants.Entities.TableSegment.Border) / 8 * 2,
				Layout.Count * Textures.Table.Edge.Back.NORTH.Width / 4 * 1);

			/// <summary>
			/// Location of second cue ball in gamemodes where there are two balls
			/// </summary>
			public static Vector2 Player2CueBallStart = new Vector2(
				Layout[0].Count * Textures.Table.Edge.Back.NORTH.Width - 2 *
				(RenderConstants.Entities.TableSegment.Margin + RenderConstants.Entities.TableSegment.Border) / 8 * 2,
				Layout.Count * Textures.Table.Edge.Back.NORTH.Width / 4 * 3);

			/// <summary>
			/// Direction the balls are oriented when racked
			/// </summary>
			public static Direction RackOrientation = Direction.East;
		}

		public class TugOfWar
		{
			public static IList<IList<TableSegmentType>> Layout = new List<IList<TableSegmentType>>
			{
				new List<TableSegmentType>
				{
					TableSegmentType.NorthWestEdge,
					TableSegmentType.NorthPocket,
					TableSegmentType.NorthEastEdge,
					TableSegmentType.Empty,
					TableSegmentType.Empty,
					TableSegmentType.Empty,
					TableSegmentType.NorthWestEdge,
					TableSegmentType.NorthPocket,
					TableSegmentType.NorthEastEdge
				},
				new List<TableSegmentType>
				{
					TableSegmentType.WestEdge,
					TableSegmentType.Felt,
					TableSegmentType.EastEdge,
					TableSegmentType.Empty,
					TableSegmentType.Empty,
					TableSegmentType.Empty,
					TableSegmentType.WestEdge,
					TableSegmentType.Felt,
					TableSegmentType.EastEdge
				},
				new List<TableSegmentType>
				{
					TableSegmentType.WestEdge,
					TableSegmentType.Felt,
					TableSegmentType.NorthEastCorner,
					TableSegmentType.NorthEdge,
					TableSegmentType.NorthEdge,
					TableSegmentType.NorthEdge,
					TableSegmentType.NorthWestCorner,
					TableSegmentType.Felt,
					TableSegmentType.EastEdge
				},
				new List<TableSegmentType>
				{
					TableSegmentType.WestEdge,
					TableSegmentType.Felt,
					TableSegmentType.Felt,
					TableSegmentType.Felt,
					TableSegmentType.Felt,
					TableSegmentType.Felt,
					TableSegmentType.Felt,
					TableSegmentType.Felt,
					TableSegmentType.EastEdge
				},
				new List<TableSegmentType>
				{
					TableSegmentType.SouthWestEdge,
					TableSegmentType.SouthEdge,
					TableSegmentType.SouthEdge,
					TableSegmentType.SouthEdge,
					TableSegmentType.SouthEdge,
					TableSegmentType.SouthEdge,
					TableSegmentType.SouthEdge,
					TableSegmentType.SouthEdge,
					TableSegmentType.SouthEastEdge
				}
			};
		}
	}
}