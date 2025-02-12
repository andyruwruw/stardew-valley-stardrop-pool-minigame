using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MinigameFramework.Enums;
using MinigameFramework.Entities;
using MinigameFramework.Render.Filters.Transitions;
using MinigameFramework.Entities.UI;
using MinigameFramework.Helpers;
using MinigameFramework.Constants;

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
        /// Main section entity.
        /// </summary>
        protected Section? _section = null;

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
            // Create container section.
            _section = new Section(
                parent: null,
                key: GetKey(),
                children: InitializeEntities(),
                layerDepth: 0.0010f
            );
            InitializeStaticEntities();
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

            if (_section != null)
            {
                _section.Draw(batch);
            }
        }

        /// <inheritdoc cref="IScene.HandleClick"/>
        public virtual void HandleClick(
            int x,
            int y
        ) {
            if (_section != null)
            {
                _section.UpdateClick();
            }
        }

        /// <inheritdoc cref="IScene.HandleRightClick"/>
        public virtual void HandleRightClick(
            int x,
            int y
        ) {
            if (_section != null)
            {
                _section.UpdateRightClick();
            }
        }

        /// <inheritdoc cref="IScene.HandleKeyPress"/>
        public virtual void HandleKeyPress(Keys key)
        {
            if (_section != null)
            {
                _section.UpdateKeyPress(key);
            }
        }

        /// <inheritdoc cref="IScene.HandleKeyReleased"/>
        public virtual void HandleKeyReleased(Keys key)
        {
            if (_section != null)
            {
                _section.UpdateKeyReleased(key);
            }
        }

        /// <inheritdoc cref="IScene.HandleClickHeld"/>
        public virtual void HandleClickHeld(
            int x,
            int y
        )
        {
            if (_section != null)
            {
                _section.HandleClickHeld();
            }
        }

        /// <inheritdoc cref="IScene.HandleRightClickHeld"/>
        public virtual void HandleRightClickHeld(
            int x,
            int y
        )
        {
            if (_section != null)
            {
                _section.HandleRightClickHeld();
            }
        }

        /// <inheritdoc cref="IScene.HandleClickReleased"/>
        public virtual void HandleClickReleased (
            int x,
            int y
        )
        {
            if (_section != null)
            {
                _section.UpdateClickReleased();
            }
        }

        /// <inheritdoc cref="IScene.HandleRightClickReleased"/>
        public virtual void HandleRightClickReleased(
            int x,
            int y
        )
        {
            if (_section != null)
            {
                _section.UpdateRightClickReleased();
            }
        }

        /// <inheritdoc cref="IScene.GetTransitionState"/>
        public virtual TransitionState GetTransitionState()
        {
            return _transitionState;
        }

        /// <inheritdoc cref="IScene.GetTransitionState"/>
        public virtual void SetTransitionState(TransitionState state) {
            _transitionState = state;

            if (state == TransitionState.Entering || state == TransitionState.Exiting)
            {
                foreach (IEntity entity in _entities.Values)
                {
                    entity.SetTransitionState(TransitionState.Entering, true);
                }
            }
        }

        /// <summary>
        /// <para>Overrideable method to add <see cref="Scene"/> specific <see cref="IEntity">IEntities</see></para>
        /// <para>Automatically called in <see cref="Scene"/> constructor</para>
        /// <para>Should add <see cref="IEntity">IEntities</see> to <see cref="_entities"/> protected <see cref="IList"/>, which will already be instantiated</para>
        /// </summary>
        protected virtual IList<IEntity> InitializeEntities()
        {
            return new List<IEntity>();
        }

        /// <summary>
        /// Add a set of static entities.
        /// </summary>
        protected virtual void InitializeStaticEntities()
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
