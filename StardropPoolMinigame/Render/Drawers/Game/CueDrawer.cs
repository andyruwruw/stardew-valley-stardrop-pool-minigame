using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardropPoolMinigame.Entities;

namespace StardropPoolMinigame.Render.Drawers
{
    class CueDrawer : Drawer
    {
        public CueDrawer(Cue cue) : base(cue)
        {
        }

        public override void Draw(SpriteBatch batch)
        {

        }

        protected override Rectangle GetRawSource()
        {
            return Textures.CUE_BASIC_BOUNDS;
        }

    }
}
