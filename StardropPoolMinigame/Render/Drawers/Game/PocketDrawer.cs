using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardropPoolMinigame.Entities;

namespace StardropPoolMinigame.Render.Drawers
{
    class PocketDrawer : Drawer
    {
        public PocketDrawer(Pocket pocket) : base(pocket)
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
