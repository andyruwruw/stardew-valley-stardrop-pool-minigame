using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;
using MinigameFramework.Constants;
using MinigameFramework.Enums;
using MinigameFramework.Render.Filters;
using MinigameFramework.Utilities;
using xTile.Tiles;
using MinigameFramework.Helpers;

namespace MinigameFramework.Entities.UI.Portraits
{
    /// <summary>
    /// Displays a NPC's portrait.
    /// </summary>
    class Portrait : Entity
    {
        /// <summary>
        /// Loaded texture.
        /// </summary>
        protected Texture2D? _texture = null;

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
        /// Instantiates a portrait display.
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
            return _emotion;
        }

        /// <inheritdoc cref="IEntity.GetName"/>
        public override string GetName()
        {
            return $"portrait-{_key}";
        }

        /// <summary>
        /// Retrieve who this portrait is of.
        /// </summary>
        public DisplayableNPC GetNpc()
        {
            return _name;
        }

        /// <summary>
        /// Get the scale of the portrait.
        /// </summary>
        public float GetScale()
        {
            return _scale;
        }

        /// <inheritdoc cref="IEntity.GetHeight"/>
        public override float GetHeight()
        {
            return GenericTextureConstants.Portrait.Size;
        }

        /// <inheritdoc cref="IEntity.GetWidth"/>
        public override float GetWidth()
        {
            return GenericTextureConstants.Portrait.Size;
        }

        /// <summary>
        /// Whether the portrait is displayed darker.
        /// </summary>
        public bool IsDarker()
        {
            return _isDarker;
        }

        /// <summary>
        /// Whether the portrait is flaming.
        /// </summary>
        public bool IsOnFire()
        {
            return _isOnFire;
        }

        /// <summary>
        /// Whether the portrait is shining.
        /// </summary>
        public bool IsShining()
        {
            return _isShining;
        }

        /// <summary>
        /// Whether the portrait is a silhouette.
        /// </summary>
        public bool IsSilhouette()
        {
            return _isSilhouette;
        }

        /// <summary>
        /// Retrieves the NPC's name.
        /// </summary>
        protected string GetNpcName()
        {
            switch (_name)
            {
                case (DisplayableNPC.Abigail):
                    return "Abigail";
                case (DisplayableNPC.Alex):
                    return "Alex";
                case (DisplayableNPC.Bear):
                    return "Bear";
                case (DisplayableNPC.Birdie):
                    return "Birdie";
                case (DisplayableNPC.Bouncer):
                    return "Bouncer";
                case (DisplayableNPC.Caroline):
                    return "Caroline";
                case (DisplayableNPC.Clint):
                    return "Clint";
                case (DisplayableNPC.Demetrius):
                    return "Demetrius";
                case (DisplayableNPC.Dwarf):
                    return "Dwarf";
                case (DisplayableNPC.Elliot):
                    return "Elliot";
                case (DisplayableNPC.Emily):
                    return "Emily";
                case (DisplayableNPC.Evelyn):
                    return "Evelyn";
                case (DisplayableNPC.Fizz):
                    return "Fizz";
                case (DisplayableNPC.George):
                    return "George";
                case (DisplayableNPC.Gil):
                    return "Gil";
                case (DisplayableNPC.Governor):
                    return "Governor";
                case (DisplayableNPC.Grandpa):
                    return "Grandpa";
                case (DisplayableNPC.Gunther):
                    return "Gunther";
                case (DisplayableNPC.Gus):
                    return "Gus";
                case (DisplayableNPC.Haley):
                    return "Haley";
                case (DisplayableNPC.Harvey):
                    return "Harvey";
                case (DisplayableNPC.Henchman):
                    return "Henchman";
                case (DisplayableNPC.Jas):
                    return "Jas";
                case (DisplayableNPC.Jodi):
                    return "Jodi";
                case (DisplayableNPC.Kent):
                    return "Kent";
                case (DisplayableNPC.Krobus):
                    return "Krobus";
                case (DisplayableNPC.Leah):
                    return "Leah";
                case (DisplayableNPC.Leo):
                    return "ParrotBoy";
                case (DisplayableNPC.Lewis):
                    return "Lewis";
                case (DisplayableNPC.Linus):
                    return "Linus";
                case (DisplayableNPC.Marlon):
                    return "Marlon";
                case (DisplayableNPC.Marnie):
                    return "Marnie";
                case (DisplayableNPC.Maru):
                    return "Maru";
                case (DisplayableNPC.Morris):
                    return "Morris";
                case (DisplayableNPC.Mr_Qi):
                    return "MrQi";
                case (DisplayableNPC.Pam):
                    return "Pam";
                case (DisplayableNPC.Penny):
                    return "Penny";
                case (DisplayableNPC.Pierre):
                    return "Pierre";
                case (DisplayableNPC.Professor_Snail):
                    return "SafariGuy";
                case (DisplayableNPC.Robin):
                    return "Robin";
                case (DisplayableNPC.Sam):
                    return "Sam";
                case (DisplayableNPC.Sandy):
                    return "Sandy";
                case (DisplayableNPC.Sebastian):
                    return "Sebastian";
                case (DisplayableNPC.Shane):
                    return "Shane";
                case (DisplayableNPC.Vincent):
                    return "Vincent";
                case (DisplayableNPC.Willy):
                    return "Willy";
                case (DisplayableNPC.Wizard):
                    return "Wizard";
                default:
                    return "Abigail";
            }
        }

        /// <summary>
        /// Color before filters.
        /// </summary>
        protected override Color GetRawColor()
        {
            if (IsSilhouette())
            {
                return Color.Black;
            }
            if (IsDarker())
            {
                return GenericTextureConstants.Color.Shader.Shadowed;
            }
            return Color.White;
        }

        /// <inheritdoc cref="Entity.GetRawSource"/>
        protected override Microsoft.Xna.Framework.Rectangle GetRawSource()
        {
            Texture2D tileSheet = GetTileset();
            int size = GenericTextureConstants.Portrait.Size;

            if (tileSheet == null)
            {
                return new Rectangle(
                    0,
                    0,
                    size,
                    size
                );
            }

            int index = PortraitHelper.GetPortraitIndex(
                GetNpc(),
                GetEmotion()
            );

            return new Microsoft.Xna.Framework.Rectangle(
                index * size % tileSheet.Width,
                index * size / tileSheet.Width * size,
                size,
                size
            );
        }

        /// <inheritdoc cref="Entity.GetTileset"/>
        protected override Texture2D? GetTileset()
        {
            if (_texture == null) {
                Logger.Debug($"Loading Texture for {NPC.getTextureNameForCharacter(GetNpcName())}");
                _texture = Game1.content.Load<Texture2D>("Portraits\\" + NPC.getTextureNameForCharacter(GetNpcName()));
            }
            return _texture;
        }
    }
}
