using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MinigameFramework.Attributes;
using MinigameFramework.Constants;
using MinigameFramework.Entities;
using MinigameFramework.Enums;
using MinigameFramework.Helpers;
using MinigameFramework.Render.Filters;
using MinigameFramework.Structures.Primitives;
using MinigameFramework.Utilities;
using StardopPoolMinigame.Constants;
using StardopPoolMinigame.Enums;
using StardopPoolMinigame.Render;
using StardopPoolMinigame.Render.Filters.Animations;

namespace StardopPoolMinigame.Entities.Game
{
    class Ball : Entity
    {
        /// <summary>
        /// Filter for ball highlighting.
        /// </summary>
        protected static IFilter _flashingFilter = new BallFlashingAnimation("static");

        /// <summary>
        /// Orientation of the ball.
        /// </summary>
        protected Orientation _orientation;

        /// <summary>
        /// Physical attributes of the ball.
        /// </summary>
        protected Physics _physics;

        /// <summary>
        /// Ball number.
        /// </summary>
        protected int _number;

        /// <summary>
        /// Radius of the ball.
        /// </summary>
        protected float _radius;

        /// <summary>
        /// Whether the ball is flashing.
        /// </summary>
        protected bool _isFlashing;

        /// <summary>
        /// Whether the ball is highlighted.
        /// </summary>
        protected bool _isHighlighted;

        /// <summary>
        /// Whether the ball is pocketed.
        /// </summary>
        protected bool _isPocketed;

        /// <summary>
        /// Instantiates a ball.
        /// </summary>
        /// <param name="anchor"><see cref="Entity">Entity's</see> anchor, or position<inheritdoc cref="_anchor"/></param>
		/// <param name="layerDepth"><see cref="Entity">Entity's</see> layer depth for rendering</param>
		/// <param name="origin">Anchor's relation to <see cref="Entity">Entity's</see> position</param>
		/// <param name="enteringTransition"><see cref="Entity">Entity's</see> entering <see cref="Transition"/></param>
		/// <param name="exitingTransition"><see cref="Entity">Entity's</see> exiting <see cref="Transition"/></param>
        public Ball(
            Vector2 anchor,
            int number = 0,
            float layerDepth = 0,
            Origin origin = Origin.CenterCenter,
            IFilter? enteringTransition = null,
            IFilter? exitingTransition = null,
            bool isFlashing = false,
            bool isHighlighted = false,
            bool isPocketed = false
        ) : base(
            anchor,
            layerDepth,
            origin,
            enteringTransition,
            exitingTransition
        ) {
            _number = number;
            _isFlashing = isFlashing;
            _isHighlighted = isHighlighted;
            _isPocketed= isPocketed;
            _radius = GameConstants.Ball.Radius;

            _orientation = new Orientation(_radius);
            _physics = new Physics(GetCenter());
        }

        /// <inheritdoc cref="IEntity.Draw"/>
        public override void Draw(
            SpriteBatch batch,
            Vector2? overrideDestination = null,
            Microsoft.Xna.Framework.Rectangle? overrideSource = null,
            Color? overrideColor = null,
            float? overrideRotation = null,
            Vector2? overrideOrigin = null,
            float? overrideScale = null,
            SpriteEffects? overrideEffects = null,
            float? overrideLayerDepth = null
        ) {
            DrawBase(
                batch,
                overrideDestination,
                overrideSource,
                overrideColor,
                overrideRotation,
                overrideOrigin,
                overrideScale,
                overrideEffects,
                overrideLayerDepth
            );

            if (GetBallType() != BallType.White)
            {
                DrawCore(
                    batch,
                    overrideDestination,
                    overrideRotation,
                    overrideOrigin,
                    overrideScale,
                    overrideEffects,
                    overrideLayerDepth
                );

                DrawStripes(
                    batch,
                    overrideDestination,
                    overrideRotation,
                    overrideOrigin,
                    overrideScale,
                    overrideEffects,
                    overrideLayerDepth
                );
            }

            DrawShadows(
                batch,
                overrideDestination,
                overrideRotation,
                overrideOrigin,
                overrideScale,
                overrideEffects,
                overrideLayerDepth
            );

            if (IsHighlighted() || IsFlashing())
            {
                DrawHighlight(
                    batch,
                    overrideDestination,
                    overrideRotation,
                    overrideOrigin,
                    overrideScale,
                    overrideEffects,
                    overrideLayerDepth
                );
            }

            if (DevConstants.DebugVisuals)
            {
                DrawDebug(batch);
            }
        }

        /// <summary>
        /// Gets the ball's type.
        /// </summary>
        public BallType GetBallType()
        {
            if (_number == 0)
            {
                return BallType.White;
            }

            float type = MiscellaneousHelpers.Modulo(
                _number - 1,
                15
            );

            if (type < 8)
            {
                return BallType.Solid;
            }

            return BallType.Stripped;
        }

