using StardropPoolMinigame.Entities;
using StardropPoolMinigame.Players;
using StardropPoolMinigame.Rules;

namespace StardropPoolMinigame.Scenes
{
    /// <inheritdoc cref="ISceneCreator"/>
    class GameSceneCreator : ISceneCreator
    {
        /// <summary>
        /// Stored parameter for <see cref="GameScene"/> creation
        /// </summary>
        private IPlayer _player1;

        /// <summary>
        /// Stored parameter for <see cref="GameScene"/> creation
        /// </summary>
        private IPlayer _player2;

        /// <summary>
        /// Stored parameter for <see cref="GameScene"/> creation
        /// </summary>
        private IRules _rules;

        /// <summary>
        /// Stored parameter for <see cref="GameScene"/> creation
        /// </summary>
        private Table _table;

        /// <summary>
        /// Instantiates <see cref="GameSceneCreator"/>.
        /// </summary>
        /// <param name="player1">Stored parameter for <see cref="GameScene"/> creation</param>
        /// <param name="player2">Stored parameter for <see cref="GameScene"/> creation</param>
        /// <param name="rules">Stored parameter for <see cref="GameScene"/> creation</param>
        /// <param name="table">Stored parameter for <see cref="GameScene"/> creation</param>
        public GameSceneCreator(
            IPlayer player1,
            IPlayer player2,
            IRules rules = null,
            Table table = null)
        {
            this._player1 = player1;
            this._player2 = player2;
            this._rules = rules;
            this._table = table;
        }

        /// <inheritdoc cref="ISceneCreator.GetScene"/>
        public IScene GetScene()
        {
            return new GameScene(
                this._player1,
                this._player2,
                this._rules,
                this._table);
        }
    }
}
