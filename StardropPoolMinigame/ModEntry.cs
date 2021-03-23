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
using StardropPoolMinigame.Messages;
using xTile.Tiles;

namespace StardropPoolMinigame
{
    public class ModEntry : Mod
    {
        public override void Entry(IModHelper helper)
        {
            Multiplayer.SetHelper(helper);
            Console.SetMonitor(this.Monitor);

            helper.Events.Input.ButtonPressed += this.OnButtonPressed;
        }

        private void OnButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            if (!Context.IsWorldReady)
                return;

            if (e.Button.IsActionButton()) //  && PoolTableDetector.IsPoolTable()
            {
                this.startGame();
            }
        }

        private void startGame()
        {
            Game1.currentMinigame = new StardropPoolMinigame();
        }

        private void OnModMessageRecieved(object sender, ModMessageReceivedEventArgs e)
        {
            if (e.FromModID == this.ModManifest.UniqueID)
            {
                IModMessage message;

                switch(e.Type)
                {
                    case "Test":
                        message = e.ReadAs<IModMessage>();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}