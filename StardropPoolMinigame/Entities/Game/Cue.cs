using Microsoft.Xna.Framework;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Render.Drawers;

namespace StardropPoolMinigame.Entities
{
    class Cue: Entity
    {
        public Cue(Origin origin, Vector2 anchor) : base(origin, anchor)
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
