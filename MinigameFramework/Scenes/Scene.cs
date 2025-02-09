using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MinigameFramework.Enums;
using MinigameFramework.Entities;
using MinigameFramework.Render.Filters.Transitions;

namespace MinigameFramework.Scenes
{
    /// <inheritdoc cref="IScene"/>
    abstract class Scene : IScene
    {
        /// <summary>
        /// Whether a new scene is ready.
        /// </summary>
        protected bool _hasNewScene;

        /// <summary>
        /// New scene to replace this.
        /// </summary>
        protected IScene _newScene;

        /// <summary>
        /// Dictionary of <see cref="Scene">Scene's</see> <see cref="IEntity">IEntities</see>
        /// </summary>
        protected IDictionary<string, IEntity> _entities;

        /// <summary>
        /// Current <see cref="TransitionState"/> of <see cref="Scene"/>
        /// </summary>
        protected TransitionState _transitionState;

        /// <summary>
        /// Instantiates a new scene.
        /// </summary>
        public Scene()
        {
            this._newScene = null;

            this._transitionState = TransitionState.Entering;
            this._entities = new Dictionary<string, IEntity>();

            this.AddEntities();
        }

        /// <inheritdoc cref="IScene.GetKey"/>
        public abstract string GetKey();

        /// <inheritdoc cref="IScene.HasNewScene"/>
        public bool HasNewScene()
        {
            return this._hasNewScene;
        }

        /// <inheritdoc cref="IScene.GetNewScene"/>
        public IScene GetNewScene()
        {
            return this._newScene;
        }

        /// <inheritdoc cref="IScene.Start"/>
        public virtual void Start()
        {
        }

        /// <inheritdoc cref="IScene.Update"/>
        public virtual void Update(GameTime time)
        {
            UpdateEntities(time);
        }

        /// <inheritdoc cref="IScene.Draw"/>
        public virtual void Draw(SpriteBatch b)
        {
        }

        /// <inheritdoc cref="IScene.HandleLeftClick"/>
        public virtual void HandleLeftClick(
            int x,
            int y
        ) {
        }

        /// <inheritdoc cref="IScene.HandleRightClick"/>
        public virtual void HandleRightClick(
            int x,
            int y
        ) {
        }

        /// <inheritdoc cref="IScene.HandleKeyPress"/>
        public virtual void HandleKeyPress(Keys k) {
        }

        /// <inheritdoc cref="IScene.HandleKeyRelease"/>
        public virtual void HandleKeyRelease(Keys k)
        {
        }

        /// <inheritdoc cref="IScene.HandleLeftClickHeld"/>
        public virtual void HandleLeftClickHeld(
            int x,
            int y
        ) {
        }

        /// <inheritdoc cref="IScene.HandleRightClickHeld"/>
        public virtual void HandleRightClickHeld(
            int x,
            int y
        ) {
        }

        /// <inheritdoc cref="IScene.HandleLeftClickReleased"/>
        public virtual void HandleLeftClickReleased (
            int x,
            int y
        ) {
        }

        /// <inheritdoc cref="IScene.HandleRightClickReleased"/>
        public virtual void HandleRightClickReleased(
            int x,
            int y
        ) {
        }

        /// <inheritdoc cref="IScene.GetEntities"/>
        public virtual IList<IEntity> GetEntities()
        {
            return new List<IEntity>(this._entities.Values);
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
        protected void UpdateEntities(GameTime time)
        {
            bool updateTransition = true;

            foreach (IEntity entity in this._entities.Values)
            {
                entity.Update(time);

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
                }
                else if (this._transitionState == TransitionState.Exiting)
                {
                    this._transitionState = TransitionState.Dead;
                }
            }
        }
    }
}
