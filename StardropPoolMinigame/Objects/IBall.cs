using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardropPoolMinigame.Structures;
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

        Vector2 GetAcceleration();

        void SetCurrentlyColliding(IList<IBall> balls);

        void SetCurrentlyBouncing(IList<Structures.Rectangle> walls);

        int GetNumber();

        Color GetColor();

        BallType GetBallType();

        void Update(ITable table);

        void SetAcceleration(Vector2 acceleration);

        void SetVelocity(Vector2 velocity);

        float GetMassMultiplyer();
    }
}
