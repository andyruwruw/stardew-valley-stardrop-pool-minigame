using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StardropPoolMinigame
{
    interface IBall
    {
        void Draw(SpriteBatch batch);

        Vector2 GetPosition();

        Vector2 GetVelocity();

        int GetNumber();

        Color GetColor();

        BallType GetBallType();
    }
}