        /// <inheritdoc cref="Entity.GetBoundary"/>
		public override IRange GetBoundary()
        {
            return new Circle(
                _anchor,
                GetRadius()
            );
        }

        /// <summary>
        /// Gets the ball's color.
        /// </summary>
        public BallColor GetBallColor()
        {
            if (_number == 0)
            {
                return BallColor.White;
            }

            switch (MiscellaneousHelpers.Modulo(
                _number,
                8
            )) {
                case 1:
                    return BallColor.Yellow;
                case 2:
                    return BallColor.Blue;
                case 3:
                    return BallColor.Red;
                case 4:
                    return BallColor.Purple;
                case 5:
                    return BallColor.Orange;
                case 6:
                    return BallColor.Green;
                case 7:
                    return BallColor.Maroon;
                default:
                    return BallColor.Black;
            }
        }

        /// <inheritdoc cref="IEntity.GetHeight"/>
        public override float GetHeight()
        {
            return TextureConstants.Ball.Base.White.Height;
        }

        /// <inheritdoc cref="IEntity.GetId"/>
        public override string GetId()
        {
            return $"ball-{GetBallType()}-{_number}-{_id}";
        }

        /// <summary>
        /// Gets the ball's orientation.
        /// </summary>
        public Orientation GetOrientation()
        {
            return _orientation;
        }

        /// <summary>
        /// Retrieves the ball's radius.
        /// </summary>
        public float GetRadius()
        {
            return _radius;
        }

        /// <inheritdoc cref="IEntity.GetRawSource"/>
        public override Microsoft.Xna.Framework.Rectangle GetRawSource()
        {
            return Textures.GetBallBase(GetBallColor());
        }

        /// <inheritdoc cref="IEntity.GetWidth"/>
        public override float GetWidth()
        {
            return TextureConstants.Ball.Base.White.Width;
        }

        /// <summary>
        /// Whether the pool ball is flashing.
        /// </summary>
        public bool IsFlashing()
        {
            return _isFlashing;
        }

        /// <summary>
        /// Whether the pool ball is highlighted.
        /// </summary>
        public bool IsHighlighted()
        {
            return _isHighlighted;
        }

        /// <summary>
        /// Whether the pool ball is pocketed.
        /// </summary>
        public bool IsPocketed()
        {
            return _isPocketed;
        }

        /// <summary>
        /// Sets whether the ball is flashing.
        /// </summary>
        public void SetFlashing(bool isFlashing)
        {
            _isFlashing = isFlashing;
        }

        /// <summary>
        /// Sets whether the ball is highlighted.
        /// </summary>
        public void SetHighlighted(bool isHighlighted)
        {
            _isHighlighted = isHighlighted;
        }

        /// <summary>
        /// Changes the number (and maybe type) of the ball.
        /// </summary>
        public void SetNumber(int number)
        {
            _number = number;
        }

        /// <summary>
        /// Sets whether the ball is pocketed..
        /// </summary>
        public void SetPocketed(bool isPocketed)
        {
            _isPocketed = isPocketed;
        }

        /// <summary>
        /// Switches the ball from solids to stripes.
        /// </summary>
        public void SwitchType(int number)
        {
            if (_number == 0)
            {
                return;
            }

            if (_number == 8)
            {
                _number = 15;
            }
            else if (_number < 9)
            {
                _number = _number + 8;
            } else
            {
                _number = _number - 8;
            }
        }

        /// <inheritdoc cref="EntityPhysics.Update"/>
		public override void Update(GameTime time)
        {
            base.Update(time);
        }

        /// <summary>
        /// Draws the base object.
        /// </summary>
        protected void DrawBase(
            SpriteBatch batch,
            Vector2? overrideDestination = null,
            Microsoft.Xna.Framework.Rectangle? overrideSource = null,
            Color? overrideColor = null,
            float? overrideRotation = null,
            Vector2? overrideOrigin = null,
            float? overrideScale = null,
            SpriteEffects? overrideEffects = null,
            float? overrideLayerDepth = null
        ) {
            batch.Draw(
                GetTileset(),
                GetDestination(overrideDestination),
                GetSource(overrideSource),
                GetColor(overrideColor),
                GetRotation(overrideRotation),
                GetOrigin(overrideOrigin),
                GetScale(overrideScale),
                GetEffects(overrideEffects),
                GetLayerDepth(overrideLayerDepth)
            );
        }

