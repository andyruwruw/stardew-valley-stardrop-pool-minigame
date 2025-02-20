using MinigameFramework.Entities;
using MinigameFramework.Enums;
using MinigameFramework.Scenes;
using MinigameFramework.Utilities;
using StardopPoolMinigame.Constants;
using StardopPoolMinigame.Enums;

namespace StardopPoolMinigame.Scenes
{
    /// <summary>
    /// Setting up your game.
    /// </summary>
    class GameSetupScene : Scene
    {
        /// <summary>
        /// The type of opponent.
        /// </summary>
        protected OpponentType _opponentType;

        /// <summary>
		/// Selected opponent.
		/// </summary>
		protected DisplayableNPC _npc;

        /// <summary>
        /// The type of table.
        /// </summary>
        protected TableType _tableType;

        /// <summary>
        /// Ruleset to use.
        /// </summary>
        protected GameRules _rules;
        
        /// <summary>
        /// Additional game modifiers.
        /// </summary>
        protected IList<GameModifiers> _modifiers;
        
        /// <summary>
        /// Instantiates a <see cref="GameSetupScene"/>.
        /// </summary>
        public GameSetupScene(bool multiplayer = false) : base()
        {
            Sounds.PlayMusic(SoundConstants.GameTheme);
        }

        /// <inheritdoc cref="IScene.GetKey"/>
        public override string GetKey()
        {
            return "game-setup-scene";
        }

        /// <inheritdoc cref="Scene.InitializeEntities"/>
        protected override IList<IEntity> InitializeEntities()
        {
            return new List<IEntity>();
        }
    }
}
