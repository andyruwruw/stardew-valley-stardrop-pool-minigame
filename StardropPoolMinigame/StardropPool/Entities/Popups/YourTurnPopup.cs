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

        /// <inheritdoc cref="IEntity.GetName"/>
        public override string GetName()
        {
            return $"your-turn-popup-{_key}";
        }

        /// <summary>
        /// Setup default entities.
        /// </summary>
        protected override void InitializeEntities()
        {

        }
    }
}
