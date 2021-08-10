using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StardropPoolMinigame.Objects.Primitives
{
    class Line
    {
        private Vector2 _start;

        private Vector2 _end;

        public Line(Vector2 start, Vector2 end)
        {
            this._start = start;
            this._end = end;
        }

        public Vector2 GetVector()
        {
            return new Vector2(this._start.X - this._end.X, this._start.Y - this._end.Y);
        }

        public Vector2 GetStart()
        {
            return this._start;
        }

        public Vector2 GetEnd()
        {
            return this._end;
        }
    }
}
