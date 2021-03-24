using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StardropPoolMinigame.Objects
{
    class Cue : ICue
    {
        private Vector2 _anchor;

        private Vector2 _angle;

        private Vector2 _power;

        private CueState _cueState;

        public Cue() {
            this._cueState = CueState.Invisible;
        }

        public void SetCueState(CueState state)
        {
            this._cueState = state;
        }

        public void SetAnchor(Vector2 anchor)
        {
            this._anchor = anchor;
        }

        public void SetAngle(Vector2 angle)
        {
            this._angle = angle;
        }

        public void SetPower(Vector2 power)
        {
            this._power = power;
        }

        public Vector2 GetAnchor()
        {
            return this._anchor;
        }

        public Vector2 GetAngle()
        {
            return this._anchor;
        }

        public Vector2 GetPower()
        {
            return this._power;
        }

        public CueState GetCueState()
        {
            return this._cueState;
        }

        public void Draw(SpriteBatch batch, int x, int y)
        {
            
            
            batch.Draw(Game1.staminaRect, new Rectangle(0, 0, Table.Width, Table.Height), Game1.staminaRect.Bounds, Color.Gray, 0f, Vector2.Zero, SpriteEffects.None, 0.0001f);
            //batch.Draw(Game1.staminaRect, new Rectangle((int)Math.Round(this._anchor.X), (int)Math.Round(this._anchor.Y), 128, 3), Game1.staminaRect.Bounds, Color.Red, 
        }
    }
}
