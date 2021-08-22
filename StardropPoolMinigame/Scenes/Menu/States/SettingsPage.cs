using StardropPoolMinigame.Behaviors.Attributes;
using System.Collections.Generic;

namespace StardropPoolMinigame.Scenes.States
{
    class SettingsPage: MenuPage
    {
        public SettingsPage(): base()
        {
        }

        public override void Update()
        {
            foreach (Hoverable hoverable in this._hoverables)
            {
                hoverable.UpdateHoverable();
            }
        }

        public override void ReceiveLeftClick()
        {

        }

        public override void ReceiveRightClick()
        {

        }
    }
}