        /// <summary>
        /// Draws the white core.
        /// </summary>
        protected void DrawCore(
            SpriteBatch batch,
            Vector2? overrideDestination = null,
            float? overrideRotation = null,
            Vector2? overrideOrigin = null,
            float? overrideScale = null,
            SpriteEffects? overrideEffects = null,
            float? overrideLayerDepth = null
        ) {
            batch.Draw(
                GetTileset(),
                GetDestination(overrideDestination),
                GetCoreSource(),
                GetColor(),
                GetRotation(overrideRotation),
                GetOrigin(overrideOrigin),
                GetScale(overrideScale),
                GetEffects(overrideEffects),
                GetLayerDepth(overrideLayerDepth) + 0.0001f
            );
        }

        /// <inheritdoc cref="Entity.DrawDebug"/>
        protected override void DrawDebug(SpriteBatch batch)
        {
            RenderHelpers.DrawDebugPoint(
                batch,
                GetCenter()
            );

            RenderHelpers.DrawDebugPhysics(
                batch,
                _physics
            );

            RenderHelpers.DrawDebugCircle(
                batch,
                GetCenter(),
                ((Circle)GetBoundary()).GetRadius(),
                Color.Gold
            );

            RenderHelpers.DrawDebugCircle(
                batch,
                GetCenter(),
                ((Circle)GetBoundary()).GetRadius() * 2,
                Color.White
            );
        }

        /// <summary>
        /// Draws the highlighted portion of the ball.
        /// </summary>
        protected void DrawHighlight(
            SpriteBatch batch,
            Vector2? overrideDestination = null,
            float? overrideRotation = null,
            Vector2? overrideOrigin = null,
            float? overrideScale = null,
            SpriteEffects? overrideEffects = null,
            float? overrideLayerDepth = null
        ) {
            batch.Draw(
                GetTileset(),
                GetDestination(overrideDestination),
                TextureConstants.Ball.Highlight,
                IsFlashing() ? Ball._flashingFilter.GetColor(GetColor()) : GetColor(),
                GetRotation(overrideRotation),
                GetOrigin(overrideOrigin),
                GetScale(overrideScale),
                GetEffects(overrideEffects),
                GetLayerDepth(overrideLayerDepth) + 0.0003f
            );
        }

        /// <summary>
        /// Draws the ball shadow.
        /// </summary>
        protected void DrawShadows(
            SpriteBatch batch,
            Vector2? overrideDestination = null,
            float? overrideRotation = null,
            Vector2? overrideOrigin = null,
            float? overrideScale = null,
            SpriteEffects? overrideEffects = null,
            float? overrideLayerDepth = null
        ) {
            batch.Draw(
                GetTileset(),
                GetDestination(overrideDestination),
                TextureConstants.Ball.Shadow,
                GetColor(),
                GetRotation(overrideRotation),
                GetOrigin(overrideOrigin),
                GetScale(overrideScale),
                GetEffects(overrideEffects),
                GetLayerDepth(overrideLayerDepth) + 0.0002f
            );
        }

        /// <summary>
        /// Draws the ball's stripes if applicable.
        /// </summary>
        protected void DrawStripes(
            SpriteBatch batch,
            Vector2? overrideDestination = null,
            float? overrideRotation = null,
            Vector2? overrideOrigin = null,
            float? overrideScale = null,
            SpriteEffects? overrideEffects = null,
            float? overrideLayerDepth = null
        ) {
            if (GetBallType() == BallType.Stripped)
            {
                batch.Draw(
                    GetTileset(),
                    GetDestination(overrideDestination),
                    GetStripeSource(),
                    GetColor(),
                    GetRotation(overrideRotation),
                    GetOrigin(overrideOrigin),
                    GetScale(overrideScale),
                    GetEffects(overrideEffects),
                    GetLayerDepth(overrideLayerDepth) + 0.0001f);
            }
        }

        /// <summary>
        /// Retrieves the source for the core.
        /// </summary>
        protected Microsoft.Xna.Framework.Rectangle GetCoreSource()
        {
            return Textures.GetBallCoreBounds(GetOrientation().GetFace());
        }

        /// <inheritdoc cref="Entity.GetRawDestination"/>
        protected override Vector2 GetRawDestination()
        {
            Vector2 topLeft = GetTopLeft();

            return RenderHelpers.ConvertAdjustedScreenToRaw(new Vector2(
                topLeft.X - RenderConstants.Entities.Ball.MarginLeft,
                topLeft.Y - RenderConstants.Entities.Ball.MarginTop
            ));
        }

        /// <summary>
        /// Retrieves the source for the stripes if needed.
        /// </summary>
        protected Microsoft.Xna.Framework.Rectangle GetStripeSource()
        {
            return Textures.GetBallStripesBounds(GetOrientation().GetFace());
        }

        /// <inheritdoc cref="Entity.GetTileset"/>
        protected override Texture2D? GetTileset()
        {
            return Textures.Tileset.Default;
        }
    }
}
