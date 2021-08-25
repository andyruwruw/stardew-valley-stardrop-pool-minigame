using Microsoft.Xna.Framework;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Render;
using StardropPoolMinigame.Render.Drawers;
using StardropPoolMinigame.Render.Filters;

namespace StardropPoolMinigame.Entities
{
    class Cue : EntityStatic
    {
        public Cue(
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
            this.SetDrawer(new CueDrawer(this));
        }

        public override void Update()
        {
            this.UpdateTransitionState();
        }

        public override IDrawer GetDrawer()
        {
            return this._drawer;
        }

        public override string GetId()
        {
            return $"cue-{this._id}";
        }

        public override float GetTotalWidth()
        {
            return Textures.CUE_BASIC_BOUNDS.Width;
        }

        public override float GetTotalHeight()
        {
            return Textures.CUE_BASIC_BOUNDS.Height;
        }
    }
}
