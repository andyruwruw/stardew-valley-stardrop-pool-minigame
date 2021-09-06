using Microsoft.Xna.Framework;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Render;
using StardropPoolMinigame.Render.Drawers;
using StardropPoolMinigame.Render.Filters;
using System.Collections.Generic;

namespace StardropPoolMinigame.Entities
{
    class PortraitRays : EntityStatic
    {
        public PortraitRays(
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
            this.SetDrawer(new PortraitRaysDrawer(this));
        }

        public override string GetId()
        {
            return $"portrait-rays-{this._id}";
        }

        public override float GetTotalHeight()
        {
            return Textures.PORTRAIT_RAYS.Height;
        }

        public override float GetTotalWidth()
        {
            return Textures.PORTRAIT_RAYS.Width;
        }

        protected override void InicializeFilters()
        {
            this._filters = new List<IFilter>();
            this._filters.Add(new Rotate($"{this.GetId()}-animation", 400));
        }
    }
}