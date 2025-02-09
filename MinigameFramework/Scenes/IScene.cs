using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace MinigameFramework.Scenes
{
    /// <summary>
    /// Designates a set of entities and state.
    /// </summary>
    interface IScene
    {
        /// <summary>
        /// Whether a new scene is available.
        /// </summary>
        bool HasNewScene();

        /// <summary>
        /// Retrieves the new scene.
        /// </summary>
        IScene GetNewScene();

        /// <summary>
        /// Triggers the scene to start running.
        /// </summary>
        void Start();

        /// <summary>
        /// General update for a scene.
        /// </summary>
        void Update(GameTime time);

        /// <summary>
        /// Draws the current scene.
        /// </summary>
        /// <param name="b">Active sprite batch.</param>
        void Draw(SpriteBatch b);

        /// <summary>
        /// Left click handler.
        /// </summary>
        /// <param name="x">X coordinate of the mouse click.</param>
        /// <param name="y">Y coordinate of the mouse click.</param>
        void HandleLeftClick(
            int x,
            int y
        );

        /// <summary>
        /// Right click handler.
        /// </summary>
        /// <param name="x">X coordinate of the mouse click.</param>
        /// <param name="y">Y coordinate of the mouse click.</param>
        void HandleRightClick(
            int x,
            int y
        );

        /// <summary>
        /// General key press handler.
        /// </summary>
        /// <param name="x"><see cref="Keys">Key</see> representation of the key pressed.</param>
        void HandleKeyPress(Keys k);

        /// <summary>
        /// General key release handler.
        /// </summary>
        /// <param name="x"><see cref="Keys">Key</see> representation of the key pressed.</param>
        void HandleKeyRelease(Keys k);

        /// <summary>
        /// Left click held handler.
        /// </summary>
        /// <param name="x">X coordinate of the mouse click.</param>
        /// <param name="y">Y coordinate of the mouse click.</param>
        void HandleLeftClickHeld(
            int x,
            int y
        );

        /// <summary>
        /// Right click held handler.
        /// </summary>
        /// <param name="x">X coordinate of the mouse click.</param>
        /// <param name="y">Y coordinate of the mouse click.</param>
        void HandleRightClickHeld(
            int x,
            int y
        );

        /// <summary>
        /// Left click released handler.
        /// </summary>
        /// <param name="x">X coordinate of the mouse click.</param>
        /// <param name="y">Y coordinate of the mouse click.</param>
        void HandleLeftClickReleased(
            int x,
            int y
        );

        /// <summary>
        /// Right click released handler.
        /// </summary>
        /// <param name="x">X coordinate of the mouse click.</param>
        /// <param name="y">Y coordinate of the mouse click.</param>
        void HandleRightClickReleased(
            int x,
            int y
        );
    }
}
