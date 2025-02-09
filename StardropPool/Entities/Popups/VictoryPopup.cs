using MinigameFramework.Entities;
using MinigameFramework.Entities.Popups;

namespace StardopPoolMinigame.Entities.Popups
{
    class VictoryPopup : Popup
    {
        /// <summary>
        /// Instantiates a new <see cref="VictoryPopup"/>.
        /// </summary>
        public VictoryPopup() : base(new List<IEntity>())
        {
        }

        /// <inheritdoc cref="IEntity.GetId"/>
        public override string GetId()
        {
            return $"victory-popup-{_id}";
        }

        /// <summary>
        /// Setup default entities.
        /// </summary>
        protected virtual void InitializeEntities()
        {

        }
    }
}
