using StardropPoolMinigame.Entities;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Render.Filters;
using System.Collections.Generic;

namespace StardropPoolMinigame.Scenes
{
    /// <inheritdoc cref="IScene"/>
    abstract class Scene : IScene
    {
        /// <summary>
        /// <para>New <see cref="IScene"/> to replace this <see cref="Scene"/></para>
        /// <para>Default value is <b>null</b>, but once set, the new scene replaces the current</para>
        /// </summary>
        protected IScene _newScene;

        /// <summary>
        /// Current <see cref="TransitionState"/> of <see cref="Scene"/>
        /// </summary>
        protected TransitionState _transitionState;

        /// <summary>
        /// List of <see cref="Scene">Scene's</see> <see cref="IEntity">IEntities</see>
        /// </summary>
        protected IList<IEntity> _entities;

        public Scene()
        {
            this._newScene = null;
            this._transitionState = TransitionState.Entering;
            this._entities = new List<IEntity>();

            this.AddEntities();
        }

        /// <inheritdoc cref="IScene.GetKey"/>
        public abstract string GetKey();

        /// <inheritdoc cref="IScene.Update"/>
        public virtual void Update()
        {
            this.UpdateEntities();
        }

        /// <inheritdoc cref="IScene.ReceiveLeftClick"/>
        public virtual void ReceiveLeftClick()
        {
        }

        /// <inheritdoc cref="IScene.ReceiveRightClick"/>
        public virtual void ReceiveRightClick()
        {
        }

        /// <inheritdoc cref="IScene.GetEntities"/>
        public virtual IList<IEntity> GetEntities()
        {
            return this._entities;
        }

        /// <inheritdoc cref="IScene.HasNewScene"/>
        public bool HasNewScene()
        {
            return this._newScene != null;
        }

        /// <inheritdoc cref="IScene.GetNewScene"/>
        public IScene GetNewScene()
        {
            return this._newScene;
        }

        /// <inheritdoc cref="IScene.GetTransitionState"/>
        public TransitionState GetTransitionState()
        {
            return this._transitionState;
        }

        /// <inheritdoc cref="IScene.SetTransitionState"/>
        public void SetTransitionState(TransitionState transitionState)
        {
            this._transitionState = transitionState;
        }

        /// <summary>
        /// <para>Overrideable method to add <see cref="Scene"/> specific <see cref="IEntity">IEntities</see></para>
        /// <para>Automatically called in <see cref="Scene"/> constructor</para>
        /// <para>Should add <see cref="IEntity">IEntities</see> to <see cref="_entities"/> protected <see cref="IList"/>, which will already be instantiated</para>
        /// </summary>
        protected virtual void AddEntities()
        {
        }

        /// <summary>
        /// Updates all scene specific <see cref="IEntity">IEntities</see> from <see cref="Scene._entities"/>
        /// </summary>
        protected void UpdateEntities()
        {
            bool updateTransition = true;

            foreach (IEntity entity in this._entities)
            {
                entity.Update();

                // Set Entity Exiting if Scene Exiting
                if (this._transitionState == TransitionState.Exiting
                    && (entity.GetTransitionState() != TransitionState.Exiting && entity.GetTransitionState() != TransitionState.Dead))
                {
                    entity.SetTransitionState(TransitionState.Exiting, true);
                }

                // Check if entities are finished transitioning
                if (this._transitionState == TransitionState.Entering
                    && (Transition)entity.GetEnteringTransition() != null
                    && !(((Transition)entity.GetEnteringTransition()).IsFinished()))
                {
                    updateTransition = false;
                }
                if (this._transitionState == TransitionState.Exiting
                    && (Transition)entity.GetExitingTransition() != null
                    && !(((Transition)entity.GetExitingTransition()).IsFinished()))
                {
                    updateTransition = false;
                }
            }

            // If finished transitioning, update transition state
            if (this._transitionState != TransitionState.Present && updateTransition)
            {
                if (this._transitionState == TransitionState.Entering)
                {
                    this._transitionState = TransitionState.Present;
                } else if (this._transitionState == TransitionState.Exiting)
                {
                    this._transitionState = TransitionState.Dead;
                }
            }
        }
    }
}
