using Microsoft.Xna.Framework;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Primitives;
using StardropPoolMinigame.Render.Drawers;
using StardropPoolMinigame.Render.Filters;
using System.Collections.Generic;

namespace StardropPoolMinigame.Entities
{
    /// <summary>
    /// Drawable object in an <see cref="Scenes.IScene"/>.
    /// </summary>
    internal interface IEntity
    {
        /// <summary>
        /// Callback when <see cref="IEntity"/> is clicked.
        /// </summary>
        void ClickCallback();

        /// <summary>
        /// Retrieves <see cref="IEntity">IEntity's</see> anchor, or position.
        /// </summary>
        /// <returns><see cref="IEntity">IEntity's</see> anchor</returns>
        Vector2 GetAnchor();

        /// <summary>
        /// Retrieves the boundary, or <see cref="Primitives.Rectangle"/>, of the <see cref="IEntity"/>.
        /// </summary>
        /// <returns>Boundary of the <see cref="IEntity"/></returns>
        IRange GetBoundary();

        /// <summary>
        /// Retrieves <see cref="Vector2"/> of the center of the <see cref="IEntity"/>.
        /// </summary>
        /// <returns>Center of the <see cref="IEntity"/> as <see cref="Vector2"/></returns>
        Vector2 GetCenter();

        /// <summary>
        /// Retrieves <see cref="IEntity">IEntity's</see> <see cref="IDrawer"/> for rendering.
        /// </summary>
        /// <returns><see cref="IEntity">IEntity's</see> <see cref="IDrawer"/></returns>
        IDrawer GetDrawer();

        /// <summary>
        /// Retrieves <see cref="IEntity">IEntity's</see> entering <see cref="Transition"/>.
        /// </summary>
        /// <returns><see cref="IEntity">IEntity's</see> entering <see cref="Transition"/></returns>
        IFilter GetEnteringTransition();

        /// <summary>
        /// Retrieves <see cref="IEntity">IEntity's</see> exiting <see cref="Transition"/>.
        /// </summary>
        /// <returns><see cref="IEntity">IEntity's</see> exiting <see cref="Transition"/></returns>
        IFilter GetExitingTransition();

        /// <summary>
        /// Retrieves <see cref="IEntity">IEntity's</see> perminant <see cref="IFilter">IFilters</see>.
        /// </summary>
        /// <returns><see cref="IEntity">IEntity's</see> perminant <see cref="IFilter">IFilters</see></returns>
        IList<IFilter> GetFilters();

        /// <summary>
        /// Retrieves <see cref="IEntity">IEntity's</see> unique identifier.
        /// </summary>
        /// <returns>Unique identifier</returns>
        string GetId();

        /// <summary>
        /// Retrieves <see cref="IEntity">IEntity's</see> layer depth for rendering.
        /// </summary>
        /// <returns><see cref="IEntity">IEntity's</see> layer depth</returns>
        float GetLayerDepth();

        /// <summary>
        /// Retrieves anchor's relation to <see cref="IEntity">IEntity's</see> position.
        /// </summary>
        /// <returns>Anchor's relation to <see cref="IEntity">IEntity's</see> position</returns>
        Origin GetOrigin();

        /// <summary>
        /// Retrieves the raw boundary, or <see cref="Primitives.Rectangle"/>, of the <see cref="IEntity"/>.
        /// </summary>
        /// <returns>Raw boundary of the <see cref="IEntity"/></returns>
        Primitives.Rectangle GetRawBoundary();

        /// <summary>
        /// Retrieves <see cref="Vector2"/> of the top-left of the <see cref="IEntity"/>.
        /// </summary>
        /// <returns>Top-left of the <see cref="IEntity"/> as <see cref="Vector2"/></returns>
        Vector2 GetTopLeft();

        /// <summary>
        /// Retrieves the total height of the <see cref="IEntity"/>.
        /// </summary>
        /// <returns>Total height of the <see cref="IEntity"/></returns>
        float GetTotalHeight();

        /// <summary>
        /// Retrieves the total width of the <see cref="IEntity"/>.
        /// </summary>
        /// <returns>Total width of the <see cref="IEntity"/></returns>
        float GetTotalWidth();

        /// <summary>
        /// Retrieves <see cref="IEntity">IEntity's</see> current <see cref="TransitionState"/>.
        /// </summary>
        /// <returns><see cref="IEntity">IEntity's</see> current <see cref="TransitionState"/></returns>
        TransitionState GetTransitionState();

        /// <summary>
        /// Callback when <see cref="IEntity"/> is hovered.
        /// </summary>
        void HoverCallback();

        /// <summary>
        /// Whether the <see cref="IEntity"/> is hovered by the cursor.
        /// </summary>
        /// <returns>Whether the <see cref="IEntity"/> is hovered</returns>
        bool IsHovered();

        /// <summary>
        /// Sets <see cref="IEntity">IEntity's</see> anchor, or position.
        /// </summary>
        /// <param name="anchor">New anchor as <see cref="Vector2"/></param>
        void SetAnchor(Vector2 anchor);

        /// <summary>
        /// Sets <see cref="IEntity">IEntity's</see> entering <see cref="Transition"/>.
        /// </summary>
        /// <param name="transition">New entering <see cref="Transition"/></param>
        void SetEnteringTransition(IFilter transition);

        /// <summary>
        /// Sets <see cref="IEntity">IEntity's</see> exiting <see cref="Transition"/>.
        /// </summary>
        /// <param name="transition">New exiting <see cref="Transition"/></param>
        void SetExitingTransition(IFilter transition);

        /// <summary>
        /// Sets <see cref="IEntity">IEntity's</see> current <see cref="TransitionState"/>.
        /// </summary>
        /// <param name="transitionState">New <see cref="TransitionState"/></param>
        /// <param name="start">Whether to trigger <see cref="Transition">Transition's</see> start.</param>
        void SetTransitionState(TransitionState transitionState, bool start = false);

        /// <summary>
        /// Updates <see cref="IEntity"/>.
        /// </summary>
        void Update();
    }
}