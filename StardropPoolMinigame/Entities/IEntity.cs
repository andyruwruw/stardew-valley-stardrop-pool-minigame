using Microsoft.Xna.Framework;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Render.Drawers;
using StardropPoolMinigame.Render.Filters;
using System.Collections.Generic;

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

        TransitionState GetTransitionState();

        IFilter GetEnteringTransition();

        IFilter GetExitingTransition();

        Vector2 GetTopLeft();

        float GetTotalWidth();

        float GetTotalHeight();

        Primitives.Rectangle GetBoundary();

        Primitives.Rectangle GetRawBoundary();

        IList<IFilter> GetFilters();
    }
}
