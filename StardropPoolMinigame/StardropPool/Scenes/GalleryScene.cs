using MinigameFramework.Scenes;
using MinigameFramework.Utilities;
using StardopPoolMinigame.Constants;

namespace StardopPoolMinigame.Scenes
{
    /// <summary>
    /// Looking through your queues.
    /// </summary>
    class GalleryScene : Scene
    {
        /// <summary>
        /// Instantiates a <see cref="GalleryScene"/>.
        /// </summary>
        public GalleryScene() : base()
        {
            Sounds.PlayMusic(SoundConstants.GameTheme);
        }

        /// <inheritdoc cref="IScene.GetKey"/>
        public override string GetKey()
        {
            return "gallery-scene";
        }

        /// <inheritdoc cref="Scene.AddEntities"/>
        protected override void AddEntities()
        {

        }
    }
}
