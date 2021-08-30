using Microsoft.Xna.Framework;
using StardropPoolMinigame.Entities;
using System;

namespace StardropPoolMinigame.Render.Drawers
{
    class PortraitFireDrawer : Drawer
    {
        public PortraitFireDrawer(PortraitFire fire) : base(fire)
        {
        }

        protected override Rectangle GetRawSource()
        {
            return Textures.PortraitFire.FRAME_1;
        }
    }
}
