using MinigameFramework.Entities;
using MinigameFramework.Entities.Popups;
using System.Security.Cryptography;

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

        /// <inheritdoc cref="IEntity.GetId"/>
        public override string GetId()
        {
            return $"defeat-popup-{_id}";
        }

        /// <summary>
        /// Setup default entities.
        /// </summary>
        protected override void InitializeEntities()
        {

        }
    }
}
