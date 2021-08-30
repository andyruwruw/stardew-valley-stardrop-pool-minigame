﻿using Microsoft.Xna.Framework;
using StardropPoolMinigame.Entities;

namespace StardropPoolMinigame.Render.Drawers
{
    class BarShelvesDrawer : Drawer
    {
        public BarShelvesDrawer(BarShelves shelves) : base(shelves)
        {
        }

        protected override Rectangle GetRawSource()
        {
            return Textures.BAR_SHELVES;
        }
    }
}
