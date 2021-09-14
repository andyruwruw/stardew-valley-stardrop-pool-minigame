using Microsoft.Xna.Framework;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Render;
using StardropPoolMinigame.Render.Drawers;
using StardropPoolMinigame.Render.Filters;
using System.Collections.Generic;

namespace StardropPoolMinigame.Entities
{
    class PortraitFire : Entity
    {
        public PortraitFire(
            Origin origin,
            Vector2 anchor,
            float layerDepth,
            IFilter enteringTransition,
            IFilter exitingTransition
        ) : base(
            origin,
            anchor,
            layerDepth,
            enteringTransition,
            exitingTransition)
        {
            this.SetDrawer(new PortraitFireDrawer(this));
        }

        public override string GetId()
        {
            return $"portrait-fire-{this._id}";
        }

        public override float GetTotalHeight()
        {
            return Textures.PortraitFire.FRAME_1.Height;
        }

        public override float GetTotalWidth()
        {
            return Textures.PortraitFire.FRAME_1.Width;
        }

        protected override void InicializeFilters()
        {
            this._filters = new List<IFilter>();
            this._filters.Add(new PortraitFireAnimation($"{this.GetId()}-animation"));
        }
    }
}
