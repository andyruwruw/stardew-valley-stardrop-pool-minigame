using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using StardropPoolMinigame.Data;
using StardropPoolMinigame.Detect.Hover;
using StardropPoolMinigame.Render;
using StardropPoolMinigame.Utilities;

namespace StardropPoolMinigame
{
    public class ModEntry : Mod
    {
        /// <summary>
        /// Provides <see cref="IModHelper"/> to other classes and sets events.
        /// </summary>
        public override void Entry(IModHelper helper)
        {
            // Inicialize helper classes
            Config.SetConfig(this.Helper.ReadConfig<ModConfig>());
            Helpers.Multiplayer.SetHelper(this.Helper.Multiplayer);
            Translations.SetHelper(this.Helper.Translation);
            Logger.SetMonitor(this.Monitor);

            // Set event handlers
            helper.Events.Input.ButtonPressed += this.OnButtonPressed;
            helper.Events.GameLoop.SaveLoaded += this.OnSaveLoaded;
            helper.Events.GameLoop.Saving += this.OnSaving;
        }

        /// <summary>
        /// Detects if pool table is right clicked.
        /// </summary>
        private void OnButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            if (!Context.IsWorldReady)
            {
                return;
            }

            if (e.Button.IsActionButton()
                && (new PoolTableHoverDetector()).IsHovering()
                && Game1.currentMinigame == null)
            {
                this.StartGame();
            }
        }

        /// <summary>
        /// Loads mod save data.
        /// </summary>
        private void OnSaveLoaded(object sender, SaveLoadedEventArgs e)
        {
            Save.SetData(this.Helper.Data);
            Textures.LoadTextures();
        }

        /// <summary>
        /// Saves mod data.
        /// </summary>
        private void OnSaving(object sender, SavingEventArgs e)
        {
            Save.WriteSaveData();
        }

        /// <summary>
        /// Begins the <see cref="StardropPoolMinigame"/>.
        /// </summary>
        private void StartGame()
        {
            Game1.currentMinigame = new StardropPoolMinigame();
        }
    }
}