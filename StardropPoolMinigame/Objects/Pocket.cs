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

        public Pocket(int id)
        {
            this._id = id;
        }

        public int GetId()
        {
            return this._id;
        }
    }
}
