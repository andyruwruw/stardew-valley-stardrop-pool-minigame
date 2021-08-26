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
                    return Textures.CURSOR_TRANSITION_1_BOUNDS;
                case 1:
                    return Textures.CURSOR_TRANSITION_2_BOUNDS;
                case 2:
                    return Textures.CURSOR_TRANSITION_3_BOUNDS;
                default:
                    return Textures.CURSOR_BOUNDS;
            }
        }
    }
}
