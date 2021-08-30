using Microsoft.Xna.Framework;
using StardropPoolMinigame.Enums;
using System;

namespace StardropPoolMinigame.Render.Filters
{
    class CursorAnimation : Transition
    {
        public CursorAnimation(int delay = 0, bool delayOnce = false) : base(
            16,
            false,
            TransitionState.Entering,
            delay,
            delayOnce)
        {
        }

        public override string GetName()
        {
            return "cursor-animation";
        }

        public override Rectangle ExecuteSource(Rectangle source)
        {
            switch (Math.Floor(this.GetProgress() * 4))
            {
                case 0:
                    return Textures.Cursor.FRAME_1;
                case 1:
                    return Textures.Cursor.FRAME_2;
                case 2:
                    return Textures.Cursor.FRAME_3;
                default:
                    return Textures.Cursor.DEFAULT;
            }
        }
    }
}
