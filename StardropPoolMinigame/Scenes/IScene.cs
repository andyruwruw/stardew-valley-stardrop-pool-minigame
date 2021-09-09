using StardropPoolMinigame.Entities;
using StardropPoolMinigame.Enums;
using System.Collections.Generic;

namespace StardropPoolMinigame.Scenes
{
    /// <summary>
    /// An interactable page, comprised of <see cref="IEntity">IEntities</see> and logic for handling events
    /// </summary>
    interface IScene
    {
        /// <summary>
        /// Unique identifier for <see cref="IScene"/>
        /// </summary>
        /// <returns>ID of <see cref="IScene"/></returns>
        string GetKey();

        /// <summary>
        /// Updates all <see cref="IScene">IScene's</see> <see cref="IEntity">IEntities</see> and runs all <see cref="IScene"/> specific logic
        /// </summary>
        void Update();

        /// <summary>
        /// Handles left click event for <see cref="IScene"/>
        /// </summary>
        void ReceiveLeftClick();

        /// <summary>
        /// Handles right click event for <see cref="IScene"/>
        /// </summary>
        void ReceiveRightClick();

        /// <summary>
        /// Gets all <see cref="IScene">IScene's</see> <see cref="IEntity">IEntities</see>
        /// </summary>
        IList<IEntity> GetEntities();

        /// <summary>
        /// Whether the <see cref="IScene"/> is finished and a new <see cref="IScene"/> ready
        /// </summary>
        /// <returns>Whether new <see cref="IScene"/> is ready</returns>
        bool HasNewScene();

        /// <summary>
        /// Gets the new <see cref="IScene"/> to replace this <see cref="IScene"/>
        /// </summary>
        /// <returns>New <see cref="IScene"/></returns>
        IScene GetNewScene();

        /// <summary>
        /// Gets the <see cref="TransitionState"/> of the <see cref="IScene"/>
        /// </summary>
        /// <returns><see cref="TransitionState"/> of <see cref="IScene"/></returns>
        TransitionState GetTransitionState();

        /// <summary>
        /// Sets the <see cref="TransitionState"/> of the <see cref="IScene"/>
        /// </summary>
        /// <param name="transitionState">New <see cref="TransitionState"/></param>
        void SetTransitionState(TransitionState transitionState);
    }
}
