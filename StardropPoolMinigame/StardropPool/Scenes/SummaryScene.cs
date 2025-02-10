using MinigameFramework.Scenes;
using MinigameFramework.Utilities;
using StardopPoolMinigame.Constants;

namespace StardopPoolMinigame.Scenes
{
    /// <summary>
    /// Post-game summary before returning to the main menu.
    /// </summary>
    class SummaryScene : Scene
    {
        /// <summary>
        /// Instantiates a <see cref="SummaryScene"/>.
        /// </summary>
        public SummaryScene() : base()
        {
            Sounds.PlayMusic(SoundConstants.GameTheme);
        }

        /// <inheritdoc cref="IScene.GetKey"/>
        public override string GetKey()
        {
            return "summary-scene";
        }

        /// <inheritdoc cref="Scene.AddEntities"/>
        protected override void AddEntities()
        {

        }
    }
}
