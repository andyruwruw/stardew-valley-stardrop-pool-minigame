using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using MinigameFramework.Entities;
using MinigameFramework.Enums;
using MinigameFramework.Render.Filters;
using StardopPoolMinigame.Constants;
using StardopPoolMinigame.Enums;

namespace StardopPoolMinigame.Entities.Game
{
    class Cue : Entity
    {
        /// <summary>
        /// Whether this is the player's cue.
        /// </summary>
        protected bool _isPlayers;

        /// <summary>
        /// Style of cue.
        /// </summary>
        private CueType _type;

        /// <summary>
        /// Instantiates a pool cue.
        /// </summary>
        public Cue(
            Vector2 anchor,
            bool isPlayers,
            CueType type,
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
            _isPlayers = isPlayers;
            _type = type;
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
            return TextureConstants.Cue.Basic.Height;
        }

        /// <inheritdoc cref="IEntity.GetId"/>
        public override string GetId()
        {
            return $"cue-{_type}-{_isPlayers}-{_id}";
        }

        /// <inheritdoc cref="IEntity.GetWidth"/>
        public override float GetWidth()
        {
            return TextureConstants.Cue.Basic.Width;
        }

        /// <inheritdoc cref="EntityPhysics.Update"/>
		public override void Update(GameTime time)
        {
            base.Update(time);
        }
    }
}
