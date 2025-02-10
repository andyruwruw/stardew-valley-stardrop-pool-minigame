using MinigameFramework.Entities;
using MinigameFramework.Entities.Popups;

namespace StardopPoolMinigame.Entities.Popups
{
    class ScratchPopup : Popup
    {
        /// <summary>
        /// Instantiates a new <see cref="ScratchPopup"/>.
        /// </summary>
        public ScratchPopup() : base(new List<IEntity>())
        {
        }

        /// <inheritdoc cref="IEntity.GetId"/>
        public override string GetId()
        {
            return $"scratch-popup-{_id}";
        }

        /// <summary>
        /// Setup default entities.
        /// </summary>
        protected override void InitializeEntities()
        {

        }
    }
}
