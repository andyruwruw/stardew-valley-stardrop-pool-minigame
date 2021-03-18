using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StardropPoolMinigame.Objects
{
    class Ball : IBall
    {
        public static int radius = 5;

        private Point _position;

        private Point _motion;

        private Color _color;

        private BallType _type;

        public Ball(Color color, BallType type)
        {
            this._color = color;
            this._type = type;

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

        public Color GetColor()
        {
            return this._color;
        }
    }
}
