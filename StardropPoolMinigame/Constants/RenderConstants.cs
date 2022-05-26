using Microsoft.Xna.Framework;
using StardewValley;

namespace StardropPoolMinigame.Constants
{
	internal class RenderConstants
	{
		/// <summary>Tile size on tile sheet.</summary>
		public static int TileSize = 16;

		/// <summary>
		/// Converts <see cref="Vector2"/> coordinates relative to <see cref="AdjustedScreen"/>, to
		/// <see cref="Vector2"/> relative to <see cref="Viewport"/>.
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
		/// Converts <see cref="Vector2"/> coordinates relative to <see cref="Viewport"/>, to <see cref="Vector2"/>
		/// relative to <see cref="AdjustedScreen"/>.
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

		/// <summary>Stardew Valley zoom settings.</summary>
		public static float PixelZoomAdjustement()
		{
			return 1f / Game1.options.zoomLevel;
		}

		/// <summary>Tile size and pixel zoom adjustment.</summary>
		/// <returns>Multiplier value</returns>
		public static float TileScale()
		{
			return 4 * PixelZoomAdjustement();
		}

		/// <summary>Dimensions of the minigame window adjusted with zoom settings and tile scale.</summary>
		public class AdjustedScreen
		{
			/// <summary>Gets center of minigame window adjusted with zoom settings and tile scale.</summary>
			public static Vector2 GetCenter()
			{
				return Vector2.Divide(new Vector2(Width(), Height()), 2);
			}

			/// <summary>Gets top-right of minigame window adjusted with zoom settings and tile scale.</summary>
			public static Vector2 GetNorthEast()
			{
				return new Vector2(Viewport.Width() - Margin.Width(), Margin.Height());
			}

			/// <summary>Gets top-left of minigame window adjusted with zoom settings and tile scale.</summary>
			public static Vector2 GetNorthWest()
			{
				return new Vector2(Margin.Width(), Margin.Height());
			}

			/// <summary>Gets bottom-right of minigame window adjusted with zoom settings and tile scale.</summary>
			public static Vector2 GetSouthEast()
			{
				return new Vector2(Viewport.Width() - Margin.Width(), Viewport.Height() - Margin.Height());
			}

			/// <summary>Gets bottom-left of minigame window adjusted with zoom settings and tile scale.</summary>
			public static Vector2 GetSouthWest()
			{
				return new Vector2(Margin.Width(), Viewport.Height() - Margin.Height());
			}

			/// <summary>The height of the minigame window adjusted with zoom settings and tile scale.</summary>
			public static float Height()
			{
				return MinigameScreen.Height * TileScale();
			}

			/// <summary>The width of the minigame window adjusted with zoom settings and tile scale.</summary>
			public static float Width()
			{
				return MinigameScreen.Width * TileScale();
			}

			/// <summary>Difference between the <see cref="Viewport"/> and <see cref="AdjustedScreen"/>.</summary>
			public class Difference
			{
				/// <summary>Difference in height between the <see cref="Viewport"/> and <see cref="AdjustedScreen"/>.</summary>
				public static float Height()
				{
					return Viewport.Height() - AdjustedScreen.Height();
				}

				/// <summary>Difference in width between the <see cref="Viewport"/> and <see cref="AdjustedScreen"/>.</summary>
				public static float Width()
				{
					return Viewport.Width() - AdjustedScreen.Width();
				}
			}

			/// <summary>Space between <see cref="Viewport"/> and <see cref="AdjustedScreen"/>.</summary>
			public class Margin
			{
				/// <summary>Space between top of <see cref="Viewport"/> and top of <see cref="AdjustedScreen"/>.</summary>
				public static float Height()
				{
					return Difference.Height() / 2;
				}

				/// <summary>Space between left of <see cref="Viewport"/> and left of <see cref="AdjustedScreen"/>.</summary>
				public static float Width()
				{
					return Difference.Width() / 2;
				}
			}
		}

		/// <summary><see cref="Entities.IEntity"/> related render constants</summary>
		public class Entities
		{
			/// <summary><see cref="Entities.Ball"/> related render constants</summary>
			public class Ball
			{
				public static float MarginLeft = 3f;

