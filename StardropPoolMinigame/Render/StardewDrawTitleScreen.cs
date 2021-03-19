using Microsoft.Xna.Framework.Graphics;
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
        public StardewDrawTitleScreen() { }

        public void draw(IScene scene, SpriteBatch batch)
        {
            Console.Info("Draw");
        }
    }
}
