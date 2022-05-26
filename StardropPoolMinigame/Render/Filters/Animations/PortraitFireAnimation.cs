using Microsoft.Xna.Framework;
using StardropPoolMinigame.Constants;
using System;

namespace StardropPoolMinigame.Render.Filters
{
    internal class PortraitFireAnimation : Animation
    {
        public PortraitFireAnimation(string key) : base(key, RenderConstants.Entities.PortraitFire.Frames * RenderConstants.Entities.PortraitFire.FrameDuration)
        {
        }

        public override Rectangle ExecuteSource(Rectangle source)
        {
            switch (Math.Floor(this.GetProgress() * RenderConstants.Entities.PortraitFire.Frames))
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