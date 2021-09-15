namespace StardropPoolMinigame.Scenes.Dialog.Scripts
{
    internal interface IScript
    {
        /// <summary>
        /// Retrieves previous <see cref="IRecitation"/>, or line of dialog from <see cref="Script"/>
        /// </summary>
        /// <returns>Previous <see cref="IRecitation"/></returns>
        IRecitation GetLast();

        /// <summary>
        /// Retrieves next <see cref="IRecitation"/>, or line of dialog from <see cref="Script"/>
        /// </summary>
        /// <returns>Next <see cref="IRecitation"/></returns>
        IRecitation GetNext();
    }
}