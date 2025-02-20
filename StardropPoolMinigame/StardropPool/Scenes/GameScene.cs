using MinigameFramework.Entities;
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

        /// <inheritdoc cref="Scene.InitializeEntities"/>
        protected override IList<IEntity> InitializeEntities()
        {
            return new List<IEntity>();
        }
    }
}
