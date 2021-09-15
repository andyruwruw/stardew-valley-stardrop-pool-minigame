using Microsoft.Xna.Framework;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Render;
using StardropPoolMinigame.Render.Filters;

namespace StardropPoolMinigame.Entities
{
    internal class PurpleWhisp : Particle
    {
        public PurpleWhisp(
            Vector2 anchor,
            float layerDepth,
            IFilter enteringTransition,
            IFilter exitingTransition,
            Vector2 maximumInitialVelcity,
            Vector2 minimumInitialVelcity
        ) : base(
            Origin.CenterCenter,
            anchor,
            layerDepth,
            enteringTransition,
            exitingTransition,
            GameConstants.Particle.PurpleWhisp.PERCEPTION_RADIUS,
            GameConstants.Particle.PurpleWhisp.ALIGNMENT_STRENGTH,
            GameConstants.Particle.PurpleWhisp.COHESION_STRENGTH,
            GameConstants.Particle.PurpleWhisp.SEPARATION_STRENGTH,
            GameConstants.Particle.PurpleWhisp.MAXIMUM_VELOCITY,
            GameConstants.Particle.PurpleWhisp.MAXIMUM_FORCE,
            Vector2.Multiply(maximumInitialVelcity, GameConstants.Particle.PurpleWhisp.MAXIMUM_INITIAL_VELOCITY_SCOLAR),
            Vector2.Multiply(minimumInitialVelcity, GameConstants.Particle.PurpleWhisp.MINIMUM_INITIAL_VELOCITY_SCOLAR),
            GameConstants.Particle.PurpleWhisp.LIFESPAN)
        {
        }

        public override string GetId()
        {
            return $"particle-purple-whisp-{this._id}";
        }

        public override float GetTotalHeight()
        {
            return Textures.Particle.PurpleWhisp.FRAME_1.Height;
        }

        public override float GetTotalWidth()
        {
            return Textures.Particle.PurpleWhisp.FRAME_1.Width;
        }
    }
}