using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MinigameFramework.Enums;
using MinigameFramework.Entities;
using MinigameFramework.Render.Filters.Transitions;
using MinigameFramework.Utilities;
using StardopPoolMinigame.Constants;
using MinigameFramework.Entities.UI;
using MinigameFramework.Helpers;
using MinigameFramework.Constants;
using StardopPoolMinigame.Render;

namespace MinigameFramework.Scenes
{
    /// <inheritdoc cref="IScene"/>
    abstract class Scene : IScene
    {
        /// <summary>
        /// Whether a new scene is ready.
        /// </summary>
        protected bool _hasNewScene = false;

        /// <summary>
        /// New scene to replace 
        /// </summary>
        protected IScene? _newScene = null;

        /// <summary>
        /// Dictionary of <see cref="Scene">Scene's</see> <see cref="IEntity">IEntities</see>
        /// </summary>
        protected IDictionary<string, IEntity> _entities = new Dictionary<string, IEntity>();

        /// <summary>
        /// Dictionary of <see cref="Scene">Scene's</see> <see cref="IEntity">IEntities</see> that don't get updated.
        /// </summary>
        protected IList<IEntity> _staticEntities = new List<IEntity>();

        /// <summary>
        /// Current <see cref="TransitionState"/> of <see cref="Scene"/>
        /// </summary>
        protected TransitionState _transitionState = TransitionState.Entering;

        /// <summary>
        /// Whether to draw  black margins.
        /// </summary>
        protected bool _drawMargins = true;

        /// <summary>
        /// Instantiates a new scene.
        /// </summary>
        public Scene()
        {
            AddEntities();
            AddStaticEntities();
        }

        /// <inheritdoc cref="IScene.GetKey"/>
        public abstract string GetKey();

        /// <inheritdoc cref="IScene.HasNewScene"/>
        public bool HasNewScene()
        {
            return _hasNewScene;
        }

        /// <inheritdoc cref="IScene.GetNewScene"/>
        public IScene? GetNewScene()
        {
            return _newScene;
        }

        /// <inheritdoc cref="IScene.Start"/>
        public virtual void Start()
        {
        }

        /// <inheritdoc cref="IScene.Update"/>
        public virtual void Update(GameTime time)
        {
            // Logger.Debug($"Updating Scene ${time.ToString()}");
            UpdateEntities(time);
        }

        /// <inheritdoc cref="IScene.Draw"/>
        public virtual void Draw(SpriteBatch batch)
        {
            foreach (IEntity entity in _staticEntities)
            {
                entity.Draw(batch);
            }

            IList<IEntity> entities = GetEntities();

            foreach (IEntity entity in entities)
            {
                entity.Draw(batch);
            }
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
            return new List<IEntity>(_entities.Values);
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
        /// Add a set of static entities.
        /// </summary>
        protected virtual void AddStaticEntities()
        {
            // Background
            _staticEntities.Add(new Solid(
                GenericTextureConstants.Color.Solid.Background,
                new Vector2(
                    0,
                    0
                ),
                GenericRenderConstants.MinigameScreen.Width,
                GenericRenderConstants.MinigameScreen.Height,
                0.0000f,
                Origin.TopLeft,
                null,
                null
            ));

            // Foreground
            if (!DevConstants.DisableMarginSolids)
            {
                _staticEntities.Add(new Solid(
                    Color.Black,
                    RenderHelpers.ConvertRawToAdjustedScreen(new Vector2(
                        0,
                        0
                    )),
                    RenderHelpers.AdjustedScreen.Margin.Width() / RenderHelpers.TileScale(),
                    RenderHelpers.Viewport.Height() / RenderHelpers.TileScale(),
                    0.9000f,
                    Origin.TopLeft,
                    null,
                    null
                ));
                _staticEntities.Add(new Solid(
                    Color.Black,
                    RenderHelpers.ConvertRawToAdjustedScreen(new Vector2(
                        RenderHelpers.AdjustedScreen.Margin.Width() + RenderHelpers.AdjustedScreen.Width(),
                        0
                    )),
                    RenderHelpers.AdjustedScreen.Margin.Width() / RenderHelpers.TileScale(),
                    RenderHelpers.Viewport.Height() / RenderHelpers.TileScale(),
                    0.9000f,
                    Origin.TopLeft,
                    null,
                    null
                ));
                _staticEntities.Add(new Solid(
                    Color.Black,
                    RenderHelpers.ConvertRawToAdjustedScreen(new Vector2(
                        RenderHelpers.AdjustedScreen.Margin.Width(),
                        0
                    )),
                    RenderHelpers.AdjustedScreen.Width() / RenderHelpers.TileScale(),
                    RenderHelpers.AdjustedScreen.Margin.Height() / RenderHelpers.TileScale(),
                    0.9000f,
                    Origin.TopLeft,
                    null,
                    null
                ));
                _staticEntities.Add(new Solid(
                    Color.Black,
                    new Vector2(
                        0,
                        GenericRenderConstants.MinigameScreen.Height
                    ),
                    RenderHelpers.AdjustedScreen.Width() / RenderHelpers.TileScale(),
                    RenderHelpers.AdjustedScreen.Margin.Height() / RenderHelpers.TileScale(),
                    0.9000f,
                    Origin.TopLeft,
                    null,
                    null
                ));
            }
        }

        /// <summary>
        /// Updates all scene specific <see cref="IEntity">IEntities</see> from <see cref="Scene._entities"/>
        /// </summary>
        protected void UpdateEntities(GameTime time)
        {
            bool updateTransition = true;

            foreach (IEntity entity in _entities.Values)
            {
                entity.Update(time);

                // Set Entity Exiting if Scene Exiting
                if (_transitionState == TransitionState.Exiting
                    && (entity.GetTransitionState() != TransitionState.Exiting && entity.GetTransitionState() != TransitionState.Dead))
                {
                    entity.SetTransitionState(TransitionState.Exiting, true);
                }

                // Check if entities are finished transitioning
                if (_transitionState == TransitionState.Entering
                    && entity.GetEnteringTransition() != null
                    && !((Transition)entity.GetEnteringTransition()).IsFinished())
                {
                    updateTransition = false;
                }
                if (_transitionState == TransitionState.Exiting
                    && entity.GetExitingTransition() != null
                    && !((Transition)entity.GetExitingTransition()).IsFinished())
                {
                    updateTransition = false;
                }
            }

            // If finished transitioning, update transition state
            if (_transitionState != TransitionState.Present && updateTransition)
            {
                if (_transitionState == TransitionState.Entering)
                {
                    _transitionState = TransitionState.Present;
                }
                else if (_transitionState == TransitionState.Exiting)
                {
                    _transitionState = TransitionState.Dead;
                }
            }
        }
    }
}
