using MinigameFramework.Entities;
using MinigameFramework.Entities.Popups;

namespace StardopPoolMinigame.Entities.Popups
{
    class YourTurnPopup : Popup
    {
        /// <summary>
        /// Instantiates a new <see cref="YourTurnPopup"/>.
        /// </summary>
        public YourTurnPopup() : base(new List<IEntity>())
        {
        }

        /// <inheritdoc cref="IEntity.GetId"/>
        public override string GetId()
        {
            return $"your-turn-popup-{_id}";
        }

        /// <summary>
        /// Setup default entities.
        /// </summary>
        protected virtual void InitializeEntities()
        {

        }
    }
}
