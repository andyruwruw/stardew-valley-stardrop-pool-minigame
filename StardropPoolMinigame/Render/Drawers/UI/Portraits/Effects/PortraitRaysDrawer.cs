using Microsoft.Xna.Framework;
using StardropPoolMinigame.Entities;

namespace StardropPoolMinigame.Render.Drawers
{
    internal class PortraitRaysDrawer : Drawer
    {
        public PortraitRaysDrawer(PortraitRays rays) : base(rays)
        {
        }

        protected override Vector2 GetRawOrigin()
        {
            return new Vector2(
                Textures.PORTRAIT_RAYS.Width / 2,
                Textures.PORTRAIT_RAYS.Height / 2);
        }

        protected override Rectangle GetRawSource()
        {
            return Textures.PORTRAIT_RAYS;
        }
    }
}