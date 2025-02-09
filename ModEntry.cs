using StardewValley;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using MinigameFramework.Utilities;

namespace StardopPoolMinigame
{
    public class ModEntry : Mod
    {
        /// <summary>
        /// Mod entry.
        /// </summary>
        public override void Entry(IModHelper helper)
        {
            // Multiplayer.SetHelper(helper);
            Logger.SetMonitor(Monitor);
            Translations.SetHelper(helper.Translation);

            helper.Events.Input.ButtonPressed += OnButtonPressed;
        }

        /// <summary>
        /// Hanldes button presses. No need to handle after start, as button presses are passed to minigames.
        /// </summary>
        private void OnButtonPressed(
            object sender,
            ButtonPressedEventArgs e
        ) {
            if (!Context.IsWorldReady)
            {
                return;
            }

            if (e.Button.IsActionButton()) //  && PoolTableDetector.IsPoolTable()
            {
                StartGame();
            }
        }

        /// <summary>
        /// Starts the minigame.
        /// </summary>
        private void StartGame()
        {
            Game1.currentMinigame = new StardropPoolMinigame();
        }

        /// <summary>
        /// A message!
        /// </summary>
        private void OnModMessageRecieved(
            object sender,
            ModMessageReceivedEventArgs e
        ) {
            if (e.FromModID == ModManifest.UniqueID)
            {
                IModMessage message;

                switch (e.Type)
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
