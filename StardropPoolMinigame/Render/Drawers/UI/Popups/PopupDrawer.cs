using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardropPoolMinigame.Entities;
using System.Collections.Generic;

namespace StardropPoolMinigame.Render.Drawers
{
    class PopupDrawer : Drawer
    {
        public PopupDrawer(Popup popup) : base(popup)
        {
        }

        public override void Draw(
            SpriteBatch batch,
            Vector2? overrideDestination = null,
            Rectangle? overrideSource = null,
            Color? overrideColor = null,
            float? overrideRotation = null,
            Vector2? overrideOrigin = null,
            float? overrideScale = null,
            SpriteEffects? overrideEffects = null,
            float? overrideLayerDepth = null)
        {
            IList<IEntity> entities = ((Popup)this._entity).GetEntities();

            foreach (IEntity entity in entities)
            {
                entity.GetDrawer().Draw(batch);
            }
        }
        protected override Rectangle GetRawSource()
        {
            return Textures.BAR_SHELVES;
        }
    }
}
