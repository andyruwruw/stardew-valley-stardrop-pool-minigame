using MinigameFramework.Entities;
using MinigameFramework.Entities.Popups;

namespace StardopPoolMinigame.Entities.Popups
{
    class OpponentTurnPopup : Popup
    {
        /// <summary>
        /// Instantiates a new <see cref="OpponentTurnPopup"/>.
        /// </summary>
        public OpponentTurnPopup() : base(new List<IEntity>())
        {
        }

        /// <inheritdoc cref="IEntity.GetId"/>
        public override string GetId()
        {
            return $"opponent-turn-popup-{_id}";
        }

        /// <summary>
        /// Setup default entities.
        /// </summary>
        protected virtual void InitializeEntities()
        {

        }
    }
}
