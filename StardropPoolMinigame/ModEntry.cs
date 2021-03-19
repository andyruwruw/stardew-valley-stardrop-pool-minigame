using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;
using StardewValley.Objects;
using StardewValley.TerrainFeatures;
using xTile.Tiles;

namespace StardropPoolMinigame
{
    public class ModEntry : Mod
    {
        private IList IS_POOL_TABLE_FRONT = new List<int>() { 1415, 1416, 1417, 1418, 1419 };
        private IList IS_POOL_TABLE_BUILDING = new List<int>() { 1447, 1448, 1449, 1450, 1451, 1479, 1480, 1481, 1482, 1483 };

        public override void Entry(IModHelper helper)
        {
            Console.SetMonitor(this.Monitor);
            helper.Events.Input.ButtonPressed += this.OnButtonPressed;
        }

        private void OnButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            if (!Context.IsWorldReady)
                return;

            if (e.Button.IsActionButton() && this.IsPoolTable())
            {
                this.startGame();
            }
        }

        private void startGame()
        {
            Console.Info("Hello pool table");
            Game1.currentMinigame = new StardropPoolMinigame();
        }

        private bool IsPoolTable()
        {
            Vector2 mousePosition = Utility.PointToVector2(Game1.getMousePosition()) + new Vector2(Game1.viewport.X, Game1.viewport.Y);
            int clickX = (int)Math.Floor(mousePosition.X / Game1.tileSize) * 64;
            int clickY = (int)Math.Floor(mousePosition.Y / Game1.tileSize) * 64;

            Tile front = Game1.currentLocation.map.GetLayer("Front").PickTile(new xTile.Dimensions.Location(clickX, clickY), Game1.viewport.Size);
            Tile building = Game1.currentLocation.map.GetLayer("Buildings").PickTile(new xTile.Dimensions.Location(clickX, clickY), Game1.viewport.Size);

            if ((front != null && IS_POOL_TABLE_FRONT.Contains(front.TileIndex)) ||
                building != null && IS_POOL_TABLE_BUILDING.Contains(building.TileIndex))
            {
                return true;
            }

            return false;
        }
    }
}