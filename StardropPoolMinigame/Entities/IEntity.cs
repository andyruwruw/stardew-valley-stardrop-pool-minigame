using Microsoft.Xna.Framework;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Render.Drawers;

namespace StardropPoolMinigame.Entities
{
    interface IEntity
    {
        void Update();

        string GetId();

        IDrawer GetDrawer();

        Origin GetOrigin();

        Vector2 GetAnchor();

        Vector2 GetTopLeft();
    }
}
