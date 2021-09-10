using StardropPoolMinigame.Enums;

namespace StardropPoolMinigame.Scenes.Dialog.Scripts
{
    interface IScript
    {
        /// <summary>
        /// Retrieves next <see cref="Recitation"/>, or line of dialog from <see cref="Script"/>
        /// </summary>
        /// <returns>Next <see cref="Recitation"/></returns>
        Recitation GetNext();

        /// <summary>
        /// Retrieves previous <see cref="Recitation"/>, or line of dialog from <see cref="Script"/>
        /// </summary>
        /// <returns>Previous <see cref="Recitation"/></returns>
        Recitation GetLast();

        /// <summary>
        /// Retrieves <see cref="NPCName"/> of active speaker in <see cref="Script"/>
        /// </summary>
        /// <returns>Active speaker <see cref="NPCName"/></returns>
        NPCName GetNPCName();
    }
}
