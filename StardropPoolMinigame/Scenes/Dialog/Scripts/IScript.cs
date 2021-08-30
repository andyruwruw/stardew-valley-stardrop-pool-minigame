using StardropPoolMinigame.Enums;

namespace StardropPoolMinigame.Scenes.Dialog.Scripts
{
    interface IScript
    {
        Recitation GetNext();

        Recitation GetLast();

        OpponentType GetCharacter();
    }
}