				public static float MarginTop = 2f;
			}

			/// <summary><see cref="Entities.BallButton"/> related render constants</summary>
			public class BallButton
			{
				public static float InnerPadding = 8f;

				public static float LeftOffset = 4f;
			}

			/// <summary><see cref="Entities.Particle"/> related render constants</summary>
			public class Particle
			{
				public class Spark
				{
					public static int FrameDuration = 4;

					public static int Frames = 3;

					public static float MarginLeft = 3f;

					public static float MarginTop = 3f;
				}
			}

			/// <summary><see cref="Entities.PocketedBalls"/> related render constants</summary>
			public class PocketedBalls
			{
				public static int Padding = 4;

				public static int SupportPadding = 5;

				public static float SupportUpperMargin = -3f;
			}

			/// <summary><see cref="Entities.PortraitFire"/> related render constants</summary>
			public class PortraitFire
			{
				public static int FrameDuration = 4;

				public static int Frames = 8;
			}

			/// <summary><see cref="Entities.TableSegment"/> related render constants</summary>
			public class TableSegment
			{
				public static int AngledPocketBareEdgeLength = 6;

				public static int AngledPocketBorderOffset = 3;

				public static int Border = 10;

				public static int FlatPocketBareEdgeLength = 3;

				public static int FlatPocketBorderOffset = -2;

				public static int Lip = 5;

				public static int Margin = 3;

				public static int PassableLip = 2;

				public static int PocketAngledEdgeHeight = 3;

				public static int PocketRadius = 7;

				public static int UnpassableLip = 3;

				public static int SpaceToBounceableSurface = Margin + Border + UnpassableLip;

				public static int VerticalPocketStraightEdgeHeight = 2;
			}
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

		/// <summary>Dimensions of the minigame window.</summary>
		public class MinigameScreen
		{
			/// <summary>The height of the minigame window.</summary>
			public static int Height = 224;

			/// <summary>The width of the minigame window.</summary>
			public static int Width = 400;
		}

		/// <summary>IScene related render constants</summary>
		public class Scenes
		{
			/// <summary>CharacterSelectScene related render constants</summary>
			public class CharacterSelect
			{
				public class Cursor
				{
					public static float BottomMargin = 18f;
				}

				public class SelectedName
				{
					public static float TopMargin = 18f;
				}
			}

			/// <summary>DialogScene related render constants</summary>
			public class Dialog
			{
				public class Text
				{
					public static int MaxWidth = 150;

					public static int TopMargin = 15;
				}
			}

			/// <summary>GameScene related render constants</summary>
			public class Game
			{
				public class LayerDepth
				{
					public static float Ball = 0.0040f;

					public static float FadeIn = 0.9000f;

					public static float FloorTiles = 0.0005f;

					public static float PocketedBalls = 0.0020f;

					public static float Portrait = 0.0050f;

					public static float Table = 0.0030f;

					public static float TableFront = 0.0060f;
				}
			}

			/// <summary>General IScene related render constants</summary>
			public class General
			{
				public class LayerDepth
				{
					public static float Popup = 0.9000f;

					public static float QuadTree = 0.9000f;
				}
			}

			/// <summary>MainMenuScene related render constants</summary>
			public class MainMenu
			{
				public class BallButton
				{
					public static float ButtonMargin = 4f;
				}

				public class GameTitle
				{
					public static float TopMargin = 6f;
				}
			}
		}

		/// <summary>Dimensions of the Stardew Valley window.</summary>
		public class Viewport
		{
			/// <summary>Gets center of the Stardew Valley window.</summary>
			public static Vector2 GetCenter()
			{
				return Vector2.Divide(new Vector2(Width(), Height()), 2);
			}

			/// <summary>The height of the Stardew Valley window.</summary>
			public static int Height()
			{
				return Game1.game1.localMultiplayerWindow.Height;
			}

			/// <summary>The width of the Stardew Valley window.</summary>
			public static int Width()
			{
				return Game1.game1.localMultiplayerWindow.Width;
			}
		}
	}
}