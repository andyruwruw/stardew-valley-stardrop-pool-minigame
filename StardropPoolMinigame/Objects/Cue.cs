using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StardropPoolMinigame.Objects
{
    class Cue : ICue
    {
        private Point _anchor;

        private Point _angle;

        private Point _power;

        public Cue() { }

        public void SetAnchor(Point anchor)
        {
            this._anchor = anchor;
        }

        public void SetAngle(Point angle)
        {
            this._angle = _anchor;
        }

        public void SetPower(Point power)
        {
            this._power = power;
        }
    }
}
