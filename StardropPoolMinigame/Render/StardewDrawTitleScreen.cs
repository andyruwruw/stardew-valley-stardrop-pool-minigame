using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;
using StardropPoolMinigame.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StardropPoolMinigame.Render
{
    class StardewDrawTitleScreen : IDraw
    {
        private Texture2D townInterior;

        public StardewDrawTitleScreen() {
            this.InicializeTextures();
        }

        private void InicializeTextures()
        {
            this.townInterior = Game1.content.Load<Texture2D>("Maps\\townInterior");
        }

        public void Draw(IScene scene, SpriteBatch batch)
        {
            batch.Draw(Game1.staminaRect, new Rectangle((int)DrawMath.GetGameDisplayNorthWest().X, (int)DrawMath.GetGameDisplayNorthWest().Y, (int)DrawMath.AdjustedScreenWidth, (int)DrawMath.AdjustedScreenHeight), Game1.staminaRect.Bounds, Color.LightGoldenrodYellow, 0f, Vector2.Zero, SpriteEffects.None, 0.0001f);

            this.DrawBackground(scene, batch);

            if (((TitleScene)scene).GetState() == TitleState.Main)
            {
                this.DrawTitle(batch);
            }
        }

        private void DrawBackground(IScene scene, SpriteBatch batch)
        {

        }

        public void DrawTitle(SpriteBatch batch)
        {
            // batch.Draw(Textures.TileSheet, new Rectangle(0, 0, 48, 32), Textures.Logo, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.0010f);
        }

        public void DrawWaiting(IScene scene, SpriteBatch batch)
        {

        }

        public void DrawOpponentSelect(IScene scene, SpriteBatch batch)
        {

        }
    }
}
