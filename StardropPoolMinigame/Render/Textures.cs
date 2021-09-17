using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Enums;

namespace StardropPoolMinigame.Render
{
	internal class Textures
	{
		public static Rectangle BAR_SHELVES =
			new Rectangle(0, 0, RenderConstants.TileSize * 25, RenderConstants.TileSize * 8);

		public static Rectangle FLOOR_TILES = new Rectangle(RenderConstants.TileSize * 16, RenderConstants.TileSize * 8,
			RenderConstants.TileSize * 4, RenderConstants.TileSize * 4);

		public static Rectangle GAME_TITLE = new Rectangle(0, RenderConstants.TileSize * 8,
			RenderConstants.TileSize * 8, RenderConstants.TileSize * 5);

		public static Rectangle PORTRAIT_RAYS = new Rectangle(0, RenderConstants.TileSize * 8,
			RenderConstants.TileSize * 17, RenderConstants.TileSize * 4);

		/// <summary>
		/// Retrives ball core texture based on orientation
		/// </summary>
		/// <param name="orientation">Polar coordinate <see cref="Vector2"/></param>
		/// <returns>Ball core texture</returns>
		public static Rectangle GetBallCoreBounds(Vector2 orientation)
		{
			if (orientation.Y == 90) return Ball.Core.CORE_0_90;

			if (orientation.Y == 60)
			{
				if (orientation.X == 0) return Ball.Core.CORE_0_60;

				if (orientation.X == 45) return Ball.Core.CORE_45_60;

				if (orientation.X == 90) return Ball.Core.CORE_90_60;

				if (orientation.X == 135) return Ball.Core.CORE_135_60;
			}

			if (orientation.Y == 30)
			{
				if (orientation.X == 0) return Ball.Core.CORE_0_30;

				if (orientation.X == 30) return Ball.Core.CORE_30_30;

				if (orientation.X == 60) return Ball.Core.CORE_60_30;

				if (orientation.X == 90) return Ball.Core.CORE_90_30;

				if (orientation.X == 120) return Ball.Core.CORE_120_30;

				if (orientation.X == 150) return Ball.Core.CORE_150_30;
			}

			if (orientation.Y == 0)
			{
				if (orientation.X == 0) return Ball.Core.CORE_0_0;

				if (orientation.X == 30) return Ball.Core.CORE_30_0;

				if (orientation.X == 60) return Ball.Core.CORE_60_0;

				if (orientation.X == 90) return Ball.Core.CORE_90_0;

				if (orientation.X == 120) return Ball.Core.CORE_120_0;

				if (orientation.X == 150) return Ball.Core.CORE_150_0;
			}

			if (orientation.Y == -30)
			{
				if (orientation.X == 0) return Ball.Core.CORE_0_N30;

				if (orientation.X == 30) return Ball.Core.CORE_30_N30;

				if (orientation.X == 60) return Ball.Core.CORE_60_N30;

				if (orientation.X == 90) return Ball.Core.CORE_90_N30;

				if (orientation.X == 120) return Ball.Core.CORE_120_N30;

				if (orientation.X == 150) return Ball.Core.CORE_150_N30;
			}

			if (orientation.Y == -60)
			{
				if (orientation.X == 0) return Ball.Core.CORE_0_N60;

				if (orientation.X == 45) return Ball.Core.CORE_45_N60;

				if (orientation.X == 90) return Ball.Core.CORE_90_N60;

				if (orientation.X == 135) return Ball.Core.CORE_135_N60;
			}

			return Ball.Core.CORE_0_0;
		}

		/// <summary>
		/// Retrives <see cref="Entities.Ball"/> stripes texture based on <see cref="Orientation"/>
		/// </summary>
		/// <param name="orientation">Polar coordinate <see cref="Vector2"/></param>
		/// <returns><see cref="Entities.Ball"/> stripes texture bounds</returns>
		public static Rectangle GetBallStripesBounds(Vector2 orientation)
		{
			if (orientation.Y == 90) return Ball.Stripes.STRIPES_0_90;

			if (orientation.Y == 60) return Ball.Stripes.STRIPES_0_60;

			if (orientation.Y == 30) return Ball.Stripes.STRIPES_0_30;

			if (orientation.Y == 0) return Ball.Stripes.STRIPES_0_0;

			if (orientation.Y == -30) return Ball.Stripes.STRIPES_0_N30;

			if (orientation.Y == -60) return Ball.Stripes.STRIPES_0_N60;

			return Ball.Stripes.STRIPES_0_0;
		}

