using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StardropPoolMinigame.Objects
{
    interface ICue
    {
        void SetCueState(CueState state);

        void SetAnchor(Vector2 anchor);

        void SetAngle(Vector2 angle);

        void SetPower(float power);

        Vector2 GetAnchor();

        Vector2 GetAngle();

        float GetPower();

        CueState GetCueState();

        void Draw(SpriteBatch batch, int x, int y);

        void LockAngle();

        void LockPower();

        void BallHit();
    }
}
