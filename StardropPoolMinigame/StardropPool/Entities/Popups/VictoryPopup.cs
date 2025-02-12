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

        /// <inheritdoc cref="IEntity.GetName"/>
        public override string GetName()
        {
            return $"victory-popup-{_key}";
        }

        /// <summary>
        /// Setup default entities.
        /// </summary>
        protected override void InitializeEntities()
        {

        }
    }
}
