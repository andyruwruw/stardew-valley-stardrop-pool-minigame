using MinigameFramework.Entities;
using MinigameFramework.Scenes;
using MinigameFramework.Utilities;
using StardopPoolMinigame.Constants;

namespace StardopPoolMinigame.Scenes
{
    /// <summary>
    /// Waiting for another player to join.
    /// </summary>
    class MultiplayerWaitScene : Scene
    {
        /// <summary>
        /// Instantiates a <see cref="MultiplayerWaitScene"/>.
        /// </summary>
        public MultiplayerWaitScene() : base()
        {
            Sounds.PlayMusic(SoundConstants.GameTheme);
        }

        /// <inheritdoc cref="IScene.GetKey"/>
        public override string GetKey()
        {
            return "multiplayer-wait-scene";
        }

        /// <inheritdoc cref="Scene.InitializeEntities"/>
        protected override IList<IEntity> InitializeEntities()
        {
            return new List<IEntity>();
        }
    }
}
