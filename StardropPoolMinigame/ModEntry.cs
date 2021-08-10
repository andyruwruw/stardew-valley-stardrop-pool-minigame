using StardewValley;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardropPoolMinigame.Helpers;
using StardropPoolMinigame.Detect;

namespace StardropPoolMinigame
{
    public class ModEntry : Mod
    {
        public override void Entry(IModHelper helper)
        {
            // Multiplayer.SetHelper(helper);
            Logger.SetMonitor(this.Monitor);

            helper.Events.Input.ButtonPressed += this.OnButtonPressed;
        }

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

        private void StartGame()
        {
            Game1.currentMinigame = new StardropPoolMinigame();
        }
    }
}