using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MinigameFramework.Enums;
using MinigameFramework.Render.Filters;
using MinigameFramework.Structures.Primitives;

namespace MinigameFramework.Entities
{
    /// <summary>
    /// Generally something that needs a position to be drawn and updates.
    /// </summary>
    interface IEntity
    {
        /// <summary>
        /// General update for a scene.
        /// </summary>
		void Update(GameTime time);

        /// <summary>
        /// Draws the entity.
        /// </summary>
        /// <param name="batch">Active sprite batch.</param>
        /// <param name="overrideDestination">Custom override for destination.</param>
        /// <param name="overrideSource">Custom override for source.</param>
        /// <param name="overrideColor">Custom override for color.</param>
        /// <param name="overrideRotation">Custom override for rotation.</param>
        /// <param name="overrideOrigin">Custom override for origin.</param>
        /// <param name="overrideScale">Custom override for scale.</param>
        /// <param name="overrideEffects">Custom override for effects.</param>
        /// <param name="overrideLayerDepth">Custom override for layer depth.</param>
        void Draw(
            SpriteBatch batch,
            Vector2? overrideDestination = null,
            Microsoft.Xna.Framework.Rectangle? overrideSource = null,
            Color? overrideColor = null,
            float? overrideRotation = null,
            Vector2? overrideOrigin = null,
            float? overrideScale = null,
            SpriteEffects? overrideEffects = null,
            float? overrideLayerDepth = null
        );

        /// <summary>
        /// Callback when <see cref="IEntity"/> is hovered.
        /// </summary>
        void HandleHover();

        /// <summary>
        /// Callback when <see cref="IEntity"/> is clicked.
        /// </summary>
        void HandleLeftClick();

        /// <summary>
        /// Callback when <see cref="IEntity"/> is right-clicked.
        /// </summary>
        void HandleRightClick();

        /// <summary>
        /// Whether the entity is currently hovered.
        /// </summary>
        bool IsHovered();

        /// <summary>
        /// Retrieves <see cref="IEntity">IEntity's</see> anchor, or position.
        /// </summary>
        /// <returns><see cref="IEntity">IEntity's</see> anchor</returns>
        Vector2 GetAnchor();

        /// <summary>
        /// Sets <see cref="IEntity">IEntity's</see> anchor, or position.
        /// </summary>
        /// <param name="anchor">New anchor as <see cref="Vector2"/></param>
        void SetAnchor(Vector2 anchor);

        /// <summary>
        /// Retrieves the boundary, or <see cref="Rectangle"/>, of the <see cref="IEntity"/>.
        /// </summary>
        /// <returns>Boundary of the <see cref="IEntity"/></returns>
        IRange GetBoundary();

        /// <summary>
        /// Retrieves <see cref="Vector2"/> of the center of the <see cref="IEntity"/>.
        /// </summary>
        /// <returns>Center of the <see cref="IEntity"/> as <see cref="Vector2"/></returns>
        Vector2 GetCenter();

        /// <summary>
        /// Retrieves <see cref="IEntity">IEntity's</see> entering <see cref="Transition"/>.
        /// </summary>
        /// <returns><see cref="IEntity">IEntity's</see> entering <see cref="Transition"/></returns>
        IFilter? GetEnteringTransition();

        /// <summary>
        /// Retrieves internal entities.
        /// </summary>
        IList<IEntity> GetChildren();

        /// <summary>
        /// Retrieves <see cref="IEntity">IEntity's</see> exiting <see cref="Transition"/>.
        /// </summary>
        /// <returns><see cref="IEntity">IEntity's</see> exiting <see cref="Transition"/></returns>
        IFilter? GetExitingTransition();

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
        /// Retrieves the sprite's raw source.
        /// </summary>
        Microsoft.Xna.Framework.Rectangle GetRawSource();

        /// <summary>
        /// Retrieves the raw boundary, or <see cref="Rectangle"/>, of the <see cref="IEntity"/>.
        /// </summary>
        /// <returns>Raw boundary of the <see cref="IEntity"/></returns>
        Structures.Primitives.Rectangle GetRawBoundary();

        /// <summary>
        /// Whether this entity should be drawn.
        /// </summary>
        bool ShouldDraw();

        /// <summary>
        /// Whether this entity's children should be drawn.
        /// </summary>
        bool ShouldDrawChildren();

        /// <summary>
        /// Whether this entity should be drawn itself.
        /// </summary>
        bool ShouldDrawSelf();

        /// <summary>
        /// Retrieves the total height of the <see cref="IEntity"/>.
        /// </summary>
        /// <returns>Total height of the <see cref="IEntity"/></returns>
        float GetHeight();

        /// <summary>
        /// Retrieves the width of the <see cref="IEntity"/>.
        /// </summary>
        /// <returns>Width of the <see cref="IEntity"/></returns>
        float GetWidth();

        /// <summary>
        /// Retrieves <see cref="IEntity">IEntity's</see> current <see cref="TransitionState"/>.
        /// </summary>
        /// <returns><see cref="IEntity">IEntity's</see> current <see cref="TransitionState"/></returns>
        TransitionState GetTransitionState();

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
        /// Retrieves <see cref="Vector2"/> of the top-left of the <see cref="IEntity"/>.
        /// </summary>
        /// <returns>Top-left of the <see cref="IEntity"/> as <see cref="Vector2"/></returns>
        Vector2 GetTopLeft();
    }
}
