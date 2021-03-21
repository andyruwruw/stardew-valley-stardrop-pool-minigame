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

        public void draw(IScene scene, SpriteBatch batch)
        {
            Console.Info("Draw");
        }

        private void DrawBackground(IScene scene, SpriteBatch batch)
        {

        }

        public void DrawTitle(IScene scene, SpriteBatch batch)
        {
            
        }

        public void DrawWaiting(IScene scene, SpriteBatch batch)
        {

        }

        public void DrawOpponentSelect(IScene scene, SpriteBatch batch)
        {

        }
    }
}
