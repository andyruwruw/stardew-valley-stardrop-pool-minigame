using Microsoft.Xna.Framework;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Render.Drawers;
using StardropPoolMinigame.Render.Filters;
using System.Collections.Generic;

namespace StardropPoolMinigame.Entities
{
    /// <summary>
    /// Drawable object in an <see cref="Scenes.IScene"/>
    /// </summary>
    interface IEntity
    {
        string GetId();

        void Update();

        IDrawer GetDrawer();

        Origin GetOrigin();

        Vector2 GetAnchor();

        void SetAnchor(Vector2 anchor);

        float GetLayerDepth();

        TransitionState GetTransitionState();

        void SetTransitionState(TransitionState transitionState, bool start = false);

        IFilter GetEnteringTransition();

        IFilter GetExitingTransition();

        Vector2 GetTopLeft();

        Vector2 GetCenter();

        float GetTotalWidth();

        float GetTotalHeight();

        Primitives.Rectangle GetRawBoundary();

        IList<IFilter> GetFilters();
    }
}
