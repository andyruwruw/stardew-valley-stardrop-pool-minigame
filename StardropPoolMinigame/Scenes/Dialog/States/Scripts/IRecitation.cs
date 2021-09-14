using StardropPoolMinigame.Enums;
using System.Collections.Generic;

namespace StardropPoolMinigame.Scenes.Dialog.Scripts
{
    interface IRecitation
    {
        NPCName GetName();

        PortraitEmotion GetEmotion();

        string GetText();

        IList<string> GetSounds();

        bool HasShine();

        bool HasFire();

        int GetDelay();
    }
}
