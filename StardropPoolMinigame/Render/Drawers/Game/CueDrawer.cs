using Microsoft.Xna.Framework;
using StardropPoolMinigame.Entities;

namespace StardropPoolMinigame.Render.Drawers
{
    class CueDrawer : Drawer
    {
        public CueDrawer(Cue cue) : base(cue)
        {
        }

        protected override Rectangle GetRawSource()
        {
            return Textures.CUE_BASIC_BOUNDS;
        }

    }
}
