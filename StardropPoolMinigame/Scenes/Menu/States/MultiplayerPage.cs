using StardropPoolMinigame.Behaviors.Attributes;
using System.Collections.Generic;

namespace StardropPoolMinigame.Scenes.States
{
    class MultiplayerPage: MenuPage
    {
        public MultiplayerPage(): base()
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