		/// <summary>
		/// Retrives font <see cref="Entities.Character"/> texture based on character
		/// </summary>
		/// <param name="orientation">Character to retrieve></param>
		/// <returns>Custom font texture</returns>
		public static Rectangle GetCharacterBoundsFromChar(char character)
		{
			switch (character)
			{
				case 'A':
					return Characters.UppercaseA;

				case 'b':
					return Characters.LowercaseB;

				case 'B':
					return Characters.UppercaseB;

				case 'c':
					return Characters.LowercaseC;

				case 'C':
					return Characters.UppercaseC;

				case 'd':
					return Characters.LowercaseD;

				case 'D':
					return Characters.UppercaseD;

				case 'e':
					return Characters.LowercaseE;

				case 'E':
					return Characters.UppercaseE;

				case 'f':
					return Characters.LowercaseF;

				case 'F':
					return Characters.UppercaseF;

				case 'g':
					return Characters.LowercaseG;

				case 'G':
					return Characters.UppercaseG;

				case 'h':
					return Characters.LowercaseH;

				case 'H':
					return Characters.UppercaseH;

				case 'i':
					return Characters.LowercaseI;

				case 'I':
					return Characters.UppercaseI;

				case 'j':
					return Characters.LowercaseJ;

				case 'J':
					return Characters.UppercaseJ;

				case 'k':
					return Characters.LowercaseK;

				case 'K':
					return Characters.UppercaseK;

				case 'l':
					return Characters.LowercaseL;

				case 'L':
					return Characters.UppercaseL;

				case 'm':
					return Characters.LowercaseM;

				case 'M':
					return Characters.UppercaseM;

				case 'n':
					return Characters.LowercaseN;

				case 'N':
					return Characters.UppercaseN;

				case 'o':
					return Characters.LowercaseO;

				case 'O':
					return Characters.UppercaseO;

				case 'p':
					return Characters.LowercaseP;

				case 'P':
					return Characters.UppercaseP;

				case 'q':
					return Characters.LowercaseQ;

				case 'Q':
					return Characters.UppercaseQ;

				case 'r':
					return Characters.LowercaseR;

				case 'R':
					return Characters.UppercaseR;

				case 's':
					return Characters.LowercaseS;

				case 'S':
					return Characters.UppercaseS;

				case 't':
					return Characters.LowercaseT;

				case 'T':
					return Characters.UppercaseT;

				case 'u':
					return Characters.LowercaseU;

				case 'U':
					return Characters.UppercaseU;

				case 'v':
					return Characters.LowercaseV;

				case 'V':
					return Characters.UppercaseV;

				case 'w':
					return Characters.LowercaseW;

				case 'W':
					return Characters.UppercaseW;

				case 'x':
					return Characters.LowercaseX;

				case 'X':
					return Characters.UppercaseX;

				case 'y':
					return Characters.LowercaseY;

				case 'Y':
					return Characters.UppercaseY;

				case 'z':
					return Characters.LowercaseZ;

				case 'Z':
					return Characters.UppercaseZ;

				case '.':
					return Characters.Period;

				case ',':
					return Characters.Comma;

				case '!':
					return Characters.ExclamationPoint;

				case '?':
					return Characters.QuestionMark;

				case '\'':
					return Characters.Apostrophe;

				case ':':
					return Characters.Colon;

				case 'à':
					return Characters.LowercaseAGrave;

				case 'À':
					return Characters.UppercaseAGrave;

				case 'á':
					return Characters.LowercaseAAcute;

				case 'Á':
					return Characters.UppercaseAAcute;

				case 'â':
					return Characters.LowercaseACircumflex;

				case 'Â':
					return Characters.UppercaseACircumflex;

				case 'ä':
					return Characters.LowercaseADiaerisis;

				case 'Ä':
					return Characters.UppercaseADiaerisis;

				case 'æ':
					return Characters.LowercaseAELigature;

				case 'Æ':
					return Characters.UppercaseAELigature;

				case 'ç':
					return Characters.LowercaseCCedilla;

				case 'Ç':
					return Characters.UppercaseCCedilla;

				case 'é':
					return Characters.LowercaseEAcute;

				case 'É':
					return Characters.UppercaseEAcute;

				case 'è':
					return Characters.LowercaseEGrave;

				case 'È':
					return Characters.UppercaseEGrave;

				case 'ê':
					return Characters.LowercaseECircumflex;

				case 'Ê':
					return Characters.UppercaseECircumflex;

				case 'ë':
					return Characters.LowercaseEDiaerisis;

				case 'Ë':
					return Characters.UppercaseEDiaerisis;

				case 'ì':
					return Characters.LowercaseIGrave;

				case 'Ì':
					return Characters.UppercaseIGrave;

				case 'í':
					return Characters.LowercaseIAcute;

				case 'Í':
					return Characters.UppercaseIAcute;

				case 'î':
					return Characters.LowercaseICircumflex;

				case 'Î':
					return Characters.UppercaseICircumflex;

				case 'ï':
					return Characters.LowercaseIDiaerisis;

				case 'Ï':
					return Characters.UppercaseIDiaerisis;

				case 'ó':
					return Characters.LowercaseOAcute;

				case 'Ó':
					return Characters.UppercaseOAcute;

				case 'ò':
					return Characters.LowercaseOGrave;

				case 'Ò':
					return Characters.UppercaseOGrave;

				case 'ô':
					return Characters.LowercaseOCircumflex;

				case 'Ô':
					return Characters.UppercaseOCircumflex;

				case 'ö':
					return Characters.LowercaseODiaerisis;

				case 'Ö':
					return Characters.UppercaseODiaerisis;

				case 'œ':
					return Characters.LowercaseOELigature;

				case 'Œ':
					return Characters.UppercaseOELigature;

				case 'ú':
					return Characters.LowercaseUAcute;

				case 'Ú':
					return Characters.UppercaseUAcute;

				case 'ù':
					return Characters.LowercaseUGrave;

				case 'Ù':
					return Characters.UppercaseUGrave;

				case 'û':
					return Characters.LowercaseUCircumflex;

				case 'Û':
					return Characters.UppercaseUCircumflex;

				case 'ü':
					return Characters.LowercaseUDiaerisis;

				case 'Ü':
					return Characters.UppercaseUDiaerisis;

				case 'ÿ':
					return Characters.LowercaseYDiaerisis;

				case 'Ÿ':
					return Characters.UppercaseYDiaerisis;

				case 'ß':
					return Characters.Eszett;

				case 'ñ':
					return Characters.LowercaseNTilde;

				case 'Ñ':
					return Characters.UppercaseNTilde;

				case '¿':
					return Characters.InvertedQuestionMark;

				default:
					return Characters.LowercaseA;
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
					return Table.Edge.Back.NORTH;

				case TableSegmentType.SouthEdge:
					return Table.Edge.Back.SOUTH;

				case TableSegmentType.WestEdge:
					return Table.Edge.Back.WEST;

				case TableSegmentType.EastEdge:
					return Table.Edge.Back.EAST;

				case TableSegmentType.NorthWestEdge:
					return Table.Edge.Back.NORTH_WEST;

				case TableSegmentType.NorthEastEdge:
					return Table.Edge.Back.NORTH_EAST;

				case TableSegmentType.SouthWestEdge:
					return Table.Edge.Back.SOUTH_WEST;

				case TableSegmentType.SouthEastEdge:
					return Table.Edge.Back.SOUTH_EAST;

				case TableSegmentType.NorthWestCorner:
					return Table.Corner.Back.NORTH_WEST;

				case TableSegmentType.NorthEastCorner:
					return Table.Corner.Back.NORTH_EAST;

				case TableSegmentType.SouthWestCorner:
					return Table.Corner.Back.SOUTH_WEST;

				case TableSegmentType.SouthEastCorner:
					return Table.Corner.Back.SOUTH_EAST;

				case TableSegmentType.NorthPocket:
					return Table.Pocket.Back.NORTH;

				case TableSegmentType.SouthPocket:
					return Table.Pocket.Back.SOUTH;

				case TableSegmentType.WestPocket:
					return Table.Pocket.Back.WEST;

				case TableSegmentType.EastPocket:
					return Table.Pocket.Back.EAST;

				case TableSegmentType.NorthWestPocket:
					return Table.Pocket.Back.NORTH_WEST;

				case TableSegmentType.NorthEastPocket:
					return Table.Pocket.Back.NORTH_EAST;

				case TableSegmentType.SouthWestPocket:
					return Table.Pocket.Back.SOUTH_WEST;

				case TableSegmentType.SouthEastPocket:
					return Table.Pocket.Back.SOUTH_EAST;

				default:
					return Table.FELT;
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
					return Table.Edge.Front.NORTH;

				case TableSegmentType.SouthEdge:
					return Table.Edge.Front.SOUTH;

				case TableSegmentType.WestEdge:
					return Table.Edge.Front.WEST;

				case TableSegmentType.EastEdge:
					return Table.Edge.Front.EAST;

				case TableSegmentType.NorthWestEdge:
					return Table.Edge.Front.NORTH_WEST;

				case TableSegmentType.NorthEastEdge:
					return Table.Edge.Front.NORTH_EAST;

				case TableSegmentType.SouthWestEdge:
					return Table.Edge.Front.SOUTH_WEST;

				case TableSegmentType.SouthEastEdge:
					return Table.Edge.Front.SOUTH_EAST;

				case TableSegmentType.NorthWestCorner:
					return Table.Corner.Front.NORTH_WEST;

				case TableSegmentType.NorthEastCorner:
					return Table.Corner.Front.NORTH_EAST;

				case TableSegmentType.SouthWestCorner:
					return Table.Corner.Front.SOUTH_WEST;

				case TableSegmentType.SouthEastCorner:
					return Table.Corner.Front.SOUTH_EAST;

				case TableSegmentType.NorthPocket:
					return Table.Pocket.Front.NORTH;

				case TableSegmentType.SouthPocket:
					return Table.Pocket.Front.SOUTH;

				case TableSegmentType.WestPocket:
					return Table.Pocket.Front.WEST;

				case TableSegmentType.EastPocket:
					return Table.Pocket.Front.EAST;

				case TableSegmentType.NorthWestPocket:
					return Table.Pocket.Front.NORTH_WEST;

				case TableSegmentType.NorthEastPocket:
					return Table.Pocket.Front.NORTH_EAST;

				case TableSegmentType.SouthWestPocket:
					return Table.Pocket.Front.SOUTH_WEST;

				case TableSegmentType.SouthEastPocket:
					return Table.Pocket.Front.SOUTH_EAST;

				default:
					return Table.FELT;
			}
		}

		/// <summary>
		/// Loads tilesheets.
		/// </summary>
		public static void LoadTextures()
		{
			Logger.Info("Loading Tilesets");
			Tileset.Default = Game1.content.Load<Texture2D>("Minigames\\stardropPool");
			Tileset.Font = Game1.content.Load<Texture2D>("Minigames\\stardropPoolFont");
			Tileset.PortraitAbigail = Game1.content.Load<Texture2D>("Portraits\\Abigail");
			Tileset.PortraitGus = Game1.content.Load<Texture2D>("Portraits\\Gus");
			Tileset.PortraitSam = Game1.content.Load<Texture2D>("Portraits\\Sam");
			Tileset.PortraitSebastian = Game1.content.Load<Texture2D>("Portraits\\Sebastian");
		}

		/// <summary>
		/// Bounds for all <see cref="Entities.Ball"/> components
		/// </summary>
		public class Ball
		{
			public static Rectangle HIGHLIGHT = new Rectangle(RenderConstants.TileSize * 23,
				RenderConstants.TileSize * 11, RenderConstants.TileSize, RenderConstants.TileSize);

			public static Rectangle SHADOW = new Rectangle(RenderConstants.TileSize * 24, RenderConstants.TileSize * 10,
				RenderConstants.TileSize, RenderConstants.TileSize);

