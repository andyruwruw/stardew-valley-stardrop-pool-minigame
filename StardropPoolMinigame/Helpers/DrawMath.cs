using Microsoft.Xna.Framework;
using StardewValley;
using StardropPoolMinigame.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StardropPoolMinigame
{
    public class DrawMath
    {
        public static int ScreenWidth = 1000;

        public static int ScreenHeight = 800;

        public static float PixelZoomAdjustement = 1f;

        public static float AdjustedScreenWidth = 1000;
        
        public static float AdjustedScreenHeight = 800;

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
        public static Vector2 GetCenterOfScreen()
        {
            return new Vector2((DrawMath.ViewportWidth / 2), (DrawMath.ViewportHeight / 2));
        }

        public static Vector2 GetGameDisplayNorthWest()
        {
            return new Vector2((DrawMath.ViewportWidth - DrawMath.AdjustedScreenWidth) / 2, (DrawMath.ViewportHeight - DrawMath.AdjustedScreenHeight) / 2);
        }

        public static Vector2 GetGameDisplayNorthEast()
        {
            return new Vector2((DrawMath.ViewportWidth - ((DrawMath.ViewportWidth - DrawMath.AdjustedScreenWidth) / 2)), (DrawMath.ViewportHeight - DrawMath.AdjustedScreenHeight) / 2);
        }

        public static Vector2 GetGameDisplaySouthWest()
        {
            return new Vector2((DrawMath.ViewportWidth - DrawMath.AdjustedScreenWidth) / 2, DrawMath.ViewportHeight - ((DrawMath.ViewportHeight - DrawMath.AdjustedScreenHeight) / 2));
        }

        public static Vector2 GetGameDisplaySouthEast()
        {
            return new Vector2((DrawMath.ViewportWidth - ((DrawMath.ViewportWidth - DrawMath.AdjustedScreenWidth) / 2)), DrawMath.ViewportHeight - ((DrawMath.ViewportHeight - DrawMath.AdjustedScreenHeight) / 2));
        }

        public static Vector2 GetTableNorthWest()
        {
            return new Vector2((DrawMath.ViewportWidth - Table.Width) / 2, (DrawMath.ViewportHeight - Table.Height) / 2);
        }

        public static Vector2 GetTableNorthEast()
        {
            return new Vector2((DrawMath.ViewportWidth - ((DrawMath.ViewportWidth - Table.Width) / 2)), (DrawMath.ViewportHeight - Table.Height) / 2);
        }

        public static Vector2 GetTableSouthWest()
        {
            return new Vector2((DrawMath.ViewportWidth - Table.Width) / 2, DrawMath.ViewportHeight - ((DrawMath.ViewportHeight - Table.Height) / 2));
        }

        public static Vector2 GetTableSouthEast()
        {
            return new Vector2((DrawMath.ViewportWidth - ((DrawMath.ViewportWidth - Table.Width) / 2)), DrawMath.ViewportHeight - ((DrawMath.ViewportHeight - Table.Height) / 2));
        }

        public static Vector2 GetInnerTableNorthWest()
        {
            return new Vector2((DrawMath.ViewportWidth - Table.InnerWidth) / 2, (DrawMath.ViewportHeight - Table.InnerHeight) / 2);
        }

        public static Vector2 GetInnerTableNorthEast()
        {
            return new Vector2((DrawMath.ViewportWidth - ((DrawMath.ViewportWidth - Table.InnerWidth) / 2)), (DrawMath.ViewportHeight - Table.InnerHeight) / 2);
        }

        public static Vector2 GetInnerTableSouthWest()
        {
            return new Vector2((DrawMath.ViewportWidth - Table.InnerWidth) / 2, DrawMath.ViewportHeight - ((DrawMath.ViewportHeight - Table.InnerHeight) / 2));
        }

        public static Vector2 GetInnerTableSouthEast()
        {
            return new Vector2((DrawMath.ViewportWidth - ((DrawMath.ViewportWidth - Table.InnerWidth) / 2)), DrawMath.ViewportHeight - ((DrawMath.ViewportHeight - Table.InnerHeight) / 2));
        }

        public static Vector2 RawRelativeToGameDisplay(Vector2 point)
        {
            Vector2 northWest = DrawMath.GetGameDisplayNorthWest();
            return new Vector2(point.X - northWest.X, point.Y - northWest.Y);
        }

        public static Vector2 RawRelativeToOuterTable(Vector2 point)
        {
            Vector2 northWest = DrawMath.GetTableNorthWest();
            return new Vector2(point.X - northWest.X, point.Y - northWest.Y);
        }

        public static Vector2 RawRelativeToInnerTable(Vector2 point)
        {
            Vector2 northWest = DrawMath.GetInnerTableNorthWest();
            return new Vector2(point.X - northWest.X, point.Y - northWest.Y);
        }

        public static Vector2 TableToRaw(Vector2 point)
        {
            Vector2 northWest = DrawMath.GetTableNorthWest();
            return new Vector2(point.X + northWest.X, point.Y + northWest.Y);
        }

        public static Vector2 InnerTableToRaw(Vector2 point)
        {
            Vector2 northWest = DrawMath.GetInnerTableNorthWest();
            return new Vector2(point.X + northWest.X, point.Y + northWest.Y);
        }
    }
}
