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

        /// <inheritdoc cref="IEntity.GetName"/>
        public override string GetName()
        {
            return $"opponent-turn-popup-{_key}";
        }

        /// <summary>
        /// Setup default entities.
        /// </summary>
        protected override void InitializeEntities()
        {

        }
    }
}