			public class Base
			{
				public static Rectangle BLACK = new Rectangle(RenderConstants.TileSize * 23,
					RenderConstants.TileSize * 10, RenderConstants.TileSize, RenderConstants.TileSize);

				public static Rectangle BLUE = new Rectangle(RenderConstants.TileSize * 22,
					RenderConstants.TileSize * 9, RenderConstants.TileSize, RenderConstants.TileSize);

				public static Rectangle GREEN = new Rectangle(RenderConstants.TileSize * 21,
					RenderConstants.TileSize * 10, RenderConstants.TileSize, RenderConstants.TileSize);

				public static Rectangle MAROON = new Rectangle(RenderConstants.TileSize * 22,
					RenderConstants.TileSize * 10, RenderConstants.TileSize, RenderConstants.TileSize);

				public static Rectangle ORANGE = new Rectangle(RenderConstants.TileSize * 20,
					RenderConstants.TileSize * 10, RenderConstants.TileSize, RenderConstants.TileSize);

				public static Rectangle PURPLE = new Rectangle(RenderConstants.TileSize * 24,
					RenderConstants.TileSize * 9, RenderConstants.TileSize, RenderConstants.TileSize);

				public static Rectangle RED = new Rectangle(RenderConstants.TileSize * 23, RenderConstants.TileSize * 9,
					RenderConstants.TileSize, RenderConstants.TileSize);

				public static Rectangle WHITE = new Rectangle(RenderConstants.TileSize * 20,
					RenderConstants.TileSize * 9, RenderConstants.TileSize, RenderConstants.TileSize);

				public static Rectangle YELLOW = new Rectangle(RenderConstants.TileSize * 21,
					RenderConstants.TileSize * 9, RenderConstants.TileSize, RenderConstants.TileSize);
			}

			public class Core
			{
				public static Rectangle CORE_0_0 = new Rectangle(RenderConstants.TileSize * 25,
					RenderConstants.TileSize * 3, RenderConstants.TileSize, RenderConstants.TileSize);

				public static Rectangle CORE_0_30 = new Rectangle(RenderConstants.TileSize * 25,
					RenderConstants.TileSize * 2, RenderConstants.TileSize, RenderConstants.TileSize);

				public static Rectangle CORE_0_60 = new Rectangle(RenderConstants.TileSize * 25,
					RenderConstants.TileSize * 1, RenderConstants.TileSize, RenderConstants.TileSize);

				public static Rectangle CORE_0_90 = new Rectangle(RenderConstants.TileSize * 25,
					RenderConstants.TileSize * 0, RenderConstants.TileSize, RenderConstants.TileSize);

				public static Rectangle CORE_0_N30 = new Rectangle(RenderConstants.TileSize * 25,
					RenderConstants.TileSize * 4, RenderConstants.TileSize, RenderConstants.TileSize);

				public static Rectangle CORE_0_N60 = new Rectangle(RenderConstants.TileSize * 25,
					RenderConstants.TileSize * 5, RenderConstants.TileSize, RenderConstants.TileSize);

				public static Rectangle CORE_120_0 = new Rectangle(RenderConstants.TileSize * 29,
					RenderConstants.TileSize * 3, RenderConstants.TileSize, RenderConstants.TileSize);

				public static Rectangle CORE_120_30 = new Rectangle(RenderConstants.TileSize * 29,
					RenderConstants.TileSize * 2, RenderConstants.TileSize, RenderConstants.TileSize);

				public static Rectangle CORE_120_N30 = new Rectangle(RenderConstants.TileSize * 29,
					RenderConstants.TileSize * 4, RenderConstants.TileSize, RenderConstants.TileSize);

				public static Rectangle CORE_135_60 = new Rectangle(RenderConstants.TileSize * 28,
					RenderConstants.TileSize * 1, RenderConstants.TileSize, RenderConstants.TileSize);

				public static Rectangle CORE_135_N60 = new Rectangle(RenderConstants.TileSize * 28,
					RenderConstants.TileSize * 5, RenderConstants.TileSize, RenderConstants.TileSize);

				public static Rectangle CORE_150_0 = new Rectangle(RenderConstants.TileSize * 30,
					RenderConstants.TileSize * 3, RenderConstants.TileSize, RenderConstants.TileSize);

				public static Rectangle CORE_150_30 = new Rectangle(RenderConstants.TileSize * 30,
					RenderConstants.TileSize * 2, RenderConstants.TileSize, RenderConstants.TileSize);

				public static Rectangle CORE_150_N30 = new Rectangle(RenderConstants.TileSize * 30,
					RenderConstants.TileSize * 4, RenderConstants.TileSize, RenderConstants.TileSize);

				public static Rectangle CORE_30_0 = new Rectangle(RenderConstants.TileSize * 26,
					RenderConstants.TileSize * 3, RenderConstants.TileSize, RenderConstants.TileSize);

				public static Rectangle CORE_30_30 = new Rectangle(RenderConstants.TileSize * 26,
					RenderConstants.TileSize * 2, RenderConstants.TileSize, RenderConstants.TileSize);

				public static Rectangle CORE_30_N30 = new Rectangle(RenderConstants.TileSize * 26,
					RenderConstants.TileSize * 4, RenderConstants.TileSize, RenderConstants.TileSize);

				public static Rectangle CORE_45_60 = new Rectangle(RenderConstants.TileSize * 26,
					RenderConstants.TileSize * 1, RenderConstants.TileSize, RenderConstants.TileSize);

				public static Rectangle CORE_45_N60 = new Rectangle(RenderConstants.TileSize * 26,
					RenderConstants.TileSize * 5, RenderConstants.TileSize, RenderConstants.TileSize);

				public static Rectangle CORE_60_0 = new Rectangle(RenderConstants.TileSize * 27,
					RenderConstants.TileSize * 3, RenderConstants.TileSize, RenderConstants.TileSize);

				public static Rectangle CORE_60_30 = new Rectangle(RenderConstants.TileSize * 27,
					RenderConstants.TileSize * 2, RenderConstants.TileSize, RenderConstants.TileSize);

				public static Rectangle CORE_60_N30 = new Rectangle(RenderConstants.TileSize * 27,
					RenderConstants.TileSize * 4, RenderConstants.TileSize, RenderConstants.TileSize);

				public static Rectangle CORE_90_0 = new Rectangle(RenderConstants.TileSize * 28,
					RenderConstants.TileSize * 3, RenderConstants.TileSize, RenderConstants.TileSize);

				public static Rectangle CORE_90_30 = new Rectangle(RenderConstants.TileSize * 28,
					RenderConstants.TileSize * 2, RenderConstants.TileSize, RenderConstants.TileSize);

				public static Rectangle CORE_90_60 = new Rectangle(RenderConstants.TileSize * 27,
					RenderConstants.TileSize * 1, RenderConstants.TileSize, RenderConstants.TileSize);

				public static Rectangle CORE_90_N30 = new Rectangle(RenderConstants.TileSize * 28,
					RenderConstants.TileSize * 4, RenderConstants.TileSize, RenderConstants.TileSize);

				public static Rectangle CORE_90_N60 = new Rectangle(RenderConstants.TileSize * 27,
					RenderConstants.TileSize * 5, RenderConstants.TileSize, RenderConstants.TileSize);
			}

			public class Stripes
			{
				public static Rectangle STRIPES_0_0 = new Rectangle(RenderConstants.TileSize * 25,
					RenderConstants.TileSize * 9, RenderConstants.TileSize, RenderConstants.TileSize);

				public static Rectangle STRIPES_0_30 = new Rectangle(RenderConstants.TileSize * 25,
					RenderConstants.TileSize * 8, RenderConstants.TileSize, RenderConstants.TileSize);

				public static Rectangle STRIPES_0_60 = new Rectangle(RenderConstants.TileSize * 25,
					RenderConstants.TileSize * 7, RenderConstants.TileSize, RenderConstants.TileSize);

				public static Rectangle STRIPES_0_90 = new Rectangle(RenderConstants.TileSize * 25,
					RenderConstants.TileSize * 6, RenderConstants.TileSize, RenderConstants.TileSize);

