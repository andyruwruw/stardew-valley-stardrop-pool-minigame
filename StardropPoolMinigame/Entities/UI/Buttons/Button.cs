﻿using Microsoft.Xna.Framework;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Render.Drawers;

namespace StardropPoolMinigame.Entities
{
    class Button : EntityHoverable
    {
        private Microsoft.Xna.Framework.Rectangle _textBounds;

        public Button(Origin origin, Vector2 anchor, float layerDepth, Microsoft.Xna.Framework.Rectangle textBounds) : base(origin, anchor, layerDepth)
        {
            this._textBounds = textBounds;
        }

        public override void Update()
        {
            this.UpdateHoverable();
        }

        public Microsoft.Xna.Framework.Rectangle GetTextBounds()
        {
            return this._textBounds;
        }

        public override IDrawer GetDrawer()
        {
            return new ButtonDrawer(this);
        }

        public override string GetId()
        {
            return $"basic-button-{this._id}";
        }

        public override float GetTotalWidth()
        {
            return this._textBounds.Width;
        }

        public override float GetTotalHeight()
        {
            return this._textBounds.Height;
        }
    }
}
