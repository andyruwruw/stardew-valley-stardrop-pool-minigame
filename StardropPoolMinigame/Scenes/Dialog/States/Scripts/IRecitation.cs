using StardropPoolMinigame.Enums;
using System.Collections.Generic;

namespace StardropPoolMinigame.Scenes.Dialog.Scripts
{
    internal interface IRecitation
    {
        int GetDelay();

        PortraitEmotion GetEmotion();

        NPCName GetName();

        IList<string> GetSounds();

        string GetText();

        bool HasFire();

        bool HasShine();
    }
}