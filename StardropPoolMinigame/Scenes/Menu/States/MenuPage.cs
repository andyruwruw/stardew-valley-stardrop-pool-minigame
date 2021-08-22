using StardropPoolMinigame.Behaviors.Attributes;
using System.Collections.Generic;

namespace StardropPoolMinigame.Scenes.States
{
    class MenuPage: IMenuPage
    {
        protected MenuPage _newPage;

        protected IList<Hoverable> _hoverables;

        public MenuPage()
        {
            this._newPage = null;
            this._hoverables = new List<Hoverable>();
        }

        public virtual void Update()
        {

        }

        public bool HasNewPage()
        {
            return this._newPage != null;
        }

        public MenuPage GetNewPage()
        {
            return this._newPage;
        }

        public IList<Hoverable> GetHoverables()
        {
            return this._hoverables;
        }

        public virtual void ReceiveLeftClick()
        {

        }

        public virtual void ReceiveRightClick()
        {

        }
    }
}
