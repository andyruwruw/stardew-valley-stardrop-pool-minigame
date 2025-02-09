using StardewValley;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static MinigameFramework.Constants.GenericRenderConstants;
using MinigameFramework.Attributes;

namespace MinigameFramework.Helpers
{
    /// <summary>
    /// Various functions for aid in rendering.
    /// </summary>
    static class RenderHelpers
    {
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
                    TileScale()
                ),
                AdjustedScreen.GetNorthWest()
            );
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
                    AdjustedScreen.GetNorthWest()
                ),
                TileScale()
            );
        }

        /// <summary>Dimensions of the Stardew Valley window.</summary>
		public class Viewport
        {
            /// <summary>Gets center of the Stardew Valley window.</summary>
            public static Vector2 GetCenter()
            {
                return Vector2.Divide(
                    new Vector2(
                        Width(),
                        Height()
                    ),
                    2
                );
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

        /// <summary>Dimensions of the minigame window adjusted with zoom settings and tile scale.</summary>
		public class AdjustedScreen
        {
            /// <summary>Gets center of minigame window adjusted with zoom settings and tile scale.</summary>
            public static Vector2 GetCenter()
            {
                return Vector2.Divide(
                    new Vector2(
                        Width(),
                        Height()
                    ),
                    2
                );
            }

            /// <summary>Gets top-right of minigame window adjusted with zoom settings and tile scale.</summary>
            public static Vector2 GetNorthEast()
            {
                return new Vector2(
                    Viewport.Width() - Margin.Width(),
                    Margin.Height()
                );
            }

            /// <summary>Gets top-left of minigame window adjusted with zoom settings and tile scale.</summary>
            public static Vector2 GetNorthWest()
            {
                return new Vector2(
                    Margin.Width(),
                    Margin.Height()
                );
            }

            /// <summary>Gets bottom-right of minigame window adjusted with zoom settings and tile scale.</summary>
            public static Vector2 GetSouthEast()
            {
                return new Vector2(
                    Viewport.Width() - Margin.Width(),
                    Viewport.Height() - Margin.Height()
                );
            }

            /// <summary>Gets bottom-left of minigame window adjusted with zoom settings and tile scale.</summary>
            public static Vector2 GetSouthWest()
            {
                return new Vector2(
                    Margin.Width(),
                    Viewport.Height() - Margin.Height()
                );
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

        /// <summary>
        /// Draws a debug point at a given point.
        /// </summary>
        /// <param name="batch">Sprite batch to draw to.</param>
        /// <param name="point">Where to draw the point.</param>
        /// <param name="color">Color of the point.</param>
        /// <param name="size">Size of the point.</param>
        /// <param name="isRaw">Whether point coordinates are raw coordinates.</param>
        public static void DrawDebugPoint(
            SpriteBatch batch,
            Vector2 point,
            Color? color = null,
            int size = 4,
            bool isRaw = false
        ) {
            Color resolvedColor = color == null ? Color.GreenYellow : (Color)color;
            Vector2 resolvedPoint = isRaw ? RenderHelpers.ConvertAdjustedScreenToRaw(point) : point;

            batch.Draw(
                Game1.staminaRect,
                new Rectangle(
                    (int)Math.Round(resolvedPoint.X - (size / 2)),
                    (int)Math.Round(resolvedPoint.Y - (size / 2)),
                    size,
                    size
                ),
                Game1.staminaRect.Bounds,
                resolvedColor,
                0f,
                Vector2.Zero,
                SpriteEffects.None,
                0.90000f
            );
        }

        /// <summary>
        /// Draws a debug circle at a given point.
        /// </summary>
        /// <param name="batch">Sprite batch to draw to.</param>
        /// <param name="center">Where to draw the circle.</param>
        /// <param name="radius">Radius of the circle.</param>
        /// <param name="color">Color of the circle.</param>
        /// <param name="size">Width of the outline.</param>
        /// <param name="isRaw">Whether point coordinates are raw coordinates.</param>
        public static void DrawDebugCircle(
            SpriteBatch batch,
            Vector2 center,
            float radius = 4,
            Color? color = null,
            int size = 4,
            bool isRaw = false
        ) {
            // It's made of lines, so we're just declaring no line will be longer than 3.
            int maxLineLength = 3;

            // How long the circle of lines need to be / segments we can break them into.
            float circumference = (float)(radius * 2 * Math.PI);
            int segments = (int)Math.Floor(circumference / maxLineLength);

            // Given the number of segments, the angle between them.
            float angle = (float)(2 * Math.PI) / segments;

            // We're going to start on the east side.
            Vector2 firstPoint = new Vector2(
                center.X + radius,
                center.Y
            );
            Vector2 previousPoint = firstPoint;

            // Go around the circle connecting points until you get to the last arc.
            for (int arc = 1; arc < segments; arc += 1)
            {
                Vector2 point = Vector2.Add(
                    center,
                    Vector2.Multiply(
                        Vector2.Normalize(VectorHelpers.RadiansToVector(angle * arc)),
                        radius
                    )
                );

                DrawDebugLine(
                    batch,
                    previousPoint,
                    point,
                    color,
                    size,
                    isRaw
                );

                previousPoint = point;
            }

            // Connect the last arc.
            DrawDebugLine(
                batch,
                previousPoint,
                firstPoint,
                color,
                size,
                isRaw
            );
        }

        /// <summary>
        /// Draws a debug line between a set of points.
        /// </summary>
        /// <param name="batch">Sprite batch to draw to.</param>
        /// <param name="start">Where to draw from.</param>
        /// <param name="end">Where to draw to.</param>
        /// <param name="color">Color of the line.</param>
        /// <param name="size">Width of the outline.</param>
        /// <param name="isRaw">Whether point coordinates are raw coordinates.</param>
        public static void DrawDebugLine(
            SpriteBatch batch,
            Vector2 start,
            Vector2 end,
            Color? color = null,
            int size = 4,
            bool isRaw = false
        ) {
            Color resolvedColor = color == null ? Color.GreenYellow : (Color)color;
            Vector2 resolvedStart = isRaw ? RenderHelpers.ConvertAdjustedScreenToRaw(start) : start;
            Vector2 resolvedEnd = isRaw ? RenderHelpers.ConvertAdjustedScreenToRaw(end) : end;

            Vector2 difference = Vector2.Subtract(
                resolvedEnd,
                resolvedStart
            );

            batch.Draw(
                Game1.staminaRect,
                new Rectangle(
                    (int)Math.Round(resolvedStart.X - (size / 2)),
                    (int)Math.Round(resolvedStart.Y - (size / 2)),
                    (int)Math.Round(DistanceHelpers.Pythagorean(
                        resolvedStart,
                        resolvedEnd
                    )),
                    size
                ),
                Game1.staminaRect.Bounds,
                resolvedColor,
                VectorHelpers.VectorToRadians(difference),
                Vector2.Zero,
                SpriteEffects.None,
                1f
            );
        }

        /// <summary>
        /// Draws various physical properties of an item.
        /// </summary>
        /// <param name="batch">Sprite batch to draw to.</param>
        /// <param name="entity">Physics to draw.</param>
        /// <param name="size">Size of the items to draw.</param>
        public static void DrawDebugPhysics(
            SpriteBatch batch,
            Physics entity,
            int size = 3
        ) {
            DrawDebugPoint(
                batch,
                entity.GetPosition(),
                Color.Purple,
                size
            );
            DrawDebugLine(
                batch,
                entity.GetPosition(),
                Vector2.Add(
                    entity.GetPosition(),
                    entity.GetVelocity()
                ),
                Color.LimeGreen,
                size
            );
            DrawDebugLine(
                batch,
                entity.GetPosition(),
                Vector2.Add(
                    entity.GetPosition(),
                    entity.GetAcceleration()
                ),
                Color.BlueViolet,
                size
            );
        }
    }
}
