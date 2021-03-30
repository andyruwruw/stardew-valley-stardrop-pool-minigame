using Microsoft.Xna.Framework;
using StardropPoolMinigame.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StardropPoolMinigame.Objects
{
    class Pocket : IPocket
    {
        private int _id;

        private Circle _boundary;

        public Pocket(int id, Circle boundary)
        {
            this._id = id;
            this._boundary = boundary;
        }

        public Pocket(int id, float x, float y, float radius) : this(id, new Circle(x, y, radius)) { }

        public bool IsPocketed(IBall ball)
        {
            Circle ridgidBody = new Circle(ball.GetPosition().X, ball.GetPosition().Y, Ball.Radius);
            return this._boundary.Intersects(ridgidBody);
        }

        public int GetId()
        {
            return this._id;
        }

        public Circle GetBoundary()
        {
            return this._boundary;
        }    }
}
