﻿using Microsoft.Xna.Framework;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Render;
using StardropPoolMinigame.Render.Drawers;
using StardropPoolMinigame.Render.Filters;

namespace StardropPoolMinigame.Entities
{
    internal class Cursor : Entity
    {
        public Cursor(
            Origin origin,
            Vector2 anchor,
            float layerDepth,
            int delay = 0,
            bool delayOnce = false
        ) : base(
            origin,
            anchor,
            layerDepth,
            new CursorAnimation(delay, delayOnce),
            null)
        {
            this.SetDrawer(new CursorDrawer(this));
        }

        public override string GetId()
        {
            return $"cursor-{this._id}";
        }

        public override float GetTotalHeight()
        {
            return Textures.Cursor.DEFAULT.Height;
        }

        public override float GetTotalWidth()
        {
            return Textures.Cursor.DEFAULT.Width;
        }
    }
}