				public static Rectangle STRIPES_0_N30 = new Rectangle(RenderConstants.TileSize * 25,
					RenderConstants.TileSize * 10, RenderConstants.TileSize, RenderConstants.TileSize);

				public static Rectangle STRIPES_0_N60 = new Rectangle(RenderConstants.TileSize * 25,
					RenderConstants.TileSize * 11, RenderConstants.TileSize, RenderConstants.TileSize);
			}
		}

		/// <summary>
		/// Bounds for all font <see cref="Entities.Character">Characters</see>
		/// </summary>
		public class Characters
		{
			public static Rectangle LowercaseA = new Rectangle(
				0,
				0,
				7,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle UppercaseA = new Rectangle(
				LowercaseA.X + LowercaseA.Width + RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				0,
				7,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle LowercaseB = new Rectangle(
				UppercaseA.X + UppercaseA.Width + RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				0,
				7,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle UppercaseB = new Rectangle(
				LowercaseB.X + LowercaseB.Width + RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				0,
				7,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle LowercaseC = new Rectangle(
				UppercaseB.X + UppercaseB.Width + RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				0,
				7,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle UppercaseC = new Rectangle(
				LowercaseC.X + LowercaseC.Width + RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				0,
				7,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle LowercaseD = new Rectangle(
				UppercaseC.X + UppercaseC.Width + RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				0,
				7,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle UppercaseD = new Rectangle(
				LowercaseD.X + LowercaseD.Width + RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				0,
				7,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle LowercaseE = new Rectangle(
				UppercaseD.X + UppercaseD.Width + RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				0,
				7,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle UppercaseE = new Rectangle(
				LowercaseE.X + LowercaseE.Width + RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				0,
				7,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle LowercaseF = new Rectangle(
				UppercaseE.X + UppercaseE.Width + RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				0,
				5,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle UppercaseF = new Rectangle(
				LowercaseF.X + LowercaseF.Width + RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				0,
				7,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle LowercaseG = new Rectangle(
				UppercaseF.X + UppercaseF.Width + RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				0,
				7,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle UppercaseG = new Rectangle(
				LowercaseG.X + LowercaseG.Width + RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				0,
				7,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle LowercaseH = new Rectangle(
				UppercaseG.X + UppercaseG.Width + RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				0,
				7,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle UppercaseH = new Rectangle(
				LowercaseH.X + LowercaseH.Width + RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				0,
				7,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle LowercaseI = new Rectangle(
				UppercaseH.X + UppercaseH.Width + RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				0,
				2,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle UppercaseI = new Rectangle(
				LowercaseI.X + LowercaseI.Width + RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				0,
				6,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle LowercaseJ = new Rectangle(
				UppercaseI.X + UppercaseI.Width + RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				0,
				4,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle UppercaseJ = new Rectangle(
				0,
				RenderConstants.Font.CharacterHeight,
				7,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle LowercaseK = new Rectangle(
				UppercaseJ.X + UppercaseJ.Width + RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				RenderConstants.Font.CharacterHeight,
				6,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle UppercaseK = new Rectangle(
				LowercaseK.X + LowercaseK.Width + RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				RenderConstants.Font.CharacterHeight,
				7,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle LowercaseL = new Rectangle(
				UppercaseK.X + UppercaseK.Width + RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				RenderConstants.Font.CharacterHeight,
				2,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle UppercaseL = new Rectangle(
				LowercaseL.X + LowercaseL.Width + RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				RenderConstants.Font.CharacterHeight,
				7,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle LowercaseM = new Rectangle(
				UppercaseL.X + UppercaseL.Width + RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				RenderConstants.Font.CharacterHeight,
				7,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle UppercaseM = new Rectangle(
				LowercaseM.X + LowercaseM.Width + RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				RenderConstants.Font.CharacterHeight,
				7,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle LowercaseN = new Rectangle(
				UppercaseM.X + UppercaseM.Width + RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				RenderConstants.Font.CharacterHeight,
				6,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle UppercaseN = new Rectangle(
				LowercaseN.X + LowercaseN.Width + RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				RenderConstants.Font.CharacterHeight,
				7,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle LowercaseO = new Rectangle(
				UppercaseN.X + UppercaseN.Width + RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				RenderConstants.Font.CharacterHeight,
				7,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle UppercaseO = new Rectangle(
				LowercaseO.X + LowercaseO.Width + RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				RenderConstants.Font.CharacterHeight,
				7,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle LowercaseP = new Rectangle(
				UppercaseO.X + UppercaseO.Width + RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				RenderConstants.Font.CharacterHeight,
				7,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle UppercaseP = new Rectangle(
				LowercaseP.X + LowercaseP.Width + RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				RenderConstants.Font.CharacterHeight,
				7,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle LowercaseQ = new Rectangle(
				UppercaseP.X + UppercaseP.Width + RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				RenderConstants.Font.CharacterHeight,
				7,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle UppercaseQ = new Rectangle(
				LowercaseQ.X + LowercaseQ.Width + RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				RenderConstants.Font.CharacterHeight,
				7,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle LowercaseR = new Rectangle(
				UppercaseQ.X + UppercaseQ.Width + RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				RenderConstants.Font.CharacterHeight,
				5,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle UppercaseR = new Rectangle(
				LowercaseR.X + LowercaseR.Width + RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				RenderConstants.Font.CharacterHeight,
				7,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle LowercaseS = new Rectangle(
				UppercaseR.X + UppercaseR.Width + RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				RenderConstants.Font.CharacterHeight,
				7,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle UppercaseS = new Rectangle(
				LowercaseS.X + LowercaseS.Width + RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				RenderConstants.Font.CharacterHeight,
				7,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle LowercaseT = new Rectangle(
				0,
				RenderConstants.Font.CharacterHeight * 2,
				5,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle UppercaseT = new Rectangle(
				LowercaseT.X + LowercaseT.Width + RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				RenderConstants.Font.CharacterHeight * 2,
				6,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle LowercaseU = new Rectangle(
				UppercaseT.X + UppercaseT.Width + RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				RenderConstants.Font.CharacterHeight * 2,
				7,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle UppercaseU = new Rectangle(
				LowercaseU.X + LowercaseU.Width + RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				RenderConstants.Font.CharacterHeight * 2,
				7,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle LowercaseV = new Rectangle(
				UppercaseU.X + UppercaseU.Width + RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				RenderConstants.Font.CharacterHeight * 2,
				7,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle UppercaseV = new Rectangle(
				LowercaseV.X + LowercaseV.Width + RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				RenderConstants.Font.CharacterHeight * 2,
				7,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle LowercaseW = new Rectangle(
				UppercaseV.X + UppercaseV.Width + RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				RenderConstants.Font.CharacterHeight * 2,
				7,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle UppercaseW = new Rectangle(
				LowercaseW.X + LowercaseW.Width + RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				RenderConstants.Font.CharacterHeight * 2,
				7,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle LowercaseX = new Rectangle(
				UppercaseW.X + UppercaseW.Width + RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				RenderConstants.Font.CharacterHeight * 2,
				7,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle UppercaseX = new Rectangle(
				LowercaseX.X + LowercaseX.Width + RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				RenderConstants.Font.CharacterHeight * 2,
				7,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle LowercaseY = new Rectangle(
				UppercaseX.X + UppercaseX.Width + RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				RenderConstants.Font.CharacterHeight * 2,
				7,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle UppercaseY = new Rectangle(
				LowercaseY.X + LowercaseY.Width + RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				RenderConstants.Font.CharacterHeight * 2,
				6,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle LowercaseZ = new Rectangle(
				UppercaseY.X + UppercaseY.Width + RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				RenderConstants.Font.CharacterHeight * 2,
				7,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle UppercaseZ = new Rectangle(
				LowercaseZ.X + LowercaseZ.Width + RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				RenderConstants.Font.CharacterHeight * 2,
				7,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle Period = new Rectangle(
				UppercaseZ.X + UppercaseZ.Width + RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				RenderConstants.Font.CharacterHeight * 2,
				2,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle Comma = new Rectangle(
				Period.X + Period.Width + RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				RenderConstants.Font.CharacterHeight * 2,
				3,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle ExclamationPoint = new Rectangle(
				Comma.X + Comma.Width + RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				RenderConstants.Font.CharacterHeight * 2,
				2,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle QuestionMark = new Rectangle(
				ExclamationPoint.X + ExclamationPoint.Width + RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				RenderConstants.Font.CharacterHeight * 2,
				6,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle Apostrophe
				= new Rectangle(
					QuestionMark.X + QuestionMark.Width + RenderConstants.Font.SpaceBetweenCharactersOnTileset,
					RenderConstants.Font.CharacterHeight * 2,
					2,
					RenderConstants.Font.CharacterHeight);

			public static Rectangle Colon = new Rectangle(
				Apostrophe.X + Apostrophe.Width + RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				RenderConstants.Font.CharacterHeight * 2,
				2,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle LowercaseAGrave = new Rectangle(
				Colon.X + Colon.Width + RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				RenderConstants.Font.CharacterHeight * 2,
				7,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle UppercaseAGrave = new Rectangle(
				0,
				RenderConstants.Font.CharacterHeight * 3,
				7,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle LowercaseAAcute = new Rectangle(
				UppercaseAGrave.X + UppercaseAGrave.Width + RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				RenderConstants.Font.CharacterHeight * 3,
				7,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle UppercaseAAcute = new Rectangle(
				LowercaseAAcute.X + LowercaseAAcute.Width + RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				RenderConstants.Font.CharacterHeight * 3,
				7,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle LowercaseACircumflex = new Rectangle(
				UppercaseAAcute.X + UppercaseAAcute.Width + RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				RenderConstants.Font.CharacterHeight * 3,
				7,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle UppercaseACircumflex = new Rectangle(
				LowercaseACircumflex.X + LowercaseACircumflex.Width +
				RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				RenderConstants.Font.CharacterHeight * 3,
				7,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle LowercaseADiaerisis = new Rectangle(
				UppercaseACircumflex.X + UppercaseACircumflex.Width +
				RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				RenderConstants.Font.CharacterHeight * 3,
				7,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle UppercaseADiaerisis = new Rectangle(
				LowercaseADiaerisis.X + LowercaseADiaerisis.Width +
				RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				RenderConstants.Font.CharacterHeight * 3,
				7,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle LowercaseAELigature = new Rectangle(
				UppercaseADiaerisis.X + UppercaseADiaerisis.Width +
				RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				RenderConstants.Font.CharacterHeight * 3,
				12,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle UppercaseAELigature = new Rectangle(
				LowercaseAELigature.X + LowercaseAELigature.Width +
				RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				RenderConstants.Font.CharacterHeight * 3,
				11,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle LowercaseCCedilla = new Rectangle(
				UppercaseAELigature.X + UppercaseAELigature.Width +
				RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				RenderConstants.Font.CharacterHeight * 3,
				7,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle UppercaseCCedilla = new Rectangle(
				LowercaseCCedilla.X + LowercaseCCedilla.Width +
				RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				RenderConstants.Font.CharacterHeight * 3,
				7,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle LowercaseEAcute = new Rectangle(
				UppercaseCCedilla.X + UppercaseCCedilla.Width +
				RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				RenderConstants.Font.CharacterHeight * 3,
				7,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle UppercaseEAcute = new Rectangle(
				LowercaseEAcute.X + LowercaseEAcute.Width + RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				RenderConstants.Font.CharacterHeight * 3,
				7,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle LowercaseEGrave = new Rectangle(
				UppercaseEAcute.X + UppercaseEAcute.Width + RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				RenderConstants.Font.CharacterHeight * 3,
				7,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle UppercaseEGrave = new Rectangle(
				LowercaseEGrave.X + LowercaseEGrave.Width + RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				RenderConstants.Font.CharacterHeight * 3,
				7,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle LowercaseECircumflex = new Rectangle(
				UppercaseEGrave.X + UppercaseEGrave.Width + RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				RenderConstants.Font.CharacterHeight * 3,
				7,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle UppercaseECircumflex = new Rectangle(
				LowercaseECircumflex.X + LowercaseECircumflex.Width +
				RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				RenderConstants.Font.CharacterHeight * 3,
				7,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle LowercaseEDiaerisis = new Rectangle(
				0,
				RenderConstants.Font.CharacterHeight * 4,
				7,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle UppercaseEDiaerisis = new Rectangle(
				LowercaseEDiaerisis.X + LowercaseEDiaerisis.Width +
				RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				RenderConstants.Font.CharacterHeight * 4,
				7,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle LowercaseIGrave = new Rectangle(
				UppercaseEDiaerisis.X + UppercaseEDiaerisis.Width +
				RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				RenderConstants.Font.CharacterHeight * 4,
				2,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle UppercaseIGrave = new Rectangle(
				LowercaseIGrave.X + LowercaseIGrave.Width + RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				RenderConstants.Font.CharacterHeight * 4,
				6,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle LowercaseIAcute = new Rectangle(
				UppercaseIGrave.X + UppercaseIGrave.Width + RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				RenderConstants.Font.CharacterHeight * 4,
				2,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle UppercaseIAcute = new Rectangle(
				LowercaseIAcute.X + LowercaseIAcute.Width + RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				RenderConstants.Font.CharacterHeight * 4,
				6,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle LowercaseICircumflex = new Rectangle(
				UppercaseIAcute.X + UppercaseIAcute.Width + RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				RenderConstants.Font.CharacterHeight * 4,
				3,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle UppercaseICircumflex = new Rectangle(
				LowercaseICircumflex.X + LowercaseICircumflex.Width +
				RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				RenderConstants.Font.CharacterHeight * 4,
				6,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle LowercaseIDiaerisis = new Rectangle(
				UppercaseICircumflex.X + UppercaseICircumflex.Width +
				RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				RenderConstants.Font.CharacterHeight * 4,
				4,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle UppercaseIDiaerisis = new Rectangle(
				LowercaseIDiaerisis.X + LowercaseIDiaerisis.Width +
				RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				RenderConstants.Font.CharacterHeight * 4,
				6,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle LowercaseOAcute = new Rectangle(
				UppercaseIDiaerisis.X + UppercaseIDiaerisis.Width +
				RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				RenderConstants.Font.CharacterHeight * 4,
				7,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle UppercaseOAcute = new Rectangle(
				LowercaseOAcute.X + LowercaseOAcute.Width + RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				RenderConstants.Font.CharacterHeight * 4,
				7,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle LowercaseOGrave = new Rectangle(
				UppercaseOAcute.X + UppercaseOAcute.Width + RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				RenderConstants.Font.CharacterHeight * 4,
				7,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle UppercaseOGrave = new Rectangle(
				LowercaseOGrave.X + LowercaseOGrave.Width + RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				RenderConstants.Font.CharacterHeight * 4,
				7,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle LowercaseOCircumflex = new Rectangle(
				UppercaseOGrave.X + UppercaseOGrave.Width + RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				RenderConstants.Font.CharacterHeight * 4,
				7,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle UppercaseOCircumflex = new Rectangle(
				LowercaseOCircumflex.X + LowercaseOCircumflex.Width +
				RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				RenderConstants.Font.CharacterHeight * 4,
				7,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle LowercaseODiaerisis = new Rectangle(
				UppercaseOCircumflex.X + UppercaseOCircumflex.Width +
				RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				RenderConstants.Font.CharacterHeight * 4,
				7,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle UppercaseODiaerisis = new Rectangle(
				LowercaseODiaerisis.X + LowercaseODiaerisis.Width +
				RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				RenderConstants.Font.CharacterHeight * 4,
				7,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle LowercaseOELigature = new Rectangle(
				UppercaseODiaerisis.X + UppercaseODiaerisis.Width +
				RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				RenderConstants.Font.CharacterHeight * 4,
				12,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle UppercaseOELigature = new Rectangle(
				0,
				RenderConstants.Font.CharacterHeight * 5,
				12,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle LowercaseUAcute = new Rectangle(
				UppercaseOELigature.X + UppercaseOELigature.Width +
				RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				RenderConstants.Font.CharacterHeight * 5,
				7,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle UppercaseUAcute = new Rectangle(
				LowercaseUAcute.X + LowercaseUAcute.Width + RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				RenderConstants.Font.CharacterHeight * 5,
				7,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle LowercaseUGrave = new Rectangle(
				UppercaseUAcute.X + UppercaseUAcute.Width + RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				RenderConstants.Font.CharacterHeight * 5,
				7,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle UppercaseUGrave = new Rectangle(
				LowercaseUGrave.X + LowercaseUGrave.Width + RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				RenderConstants.Font.CharacterHeight * 5,
				7,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle LowercaseUCircumflex = new Rectangle(
				UppercaseUGrave.X + UppercaseUGrave.Width + RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				RenderConstants.Font.CharacterHeight * 5,
				7,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle UppercaseUCircumflex = new Rectangle(
				LowercaseUCircumflex.X + LowercaseUCircumflex.Width +
				RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				RenderConstants.Font.CharacterHeight * 5,
				7,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle LowercaseUDiaerisis = new Rectangle(
				UppercaseUCircumflex.X + UppercaseUCircumflex.Width +
				RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				RenderConstants.Font.CharacterHeight * 5,
				7,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle UppercaseUDiaerisis = new Rectangle(
				LowercaseUDiaerisis.X + LowercaseUDiaerisis.Width +
				RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				RenderConstants.Font.CharacterHeight * 5,
				7,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle LowercaseYDiaerisis = new Rectangle(
				UppercaseUDiaerisis.X + UppercaseUDiaerisis.Width +
				RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				RenderConstants.Font.CharacterHeight * 5,
				7,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle UppercaseYDiaerisis = new Rectangle(
				LowercaseYDiaerisis.X + LowercaseYDiaerisis.Width +
				RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				RenderConstants.Font.CharacterHeight * 5,
				7,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle Eszett = new Rectangle(
				UppercaseYDiaerisis.X + UppercaseYDiaerisis.Width +
				RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				RenderConstants.Font.CharacterHeight * 5,
				7,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle LowercaseNTilde = new Rectangle(
				Eszett.X + Eszett.Width + RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				RenderConstants.Font.CharacterHeight * 5,
				7,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle UppercaseNTilde = new Rectangle(
				LowercaseNTilde.X + LowercaseNTilde.Width + RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				RenderConstants.Font.CharacterHeight * 5,
				7,
				RenderConstants.Font.CharacterHeight);

			public static Rectangle InvertedQuestionMark = new Rectangle(
				UppercaseNTilde.X + UppercaseNTilde.Width + RenderConstants.Font.SpaceBetweenCharactersOnTileset,
				RenderConstants.Font.CharacterHeight * 5,
				6,
				RenderConstants.Font.CharacterHeight);
		}

		/// <summary>
		/// Static <see cref="Microsoft.Xna.Framework.Color"/> values
		/// </summary>
		public class Color
		{
			public class Shader
			{
				public static Microsoft.Xna.Framework.Color SHADOW = new Microsoft.Xna.Framework.Color(0, 0, 0, 100);

				public static Microsoft.Xna.Framework.Color SHADOWED = new Microsoft.Xna.Framework.Color(50, 50, 50);
			}

			public class Solid
			{
				public static Microsoft.Xna.Framework.Color BACKGROUND = Microsoft.Xna.Framework.Color.Black;

				public static Microsoft.Xna.Framework.Color DISABLED = new Microsoft.Xna.Framework.Color(50, 50, 50);

				public static Microsoft.Xna.Framework.Color HOVER_ACCENT =
					new Microsoft.Xna.Framework.Color(255, 217, 104);

				public static Microsoft.Xna.Framework.Color MARGIN = new Microsoft.Xna.Framework.Color(5, 3, 4);
			}
		}

		/// <summary>
		/// Bounds for <see cref="Entities.Cue"/>
		/// </summary>
		public class Cue
		{
			public static Rectangle ABIGAIL = new Rectangle(RenderConstants.TileSize * 8, RenderConstants.TileSize * 11,
				RenderConstants.TileSize * 8, RenderConstants.TileSize);

			public static Rectangle BASIC = new Rectangle(RenderConstants.TileSize * 8, RenderConstants.TileSize * 8,
				RenderConstants.TileSize * 8, RenderConstants.TileSize);

			public static Rectangle GUS = new Rectangle(RenderConstants.TileSize * 8, RenderConstants.TileSize * 12,
				RenderConstants.TileSize * 8, RenderConstants.TileSize);

			public static Rectangle SAM = new Rectangle(RenderConstants.TileSize * 8, RenderConstants.TileSize * 9,
				RenderConstants.TileSize * 8, RenderConstants.TileSize);

			public static Rectangle SEBASTIAN = new Rectangle(RenderConstants.TileSize * 8,
				RenderConstants.TileSize * 10, RenderConstants.TileSize * 8, RenderConstants.TileSize);
		}

		/// <summary>
		/// Bounds for <see cref="Entities.Cursor"/>
		/// </summary>
		public class Cursor
		{
			public static Rectangle DEFAULT = new Rectangle(RenderConstants.TileSize * 23, RenderConstants.TileSize * 8,
				RenderConstants.TileSize, RenderConstants.TileSize);

			public static Rectangle FRAME_1 = new Rectangle(RenderConstants.TileSize * 20, RenderConstants.TileSize * 8,
				RenderConstants.TileSize, RenderConstants.TileSize);

			public static Rectangle FRAME_2 = new Rectangle(RenderConstants.TileSize * 21, RenderConstants.TileSize * 8,
				RenderConstants.TileSize, RenderConstants.TileSize);

			public static Rectangle FRAME_3 = new Rectangle(RenderConstants.TileSize * 22, RenderConstants.TileSize * 8,
				RenderConstants.TileSize, RenderConstants.TileSize);
		}

		public class Particle
		{
			public class Glimmer
			{
				public static Rectangle FRAME_1 = new Rectangle(RenderConstants.TileSize * 20,
					RenderConstants.TileSize * 11, RenderConstants.TileSize, RenderConstants.TileSize);

				public static Rectangle FRAME_2 = new Rectangle(RenderConstants.TileSize * 21,
					RenderConstants.TileSize * 11, RenderConstants.TileSize, RenderConstants.TileSize);
			}

			public class PurpleWhisp
			{
				public static Rectangle FRAME_1 = new Rectangle(RenderConstants.TileSize * 22,
					RenderConstants.TileSize * 12, RenderConstants.TileSize, RenderConstants.TileSize);

				public static Rectangle FRAME_2 = new Rectangle(RenderConstants.TileSize * 23,
					RenderConstants.TileSize * 12, RenderConstants.TileSize, RenderConstants.TileSize);

				public static Rectangle FRAME_3 = new Rectangle(RenderConstants.TileSize * 24,
					RenderConstants.TileSize * 12, RenderConstants.TileSize, RenderConstants.TileSize);
			}

			public class Spark
			{
				public static Rectangle FRAME_1 = new Rectangle(RenderConstants.TileSize * 19,
					RenderConstants.TileSize * 12, RenderConstants.TileSize, RenderConstants.TileSize);

				public static Rectangle FRAME_2 = new Rectangle(RenderConstants.TileSize * 20,
					RenderConstants.TileSize * 12, RenderConstants.TileSize, RenderConstants.TileSize);

				public static Rectangle FRAME_3 = new Rectangle(RenderConstants.TileSize * 21,
					RenderConstants.TileSize * 12, RenderConstants.TileSize, RenderConstants.TileSize);
			}

			public class Sparkle
			{
				public static Rectangle FRAME_1 = new Rectangle(RenderConstants.TileSize * 16,
					RenderConstants.TileSize * 12, RenderConstants.TileSize, RenderConstants.TileSize);

				public static Rectangle FRAME_2 = new Rectangle(RenderConstants.TileSize * 17,
					RenderConstants.TileSize * 12, RenderConstants.TileSize, RenderConstants.TileSize);

				public static Rectangle FRAME_3 = new Rectangle(RenderConstants.TileSize * 18,
					RenderConstants.TileSize * 12, RenderConstants.TileSize, RenderConstants.TileSize);
			}
		}

		public class PocketedBalls
		{
			public static Rectangle BORDER_BOX = new Rectangle(RenderConstants.TileSize * 12,
				RenderConstants.TileSize * 21, RenderConstants.TileSize * 7, RenderConstants.TileSize * 2);

			public static Rectangle SUPPORTS = new Rectangle(RenderConstants.TileSize * 24,
				RenderConstants.TileSize * 8, RenderConstants.TileSize, RenderConstants.TileSize);
		}

		/// <summary>
		/// Bounds for all <see cref="Entities.Portrait"/> characters and emotions
		/// </summary>
		public class Portrait
		{
			public class Abigail
			{
				public static Rectangle BLUSH = new Rectangle(0, RenderConstants.TileSize * 8,
					RenderConstants.TileSize * 4, RenderConstants.TileSize * 4);

				public static Rectangle CONFUSED = new Rectangle(RenderConstants.TileSize * 4,
					RenderConstants.TileSize * 4, RenderConstants.TileSize * 4, RenderConstants.TileSize * 4);

				public static Rectangle DEFAULT =
					new Rectangle(0, 0, RenderConstants.TileSize * 4, RenderConstants.TileSize * 4);

				public static Rectangle GLARE = new Rectangle(RenderConstants.TileSize * 4,
					RenderConstants.TileSize * 8, RenderConstants.TileSize * 4, RenderConstants.TileSize * 4);

				public static Rectangle LAUGH = new Rectangle(RenderConstants.TileSize * 4, 0,
					RenderConstants.TileSize * 4, RenderConstants.TileSize * 4);

				public static Rectangle SAD = new Rectangle(0, RenderConstants.TileSize * 4,
					RenderConstants.TileSize * 4, RenderConstants.TileSize * 4);

				public static Rectangle SUPRISED = new Rectangle(RenderConstants.TileSize * 4,
					RenderConstants.TileSize * 12, RenderConstants.TileSize * 4, RenderConstants.TileSize * 4);
			}

			public class Gus
			{
				public static Rectangle BLUSH = new Rectangle(0, RenderConstants.TileSize * 4,
					RenderConstants.TileSize * 4, RenderConstants.TileSize * 4);

				public static Rectangle DEFAULT =
					new Rectangle(0, 0, RenderConstants.TileSize * 4, RenderConstants.TileSize * 4);

				public static Rectangle GLARE = new Rectangle(RenderConstants.TileSize * 4,
					RenderConstants.TileSize * 4, RenderConstants.TileSize * 4, RenderConstants.TileSize * 4);

				public static Rectangle LAUGH = new Rectangle(RenderConstants.TileSize * 4, 0,
					RenderConstants.TileSize * 4, RenderConstants.TileSize * 4);
			}

			public class Sam
			{
				public static Rectangle DEFAULT =
					new Rectangle(0, 0, RenderConstants.TileSize * 4, RenderConstants.TileSize * 4);

				public static Rectangle EMBARASSED = new Rectangle(0, RenderConstants.TileSize * 20,
					RenderConstants.TileSize * 4, RenderConstants.TileSize * 4);

				public static Rectangle FRUSTRATED = new Rectangle(RenderConstants.TileSize * 4,
					RenderConstants.TileSize * 4, RenderConstants.TileSize * 4, RenderConstants.TileSize * 4);

				public static Rectangle GLARE = new Rectangle(RenderConstants.TileSize * 4,
					RenderConstants.TileSize * 8, RenderConstants.TileSize * 4, RenderConstants.TileSize * 4);

				public static Rectangle LAUGH = new Rectangle(RenderConstants.TileSize * 4, 0,
					RenderConstants.TileSize * 4, RenderConstants.TileSize * 4);

				public static Rectangle OOPS = new Rectangle(0, RenderConstants.TileSize * 8,
					RenderConstants.TileSize * 4, RenderConstants.TileSize * 4);

				public static Rectangle SAD = new Rectangle(0, RenderConstants.TileSize * 4,
					RenderConstants.TileSize * 4, RenderConstants.TileSize * 4);

				public static Rectangle SHOCK = new Rectangle(0, RenderConstants.TileSize * 16,
					RenderConstants.TileSize * 4, RenderConstants.TileSize * 4);

				public static Rectangle STRAIGHT_FACE = new Rectangle(RenderConstants.TileSize * 4,
					RenderConstants.TileSize * 12, RenderConstants.TileSize * 4, RenderConstants.TileSize * 4);
			}

			public class Sebastian
			{
				public static Rectangle BLUSH = new Rectangle(0, RenderConstants.TileSize * 8,
					RenderConstants.TileSize * 4, RenderConstants.TileSize * 4);

				public static Rectangle DEFAULT =
					new Rectangle(0, 0, RenderConstants.TileSize * 4, RenderConstants.TileSize * 4);

				public static Rectangle GLAD = new Rectangle(RenderConstants.TileSize * 4, 0,
					RenderConstants.TileSize * 4, RenderConstants.TileSize * 4);

				public static Rectangle GLARE = new Rectangle(RenderConstants.TileSize * 4,
					RenderConstants.TileSize * 8, RenderConstants.TileSize * 4, RenderConstants.TileSize * 4);

				public static Rectangle SAD = new Rectangle(RenderConstants.TileSize * 4, RenderConstants.TileSize * 4,
					RenderConstants.TileSize * 4, RenderConstants.TileSize * 4);

				public static Rectangle SMURK = new Rectangle(RenderConstants.TileSize * 4,
					RenderConstants.TileSize * 12, RenderConstants.TileSize * 4, RenderConstants.TileSize * 4);
			}
		}

		/// <summary>
		/// Bounds for <see cref="Entities.PortraitFire"/>
		/// </summary>
		public class PortraitFire
		{
			public static Rectangle FRAME_1 = new Rectangle(RenderConstants.TileSize * 12,
				RenderConstants.TileSize * 17, RenderConstants.TileSize * 4, RenderConstants.TileSize * 4);

			public static Rectangle FRAME_2 = new Rectangle(RenderConstants.TileSize * 16,
				RenderConstants.TileSize * 17, RenderConstants.TileSize * 4, RenderConstants.TileSize * 4);

			public static Rectangle FRAME_3 = new Rectangle(RenderConstants.TileSize * 20,
				RenderConstants.TileSize * 17, RenderConstants.TileSize * 4, RenderConstants.TileSize * 4);

			public static Rectangle FRAME_4 = new Rectangle(RenderConstants.TileSize * 24,
				RenderConstants.TileSize * 17, RenderConstants.TileSize * 4, RenderConstants.TileSize * 4);

			public static Rectangle FRAME_5 = new Rectangle(RenderConstants.TileSize * 28,
				RenderConstants.TileSize * 17, RenderConstants.TileSize * 4, RenderConstants.TileSize * 4);

			public static Rectangle FRAME_6 = new Rectangle(0, RenderConstants.TileSize * 21,
				RenderConstants.TileSize * 4, RenderConstants.TileSize * 4);

			public static Rectangle FRAME_7 = new Rectangle(RenderConstants.TileSize * 4, RenderConstants.TileSize * 21,
				RenderConstants.TileSize * 4, RenderConstants.TileSize * 4);

			public static Rectangle FRAME_8 = new Rectangle(RenderConstants.TileSize * 8, RenderConstants.TileSize * 21,
				RenderConstants.TileSize * 4, RenderConstants.TileSize * 4);
		}

		/// <summary>
		/// Bounds for all <see cref="Entities.TableSegment"/> pieces
		/// </summary>
		public class Table
		{
			public static Rectangle FELT = new Rectangle(RenderConstants.TileSize * 22, RenderConstants.TileSize * 11,
				RenderConstants.TileSize, RenderConstants.TileSize);

			public class Corner
			{
				public class Back
				{
					public static Rectangle NORTH_EAST = new Rectangle(0, RenderConstants.TileSize * 19,
						RenderConstants.TileSize * 2, RenderConstants.TileSize * 2);

					public static Rectangle NORTH_WEST = new Rectangle(RenderConstants.TileSize * 4,
						RenderConstants.TileSize * 19, RenderConstants.TileSize * 2, RenderConstants.TileSize * 2);

					public static Rectangle SOUTH_EAST = new Rectangle(0, RenderConstants.TileSize * 17,
						RenderConstants.TileSize * 2, RenderConstants.TileSize * 2);

					public static Rectangle SOUTH_WEST = new Rectangle(RenderConstants.TileSize * 4,
						RenderConstants.TileSize * 17, RenderConstants.TileSize * 2, RenderConstants.TileSize * 2);
				}

				public class Front
				{
					public static Rectangle NORTH_EAST = new Rectangle(RenderConstants.TileSize * 2,
						RenderConstants.TileSize * 19, RenderConstants.TileSize * 2, RenderConstants.TileSize * 2);

					public static Rectangle NORTH_WEST = new Rectangle(RenderConstants.TileSize * 6,
						RenderConstants.TileSize * 19, RenderConstants.TileSize * 2, RenderConstants.TileSize * 2);

					public static Rectangle SOUTH_EAST = new Rectangle(RenderConstants.TileSize * 2,
						RenderConstants.TileSize * 17, RenderConstants.TileSize * 2, RenderConstants.TileSize * 2);

					public static Rectangle SOUTH_WEST = new Rectangle(RenderConstants.TileSize * 6,
						RenderConstants.TileSize * 17, RenderConstants.TileSize * 2, RenderConstants.TileSize * 2);
				}
			}

			public class Edge
			{
				public class Back
				{
					public static Rectangle EAST = new Rectangle(RenderConstants.TileSize * 4,
						RenderConstants.TileSize * 13, RenderConstants.TileSize * 2, RenderConstants.TileSize * 2);

					public static Rectangle NORTH = new Rectangle(0, RenderConstants.TileSize * 13,
						RenderConstants.TileSize * 2, RenderConstants.TileSize * 2);

					public static Rectangle NORTH_EAST = new Rectangle(RenderConstants.TileSize * 28,
						RenderConstants.TileSize * 13, RenderConstants.TileSize * 2, RenderConstants.TileSize * 2);

					public static Rectangle NORTH_WEST = new Rectangle(RenderConstants.TileSize * 24,
						RenderConstants.TileSize * 13, RenderConstants.TileSize * 2, RenderConstants.TileSize * 2);

					public static Rectangle SOUTH = new Rectangle(0, RenderConstants.TileSize * 15,
						RenderConstants.TileSize * 2, RenderConstants.TileSize * 2);

					public static Rectangle SOUTH_EAST = new Rectangle(RenderConstants.TileSize * 28,
						RenderConstants.TileSize * 15, RenderConstants.TileSize * 2, RenderConstants.TileSize * 2);

					public static Rectangle SOUTH_WEST = new Rectangle(RenderConstants.TileSize * 24,
						RenderConstants.TileSize * 15, RenderConstants.TileSize * 2, RenderConstants.TileSize * 2);

					public static Rectangle WEST = new Rectangle(RenderConstants.TileSize * 4,
						RenderConstants.TileSize * 15, RenderConstants.TileSize * 2, RenderConstants.TileSize * 2);
				}

				public class Front
				{
					public static Rectangle EAST = new Rectangle(RenderConstants.TileSize * 6,
						RenderConstants.TileSize * 13, RenderConstants.TileSize * 2, RenderConstants.TileSize * 2);

					public static Rectangle NORTH = new Rectangle(RenderConstants.TileSize * 2,
						RenderConstants.TileSize * 13, RenderConstants.TileSize * 2, RenderConstants.TileSize * 2);

					public static Rectangle NORTH_EAST = new Rectangle(RenderConstants.TileSize * 30,
						RenderConstants.TileSize * 13, RenderConstants.TileSize * 2, RenderConstants.TileSize * 2);

					public static Rectangle NORTH_WEST = new Rectangle(RenderConstants.TileSize * 26,
						RenderConstants.TileSize * 13, RenderConstants.TileSize * 2, RenderConstants.TileSize * 2);

					public static Rectangle SOUTH = new Rectangle(RenderConstants.TileSize * 2,
						RenderConstants.TileSize * 15, RenderConstants.TileSize * 2, RenderConstants.TileSize * 2);

					public static Rectangle SOUTH_EAST = new Rectangle(RenderConstants.TileSize * 30,
						RenderConstants.TileSize * 15, RenderConstants.TileSize * 2, RenderConstants.TileSize * 2);

					public static Rectangle SOUTH_WEST = new Rectangle(RenderConstants.TileSize * 26,
						RenderConstants.TileSize * 15, RenderConstants.TileSize * 2, RenderConstants.TileSize * 2);

					public static Rectangle WEST = new Rectangle(RenderConstants.TileSize * 6,
						RenderConstants.TileSize * 15, RenderConstants.TileSize * 2, RenderConstants.TileSize * 2);
				}
			}

			public class Pocket
			{
				public class Back
				{
					public static Rectangle EAST = new Rectangle(RenderConstants.TileSize * 20,
						RenderConstants.TileSize * 13, RenderConstants.TileSize * 2, RenderConstants.TileSize * 2);

					public static Rectangle NORTH = new Rectangle(RenderConstants.TileSize * 16,
						RenderConstants.TileSize * 13, RenderConstants.TileSize * 2, RenderConstants.TileSize * 2);

					public static Rectangle NORTH_EAST = new Rectangle(RenderConstants.TileSize * 12,
						RenderConstants.TileSize * 13, RenderConstants.TileSize * 2, RenderConstants.TileSize * 2);

					public static Rectangle NORTH_WEST = new Rectangle(RenderConstants.TileSize * 8,
						RenderConstants.TileSize * 13, RenderConstants.TileSize * 2, RenderConstants.TileSize * 2);

					public static Rectangle SOUTH = new Rectangle(RenderConstants.TileSize * 16,
						RenderConstants.TileSize * 15, RenderConstants.TileSize * 2, RenderConstants.TileSize * 2);

					public static Rectangle SOUTH_EAST = new Rectangle(RenderConstants.TileSize * 12,
						RenderConstants.TileSize * 15, RenderConstants.TileSize * 2, RenderConstants.TileSize * 2);

					public static Rectangle SOUTH_WEST = new Rectangle(RenderConstants.TileSize * 8,
						RenderConstants.TileSize * 15, RenderConstants.TileSize * 2, RenderConstants.TileSize * 2);

					public static Rectangle WEST = new Rectangle(RenderConstants.TileSize * 20,
						RenderConstants.TileSize * 15, RenderConstants.TileSize * 2, RenderConstants.TileSize * 2);
				}

				public class Front
				{
					public static Rectangle EAST = new Rectangle(RenderConstants.TileSize * 22,
						RenderConstants.TileSize * 13, RenderConstants.TileSize * 2, RenderConstants.TileSize * 2);

					public static Rectangle NORTH = new Rectangle(RenderConstants.TileSize * 18,
						RenderConstants.TileSize * 13, RenderConstants.TileSize * 2, RenderConstants.TileSize * 2);

					public static Rectangle NORTH_EAST = new Rectangle(RenderConstants.TileSize * 14,
						RenderConstants.TileSize * 13, RenderConstants.TileSize * 2, RenderConstants.TileSize * 2);

					public static Rectangle NORTH_WEST = new Rectangle(RenderConstants.TileSize * 10,
						RenderConstants.TileSize * 13, RenderConstants.TileSize * 2, RenderConstants.TileSize * 2);

					public static Rectangle SOUTH = new Rectangle(RenderConstants.TileSize * 18,
						RenderConstants.TileSize * 15, RenderConstants.TileSize * 2, RenderConstants.TileSize * 2);

					public static Rectangle SOUTH_EAST = new Rectangle(RenderConstants.TileSize * 14,
						RenderConstants.TileSize * 15, RenderConstants.TileSize * 2, RenderConstants.TileSize * 2);

					public static Rectangle SOUTH_WEST = new Rectangle(RenderConstants.TileSize * 10,
						RenderConstants.TileSize * 15, RenderConstants.TileSize * 2, RenderConstants.TileSize * 2);

					public static Rectangle WEST = new Rectangle(RenderConstants.TileSize * 22,
						RenderConstants.TileSize * 15, RenderConstants.TileSize * 2, RenderConstants.TileSize * 2);
				}
			}
		}

		/// <summary>
		/// <see cref="Texture2D"/> tileset references
		/// </summary>
		public class Tileset
		{
			public static Texture2D Default;

			public static Texture2D Font;

			public static Texture2D PortraitAbigail;

			public static Texture2D PortraitGus;

			public static Texture2D PortraitSam;

			public static Texture2D PortraitSebastian;
		}
	}
}