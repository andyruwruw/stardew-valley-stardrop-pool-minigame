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

        float GetLayerDepth();

        Vector2 GetTopLeft();

        float GetTotalWidth();

        float GetTotalHeight();

        Primitives.Rectangle GetBoundary();

        Primitives.Rectangle GetRawBoundary();
    }
}
