using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using MinigameFramework.Enums;
using MinigameFramework.Render.Filters;
using MinigameFramework.Entities;
using StardopPoolMinigame.Constants;
using StardopPoolMinigame.Render;

namespace StardopPoolMinigame.Entities.Game
{
    /// <summary>
    /// Displays pocketed balls.
    /// </summary>
    class PocketedBallsIndicator : Entity
    {
        /// <summary>
        /// Balls to display.
        /// </summary>
        protected IList<Ball> _balls;

        /// <summary>
        /// Instantiates a pocketed-balls indicator.
        /// </summary>
        public PocketedBallsIndicator(
            IEntity? parent = null,
            string? key = null,
            Vector2? anchor = null,
            Position? position = Position.Relative,
            IList<IEntity>? children = null,
            float? layerDepth = null,
            bool? isHoverable = false,
            bool? isInteractable = false,
            IFilter? enteringTransition = null,
            IFilter? exitingTransition = null,
            bool? isRow = false,
            bool? centerContent = false,
            bool? center = false,
            Vector2? contentOffset = null,
            bool? fixedPosition = true,
            float? gap = 0f,
            float? height = -1f,
            float? margin = 0f,           
            float? marginBottom = 0f,
            float? marginLeft = 0f,
            float? marginRight = 0f,
            float? marginTop = 0f,
            float? maxHeight = -1f,
            float? maxWidth = -1f,
            float? minHeight = -1f,
            float? minWidth = -1f,
            bool? overflow = false,
            float? padding = 0f,
            float? paddingBottom = 0f,
            float? paddingLeft = 0f,
            float? paddingRight = 0f,
            float? paddingTop = 0f,
            float? width = -1f
        ) : base(
            parent,
            key,
            anchor,
            position,
            children,
            layerDepth,
            isHoverable,
            isInteractable,
            enteringTransition,
            exitingTransition,
            isRow,
            centerContent,
            center,
            contentOffset,
            fixedPosition,
            gap,
            height,
            margin,
            marginBottom,
            marginLeft,
            marginRight,
            marginTop,
            maxHeight,
            maxWidth,
            minHeight,
            minWidth,
            overflow,
            padding,
            paddingBottom,
            paddingLeft,
            paddingRight,
            paddingTop,
            width
        )
        {
            _balls = new List<Ball>();
        }

        /// <summary>
        /// Add a ball to the list.
        /// </summary>
        public void Add(Ball ball)
        {
            _balls.Add(ball);
        }

        /// <summary>
        /// Get a ball at a given index.
        /// </summary>
        public Ball Get(int index)
        {
            return _balls[index];
        }

        /// <summary>
        /// Clear the indicator of balls.
        /// </summary>
        public void Clear()
        {
            _balls.Clear();
        }

        /// <summary>
        /// Retrieve the number of balls in the indicator.
        /// </summary>
        public int Count()
        {
            return _balls.Count();
        }

        /// <inheritdoc cref="IEntity.Draw"/>
        public override void Draw(
            SpriteBatch batch,
            Vector2? overrideDestination = null,
            Rectangle? overrideSource = null,
            Color? overrideColor = null,
            float? overrideRotation = null,
            Vector2? overrideOrigin = null,
            float? overrideScale = null,
            SpriteEffects? overrideEffects = null,
            float? overrideLayerDepth = null
        )
        {
            foreach (Ball ball in  _balls)
            {
                if (ball != null)
                {
                    ball.Draw(
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
                }
            }
        }

        /// <inheritdoc cref="IEntity.GetHeight"/>
        public override float GetHeight()
        {
            return TextureConstants.PocketedBalls.BorderBox.Height + TextureConstants.PocketedBalls.Supports.Height;
        }

        /// <inheritdoc cref="IEntity.GetName"/>
        public override string GetName()
        {
            return $"pocketed-balls-indicator-{_key}";
        }

        /// <inheritdoc cref="IEntity.GetWidth"/>
        public override float GetWidth()
        {
            return TextureConstants.PocketedBalls.BorderBox.Width;
        }

        /// <summary>
        /// Get the index of a given ball in the indicator.
        /// </summary>
        public int IndexOf(Ball ball)
        {
            return _balls.IndexOf(ball);
        }

        /// <summary>
        /// Remove a ball from the indicator.
        /// </summary>
        public bool Remove(Ball item)
        {
            return _balls.Remove(item);
        }

        /// <inheritdoc cref="EntityPhysics.Update"/>
		public override void Update(GameTime time)
        {
            base.Update(time);

            foreach (Ball ball in _balls)
            {
                if (ball != null)
                {
                    ball.Update(time);
                }
            }
        }

        /// <inheritdoc cref="Entity.GetTileset"/>
        protected override Texture2D? GetTileset()
        {
            return Textures.Tileset.Default;
        }
    }
}
