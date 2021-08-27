using StardropPoolMinigame.Enums;

namespace StardropPoolMinigame.Scenes.Dialog.Scripts
{
    class Script : IScript
    {
        public Script()
        {
        }

        public static IScript GetScript(OpponentType opponentName)
        {
            return new Script();
        }
    }
}
