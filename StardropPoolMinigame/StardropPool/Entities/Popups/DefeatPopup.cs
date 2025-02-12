using MinigameFramework.Entities;
using MinigameFramework.Entities.Popups;

namespace StardopPoolMinigame.Entities.Popups
{
    class DefeatPopup : Popup
    {
        /// <summary>
        /// Instantiates a new <see cref="DefeatPopup"/>.
        /// </summary>
        public DefeatPopup() : base(new List<IEntity>())
        {
        }

        /// <inheritdoc cref="IEntity.GetName"/>
        public override string GetName()
        {
            return $"defeat-popup-{_key}";
        }

        /// <summary>
        /// Setup default entities.
        /// </summary>
        protected override void InitializeEntities()
        {

        }
    }
}
