using StardewValley;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardropPoolMinigame.Helpers;
using StardropPoolMinigame.Detect;

namespace StardropPoolMinigame
{
    public class ModEntry : Mod
    {
        /// <summary>
        /// Provides helper to other classes and sets events
        /// </summary>
        public override void Entry(IModHelper helper)
        {
            Helpers.Multiplayer.SetHelper(this.Helper.Multiplayer);
            Translations.SetHelper(this.Helper.Translation);
            Logger.SetMonitor(this.Monitor);

            helper.Events.Input.ButtonPressed += this.OnButtonPressed;
            helper.Events.GameLoop.SaveLoaded += this.OnSaveLoaded;
            helper.Events.GameLoop.Saving += this.OnSaving;
        }

        /// <summary>
        /// Loads mod save data
        /// </summary>
        private void OnSaveLoaded(object sender, SaveLoadedEventArgs e)
        {
            Save.SetData(this.Helper.Data);
        }

        /// <summary>
        /// Saves mod data
        /// </summary>
        private void OnSaving(object sender, SavingEventArgs e)
        {
            Save.WriteSaveData();
        }

        /// <summary>
        /// Detects if pool table is right clicked
        /// </summary>
        private void OnButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            if (!Context.IsWorldReady)
            {
                return;
            }

            if (e.Button.IsActionButton() && Use.IsPoolTable())
            {
                this.StartGame();
            }
        }

        /// <summary>
        /// Begins the mini-game
        /// </summary>
        private void StartGame()
        {
            Game1.currentMinigame = new StardropPoolMinigame();
        }
    }
}