using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;

namespace StardropPoolMinigame.Objects
{
    class Ball : IBall
    {
        public static int Radius = 15;

        private Vector2 _position;

        private Vector2 _velocity;

        private Vector2 _acceleration;

        private int _number;

        public Ball(int number, Vector2 position)
        {
            this._number = number;
            this._position = position;
            this._velocity = new Vector2(0, 0);
            this._acceleration = new Vector2(0, 0);
        }

        public void Update()
        {
            this._position = Vector2.Add(this._position, this._velocity);
            this._velocity = Vector2.Add(this._velocity, this._acceleration);

            this.UpdateAcceleration();
        }

        public void UpdateAcceleration()
        {
            this._acceleration = new Vector2(0, 0);
            
        }

        public void Draw(SpriteBatch batch)
        {
            batch.Draw(Game1.staminaRect, new Microsoft.Xna.Framework.Rectangle((int)this._position.X, (int)this._position.Y, Ball.Radius, Ball.Radius), Game1.staminaRect.Bounds, this.GetColor(), 0f, Vector2.Zero, SpriteEffects.None, 0.0001f);
        }

        public Vector2 GetPosition()
        {
            return this._position;
        }

        public Vector2 GetVelocity()
        {
            return this._velocity;
        }

        public int GetNumber()
        {
            return this._number;
        }

        public Color GetColor()
        {
            if (this._number == 0)
            {
                return Color.White;
            }

            switch ((this._number - 1) % 8)
            {
                case 0:
                    return Color.Yellow;
                case 1:
                    return Color.Blue;
                case 2:
                    return Color.Red;
                case 3:
                    return Color.Purple;
                case 4:
                    return Color.Orange;
                case 5:
                    return Color.Green;
                case 6:
                    return Color.Maroon;
                default:
                    return Color.Black;
            }
        }

        public BallType GetBallType()
        {
            if (this._number == 0)
            {
                return BallType.White;
            }

            if (this._number <= 8)
            {
                return BallType.Solid;
            }
            return BallType.Stripped;
        }
    }
}
