using Microsoft.Xna.Framework;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Render.Drawers;

namespace StardropPoolMinigame.Entities
{
    class Cue : EntityStatic
    {
        public Cue(Origin origin, Vector2 anchor, float layerDepth) : base(origin, anchor, layerDepth)
        {

        }

        public override void Update()
        {

        }

        public override IDrawer GetDrawer()
        {
            return new CueDrawer(this);
        }

        public override string GetId()
        {
            return $"cue-{this._id}";
        }
    }
}
