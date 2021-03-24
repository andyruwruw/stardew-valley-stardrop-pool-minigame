using Microsoft.Xna.Framework;
using StardewValley;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StardropPoolMinigame
{
    public class DrawMath
    {
        public static int ScreenWidth = 800;

        public static int ScreenHeight = 544;

        public static float PixelZoomAdjustement = 1f;

        public static float AdjustedScreenWidth = 800;
        
        public static float AdjustedScreenHeight = 544;

        public static int ViewportWidth = 0;

        public static int ViewportHeight = 0;

        public static void ChangeScreenSize()
        {
            DrawMath.PixelZoomAdjustement = 1f / Game1.options.zoomLevel;

            DrawMath.AdjustedScreenWidth = DrawMath.ScreenWidth * DrawMath.PixelZoomAdjustement;
            DrawMath.AdjustedScreenHeight = DrawMath.ScreenHeight * DrawMath.PixelZoomAdjustement;

            DrawMath.ViewportWidth = Game1.game1.localMultiplayerWindow.Width;
            DrawMath.ViewportHeight = Game1.game1.localMultiplayerWindow.Height;
        }

        public static Vector2 GetNorthWestGameDisplay()
        {
            return new Vector2((DrawMath.ViewportWidth - DrawMath.AdjustedScreenWidth) / 2, (DrawMath.ViewportHeight - DrawMath.AdjustedScreenHeight) / 2);
        }

        public static Vector2 GetNorthEastGameDisplay()
        {
            return new Vector2((DrawMath.ViewportWidth - ((DrawMath.ViewportWidth - DrawMath.AdjustedScreenWidth) / 2)), (DrawMath.ViewportHeight - DrawMath.AdjustedScreenHeight) / 2);
        }

        public static Vector2 GetSouthWestGameDisplay()
        {
            return new Vector2((DrawMath.ViewportWidth - DrawMath.AdjustedScreenWidth) / 2, DrawMath.ViewportHeight - ((DrawMath.ViewportHeight - DrawMath.AdjustedScreenHeight) / 2));
        }

        public static Vector2 GetSouthEastGameDisplay()
        {
            return new Vector2((DrawMath.ViewportWidth - ((DrawMath.ViewportWidth - DrawMath.AdjustedScreenWidth) / 2)), DrawMath.ViewportHeight - ((DrawMath.ViewportHeight - DrawMath.AdjustedScreenHeight) / 2));
        }

        public static Vector2 GetCenterOfScreen()
        {
            return new Vector2((DrawMath.ViewportWidth / 2), (DrawMath.ViewportHeight / 2));
        }

        public static Vector2 RelativeToGameDisplay(Vector2 point)
        {
            Vector2 northWest = DrawMath.GetNorthWestGameDisplay();
            return new Vector2(point.X - northWest.X, point.Y - northWest.Y);
        }

        public static Vector2 RelativeToOuterTable(Vector2 point)
        {
            // Incorrect
            return new Vector2((DrawMath.ViewportWidth / 2), (DrawMath.ViewportHeight / 2));
        }
    }
}
