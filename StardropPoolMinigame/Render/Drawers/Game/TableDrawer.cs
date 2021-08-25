using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardropPoolMinigame.Entities;

namespace StardropPoolMinigame.Render.Drawers
{
    class TableDrawer : Drawer
    {
        public TableDrawer(Table table) : base(table)
        {
        }

        public override void Draw(SpriteBatch batch)
        {

        }

        protected override Rectangle GetRawSource()
        {
            return new Rectangle();
        }
    }
}
