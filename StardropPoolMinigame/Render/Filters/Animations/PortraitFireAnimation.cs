using Microsoft.Xna.Framework;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Helpers;
using System;

namespace StardropPoolMinigame.Render.Filters
{
    class PortraitFireAnimation : Animation
    {
        public PortraitFireAnimation(string key) : base(key, RenderConstants.Entities.PortraitFire.FRAMES * RenderConstants.Entities.PortraitFire.FRAME_DURATION)
        {
        }

        public override Rectangle ExecuteSource(Rectangle source)
        {
            switch (Math.Floor(this.GetProgress() * RenderConstants.Entities.PortraitFire.FRAMES))
            {
                case 1:
                    return Textures.PortraitFire.FRAME_2;
                case 2:
                    return Textures.PortraitFire.FRAME_3;
                case 3:
                    return Textures.PortraitFire.FRAME_4;
                case 4:
                    return Textures.PortraitFire.FRAME_5;
                case 5:
                    return Textures.PortraitFire.FRAME_6;
                case 6:
                    return Textures.PortraitFire.FRAME_7;
                case 7:
                    return Textures.PortraitFire.FRAME_8;
                default:
                    return Textures.PortraitFire.FRAME_1;
            }
        }
    }
}
