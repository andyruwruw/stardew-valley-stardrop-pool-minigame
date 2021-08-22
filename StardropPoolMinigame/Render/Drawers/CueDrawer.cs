using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StardropPoolMinigame.Render.Drawers
{
    class CueDrawer
    {
        public CueDrawer()
        {

        }

        public void Draw(SpriteBatch batch)
        {

        }

        public Texture2D GetTileSheet()
        {
            return Textures.TileSheet;
        }

        public Rectangle GetDestination()
        {
            return new Rectangle();
        }

        public Rectangle GetSource()
        {
            return new Rectangle();
        }

        public Color GetColor()
        {
            return new Color();
        }

        public float GetRotation()
        {
            return 1;
        }

        public Vector2 GetOrigin()
        {
            return new Vector2(0, 0);
        }

        public Vector2 GetScale()
        {
            return new Vector2(1, 1);
        }

        public SpriteEffects GetEffects()
        {
            return new SpriteEffects();
        }

        public float GetLayerDepth()
        {
            return 1;
        }
    }
}
