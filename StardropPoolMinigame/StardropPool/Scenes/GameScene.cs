using MinigameFramework.Scenes;
using MinigameFramework.Utilities;
using StardopPoolMinigame.Constants;

namespace StardopPoolMinigame.Scenes
{
    /// <summary>
    /// Scene holding all game logic.
    /// </summary>
    class GameScene : Scene
    {
        /// <summary>
        /// Instantiates a <see cref="GameScene"/>.
        /// </summary>
        public GameScene() : base()
        {
            Sounds.PlayMusic(SoundConstants.GameTheme);
        }

        /// <inheritdoc cref="IScene.GetKey"/>
        public override string GetKey()
        {
            return "game-scene";
        }

        /// <inheritdoc cref="Scene.AddEntities"/>
        protected override void AddEntities()
        {

        }
    }
}
