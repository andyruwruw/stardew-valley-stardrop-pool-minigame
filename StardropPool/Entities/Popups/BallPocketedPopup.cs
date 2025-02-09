using MinigameFramework.Entities;
using MinigameFramework.Entities.Popups;

namespace StardopPoolMinigame.Entities.Popups
{
    class BallPocketedPopup : Popup
    {
        /// <summary>
        /// Instantiates a new <see cref="BallPocketedPopup"/>.
        /// </summary>
        public BallPocketedPopup() : base(new List<IEntity>())
        {
        }

        /// <inheritdoc cref="IEntity.GetId"/>
        public override string GetId()
        {
            return $"ball-pocketed-popup-{_id}";
        }

        /// <summary>
        /// Setup default entities.
        /// </summary>
        protected virtual void InitializeEntities()
        {

        }
    }
}
