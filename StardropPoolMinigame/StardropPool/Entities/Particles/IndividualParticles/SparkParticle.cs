using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using MinigameFramework.Enums;
using MinigameFramework.Render.Filters;
using StardopPoolMinigame.Constants;
using MinigameFramework.Entities.Particles;
using StardopPoolMinigame.Render;

namespace StardopPoolMinigame.Entities.Particles.IndividualParticles
{
    class SparkParticle : Particle
    {
        /// <summary>
        /// Instantiates a sparkle particle.
        /// </summary>
        public SparkParticle(
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
        )
        {
        }

        /// <inheritdoc cref="IEntity.GetHeight"/>
        public override float GetHeight()
        {
            return TextureConstants.Particle.Spark.Frame1.Height;
        }

        /// <inheritdoc cref="IEntity.GetId"/>
        public override string GetId()
        {
            return $"particle-spark-{_id}";
        }

        /// <inheritdoc cref="IEntity.GetWidth"/>
        public override float GetWidth()
        {
            return TextureConstants.Particle.Spark.Frame1.Width;
        }

        /// <inheritdoc cref="EntityPhysics.Update"/>
		public override void Update(GameTime time)
        {
            base.Update(time);
        }

        /// <inheritdoc cref="Entity.GetTileset"/>
        protected override Texture2D? GetTileset()
        {
            return Textures.Tileset.Default;
        }
    }
}
