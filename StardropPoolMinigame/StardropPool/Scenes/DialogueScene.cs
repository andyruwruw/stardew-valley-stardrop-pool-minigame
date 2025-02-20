using MinigameFramework.Entities;
using MinigameFramework.Scenes;
using MinigameFramework.Utilities;
using StardopPoolMinigame.Constants;

namespace StardopPoolMinigame.Scenes
{
    /// <summary>
    /// Pre or post game dialogue scenes with NPC.
    /// </summary>
    class DialogueScene : Scene
    {
        /// <summary>
        /// Instantiates a <see cref="DialogueScene"/>.
        /// </summary>
        public DialogueScene() : base()
        {
            Sounds.PlayMusic(SoundConstants.GameTheme);
        }

        /// <inheritdoc cref="IScene.GetKey"/>
        public override string GetKey()
        {
            return "dialogue-scene";
        }

        /// <inheritdoc cref="Scene.InitializeEntities"/>
        protected override IList<IEntity> InitializeEntities()
        {
            return new List<IEntity>();
        }
    }
}
