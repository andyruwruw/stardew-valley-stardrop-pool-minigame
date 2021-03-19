using Microsoft.Xna.Framework;

namespace StardropPoolMinigame.Objects
{
    class Ball : IBall
    {
        public static int radius = 5;

        private Point _position;

        private Point _motion;

        private int _number;

        public Ball(int number)
        {
            this._number = number;
            this._position = new Point(0, 0);
            this._motion = new Point(0, 0);
        }

        public Point GetPosition()
        {
            return this._position;
        }

        public Point GetMotion()
        {
            return this._motion;
        }

        public int GetNumber()
        {
            return this._number;
        }

        public Color GetColor()
        {
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
            if (this._number <= 8)
            {
                return BallType.Solid;
            }
            return BallType.Stripped;
        }
    }
}
