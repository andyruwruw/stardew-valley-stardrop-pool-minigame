using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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
        /// Adds an on click handler.
        /// </summary>
        void AddOnClickHandler(EventHandler<string> handler);

        /// <summary>
        /// Adds an on click held handler.
        /// </summary>
        void AddOnClickHeldHandler(EventHandler<string> handler);

        /// <summary>
        /// Adds an on click released handler.
        /// </summary>
        void AddOnClickReleasedHandler(EventHandler<string> handler);

        /// <summary>
        /// Adds an on hover handler.
        /// </summary>
        void AddOnHoverHandler(EventHandler<string> handler);

        /// <summary>
        /// Adds an on key press handler.
        /// </summary>
        void AddOnKeyPressHandler(EventHandler<string> handler);

        /// <summary>
        /// Adds an on key release handler.
        /// </summary>
        void AddOnKeyReleaseHandler(EventHandler<string> handler);

        /// <summary>
        /// Adds an on right-click handler.
        /// </summary>
        void AddOnRightClickHandler(EventHandler<string> handler);

        /// <summary>
        /// Adds an on right-click held handler.
        /// </summary>
        void AddOnRightClickHeldHandler(EventHandler<string> handler);

        /// <summary>
        /// Adds an on right-click released handler.
        /// </summary>
        void AddOnRightClickReleasedHandler(EventHandler<string> handler);

        /// <summary>
        /// Adds an on unhover handler.
        /// </summary>
        void AddOnUnhoverHandler(EventHandler<string> handler);

        /// <summary>
        /// Clears the entity of children.
        /// </summary>
        void Clear();

        /// <summary>
        /// Draws the entity.
        /// </summary>
        /// <param name="batch">Sprite batch to draw to.</param>
        /// <param name="offset">Parent draw offset.</param>
        /// <param name="color">Parent draw color.</param>
        /// <param name="rotation">Parent draw rotation.</param>
        /// <param name="origin">Parent draw origin.</param>
        /// <param name="scale">Parent draw scale.</param>
        /// <param name="effects">Parent draw effects.</param>
        /// <param name="layerDepth">Parent draw layer effect.</param>
        Vector2 Draw(
            SpriteBatch batch,
            Vector2? offset = null,
            Color? color = null,
            float? rotation = null,
            Vector2? origin = null,
            float? scale = 1f,
            SpriteEffects? effects = null,
            float? layerDepth = null
        );

        /// <summary>
        /// Tests for equality.
        /// </summary>
        bool Equals(object? obj);

        /// <summary>
        /// Retrieves <see cref="IEntity">IEntity's</see> anchor, or position.
        /// </summary>
        /// <returns><see cref="IEntity">IEntity's</see> anchor</returns>
        Vector2 GetAnchor();

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
        /// Retrieves internal entities.
        /// </summary>
        IList<IEntity> GetChildren();

        /// <summary>
        /// Retrieves the entity's entering transition.
        /// </summary>
		IFilter? GetEnteringTransition();

        /// <summary>
        /// Retrieves the entity's exiting transition.
        /// </summary>
        IFilter? GetExitingTransition();

        /// <summary>
        /// Retrieves the total height of the <see cref="IEntity"/>.
        /// </summary>
        /// <returns>Total height of the <see cref="IEntity"/></returns>
        float GetHeight();

        /// <summary>
        /// Retrieves the item's hash code.
        /// </summary>
        int GetHashCode();

        /// <summary>
        /// Retrieves <see cref="IEntity">IEntity's</see> unique identifier.
        /// </summary>
        /// <returns>Unique identifier</returns>
        string GetKey();

        /// <summary>
        /// Retrieves layer depth after filters for drawing.
        /// </summary>
        float GetLayerDepth();

        /// <summary>
        /// Retrieves <see cref="IEntity">IEntity's</see> name with key.
        /// </summary>
        /// <returns>Unique identifier</returns>
        string GetName();

        /// <summary>
        /// Retrieves the margin on bottom.
        /// </summary>
        float GetMarginBottom();

        /// <summary>
        /// Retrieves the margin on the left.
        /// </summary>
        float GetMarginLeft();

        /// <summary>
        /// Retrieves the margin on the right.
        /// </summary>
        float GetMarginRight();

        /// <summary>
        /// Retrieves the margin on top.
        /// </summary>
        float GetMarginTop();

        /// <summary>
        /// Retrieves the maximum height of the entity.
        /// </summary>
        float GetMaxHeight();

        /// <summary>
        /// Retrieves the maximum width of the entity.
        /// </summary>
        float GetMaxWidth();

        /// <summary>
        /// Retrieves the maximum height of the entity.
        /// </summary>
        float GetMinHeight();

        /// <summary>
        /// Retrieves the minimum width of the entity.
        /// </summary>
        float GetMinWidth();

        /// <summary>
        /// Retrieves the padding on bottom.
        /// </summary>
        float GetPaddingBottom();

        /// <summary>
        /// Retrieves the padding on the left.
        /// </summary>
        float GetPaddingLeft();

        /// <summary>
        /// Retrieves the padding on the right.
        /// </summary>
        float GetPaddingRight();

        /// <summary>
        /// Retrieves the padding on top.
        /// </summary>
        float GetPaddingTop();

        /// <summary>
        /// Get's the entity's scroll position.
        /// </summary>
        Vector2 GetScroll();

        /// <summary>
        /// Retrieves <see cref="IEntity">IEntity's</see> current <see cref="TransitionState"/>.
        /// </summary>
        /// <returns><see cref="IEntity">IEntity's</see> current <see cref="TransitionState"/></returns>
        TransitionState GetTransitionState();

        /// <summary>
        /// Retrieves the width of the <see cref="IEntity"/>.
        /// </summary>
        /// <returns>Width of the <see cref="IEntity"/></returns>
        float GetWidth();

        /// <summary>
        /// Insert a new child at a desired index.
        /// </summary>
        /// <param name="entity">Entity to insert.</param>
        /// <param name="index">Index to insert, -1 by default appends.</param>
        void Insert(
            IEntity entity,
            int? index = -1
        );

        /// <summary>
        /// Handles a given event and calls delegates.
        /// </summary>
        void HandleChildUpdate();

        /// <summary>
        /// Handles a given event and calls delegates.
        /// </summary>
		void HandleClick();

        /// <summary>
        /// Handles a given event and calls delegates.
        /// </summary>
		void HandleClickHeld();

        /// <summary>
        /// Handles a given event and calls delegates.
        /// </summary>
		void HandleClickReleased();

        /// <summary>
        /// Handles a given event and calls delegates.
        /// </summary>
		void HandleHover();

        /// <summary>
        /// Handles a given event and calls delegates.
        /// </summary>
		void HandleKeyPress();

        /// <summary>
        /// Handles a given event and calls delegates.
        /// </summary>
		void HandleKeyRelease();

        /// <summary>
        /// Handles a given event and calls delegates.
        /// </summary>
		void HandleRightClick();

        /// <summary>
        /// Handles a given event and calls delegates.
        /// </summary>
		void HandleRightClickHeld();

        /// <summary>
        /// Handles a given event and calls delegates.
        /// </summary>
		void HandleRightClickReleased();

        /// <summary>
        /// Handles a given event and calls delegates.
        /// </summary>
		void HandleUnhover();

        /// <summary>
        /// Whether this entity should be centered in its parent.
        /// </summary>
        bool IsCentered();

        /// <summary>
        /// Whether children of this entity should be centered.
        /// </summary>
        bool IsContentCentered();

        /// <summary>
        /// Whether this component has a fixed position independant of siblings.
        /// </summary>
        bool IsFixed();

        /// <summary>
        /// Whether an element should check for hover events.
        /// </summary>
        bool IsHoverable();

        /// <summary>
        /// Whether the entity is currently hovered.
        /// </summary>
        bool IsHovered();

        /// <summary>
        /// Whether the entity should check for click events.
        /// </summary>
        bool IsInteractable();

        /// <summary>
        /// Whether the entity is currently selected.
        /// </summary>
        bool IsSelected();

        /// <summary>
        /// Whether children of this entity should appear in a row.
        /// </summary>
        bool IsRow();

        /// <summary>
        /// Removes a child from the entity.
        /// </summary>
        /// <param name="key">Key of the child.</param>
        void Remove(string key);

        /// <summary>
        /// Removes a child from the entity.
        /// </summary>
        /// <param name="entity">Entity to remove</param>
        void Remove(IEntity entity);

        /// <summary>
        /// Sets the component's anchor.
        /// </summary>
        /// <param name="anchor">New anchor.</param>
        void SetAnchor(Vector2 anchor)

        /// <summary>
        /// Sets the entity's children.
        /// </summary>
        /// <param name="children">Children to set.</param>
        void SetChildren(IList<IEntity> children);

        /// <summary>
        /// Sets <see cref="IEntity">IEntity's</see> current <see cref="TransitionState"/>.
        /// </summary>
        /// <param name="transitionState">New <see cref="TransitionState"/></param>
        /// <param name="start">Whether to trigger <see cref="Transition">Transition's</see> start.</param>
        void SetTransitionState(TransitionState transitionState, bool start = false);

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
        /// Whether children of this entity should be drawn when out of bounds.
        /// </summary>
        bool ShouldOverflow();

        /// <summary>
        /// General update for a scene.
        /// </summary>
		void Update(GameTime time);

        /// <summary>
        /// Updates based on an event.
        /// </summary>
        void UpdateClick();

        /// <summary>
        /// Updates based on an event.
        /// </summary>
        void UpdateClickHeld();

        /// <summary>
        /// Updates based on an event.
        /// </summary>
        void UpdateClickReleased();

        /// <summary>
        /// Updates based on an event.
        /// </summary>
		void UpdateHover();

        /// <summary>
        /// Updates based on an event.
        /// </summary>
        void UpdateKeyPress(Keys key);

        /// <summary>
        /// Updates based on an event.
        /// </summary>
        void UpdateKeyReleased(Keys key);

        /// <summary>
        /// Updates based on an event.
        /// </summary>
        void UpdateRightClick();

        /// <summary>
        /// Updates based on an event.
        /// </summary>
        void UpdateRightClickHeld();

        /// <summary>
        /// Updates based on an event.
        /// </summary>
        void UpdateRightClickReleased();
    }
}
