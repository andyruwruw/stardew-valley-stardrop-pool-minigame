using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;
using StardropPoolMinigame.Render;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StardropPoolMinigame.Objects
{
    class Cue : ICue
    {
        public static int Width = 128 * Table.Scale;

        public static int Height = 16 * Table.Scale;

        private Vector2 _anchor;

        private Vector2 _angle;

        private float _power;

        private CueState _cueState;

        private int _startShooting;

        public Cue() {
            this._cueState = CueState.Invisible;
            this._startShooting = 0;
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

        public void SetPower(float power)
        {
            this._power = power;
        }

        public Vector2 GetAnchor()
        {
            return this._anchor;
        }

        public Vector2 GetAngle()
        {
            return this._angle;
        }

        public float GetPower()
        {
            return this._power;
        }

        public CueState GetCueState()
        {
            return this._cueState;
        }

        public void Draw(SpriteBatch batch, int x, int y)
        {
            Vector2 anchor = DrawMath.InnerTableToRaw(this._anchor);

            if (this._cueState == CueState.Angle)
            {
                Vector2 direction = VectorMath.VectorBetweenTwoPoints(anchor, new Vector2((float)x, (float)y));
                direction.Normalize();

                this._angle = direction;

                float radians = VectorMath.VectorToRadians(this._angle);

                int offsetX = (int)(anchor.X + this._angle.X * DrawMath.PixelZoomAdjustement * 4);
                int offsetY = (int)(anchor.Y + this._angle.Y * DrawMath.PixelZoomAdjustement * 4);

                batch.Draw(Textures.TileSheet, new Rectangle(offsetX, offsetY, Cue.Width, Cue.Height), Textures.Cue, Color.White, radians, new Vector2(-10 * DrawMath.PixelZoomAdjustement, 8), SpriteEffects.None, 0.0030f);

                batch.Draw(Textures.TileSheet, new Rectangle(offsetX + 10 * (int)DrawMath.PixelZoomAdjustement, offsetY + 10 * (int)DrawMath.PixelZoomAdjustement, Cue.Width, Cue.Height), Textures.CueShadow, Color.White, radians, new Vector2(-10 * DrawMath.PixelZoomAdjustement, 8), SpriteEffects.None, 0.0019f);
            } else if (this._cueState == CueState.Power)
            {
                // Distance from mouse to perpendicular line to angle intersecting at cue ball.
                double distance = (Math.Abs(((this._angle.X * -1) - anchor.X) * (anchor.Y - y) - (anchor.X - x) * (this._angle.Y - anchor.Y))) / (Math.Sqrt(Math.Pow((this._angle.X * -1) - anchor.X, 2) + Math.Pow(this._angle.Y - anchor.Y, 2)));
                double offset = this._angle.X * DrawMath.PixelZoomAdjustement * 4;
                
                double fx = (Vector2.Add(anchor, this._angle).X * -1) - anchor.X;
                double fy = (Vector2.Add(anchor, this._angle).Y * -1) - anchor.Y;

                double valid = fx * (Vector2.Add(anchor, this._angle).Y - anchor.Y) - fy * (Vector2.Add(anchor, this._angle).X - anchor.X);
                double side = fx * (y - anchor.Y) - fy * (x - anchor.X);

                if ((valid > 0 && side > 0) ||
                    (valid < 0 && side < 0))
                {
                    double growth = .03;
                    double capacity = 200;

                    // Logistic Growth
                    offset = capacity / (1 + Math.Pow(Math.E, (growth * -1) * (distance - capacity))) * DrawMath.PixelZoomAdjustement;

                    if (offset > 150 && VectorMath.Modulo(Game1.ticks, 250) == 0)
                    {
                        Game1.playSound(Sounds.CueFullCharge);
                    }
                }

                this._power = (float)offset / 200;

                int jiggleX = (int)Math.Round((Math.Sin((double)Game1.ticks / offset / 150) + (Math.Sin((double)Game1.ticks))) * offset / 150);
                int jiggleY = (int)Math.Round((Math.Cos((double)Game1.ticks / offset / 150) + (Math.Sin((double)Game1.ticks))) * offset / 150);

                int offsetX = (int)(anchor.X + this._angle.X  * offset) + jiggleX;
                int offsetY = (int)(anchor.Y + this._angle.Y * offset) + jiggleY + 8 * Table.Scale;

                float radians = VectorMath.VectorToRadians(this._angle);

                batch.Draw(Textures.TileSheet, new Rectangle(offsetX, offsetY, Cue.Width, Cue.Height), Textures.Cue, Color.White, radians, Vector2.Zero, SpriteEffects.None, 0.0030f);

                batch.Draw(Textures.TileSheet, new Rectangle(offsetX + 10 * (int)DrawMath.PixelZoomAdjustement, offsetY + 10 * (int)DrawMath.PixelZoomAdjustement, Cue.Width, Cue.Height), Textures.CueShadow, Color.White, radians, Vector2.Zero, SpriteEffects.None, 0.0019f);
            } else if (this._cueState == CueState.Shooting)
            {
                if (this._startShooting == 0)
                {
                    this._startShooting = Game1.ticks;
                }

                int time = (int)Math.Round(this._power * Feel.CueStrikingSpeed);
                double completion = (double)(time - (Game1.ticks - this._startShooting)) / (double)time;

                if (completion <= 0)
                {
                    this.SetCueState(CueState.Invisible);
                    this.BallHit();
                }

                int offsetX = (int)(anchor.X + Math.Round(this._angle.X * this._power * 200 * completion));
                int offsetY = (int)(anchor.Y + Math.Round(this._angle.Y * this._power * 200 * completion)) + 8 * Table.Scale;

                float radians = VectorMath.VectorToRadians(this._angle);

                batch.Draw(Textures.TileSheet, new Rectangle(offsetX, offsetY, Cue.Width, Cue.Height), Textures.Cue, Color.White, radians, Vector2.Zero, SpriteEffects.None, 0.0030f);

                batch.Draw(Textures.TileSheet, new Rectangle(offsetX + 10 * (int)DrawMath.PixelZoomAdjustement, offsetY + 10 * (int)DrawMath.PixelZoomAdjustement, Cue.Width, Cue.Height), Textures.CueShadow, Color.White, radians, Vector2.Zero, SpriteEffects.None, 0.0019f);
            }
        }

        public void LockAngle()
        {
            Game1.playSound(Sounds.CueLockAngle);
        }

        public void LockPower()
        {
            Game1.playSound(Sounds.CueLockPower);
        }

        public void BallHit()
        {
            Game1.playSound(Sounds.CueStrike);
        }
    }
}
