﻿using Microsoft.Xna.Framework.Graphics;
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
            Vector2 anchor,
            float layerDepth = 0,
            Origin origin = Origin.CenterCenter,
            IFilter? enteringTransition = null,
            IFilter? exitingTransition = null
        ) : base(
            anchor,
            layerDepth,
            origin,
            enteringTransition,
            exitingTransition
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
