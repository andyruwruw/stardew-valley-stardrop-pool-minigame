using Microsoft.Xna.Framework;
using MinigameFramework.Constants;
using MinigameFramework.Enums;
using MinigameFramework.Render.Filters;

namespace MinigameFramework.Entities.UI.Portraits
{
    /// <summary>
    /// Displays a NPC's portrait.
    /// </summary>
    class Portrait : Entity
    {
        /// <summary>
        /// NPC being displayed.
        /// </summary>
        protected DisplayableNPC _name;

        /// <summary>
        /// Emotion the portrait is depicting.
        /// </summary>
        protected PortraitEmotion _emotion;

        /// <summary>
        /// Scale the portrait.
        /// </summary>
        protected float _scale;

        /// <summary>
        /// Whether to display the portrait darker.
        /// </summary>
        protected bool _isDarker;

        /// <summary>
        /// Whether the portrait can be hovered.
        /// </summary>
        protected bool _isHoverable;

        /// <summary>
        /// Whether the portrait is on fire.
        /// </summary>
        protected bool _isOnFire;

        /// <summary>
        /// Whether the portrait is shining.
        /// </summary>
        protected bool _isShining;

        /// <summary>
        /// Whether the portrait is a silhouette.
        /// </summary>
        protected bool _isSilhouette;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">NPC's name.</param>
        /// <param name="anchor"><see cref="Entity">Entity's</see> anchor, or position<inheritdoc cref="_anchor"/></param>
        /// <param name="emotion">What emotion to display.</param>
		/// <param name="layerDepth"><see cref="Entity">Entity's</see> layer depth for rendering</param>
		/// <param name="origin">Anchor's relation to <see cref="Entity">Entity's</see> position</param>
		/// <param name="enteringTransition"><see cref="Entity">Entity's</see> entering <see cref="Transition"/></param>
		/// <param name="exitingTransition"><see cref="Entity">Entity's</see> exiting <see cref="Transition"/></param>
        /// <param name="scale">Scale the portrait.</param>
        public Portrait(
            DisplayableNPC name,
            Vector2 anchor,
            PortraitEmotion emotion = PortraitEmotion.Default,
            float layerDepth = 0,
            Origin origin = Origin.TopLeft,
            IFilter? enteringTransition = null,
            IFilter? exitingTransition = null,
            float scale = 1f,
            bool isDarker = false,
            bool isHoverable = false,
            bool isOnFire = false,
            bool isShining = false,
            bool isSilhouette = false
        ) : base(
            anchor,
            layerDepth,
            origin,
            enteringTransition,
            exitingTransition
        ) {
            _name = name;
            _emotion = emotion;
            _scale = scale;
            _isDarker = isDarker;
            _isHoverable = isHoverable;
            _isOnFire = isOnFire;
            _isShining = isShining;
            _isSilhouette = isSilhouette;
        }

        /// <summary>
        /// Retrieves the portrait's emotion.
        /// </summary>
        public PortraitEmotion GetEmotion()
        {
            return this._emotion;
        }

        /// <inheritdoc cref="IEntity.GetId"/>
        public override string GetId()
        {
            return $"portrait-{this._id}";
        }

        /// <summary>
        /// Retrieve who this portrait is of.
        /// </summary>
        public DisplayableNPC GetNPC()
        {
            return this._name;
        }

        /// <summary>
        /// Get the scale of the portrait.
        /// </summary>
        public float GetScale()
        {
            return this._scale;
        }

        /// <inheritdoc cref="IEntity.GetHeight"/>
        public override float GetHeight()
        {
            return GenericTextureConstants.Portrait.Sam.DEFAULT.Height;
        }

        /// <inheritdoc cref="IEntity.GetWidth"/>
        public override float GetWidth()
        {
            return GenericTextureConstants.Portrait.Sam.DEFAULT.Width;
        }
    }
}
